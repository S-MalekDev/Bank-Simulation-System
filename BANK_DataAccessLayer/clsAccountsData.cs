using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsAccountsData
    {

        static public DataTable GetAllAccounts()
        {
            DataTable dtAccountsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM AccountsList ORDER BY [Account No] ASC;"; ;
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAccountsList.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dtAccountsList;
        }

        static public DataTable GetAccountsListByClientIDLikeTheNumber(string TextNum)
        {
            DataTable dtAccountsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM AccountsList WHERE [Client ID] LIKE''+@TextNum + '%' ORDER BY [Client ID] ASC;"; 

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TextNum", TextNum);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAccountsList.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dtAccountsList;
        }

        static public DataTable GetAccountsListByAccountNumberLikeTheNumber(string TextNum)
        {
            DataTable dtAccountsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM AccountsList WHERE [Account No] LIKE''+@TextNum + '%' ORDER BY [Account No] ASC;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TextNum", TextNum);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAccountsList.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dtAccountsList;
        }

        static public bool GetAccountInfoByAccountNumber(int AccountNumber, ref int ClientID, ref string Password, ref decimal Balance, ref byte AccountCurrency, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Accounts WHERE AccountNumber =@AccountNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {


                    if (Reader["ClientID"] != DBNull.Value)
                        ClientID = (int)Reader["ClientID"];

                    Password = (string)Reader["Password"];
                    Balance = (decimal)Reader["Balance"];
                    AccountCurrency = (byte)Reader["AccountCurrency"];
                    IsActive = (bool)Reader["IsActive"];


                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }

        static public bool GetAccountInfoByClientID(ref int AccountNumber, int ClientID, ref string Password, ref decimal Balance, ref byte AccountCurrency, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Accounts WHERE ClientID =@ClientID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    AccountNumber = (int)Reader["AccountNumber"];
                    Password = (string)Reader["Password"];
                    Balance = (decimal)Reader["Balance"];
                    AccountCurrency = (byte)Reader["AccountCurrency"];
                    IsActive = (bool)Reader["IsActive"];


                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }
        
        static public int AddNewAccount(int ClientID, string Password, decimal Balance, byte AccountCurrency, bool IsActive)
        {
            int AccountNumber = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Accounts
                                         (ClientID, Password, Balance, AccountCurrency, IsActive)
                                   VALUES
                                         (@ClientID, @Password, @Balance, @AccountCurrency, @IsActive);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            if (ClientID == default)
                Command.Parameters.AddWithValue("@ClientID", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ClientID", ClientID);

            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Balance", Balance);
            Command.Parameters.AddWithValue("@AccountCurrency", AccountCurrency);
            Command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    AccountNumber = ID;
                }
            }
            catch (Exception ex)
            {
                AccountNumber = -1;
            }
            finally
            {
                Connection.Close();
            }


            return AccountNumber;
        }

        static public bool UpdateAccount(int AccountNumber, int ClientID, string Password, decimal Balance, byte AccountCurrency, bool IsActive)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Accounts 
SET ClientID = @ClientID
, Password = @Password
, Balance = @Balance
, AccountCurrency = @AccountCurrency
, IsActive = @IsActive
WHERE AccountNumber = @AccountNumber";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            if (ClientID == default)
                Command.Parameters.AddWithValue("@ClientID", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ClientID", ClientID);

            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Balance", Balance);
            Command.Parameters.AddWithValue("@AccountCurrency", AccountCurrency);
            Command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                Connection.Open();
                RowsEfacts = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return RowsEfacts > 0;
        }

        static public bool DepositeAmountByClientID(decimal Amount, int ClientID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Accounts 
SET Balance = Balance + @Amount 
WHERE ClientID = @ClientID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@Amount", Amount);

            try
            {
                Connection.Open();
                RowsEfacts = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return RowsEfacts > 0;
        }

        static public bool DeleteAccount(int AccountNumber)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Accounts WHERE AccountNumber = @AccountNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                Connection.Open();
                RowsEfacts = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowsEfacts > 0;
        }

        static public bool IsAccountExist(int AccountNumber)
        {
            bool IsAccountExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Accounts WHERE AccountNumber = @AccountNumber;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsAccountExist = true;
                }
            }
            catch (Exception ex)
            {
                IsAccountExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsAccountExist;
        }

        static public bool IsAccountExistByPersonID(int PersonID)
        {
            bool IsAccountExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = @"SELECT 1
WHERE EXISTS
(
SELECT Found = 1 FROM Accounts INNER JOIN Clients ON Accounts.ClientID = Clients.ClientID
WHERE Clients.PersonID = @PersonID
)";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsAccountExist = true;
                }
            }
            catch (Exception ex)
            {
                IsAccountExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsAccountExist;
        }

    }


}

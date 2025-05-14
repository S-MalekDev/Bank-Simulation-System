using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsAccountCurrenciesData
    {

        static public DataTable GetAllAccountCurrencies()
        {
            DataTable dtAccountCurrenciesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = @"SELECT AccountCurrencies.AccountCurrencyID,Currencies.*
FROM AccountCurrencies INNER JOIN Currencies ON AccountCurrencies.CurrencyID = Currencies.CurrencyID;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAccountCurrenciesList.Load(Reader);
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


            return dtAccountCurrenciesList;
        }

        static public bool GetAccountCurrencyInfoByID(int AccountCurrencyID, ref byte CurrencyID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM AccountCurrencies WHERE AccountCurrencyID =@AccountCurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountCurrencyID", AccountCurrencyID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    CurrencyID = (byte)Reader["CurrencyID"];


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
        
        static public bool GetAccountCurrencyInfoByCurrencyID(ref int AccountCurrencyID,  byte CurrencyID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM AccountCurrencies WHERE CurrencyID =@CurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    AccountCurrencyID = (byte)Reader["AccountCurrencyID"];


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
        static public int AddNewAccountCurrency(byte CurrencyID)
        {
            int AccountCurrencyID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO AccountCurrencies
                                         (CurrencyID)
                                   VALUES
                                         (@CurrencyID);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    AccountCurrencyID = ID;
                }
            }
            catch (Exception ex)
            {
                AccountCurrencyID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return AccountCurrencyID;
        }

        static public bool UpdateAccountCurrency(int AccountCurrencyID, byte CurrencyID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE AccountCurrencies 
SET CurrencyID = @CurrencyID
WHERE AccountCurrencyID = @AccountCurrencyID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountCurrencyID", AccountCurrencyID);
            Command.Parameters.AddWithValue("@CurrencyID", CurrencyID);


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

        static public bool DeleteAccountCurrency(int AccountCurrencyID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM AccountCurrencies WHERE AccountCurrencyID = @AccountCurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountCurrencyID", AccountCurrencyID);

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

        static public bool IsAccountCurrencyExist(int AccountCurrencyID)
        {
            bool IsAccountCurrencyExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM AccountCurrencies WHERE AccountCurrencyID = @AccountCurrencyID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountCurrencyID", AccountCurrencyID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsAccountCurrencyExist = true;
                }
            }
            catch (Exception ex)
            {
                IsAccountCurrencyExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsAccountCurrencyExist;
        }

    }

}

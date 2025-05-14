using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsTransactionTypesData
    {

        static public DataTable GetAllTransactionTypes()
        {
            DataTable dtTransactionTypesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT TransactionTypeID AS ID, Name AS [Transaction Name],Description, CAST(Fees AS nvarchar) + ' $' AS Fees FROM TransactionTypes;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtTransactionTypesList.Load(Reader);
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


            return dtTransactionTypesList;
        }

        static public bool GetTransactionTypeInfoByID(int TransactionTypeID, ref string Name, ref string Description, ref decimal Fees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM TransactionTypes WHERE TransactionTypeID =@TransactionTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    Name = (string)Reader["Name"];
                    Description = (string)Reader["Description"];
                    Fees = (decimal)Reader["Fees"];


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

        static public int AddNewTransactionType(string Name, string Description, decimal Fees)
        {
            int TransactionTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO TransactionTypes
                                         (Name, Description, Fees)
                                   VALUES
                                         (@Name, @Description, @Fees);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@Fees", Fees);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TransactionTypeID = ID;
                }
            }
            catch (Exception ex)
            {
                TransactionTypeID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return TransactionTypeID;
        }

        static public bool UpdateTransactionType(int TransactionTypeID, string Name, string Description, decimal Fees)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE TransactionTypes 
SET Name = @Name
, Description = @Description
, Fees = @Fees
WHERE TransactionTypeID = @TransactionTypeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@Fees", Fees);


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

        static public bool DeleteTransactionType(int TransactionTypeID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

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

        static public bool IsTransactionTypeExist(int TransactionTypeID)
        {
            bool IsTransactionTypeExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsTransactionTypeExist = true;
                }
            }
            catch (Exception ex)
            {
                IsTransactionTypeExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTransactionTypeExist;
        }

    }
}

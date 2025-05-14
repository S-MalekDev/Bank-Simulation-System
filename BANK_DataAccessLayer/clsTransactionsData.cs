using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsTransactionsData
    {

        static public DataTable GetAllTransactions()
        {
            DataTable dtTransactionsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM Transactions;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtTransactionsList.Load(Reader);
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


            return dtTransactionsList;
        }

        static public bool GetTransactionInfoByID(int TransactionID, ref byte TransactionTypeID, ref int ServiceAppID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Transactions WHERE TransactionID =@TransactionID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransactionTypeID = (byte)Reader["TransactionTypeID"];
                    ServiceAppID = (int)Reader["ServiceAppID"];


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

        static public int AddNewTransaction(byte TransactionTypeID, int ServiceAppID)
        {
            int TransactionID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Transactions
                                         (TransactionTypeID, ServiceAppID)
                                   VALUES
                                         (@TransactionTypeID, @ServiceAppID);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            Command.Parameters.AddWithValue("@ServiceAppID", ServiceAppID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TransactionID = ID;
                }
            }
            catch (Exception ex)
            {
                TransactionID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return TransactionID;
        }

        static public bool UpdateTransaction(int TransactionID, byte TransactionTypeID, int ServiceAppID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Transactions 
SET TransactionTypeID = @TransactionTypeID
, ServiceAppID = @ServiceAppID
WHERE TransactionID = @TransactionID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);
            Command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);
            Command.Parameters.AddWithValue("@ServiceAppID", ServiceAppID);


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

        static public bool DeleteTransaction(int TransactionID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Transactions WHERE TransactionID = @TransactionID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);

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

        static public bool IsTransactionExist(int TransactionID)
        {
            bool IsTransactionExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Transactions WHERE TransactionID = @TransactionID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsTransactionExist = true;
                }
            }
            catch (Exception ex)
            {
                IsTransactionExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTransactionExist;
        }

    }

}

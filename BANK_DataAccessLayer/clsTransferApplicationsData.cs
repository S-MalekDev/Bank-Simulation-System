using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsTransferApplicationsData
    {

        static public DataTable GetAllTransferApplications()
        {
            DataTable dtTransferApplicationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM TransferApplications;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtTransferApplicationsList.Load(Reader);
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


            return dtTransferApplicationsList;
        }

        static public bool GetTransferAppInfoByID(int TransferID, ref int TransactionID, ref byte TransferTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM TransferApplications WHERE TransferID =@TransferID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferID", TransferID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransactionID = (int)Reader["TransactionID"];
                    TransferTypeID = (byte)Reader["TransferTypeID"];


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

        static public int AddNewTransferApp(int TransactionID, byte TransferTypeID)
        {
            int TransferID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO TransferApplications
                                         (TransactionID, TransferTypeID)
                                   VALUES
                                         (@TransactionID, @TransferTypeID);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);
            Command.Parameters.AddWithValue("@TransferTypeID", TransferTypeID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TransferID = ID;
                }
            }
            catch (Exception ex)
            {
                TransferID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return TransferID;
        }

        static public bool UpdateTransferApp(int TransferID, int TransactionID, byte TransferTypeID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE TransferApplications 
SET TransactionID = @TransactionID
, TransferTypeID = @TransferTypeID
WHERE TransferID = @TransferID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferID", TransferID);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);
            Command.Parameters.AddWithValue("@TransferTypeID", TransferTypeID);


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

        static public bool DeleteTransferApp(int TransferID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM TransferApplications WHERE TransferID = @TransferID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferID", TransferID);

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

        static public bool IsTransferAppExist(int TransferID)
        {
            bool IsTransferAppExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM TransferApplications WHERE TransferID = @TransferID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferID", TransferID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsTransferAppExist = true;
                }
            }
            catch (Exception ex)
            {
                IsTransferAppExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTransferAppExist;
        }

    }
}

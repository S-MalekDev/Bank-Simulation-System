using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsTransferTypesData
    {

        static public DataTable GetAllTransferTypes()
        {
            DataTable dtTransferTypesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT TransferTypeID AS ID, TransferName AS [Transfer Name],TransferDescription AS Description, CAST(TransferFees AS nvarchar) + ' $'  AS Fees FROM TransferTypes;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtTransferTypesList.Load(Reader);
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


            return dtTransferTypesList;
        }

        static public bool GetTransferTypeInfoByID(byte TransferTypeID, ref string TransferName, ref decimal TransferFees, ref string TransferDescription)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM TransferTypes WHERE TransferTypeID =@TransferTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferTypeID", TransferTypeID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransferName = (string)Reader["TransferName"];
                    TransferFees = (decimal)Reader["TransferFees"];
                    TransferDescription = (string)Reader["TransferDescription"];


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

        static public int AddNewTransferType(string TransferName, decimal TransferFees, string TransferDescription)
        {
            int TransferTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO TransferTypes
                                         (TransferName, TransferFees, TransferDescription)
                                   VALUES
                                         (@TransferName, @TransferFees, @TransferDescription);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferName", TransferName);
            Command.Parameters.AddWithValue("@TransferFees", TransferFees);
            Command.Parameters.AddWithValue("@TransferDescription", TransferDescription);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    TransferTypeID = ID;
                }
            }
            catch (Exception ex)
            {
                TransferTypeID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return TransferTypeID;
        }

        static public bool UpdateTransferType(byte TransferTypeID, string TransferName, decimal TransferFees, string TransferDescription)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE TransferTypes 
SET TransferName = @TransferName
, TransferFees = @TransferFees
, TransferDescription = @TransferDescription
WHERE TransferTypeID = @TransferTypeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferTypeID", TransferTypeID);
            Command.Parameters.AddWithValue("@TransferName", TransferName);
            Command.Parameters.AddWithValue("@TransferFees", TransferFees);
            Command.Parameters.AddWithValue("@TransferDescription", TransferDescription);


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

        static public bool DeleteTransferType(byte TransferTypeID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM TransferTypes WHERE TransferTypeID = @TransferTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
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

        static public bool IsTransferTypeExist(byte TransferTypeID)
        {
            bool IsTransferTypeExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM TransferTypes WHERE TransferTypeID = @TransferTypeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferTypeID", TransferTypeID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsTransferTypeExist = true;
                }
            }
            catch (Exception ex)
            {
                IsTransferTypeExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTransferTypeExist;
        }



    }

}

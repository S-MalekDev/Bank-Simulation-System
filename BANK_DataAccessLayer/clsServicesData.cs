using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsServicesData
    {

        static public DataTable GetAllServices()
        {
            DataTable dtServicesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT ServiceID AS ID, ServiceTitle AS Title , ServiceDescription AS Description, CAST(Fees AS nvarchar) + ' $' AS Fees  FROM Services;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtServicesList.Load(Reader);
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


            return dtServicesList;
        }

        static public bool GetServiceInfoByID(int ServiceID, ref string ServiceTitle,ref string ServiceDescription, ref decimal Fees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Services WHERE ServiceID =@ServiceID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    
                    ServiceTitle = (string)Reader["ServiceTitle"];
                    ServiceDescription = (string)Reader["ServiceDescription"];
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

        static public int AddNewService(string ServiceTitle,string ServiceDescription, decimal Fees)
        {
            int ServiceID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Services
                                         (ServiceTitle,ServiceDescription, Fees)
                                   VALUES
                                         (@ServiceTitle,@ServiceDescription, @Fees);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceDescription", ServiceDescription);
            Command.Parameters.AddWithValue("@ServiceTitle", ServiceTitle);
            Command.Parameters.AddWithValue("@Fees", Fees);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ServiceID = ID;
                }
            }
            catch (Exception ex)
            {
                ServiceID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return ServiceID;
        }

        static public bool UpdateService(int ServiceID, string ServiceTitle, string ServiceDescription, decimal Fees)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Services 
SET ServiceTitle = @ServiceTitle
,ServiceDescription = @ServiceDescription
, Fees = @Fees
WHERE ServiceID = @ServiceID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            Command.Parameters.AddWithValue("@ServiceDescription", ServiceDescription);
            Command.Parameters.AddWithValue("@ServiceTitle", ServiceTitle);
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

        static public bool DeleteService(int ServiceID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Services WHERE ServiceID = @ServiceID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);

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

        static public bool IsServiceExist(int ServiceID)
        {
            bool IsServiceExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Services WHERE ServiceID = @ServiceID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsServiceExist = true;
                }
            }
            catch (Exception ex)
            {
                IsServiceExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsServiceExist;
        }

    }

}

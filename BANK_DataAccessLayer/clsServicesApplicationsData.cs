using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsServicesApplicationsData
    {
        static public DataTable GetAllServicesApplications()
        {
            DataTable dtServicesApplicationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM ServicesApplications;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtServicesApplicationsList.Load(Reader);
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


            return dtServicesApplicationsList;
        }

        static public bool GetServicesAppInfoByID(int ServiceAppID, ref int ClientID, ref int UserID, ref byte ServiceID, ref DateTime RequestDate)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM ServicesApplications WHERE ServiceAppID =@ServiceAppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceAppID", ServiceAppID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    ClientID = (int)Reader["ClientID"];
                    UserID = (int)Reader["UserID"];
                    ServiceID = (byte)Reader["ServiceID"];
                    RequestDate = (DateTime)Reader["RequestDate"];


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

        static public int AddNewServicesApp(int ClientID, int UserID, byte ServiceID, DateTime RequestDate)
        {
            int ServiceAppID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO ServicesApplications
                                         (ClientID, UserID, ServiceID, RequestDate)
                                   VALUES
                                         (@ClientID, @UserID, @ServiceID, @RequestDate);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            Command.Parameters.AddWithValue("@RequestDate", RequestDate);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ServiceAppID = ID;
                }
            }
            catch (Exception ex)
            {
                ServiceAppID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return ServiceAppID;
        }

        static public bool UpdateServicesApp(int ServiceAppID, int ClientID, int UserID, byte ServiceID, DateTime RequestDate)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE ServicesApplications 
SET ClientID = @ClientID
, UserID = @UserID
, ServiceID = @ServiceID
, RequestDate = @RequestDate
WHERE ServiceAppID = @ServiceAppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceAppID", ServiceAppID);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@ServiceID", ServiceID);
            Command.Parameters.AddWithValue("@RequestDate", RequestDate);


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

        static public bool DeleteServicesApp(int ServiceAppID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM ServicesApplications WHERE ServiceAppID = @ServiceAppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
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

        static public bool IsServicesAppExist(int ServiceAppID)
        {
            bool IsServicesAppExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM ServicesApplications WHERE ServiceAppID = @ServiceAppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ServiceAppID", ServiceAppID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsServicesAppExist = true;
                }
            }
            catch (Exception ex)
            {
                IsServicesAppExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsServicesAppExist;
        }

    }


}

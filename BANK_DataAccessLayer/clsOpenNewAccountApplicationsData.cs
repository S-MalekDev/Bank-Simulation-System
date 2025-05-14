using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsOpenNewAccountApplicationsData
    {

        static public DataTable GetAllOpenNewAccountApplications()
        {
            DataTable dtOpenNewAccountApplicationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM OpenNewAccountApplications;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtOpenNewAccountApplicationsList.Load(Reader);
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


            return dtOpenNewAccountApplicationsList;
        }

        static public bool GetOpenNewAccountAppInfoByID(int AppID, ref int PersonID, ref int CreatedByUserID, ref DateTime OpeningDate, ref int AccountID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM OpenNewAccountApplications WHERE AppID =@AppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    OpeningDate = (DateTime)Reader["OpeningDate"];

                    if (Reader["AccountID"] != DBNull.Value)
                        AccountID = (int)Reader["AccountID"];



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
      
        static public bool GetOpenNewAccountAppInfoByAccountNumber(ref int AppID, ref int PersonID, ref int CreatedByUserID, ref DateTime OpeningDate, int AccountID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM OpenNewAccountApplications WHERE AccountID =@AccountID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AccountID", AccountID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    OpeningDate = (DateTime)Reader["OpeningDate"];
                    AppID = (int)Reader["AppID"];

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
      
        static public bool GetOpenNewAccountAppInfoByPersonID(ref int AppID,  int PersonID, ref int CreatedByUserID, ref DateTime OpeningDate,ref int AccountID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM OpenNewAccountApplications WHERE PersonID =@PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    AccountID = (int)Reader["AccountID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    OpeningDate = (DateTime)Reader["OpeningDate"];
                    AppID = (int)Reader["AppID"];

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
        
        static public int AddNewOpenNewAccountApp(int PersonID, int CreatedByUserID, DateTime OpeningDate, int AccountID)
        {
            int AppID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO OpenNewAccountApplications
                                         (PersonID, CreatedByUserID, OpeningDate, AccountID)
                                   VALUES
                                         (@PersonID, @CreatedByUserID, @OpeningDate, @AccountID);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@OpeningDate", OpeningDate);

            if (AccountID == default)
                Command.Parameters.AddWithValue("@AccountID", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@AccountID", AccountID);



            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    AppID = ID;
                }
            }
            catch (Exception ex)
            {
                AppID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return AppID;
        }

        static public bool UpdateOpenNewAccountApp(int AppID, int PersonID, int CreatedByUserID, DateTime OpeningDate, int AccountID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE OpenNewAccountApplications 
SET PersonID = @PersonID
, CreatedByUserID = @CreatedByUserID
, OpeningDate = @OpeningDate
, AccountID = @AccountID
WHERE AppID = @AppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@OpeningDate", OpeningDate);

            if (AccountID == default)
                Command.Parameters.AddWithValue("@AccountID", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@AccountID", AccountID);



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

        static public bool DeleteOpenNewAccountApp(int AppID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM OpenNewAccountApplications WHERE AppID = @AppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);

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

        static public bool SetAccountIDtoTheApp(int  AppID,int AccountID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE OpenNewAccountApplications 
SET AccountID = @AccountID
WHERE AppID = @AppID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            Command.Parameters.AddWithValue("@AccountID", AccountID);



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

        static public bool IsOpenNewAccountAppExist(int AppID)
        {
            bool IsOpenNewAccountAppExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM OpenNewAccountApplications WHERE AppID = @AppID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsOpenNewAccountAppExist = true;
                }
            }
            catch (Exception ex)
            {
                IsOpenNewAccountAppExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsOpenNewAccountAppExist;
        }

    }

}

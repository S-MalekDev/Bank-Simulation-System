using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsUsersData
    {

        static public DataTable GetAllUsers()
        {
            DataTable dtUsersList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM UsersList ORDER BY [User ID] ASC;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtUsersList.Load(Reader);
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


            return dtUsersList;
        }

        static public DataTable GetUsersListByUserIDLikeTheNumber(string TextOfNum)
        {
            DataTable dtUsersList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM UsersList WHERE [User ID] LIKE '' + @UserID + '%' ORDER BY [User ID] ASC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", TextOfNum);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtUsersList.Load(Reader);
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


            return dtUsersList;
        }

        static public DataTable GetUsersListByEmployeeIDLikeTheNumber(string TextOfNum)
        {
            DataTable dtUsersList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM UsersList WHERE [Employee ID] LIKE '' + @EmployeeID + '%' ORDER BY [User ID] ASC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", TextOfNum);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtUsersList.Load(Reader);
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


            return dtUsersList;
        }

        static public bool GetUserInfoByID(int UserID, ref int EmployeeID, ref string Username, ref string Password, ref int Permissions, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Users WHERE UserID =@UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    EmployeeID = (int)Reader["EmployeeID"];
                    Username = (string)Reader["Username"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
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

        static public bool GetUserInfoByEmployeeID(ref int UserID,  int EmployeeID, ref string Username, ref string Password, ref int Permissions, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Users WHERE EmployeeID =@EmployeeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    UserID = (int)Reader["UserID"];
                    Username = (string)Reader["Username"];
                    Password = (string)Reader["Password"];
                    Permissions = (int)Reader["Permissions"];
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
      
        static public bool GetUserInfoByUsernameAndPassword(ref int UserID,ref int EmployeeID,  string Username,  string Password, ref int Permissions, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Users WHERE Username = @Username	AND Password = @Password;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    UserID = (int)Reader["UserID"];
                    EmployeeID = (int)Reader["EmployeeID"];
                    Permissions = (int)Reader["Permissions"];
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
       
        static public int AddNewUser(int EmployeeID, string Username, string Password, int Permissions, bool IsActive)
        {
            int UserID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Users
                                         (EmployeeID, Username, Password, Permissions, IsActive)
                                   VALUES
                                         (@EmployeeID, @Username, @Password, @Permissions, @IsActive);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
            Command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    UserID = ID;
                }
            }
            catch (Exception ex)
            {
                UserID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return UserID;
        }

        static public bool UpdateUser(int UserID, int EmployeeID, string Username, string Password, int Permissions, bool IsActive)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Users 
SET EmployeeID = @EmployeeID
, Username = @Username
, Password = @Password
, Permissions = @Permissions
, IsActive = @IsActive
WHERE UserID = @UserID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permissions", Permissions);
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

        static public bool DeleteUser(int UserID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Users WHERE UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

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

        static public bool IsUserExist(int UserID)
        {
            bool IsUserExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Users WHERE UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsUserExist = true;
                }
            }
            catch (Exception ex)
            {
                IsUserExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUserExist;
        }

        static public bool IsUserActive(int UserID)
        {
            bool IsUserActive = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Users WHERE UserID = @UserID AND IsActive = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsUserActive = true;
                }
            }
            catch (Exception ex)
            {
                IsUserActive = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUserActive;
        }

        static public bool IsTheUserHasEmail(int UserID)
        {
            bool IsUserExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = @"SELECT 1
WHERE EXISTS
(
SELECT People.Email FROM Users INNER JOIN Employees ON Users.EmployeeID = Employees.EmployeeID
                               INNER JOIN People ON Employees.PersonID = People.PersonID
WHERE Users.UserID = @UserID AND NOT People.Email IS NULL
);";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsUserExist = true;
                }
            }
            catch (Exception ex)
            {
                IsUserExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUserExist;
        }

        static public bool IsUserExistByPersonID(int PersonID)
        {
            bool IsUserExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = @"SELECT Exist = 1 
WHERE EXISTS 
(
SELECT Users.UserID FROM Users INNER JOIN Employees ON Users.EmployeeID = Employees.EmployeeID
WHERE Employees.PersonID = @PersonID
);";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsUserExist = true;
                }
            }
            catch (Exception ex)
            {
                IsUserExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUserExist;
        }

        static public bool IsUsernameExist(string UserName)
        {
            bool IsUserExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Users WHERE UserName = @UserName;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsUserExist = true;
                }
            }
            catch (Exception ex)
            {
                IsUserExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsUserExist;
        }

        static public bool SetUserAccountStatus(int UserID, bool Status)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Users 
SET IsActive = @Status
WHERE UserID = @UserID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Status", Status);


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

        static public bool UpdatePassword(int UserID ,string NewPassword)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Users 
SET Password = @Password
WHERE UserID = @UserID";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@Password", NewPassword);

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

    }
}

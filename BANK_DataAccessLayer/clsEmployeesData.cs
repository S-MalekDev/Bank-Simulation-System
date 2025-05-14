using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsEmployeesData
    {

        static public DataTable GetAllEmployees()
        {
            DataTable dtEmployeesList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM Employees;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtEmployeesList.Load(Reader);
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


            return dtEmployeesList;
        }

        static public bool GetEmployeeInfoByID(int EmployeeID, ref int PersonID, ref DateTime EmploymentDate, ref int JobPosition, ref decimal Salary)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Employees WHERE EmployeeID =@EmployeeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    PersonID = (int)Reader["PersonID"];
                    EmploymentDate = (DateTime)Reader["EmploymentDate"];
                    JobPosition = (int)Reader["JobPosition"];
                    Salary = (decimal)Reader["Salary"];


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

        static public int AddNewEmployee(int PersonID, DateTime EmploymentDate, int JobPosition, decimal Salary)
        {
            int EmployeeID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO Employees
                                         (PersonID, EmploymentDate, JobPosition, Salary)
                                   VALUES
                                         (@PersonID, @EmploymentDate, @JobPosition, @Salary);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@EmploymentDate", EmploymentDate);
            Command.Parameters.AddWithValue("@JobPosition", JobPosition);
            Command.Parameters.AddWithValue("@Salary", Salary);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    EmployeeID = ID;
                }
            }
            catch (Exception ex)
            {
                EmployeeID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return EmployeeID;
        }

        static public bool UpdateEmployee(int EmployeeID, int PersonID, DateTime EmploymentDate, int JobPosition, decimal Salary)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE Employees 
SET PersonID = @PersonID
, EmploymentDate = @EmploymentDate
, JobPosition = @JobPosition
, Salary = @Salary
WHERE EmployeeID = @EmployeeID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@EmploymentDate", EmploymentDate);
            Command.Parameters.AddWithValue("@JobPosition", JobPosition);
            Command.Parameters.AddWithValue("@Salary", Salary);


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

        static public bool GetEmployeeInfoByPersonID(ref int EmployeeID,  int PersonID, ref DateTime EmploymentDate, ref int JobPosition, ref decimal Salary)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM Employees WHERE PersonID =@PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    EmployeeID = (int)Reader["EmployeeID"];
                    EmploymentDate = (DateTime)Reader["EmploymentDate"];
                    JobPosition = (int)Reader["JobPosition"];
                    Salary = (decimal)Reader["Salary"];


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

        static public bool DeleteEmployee(int EmployeeID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

        static public bool IsEmployeeExist(int EmployeeID)
        {
            bool IsEmployeeExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM Employees WHERE EmployeeID = @EmployeeID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsEmployeeExist = true;
                }
            }
            catch (Exception ex)
            {
                IsEmployeeExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsEmployeeExist;
        }


    }

}

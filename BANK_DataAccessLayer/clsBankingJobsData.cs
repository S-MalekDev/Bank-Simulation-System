using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsBankingJobsData
    {

        static public DataTable GetAllBankingJobs()
        {
            DataTable dtBankingJobsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT * FROM BankingJobs;";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtBankingJobsList.Load(Reader);
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


            return dtBankingJobsList;
        }

        static public bool GetBankingJobInfoByID(int JobID, ref string JobTitle, ref string SalaryRange)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM BankingJobs WHERE JobID =@JobID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@JobID", JobID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    JobTitle = (string)Reader["JobTitle"];
                    SalaryRange = (string)Reader["SalaryRange"];


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

        static public int AddNewBankingJob(string JobTitle, string SalaryRange)
        {
            int JobID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO BankingJobs
                                         (JobTitle, SalaryRange)
                                   VALUES
                                         (@JobTitle, @SalaryRange);

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@JobTitle", JobTitle);
            Command.Parameters.AddWithValue("@SalaryRange", SalaryRange);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    JobID = ID;
                }
            }
            catch (Exception ex)
            {
                JobID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return JobID;
        }

        static public bool UpdateBankingJob(int JobID, string JobTitle, string SalaryRange)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE BankingJobs 
SET JobTitle = @JobTitle
, SalaryRange = @SalaryRange
WHERE JobID = @JobID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@JobID", JobID);
            Command.Parameters.AddWithValue("@JobTitle", JobTitle);
            Command.Parameters.AddWithValue("@SalaryRange", SalaryRange);


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

        static public bool DeleteBankingJob(int JobID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM BankingJobs WHERE JobID = @JobID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@JobID", JobID);

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

        static public bool IsBankingJobExist(int JobID)
        {
            bool IsBankingJobExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM BankingJobs WHERE JobID = @JobID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@JobID", JobID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsBankingJobExist = true;
                }
            }
            catch (Exception ex)
            {
                IsBankingJobExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsBankingJobExist;
        }

    }


}

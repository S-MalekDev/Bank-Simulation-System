using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsWithdrawAndDepositOperationsData
    {

        static public DataTable GetAllWithdrawAndDepositOperations(int ClientID)
        {
            DataTable dtWithdrawAndDepositOperationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT ID, [Transaction Type], Amount, Date, Time FROM WithdrawDepositView WHERE ClientID = @ClientID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID",ClientID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtWithdrawAndDepositOperationsList.Load(Reader);
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


            return dtWithdrawAndDepositOperationsList;
        }

        static public bool GetWithdrawAndDepositOperationInfoByID(int OperationID, ref int TransactionID, ref int ClientID, ref decimal Amount, ref decimal OperationFees, ref decimal PreviousBalance, ref decimal BalanceAfterTransaction)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM WithdrawAndDepositOperations WHERE OperationID =@OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransactionID = (int)Reader["TransactionID"];
                    ClientID = (int)Reader["ClientID"];
                    Amount = (decimal)Reader["Amount"];
                    OperationFees = (decimal)Reader["OperationFees"];
                    PreviousBalance = (decimal)Reader["PreviousBalance"];
                    BalanceAfterTransaction = (decimal)Reader["BalanceAfterTransaction"];


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

        static public int AddNewWithdrawAndDepositOperation(int TransactionID, int ClientID, decimal Amount, decimal OperationFees, decimal PreviousBalance, decimal BalanceAfterTransaction)
        {
            int OperationID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO WithdrawAndDepositOperations
                                         (TransactionID, ClientID, Amount, OperationFees, PreviousBalance, BalanceAfterTransaction)
                                   VALUES
                                         (@TransactionID, @ClientID, @Amount, @OperationFees, @PreviousBalance, @BalanceAfterTransaction);

                                    UPDATE Accounts
                                    SET Balance = @BalanceAfterTransaction
                                    WHERE ClientID = @ClientID


                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@OperationFees", OperationFees);
            Command.Parameters.AddWithValue("@PreviousBalance", PreviousBalance);
            Command.Parameters.AddWithValue("@BalanceAfterTransaction", BalanceAfterTransaction);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    OperationID = ID;
                }
            }
            catch (Exception ex)
            {
                OperationID = -1;
            }
            finally
            {
                Connection.Close();
            }


            return OperationID;
        }

        static public bool UpdateWithdrawAndDepositOperation(int OperationID, int TransactionID, int ClientID, decimal Amount, decimal OperationFees, decimal PreviousBalance, decimal BalanceAfterTransaction)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE WithdrawAndDepositOperations 
SET TransactionID = @TransactionID
, ClientID = @ClientID
, Amount = @Amount
, OperationFees = @OperationFees
, PreviousBalance = @PreviousBalance
, BalanceAfterTransaction = @BalanceAfterTransaction
WHERE OperationID = @OperationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);
            Command.Parameters.AddWithValue("@TransactionID", TransactionID);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@OperationFees", OperationFees);
            Command.Parameters.AddWithValue("@PreviousBalance", PreviousBalance);
            Command.Parameters.AddWithValue("@BalanceAfterTransaction", BalanceAfterTransaction);


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

        static public bool DeleteWithdrawAndDepositOperation(int OperationID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM WithdrawAndDepositOperations WHERE OperationID = @OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

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

        static public bool IsWithdrawAndDepositOperationExist(int OperationID)
        {
            bool IsWithdrawAndDepositOperationExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM WithdrawAndDepositOperations WHERE OperationID = @OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsWithdrawAndDepositOperationExist = true;
                }
            }
            catch (Exception ex)
            {
                IsWithdrawAndDepositOperationExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsWithdrawAndDepositOperationExist;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsExternalTransferOperationsData
    {

        static public DataTable GetAllExternalTransferOperations(int ClientID)
        {
            DataTable dtExternalTransferOperationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "Select ID, Amount, Date, Time, Status from ExternalTransferOperationsView WHERE ClientID = @ClientID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID", ClientID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtExternalTransferOperationsList.Load(Reader);
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


            return dtExternalTransferOperationsList;
        }

        static public bool GetExternalTransferOperationInfoByID(int OperationID, ref int TransfeID, ref int DoneByUser, ref int TronsferFrom, ref byte CurrencyOfTransferID, ref decimal Amount, ref decimal Fees, ref string BankName, ref string IBAN_Number, ref string RecipientFullName, ref DateTime SendingDate, ref DateTime ArrivalDate, ref byte status)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM ExternalTransferOperations WHERE OperationID =@OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransfeID = (int)Reader["TransfeID"];
                    DoneByUser = (int)Reader["DoneByUser"];
                    TronsferFrom = (int)Reader["TronsferFrom"];
                    CurrencyOfTransferID = (byte)Reader["CurrencyOfTransferID"];
                    Amount = (decimal)Reader["Amount"];
                    Fees = (decimal)Reader["Fees"];
                    BankName = (string)Reader["BankName"];
                    IBAN_Number = (string)Reader["IBAN_Number"];
                    RecipientFullName = (string)Reader["RecipientFullName"];
                    SendingDate = (DateTime)Reader["SendingDate"];

                    if (Reader["ArrivalDate"] != DBNull.Value)
                        ArrivalDate = (DateTime)Reader["ArrivalDate"];

                    status = (byte)Reader["status"];


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

        static public int AddNewExternalTransferOperation(int TransfeID, int DoneByUser, int TronsferFrom, byte CurrencyOfTransferID, decimal Amount, decimal Fees, string BankName, string IBAN_Number, string RecipientFullName, DateTime SendingDate, DateTime ArrivalDate, byte status)
        {
            int OperationID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO ExternalTransferOperations
                                         (TransfeID, DoneByUser, TronsferFrom, CurrencyOfTransferID, Amount, Fees, BankName, IBAN_Number, RecipientFullName, SendingDate, ArrivalDate, status)
                                   VALUES
                                         (@TransfeID, @DoneByUser, @TronsferFrom, @CurrencyOfTransferID, @Amount, @Fees, @BankName, @IBAN_Number, @RecipientFullName, @SendingDate, @ArrivalDate, @status);

                                       UPDATE Accounts
                                       SET Balance = Balance - (@Amount + @Fees)
                                       WHERE ClientID = @TronsferFrom;

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransfeID", TransfeID);
            Command.Parameters.AddWithValue("@DoneByUser", DoneByUser);
            Command.Parameters.AddWithValue("@TronsferFrom", TronsferFrom);
            Command.Parameters.AddWithValue("@CurrencyOfTransferID", CurrencyOfTransferID);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@BankName", BankName);
            Command.Parameters.AddWithValue("@IBAN_Number", IBAN_Number);
            Command.Parameters.AddWithValue("@RecipientFullName", RecipientFullName);
            Command.Parameters.AddWithValue("@SendingDate", SendingDate);

            if (ArrivalDate == default)
                Command.Parameters.AddWithValue("@ArrivalDate", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ArrivalDate", ArrivalDate);

            Command.Parameters.AddWithValue("@status", status);


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

        static public bool UpdateExternalTransferOperation(int OperationID, int TransfeID, int DoneByUser, int TronsferFrom, byte CurrencyOfTransferID, decimal Amount, decimal Fees, string BankName, string IBAN_Number, string RecipientFullName, DateTime SendingDate, DateTime ArrivalDate, byte status)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE ExternalTransferOperations 
SET TransfeID = @TransfeID
, DoneByUser = @DoneByUser
, TronsferFrom = @TronsferFrom
, CurrencyOfTransferID = @CurrencyOfTransferID
, Amount = @Amount
, Fees = @Fees
, BankName = @BankName
, IBAN_Number = @IBAN_Number
, RecipientFullName = @RecipientFullName
, SendingDate = @SendingDate
, ArrivalDate = @ArrivalDate
, status = @status
WHERE OperationID = @OperationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);
            Command.Parameters.AddWithValue("@TransfeID", TransfeID);
            Command.Parameters.AddWithValue("@DoneByUser", DoneByUser);
            Command.Parameters.AddWithValue("@TronsferFrom", TronsferFrom);
            Command.Parameters.AddWithValue("@CurrencyOfTransferID", CurrencyOfTransferID);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@BankName", BankName);
            Command.Parameters.AddWithValue("@IBAN_Number", IBAN_Number);
            Command.Parameters.AddWithValue("@RecipientFullName", RecipientFullName);
            Command.Parameters.AddWithValue("@SendingDate", SendingDate);

            if (ArrivalDate == default)
                Command.Parameters.AddWithValue("@ArrivalDate", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ArrivalDate", ArrivalDate);

            Command.Parameters.AddWithValue("@status", status);


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

        static public bool DeleteExternalTransferOperation(int OperationID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM ExternalTransferOperations WHERE OperationID = @OperationID;";

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

        static public bool IsExternalTransferOperationExist(int OperationID)
        {
            bool IsExternalTransferOperationExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM ExternalTransferOperations WHERE OperationID = @OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsExternalTransferOperationExist = true;
                }
            }
            catch (Exception ex)
            {
                IsExternalTransferOperationExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsExternalTransferOperationExist;
        }

    }
}

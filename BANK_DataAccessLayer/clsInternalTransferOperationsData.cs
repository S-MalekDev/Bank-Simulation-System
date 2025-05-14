using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_DataAccessLayer
{
    public static class clsInternalTransferOperationsData
    {

        static public DataTable GetAllInternalTransferOperations(int ClientID)
        {
            DataTable dtInternalTransferOperationsList = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT ID, Amount, Date, Time, [Is Succeeded] FROM InternalTransferOperationsView Where ClientID = @ClientID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ClientID",ClientID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtInternalTransferOperationsList.Load(Reader);
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


            return dtInternalTransferOperationsList;
        }

        static public bool GetInternalTransferOperationInfoByID(int OperationID, ref int TransferID, ref byte CurrencyOfTransfer, ref int TransferFromClientID, ref int DoneByUser, ref decimal Amount, ref decimal Fees, ref byte CurrencyOfAmountReceived, ref int TransferToClientID, ref decimal AmountReceived, ref bool IsSucceedit)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"SELECT * FROM InternalTransferOperations WHERE OperationID =@OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {

                    TransferID = (int)Reader["TransferID"];
                    CurrencyOfTransfer = (byte)Reader["CurrencyOfTransfer"];
                    TransferFromClientID = (int)Reader["TransferFromClientID"];
                    DoneByUser = (int)Reader["DoneByUser"];
                    Amount = (decimal)Reader["Amount"];
                    Fees = (decimal)Reader["Fees"];
                    CurrencyOfAmountReceived = (byte)Reader["CurrencyOfAmountReceived"];
                    TransferToClientID = (int)Reader["TransferToClientID"];
                    AmountReceived = (decimal)Reader["AmountReceived"];
                    IsSucceedit = (bool)Reader["IsSucceedit"];


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

        static public int AddNewInternalTransferOperation(int TransferID, byte CurrencyOfTransfer, int TransferFromClientID, int DoneByUser, decimal Amount, decimal Fees, byte CurrencyOfAmountReceived, int TransferToClientID, decimal AmountReceived, bool IsSucceedit)
        {
            int OperationID = -1;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"INSERT INTO InternalTransferOperations
                                         (TransferID, CurrencyOfTransfer, TransferFromClientID, DoneByUser, Amount, Fees, CurrencyOfAmountReceived, TransferToClientID, AmountReceived, IsSucceedit)
                                   VALUES
                                         (@TransferID, @CurrencyOfTransfer, @TransferFromClientID, @DoneByUser, @Amount, @Fees, @CurrencyOfAmountReceived, @TransferToClientID, @AmountReceived, @IsSucceedit);

                                           UPDATE Accounts
                                           SET Balance = Balance - (@Amount + @Fees)
                                           WHERE ClientID = @TransferFromClientID;

                                           UPDATE Accounts
                                           SET Balance = Balance + @AmountReceived
                                           WHERE ClientID = @TransferToClientID;

                                         SELECT Scope_IDentity();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TransferID", TransferID);
            Command.Parameters.AddWithValue("@CurrencyOfTransfer", CurrencyOfTransfer);
            Command.Parameters.AddWithValue("@TransferFromClientID", TransferFromClientID);
            Command.Parameters.AddWithValue("@DoneByUser", DoneByUser);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@CurrencyOfAmountReceived", CurrencyOfAmountReceived);
            Command.Parameters.AddWithValue("@TransferToClientID", TransferToClientID);
            Command.Parameters.AddWithValue("@AmountReceived", AmountReceived);
            Command.Parameters.AddWithValue("@IsSucceedit", IsSucceedit);


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

        static public bool UpdateInternalTransferOperation(int OperationID, int TransferID, byte CurrencyOfTransfer, int TransferFromClientID, int DoneByUser, decimal Amount, decimal Fees, byte CurrencyOfAmountReceived, int TransferToClientID, decimal AmountReceived, bool IsSucceedit)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);


            string Query = @"UPDATE InternalTransferOperations 
SET TransferID = @TransferID
, CurrencyOfTransfer = @CurrencyOfTransfer
, TransferFromClientID = @TransferFromClientID
, DoneByUser = @DoneByUser
, Amount = @Amount
, Fees = @Fees
, CurrencyOfAmountReceived = @CurrencyOfAmountReceived
, TransferToClientID = @TransferToClientID
, AmountReceived = @AmountReceived
, IsSucceedit = @IsSucceedit
WHERE OperationID = @OperationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);
            Command.Parameters.AddWithValue("@TransferID", TransferID);
            Command.Parameters.AddWithValue("@CurrencyOfTransfer", CurrencyOfTransfer);
            Command.Parameters.AddWithValue("@TransferFromClientID", TransferFromClientID);
            Command.Parameters.AddWithValue("@DoneByUser", DoneByUser);
            Command.Parameters.AddWithValue("@Amount", Amount);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@CurrencyOfAmountReceived", CurrencyOfAmountReceived);
            Command.Parameters.AddWithValue("@TransferToClientID", TransferToClientID);
            Command.Parameters.AddWithValue("@AmountReceived", AmountReceived);
            Command.Parameters.AddWithValue("@IsSucceedit", IsSucceedit);


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

        static public bool DeleteInternalTransferOperation(int OperationID)
        {
            int RowsEfacts = 0;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "DELETE FROM InternalTransferOperations WHERE OperationID = @OperationID;";

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

        static public bool IsInternalTransferOperationExist(int OperationID)
        {
            bool IsInternalTransferOperationExist = false;

            SqlConnection Connection = new SqlConnection(clsConnectionSettings.ConnectionString);

            string Query = "SELECT 1 FROM InternalTransferOperations WHERE OperationID = @OperationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@OperationID", OperationID);

            try
            {
                Connection.Open();
                object Exist = Command.ExecuteScalar();
                if (Exist != null)
                {
                    IsInternalTransferOperationExist = true;
                }
            }
            catch (Exception ex)
            {
                IsInternalTransferOperationExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsInternalTransferOperationExist;
        }

    }

}

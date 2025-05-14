using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsExternalTransferOperations : clsTransferApplications
    {
        public enum enStatus { New = 1, Canceled = 2 , Completed  = 3 }
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public string GetStatusText()
        {
            return status == enStatus.New ? "New" : status == enStatus.Completed ? "Completed" : "Canceled";
        }
        public int OperationID { get; set; }
        public byte CurrencyOfTransferID { get; set; }
        public decimal Amount { get; set; }
        public decimal Fees { get; set; }
        public string BankName { get; set; }
        public string IBAN_Number { get; set; }
        public string RecipientFullName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public enStatus status { get; set; }
        clsAccountCurrencies CurrencyOfTransferInfo { get; set; }
        public clsExternalTransferOperations()
        {
            TransferID = -1;
            TransferType = default;
            TransactionID = -1;
            TransactionType = default;
            ServiceAppID = -1;
            ClientID = -1;
            UserID = -1;
            Service = default;
            RequestDate = DateTime.Now;
            CurrencyOfTransferID = 0;
            Amount = -1;
            Fees = -1;
            BankName = string.Empty;
            IBAN_Number = string.Empty;
            RecipientFullName = string.Empty;
            ArrivalDate = default;
            status = default;

            ClientInfo = null;
            UserInfo = null;
            ServiceInfo = null;
            TransferTypeInfo = null;
            CurrencyOfTransferInfo = null;
            _Mode = enMode.AddNew;
        }

        private clsExternalTransferOperations(int OperationID ,byte CurrencyOfTransferID, decimal Amount, decimal Fees, string BankName, string IBAN_Number, string RecipientFullName, DateTime ArrivalDate, enStatus status
            , int TransferID, clsTransferTypes.enTransferType TransferType,
            int TransactionID, clsTransactionTypes.enTransactionTypes TransactionType
            , int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
            :base (TransferID, (clsTransferTypes.enTransferType) TransferType,
             TransactionID, (clsTransactionTypes.enTransactionTypes) TransactionType
            ,  ServiceAppID,  ClientID,  UserID, (clsServices.enService) Service,  RequestDate)
        {
            this.OperationID = OperationID;
            this.CurrencyOfTransferID = CurrencyOfTransferID;
            this.Amount = Amount;
            this.Fees = Fees;
            this.BankName = BankName;
            this.IBAN_Number = IBAN_Number;
            this.RecipientFullName = RecipientFullName;
            this.ArrivalDate = ArrivalDate;
            this.status = status;

            CurrencyOfTransferInfo = clsAccountCurrencies.Find(CurrencyOfTransferID);
            _Mode = enMode.Update;
        }

        static public DataTable GetAllExternalTransferOperations(int ClientID)
        {
            return clsExternalTransferOperationsData.GetAllExternalTransferOperations(ClientID);
        }

        static public clsExternalTransferOperations Find(int OperationID)
        {
            int TransferID = -1;
            int TransactionID = -1;
            byte TransferTypeID = 0;
            byte TransactionTypeID = 0;
            int ServiceAppID = -1;
            int ClientID = -1;
            int UserID = -1;
            byte ServiceID = 0;
            DateTime RequestDate = default;

            byte CurrencyOfTransferID = 0;
            decimal Amount = -1;
            decimal Fees = -1;
            string BankName = string.Empty;
            string IBAN_Number = string.Empty;
            string RecipientFullName = string.Empty;
            DateTime ArrivalDate = default;
            byte status = 0;


            if (clsExternalTransferOperationsData.GetExternalTransferOperationInfoByID(OperationID, ref TransferID, ref UserID, ref ClientID, ref CurrencyOfTransferID, ref Amount, ref Fees, ref BankName, ref IBAN_Number, ref RecipientFullName, ref ArrivalDate, ref ArrivalDate, ref status))
            {
                if (clsTransferApplicationsData.GetTransferAppInfoByID(TransferID, ref TransactionID, ref TransferTypeID))
                {
                    if (clsTransactionsData.GetTransactionInfoByID(TransactionID, ref TransactionTypeID, ref ServiceAppID))
                    {
                        if (clsServicesApplicationsData.GetServicesAppInfoByID(ServiceAppID, ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
                        {
                            return new clsExternalTransferOperations(OperationID, CurrencyOfTransferID,  Amount,  Fees,  BankName,  IBAN_Number,  RecipientFullName,  ArrivalDate, (enStatus) status
                                   ,  TransferID, (clsTransferTypes.enTransferType) TransferTypeID,
                                    TransactionID, (clsTransactionTypes.enTransactionTypes) TransactionTypeID
                                   ,  ServiceAppID,  ClientID,  UserID, (clsServices.enService) ServiceID,  RequestDate);
                        }

                    }

                }

                
            }
            return null;

        }

        private bool _AddNewExternalTransferOperation()
        {
            OperationID = clsExternalTransferOperationsData.AddNewExternalTransferOperation(this.TransferID, this.UserID, this.ClientID, this.CurrencyOfTransferID, this.Amount, this.Fees, this.BankName, this.IBAN_Number, this.RecipientFullName, this.RequestDate, this.ArrivalDate, (byte)this.status);

            return OperationID != -1;
        }

        private bool _UpdateExternalTransferOperation()
        {
            return clsExternalTransferOperationsData.UpdateExternalTransferOperation(this.OperationID, this.TransferID, this.UserID, this.ClientID, this.CurrencyOfTransferID, this.Amount, this.Fees, this.BankName, this.IBAN_Number, this.RecipientFullName, this.RequestDate, this.ArrivalDate, (byte)this.status);
        }

        static public bool DeleteExternalTransferOperation(int OperationID)
        {
            return clsExternalTransferOperationsData.DeleteExternalTransferOperation(OperationID);
        }

        static public bool IsExternalTransferOperationExist(int OperationID)
        {
            return clsExternalTransferOperationsData.IsExternalTransferOperationExist(OperationID);
        }

        public bool Save()
        {
            base.Mode = (clsTransferApplications.enMode)this._Mode;

            if(!base.Save()) return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewExternalTransferOperation())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case enMode.Update:
                    {
                        return _UpdateExternalTransferOperation();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

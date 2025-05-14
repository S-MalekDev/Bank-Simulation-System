using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsInternalTransferOperations: clsTransferApplications
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public int OperationID { get; set; }
        public byte CurrencyOfTransfer { get; set; }
        public decimal Amount { get; set; }
        public decimal Fees { get; set; }
        public int TransferToClientID { get; set; }
        public bool IsSucceedit { get; set; }
        public byte CurrencyOfAmountReceived { get; set; }
        public decimal AmountReceived { get; set; }
        public clsClients RecipientClientInfo { get; set; }
        public clsAccountCurrencies CurrencyOfTransferInfo { get; set; }
        public clsAccountCurrencies CurrencyOfReceiveInfo { get; set; }
        public clsInternalTransferOperations()
        {

            OperationID = -1;
            CurrencyOfTransfer = 0;
            Amount = -1;
            Fees = -1;
            TransferToClientID = -1;
            IsSucceedit = false;
            TransferID = -1;
            TransferType = default;
            TransactionID = -1;
            TransactionType = default;
            ServiceAppID = -1;
            ClientID = -1;
            UserID = -1;
            Service = default;
            CurrencyOfAmountReceived = 0;
            AmountReceived = 0;
            RequestDate = DateTime.Now;

            ClientInfo = null;
            UserInfo = null;
            ServiceInfo = null;
            TransferTypeInfo = null;
            RecipientClientInfo = null;
            CurrencyOfTransferInfo = null;
            CurrencyOfReceiveInfo = null;
            _Mode = enMode.AddNew;
        }

        private clsInternalTransferOperations(int OperationID, byte CurrencyOfTransfer, decimal Amount, decimal Fees, byte CurrencyOfAmountReceived, int TransferToClientID, decimal AmountReceived, bool IsSucceedit
            , int TransferID, clsTransferTypes.enTransferType TransferType,
            int TransactionID, clsTransactionTypes.enTransactionTypes TransactionType
            , int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
            :base( TransferID, (clsTransferTypes.enTransferType) TransferType,
             TransactionID, (clsTransactionTypes.enTransactionTypes) TransactionType
            ,  ServiceAppID,  ClientID,  UserID, (clsServices.enService) Service,  RequestDate)
        {
            this.OperationID = OperationID;
            this.CurrencyOfTransfer = CurrencyOfTransfer;
            this.Amount = Amount;
            this.Fees = Fees;
            this.TransferToClientID = TransferToClientID;
            this.IsSucceedit = IsSucceedit;
            this.CurrencyOfAmountReceived = CurrencyOfAmountReceived;
            this.AmountReceived = AmountReceived;
            RecipientClientInfo = clsClients.Find(TransferToClientID);
            CurrencyOfTransferInfo = clsAccountCurrencies.Find(CurrencyOfTransfer);
            CurrencyOfReceiveInfo = clsAccountCurrencies.Find(CurrencyOfAmountReceived);
            _Mode = enMode.Update;
        }

        static public DataTable GetAllInternalTransferOperations(int ClientID)
        {
            return clsInternalTransferOperationsData.GetAllInternalTransferOperations(ClientID);
        }

        static public clsInternalTransferOperations Find(int OperationID)
        {
            int TransactionID = -1;
            byte TransferTypeID = 0;
            byte TransactionTypeID = 0;
            int ServiceAppID = -1;
            int ClientID = -1;
            int UserID = -1;
            byte ServiceID = 0;
            DateTime RequestDate = default;
            byte CurrencyOfAmountReceived = 0;
            decimal AmountReceived = -1;
            int TransferID = -1;
            byte CurrencyOfTransfer = 0;
            decimal Amount = -1;
            decimal Fees = -1;
            int TransferToClientID = -1;
            bool IsSucceedit = false;


            if (clsInternalTransferOperationsData.GetInternalTransferOperationInfoByID(OperationID, ref TransferID, ref CurrencyOfTransfer, ref ClientID, ref UserID, ref Amount, ref Fees, ref CurrencyOfAmountReceived, ref TransferToClientID,ref AmountReceived, ref IsSucceedit))
            {
                if (clsTransferApplicationsData.GetTransferAppInfoByID(TransferID, ref TransactionID, ref TransferTypeID))
                {
                    if (clsTransactionsData.GetTransactionInfoByID(TransactionID, ref TransactionTypeID, ref ServiceAppID))
                    {
                        if (clsServicesApplicationsData.GetServicesAppInfoByID(ServiceAppID, ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
                        {
                            return new clsInternalTransferOperations( OperationID,  CurrencyOfTransfer,  Amount,  Fees, CurrencyOfAmountReceived
                                ,  TransferToClientID, AmountReceived,  IsSucceedit,  TransferID, (clsTransferTypes.enTransferType) TransferTypeID
                                ,TransactionID, (clsTransactionTypes.enTransactionTypes) TransactionTypeID,  ServiceAppID,  ClientID,  UserID
                                , (clsServices.enService) ServiceID, RequestDate);
                        }

                    }

                }
                
            }
            return null;

        }

        private bool _AddNewInternalTransferOperation()
        {
            OperationID = clsInternalTransferOperationsData.AddNewInternalTransferOperation(this.TransferID, this.CurrencyOfTransfer, this.ClientID, this.UserID, this.Amount, this.Fees,this.CurrencyOfAmountReceived, this.TransferToClientID,this.AmountReceived, this.IsSucceedit);

            return OperationID != -1;
        }

        private bool _UpdateInternalTransferOperation()
        {
            return clsInternalTransferOperationsData.UpdateInternalTransferOperation(this.OperationID, this.TransferID, this.CurrencyOfTransfer, this.ClientID, this.UserID, this.Amount, this.Fees, this.CurrencyOfAmountReceived, this.TransferToClientID, this.AmountReceived, this.IsSucceedit);
        }

        static public bool DeleteInternalTransferOperation(int OperationID)
        {
            return clsInternalTransferOperationsData.DeleteInternalTransferOperation(OperationID);
        }

        static public bool IsInternalTransferOperationExist(int OperationID)
        {
            return clsInternalTransferOperationsData.IsInternalTransferOperationExist(OperationID);
        }

        public bool Save()
        {
            base.Mode = (clsTransferApplications.enMode)this._Mode;
            
            if(!base.Save()) 
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInternalTransferOperation())
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
                        return _UpdateInternalTransferOperation();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

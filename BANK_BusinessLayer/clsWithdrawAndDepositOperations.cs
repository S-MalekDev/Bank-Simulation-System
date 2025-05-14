using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BANK_BusinessLayer.clsServices;
using static BANK_BusinessLayer.clsTransactionTypes;

namespace BANK_BusinessLayer
{
    public class clsWithdrawAndDepositOperations: clsTransactions
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _OperationID;

        public int OperationID { get { return _OperationID; } }
        public decimal Amount { get; set; }
        public decimal OperationFees { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal BalanceAfterTransaction { get; set; }


        public clsWithdrawAndDepositOperations()
        {
            _OperationID = -1;
            Amount = -1;
            OperationFees = -1;
            PreviousBalance = -1;
            BalanceAfterTransaction = -1;
            TransactionID = -1;
            TransactionType = default;
            ServiceAppID = -1;
            ClientID = -1;
            UserID = -1;
            Service = default;
            RequestDate = DateTime.Now;

            ClientInfo = null;
            UserInfo = null;
            ServiceInfo = null;
            _Mode = enMode.AddNew;
        }

        protected clsWithdrawAndDepositOperations(int OperationID,  decimal Amount, decimal OperationFees, decimal PreviousBalance
            , decimal BalanceAfterTransaction, int TransactionID, clsTransactionTypes.enTransactionTypes TransactionType
            , int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
            : base ( TransactionID,  TransactionType,  ServiceAppID,  ClientID,  UserID,  Service,  RequestDate)
        {
            _OperationID = OperationID;
            this.Amount = Amount;
            this.OperationFees = OperationFees;
            this.PreviousBalance = PreviousBalance;
            this.BalanceAfterTransaction = BalanceAfterTransaction;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllWithdrawAndDepositOperations(int ClientID)
        {
            return clsWithdrawAndDepositOperationsData.GetAllWithdrawAndDepositOperations( ClientID);
        }

        static public clsWithdrawAndDepositOperations Find(int OperationID)
        {
            byte TransactionTypeID = 0;
             int ServiceAppID = 0;
            int UserID = 0;
            byte ServiceID = 0;
            DateTime RequestDate = default;
            int TransactionID = -1;
            int ClientID = -1;
            decimal Amount = -1;
            decimal OperationFees = -1;
            decimal PreviousBalance = -1;
            decimal BalanceAfterTransaction = -1;


            if (clsWithdrawAndDepositOperationsData.GetWithdrawAndDepositOperationInfoByID(OperationID, ref TransactionID, ref ClientID, ref Amount, ref OperationFees, ref PreviousBalance, ref BalanceAfterTransaction))
            {
                if(clsTransactionsData.GetTransactionInfoByID( TransactionID,ref TransactionTypeID, ref ServiceAppID))
                {
                    if(clsServicesApplicationsData.GetServicesAppInfoByID(ServiceAppID,ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
                    {
                        return new clsWithdrawAndDepositOperations(OperationID, Amount, OperationFees, PreviousBalance
            , BalanceAfterTransaction, TransactionID, (clsTransactionTypes.enTransactionTypes)TransactionTypeID
            , ServiceAppID, ClientID, UserID, (clsServices.enService)ServiceID, RequestDate);
                    }
                }
                
            }

            return null;

        }

        private bool _AddNewWithdrawAndDepositOperation()
        {
            _OperationID = clsWithdrawAndDepositOperationsData.AddNewWithdrawAndDepositOperation(this.TransactionID, this.ClientID, this.Amount, this.OperationFees, this.PreviousBalance, this.BalanceAfterTransaction);

            return _OperationID != -1;
        }

        private bool _UpdateWithdrawAndDepositOperation()
        {
            return clsWithdrawAndDepositOperationsData.UpdateWithdrawAndDepositOperation(this.OperationID, this.TransactionID, this.ClientID, this.Amount, this.OperationFees, this.PreviousBalance, this.BalanceAfterTransaction);
        }

        static public bool DeleteWithdrawAndDepositOperation(int OperationID)
        {
            return clsWithdrawAndDepositOperationsData.DeleteWithdrawAndDepositOperation(OperationID);
        }

        static public bool IsWithdrawAndDepositOperationExist(int OperationID)
        {
            return clsWithdrawAndDepositOperationsData.IsWithdrawAndDepositOperationExist(OperationID);
        }

        public bool Save()
        {
            base.Mode = (clsTransactions.enMode)this._Mode;

            if(!base.Save()) 
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewWithdrawAndDepositOperation())
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
                        return _UpdateWithdrawAndDepositOperation();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

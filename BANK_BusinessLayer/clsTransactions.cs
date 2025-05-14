using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BANK_BusinessLayer.clsServices;

namespace BANK_BusinessLayer
{
    public class clsTransactions : clsServicesApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;


        public int TransactionID { get; set; }
        public clsTransactionTypes.enTransactionTypes TransactionType { get; set; }

        public clsTransactions()
        {
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
            Mode = enMode.AddNew;
        }

        protected clsTransactions(int TransactionID, clsTransactionTypes.enTransactionTypes TransactionType
            , int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
            :base(ServiceAppID,  ClientID,  UserID,  Service,  RequestDate)
        {
            this.TransactionID = TransactionID;
            this.TransactionType = TransactionType;

            Mode = enMode.Update;
        }

        static public DataTable GetAllTransactions()
        {
            return clsTransactionsData.GetAllTransactions();
        }

        static public clsTransactions Find(int TransactionID)
        {

            byte TransactionTypeID = 0;
            int ServiceAppID = -1;
            int ClientID = -1;
            int UserID = -1;
            byte ServiceID = default;
            DateTime RequestDate = default;


            if (clsTransactionsData.GetTransactionInfoByID(TransactionID, ref TransactionTypeID, ref ServiceAppID))
            {
                if(clsServicesApplicationsData.GetServicesAppInfoByID( ServiceAppID, ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
                {
                    return new clsTransactions( TransactionID,(clsTransactionTypes.enTransactionTypes)TransactionTypeID
            ,  ServiceAppID,  ClientID,  UserID, (clsServices.enService)ServiceID,  RequestDate);
                }
                
            }
            
              return null;
            
        }

        private bool _AddNewTransaction()
        {
            TransactionID = clsTransactionsData.AddNewTransaction((byte)this.TransactionType, this.ServiceAppID);

            return TransactionID != -1;
        }

        private bool _UpdateTransaction()
        {
            return clsTransactionsData.UpdateTransaction(this.TransactionID, (byte)this.TransactionType, this.ServiceAppID);
        }

        static public bool DeleteTransaction(int TransactionID)
        {
            return clsTransactionsData.DeleteTransaction(TransactionID);
        }

        static public bool IsTransactionExist(int TransactionID)
        {
            return clsTransactionsData.IsTransactionExist(TransactionID);
        }

        public bool Save()
        {
            base.Mode = (clsServicesApplications.enMode)this.Mode;

            if(!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTransaction())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case enMode.Update:
                    {
                        return _UpdateTransaction();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BANK_BusinessLayer.clsExternalTransferOperations;
using static BANK_BusinessLayer.clsServices;
using static BANK_BusinessLayer.clsTransactionTypes;

namespace BANK_BusinessLayer
{
    public class clsTransferApplications : clsTransactions
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;

        public int TransferID { get; set; } 
        public clsTransferTypes.enTransferType TransferType { get; set; }

        public clsTransferTypes TransferTypeInfo { get; set; }
        public clsTransferApplications()
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

            ClientInfo = null;
            UserInfo = null;
            ServiceInfo = null;
            TransferTypeInfo = null;
            Mode = enMode.AddNew;
        }

        protected clsTransferApplications(int TransferID, clsTransferTypes.enTransferType TransferType,
            int TransactionID, clsTransactionTypes.enTransactionTypes TransactionType
            , int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
            : base(TransactionID, TransactionType, ServiceAppID, ClientID, UserID, Service, RequestDate)
        {
            this.TransferID = TransferID;
            this.TransferType = TransferType;
            TransferTypeInfo = clsTransferTypes.Find(TransferType);
            Mode = enMode.Update;
        }

        static public DataTable GetAllTransferApplications()
        {
            return clsTransferApplicationsData.GetAllTransferApplications();
        }

        static public clsTransferApplications Find(int TransferID)
        {

            int TransactionID = -1;
            byte TransferTypeID = 0;
            byte TransactionTypeID = 0;
            int ServiceAppID = -1;
            int ClientID = -1;
            int UserID = -1;
            byte ServiceID = 0;
            DateTime RequestDate = default;

            if (clsTransferApplicationsData.GetTransferAppInfoByID(TransferID, ref TransactionID, ref TransferTypeID))
            {
                if (clsTransactionsData.GetTransactionInfoByID(TransactionID, ref TransactionTypeID, ref ServiceAppID))
                {
                    if (clsServicesApplicationsData.GetServicesAppInfoByID(ServiceAppID, ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
                    {
                        return new clsTransferApplications(TransferID, (clsTransferTypes.enTransferType)TransferTypeID,
             TransactionID, (clsTransactionTypes.enTransactionTypes)TransactionTypeID
            , ServiceAppID, ClientID, UserID, (clsServices.enService)ServiceID, RequestDate);
            
                    }

                }

            }
            return null;

        }

        private bool _AddNewTransferApp()
        {
            TransferID = clsTransferApplicationsData.AddNewTransferApp(this.TransactionID, (byte)this.TransferType);

            return TransferID != -1;
        }

        private bool _UpdateTransferApp()
        {
            return clsTransferApplicationsData.UpdateTransferApp(this.TransferID, this.TransactionID, (byte)this.TransferType);
        }

        static public bool DeleteTransferApp(int TransferID)
        {
            return clsTransferApplicationsData.DeleteTransferApp(TransferID);
        }

        static public bool IsTransferAppExist(int TransferID)
        {
            return clsTransferApplicationsData.IsTransferAppExist(TransferID);
        }

        public bool Save()
        {
            base.Mode = (clsTransactions.enMode)this.Mode;

            if(!base.Save()) 
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTransferApp())
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
                        return _UpdateTransferApp();

                    }
                default:
                    {
                        return false;
                    }
            }

        }
    }
}

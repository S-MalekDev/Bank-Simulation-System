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
    public class clsAccounts: clsOpenNewAccountApplications
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        
        public int ClientID { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public byte AccountCurrency { get; set; }
        public bool IsActive { get; set; }


        public clsClients ClientInfo { get; set; }
        public clsAccountCurrencies CurrnecyInfo { get; set; }

        public clsAccounts()
        {
            _AppID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            OpeningDate = DateTime.Now;
            ClientID = default;
            Password = string.Empty;
            Balance = -1;
            AccountCurrency = 0;
            IsActive = false;

            UserInfo = null;
            ClientInfo = null;
            CurrnecyInfo = null;
            _Mode = enMode.AddNew;
        }

        protected clsAccounts(int AccountNumber, int ClientID, string Password, decimal Balance, byte AccountCurrency, bool IsActive 
            ,int AppID, int PersonID, int CreatedByUserID, DateTime OpeningDate)
            :base( AppID,  PersonID,  CreatedByUserID,  OpeningDate, AccountNumber)
        {
            this.ClientID = ClientID;
            this.Password = Password;
            this.Balance = Balance;
            this.AccountCurrency = AccountCurrency;
            this.IsActive = IsActive;

            ClientInfo = clsClients.Find(ClientID);
            CurrnecyInfo = clsAccountCurrencies.Find(AccountCurrency);
            _Mode = enMode.Update;
        }

        static public DataTable GetAllAccounts()
        {
            return clsAccountsData.GetAllAccounts();
        }

        static public DataTable GetAccountsListByClientIDLikeTheNumber(string TextNum)
        {
            return clsAccountsData.GetAccountsListByClientIDLikeTheNumber(TextNum);
        }

        static public DataTable GetAccountsListByAccountNumberLikeTheNumber(string TextNum)
        {
            return clsAccountsData.GetAccountsListByAccountNumberLikeTheNumber(TextNum);
        }

        static public clsAccounts FindByAccountNumber(int AccountNumber)
        {
           int AppID = -1;
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime OpeningDate = DateTime.Now;
            
            int ClientID = default;
            string Password = string.Empty;
            decimal Balance = -1;
            byte AccountCurrency = 0;
            bool IsActive = false;


            if (clsAccountsData.GetAccountInfoByAccountNumber(AccountNumber, ref ClientID, ref Password, ref Balance, ref AccountCurrency, ref IsActive))
            {
                if(clsOpenNewAccountApplicationsData.GetOpenNewAccountAppInfoByAccountNumber(ref  AppID, ref  PersonID, ref CreatedByUserID, ref  OpeningDate, AccountNumber))
                {
                    return new clsAccounts(AccountNumber, ClientID, Password, Balance, AccountCurrency, IsActive
            , AppID, PersonID, CreatedByUserID, OpeningDate);
                }
            }

            return null;

        }

        static public clsAccounts FindByClientID(int ClientID)
        {
            int AppID = -1;
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime OpeningDate = DateTime.Now;

            int AccountNumber = -1;
            string Password = string.Empty;
            decimal Balance = -1;
            byte AccountCurrency = 0;
            bool IsActive = false;


            if (clsAccountsData.GetAccountInfoByClientID(ref AccountNumber, ClientID, ref Password, ref Balance, ref AccountCurrency, ref IsActive))
            {
                if (clsOpenNewAccountApplicationsData.GetOpenNewAccountAppInfoByAccountNumber(ref AppID, ref PersonID, ref CreatedByUserID, ref OpeningDate, AccountNumber))
                {
                    return new clsAccounts(AccountNumber, ClientID, Password, Balance, AccountCurrency, IsActive
            , AppID, PersonID, CreatedByUserID, OpeningDate);
                }
            }

            return null;

        }

        static public clsAccounts FindByPersonID(int PersonID)
        {
            int AppID = -1;
            int ClientID = -1;
            int CreatedByUserID = -1;
            DateTime OpeningDate = DateTime.Now;

            int AccountNumber = -1;
            string Password = string.Empty;
            decimal Balance = -1;
            byte AccountCurrency = 0;
            bool IsActive = false;

            if (clsOpenNewAccountApplicationsData.GetOpenNewAccountAppInfoByPersonID(ref AppID,  PersonID, ref CreatedByUserID, ref OpeningDate, ref AccountNumber))
            {
                if(clsAccountsData.GetAccountInfoByAccountNumber( AccountNumber,ref ClientID, ref Password, ref Balance, ref AccountCurrency, ref IsActive))
                {
                    return new clsAccounts(AccountNumber, ClientID, Password, Balance, AccountCurrency, IsActive
            , AppID, PersonID, CreatedByUserID, OpeningDate);
                }
            }

            return null;

        }

        static public bool DepositeAmountByClientID(decimal Amount , int ClientID)
        {
            return clsAccountsData.DepositeAmountByClientID(Amount, ClientID);
        }
        private bool _AddNewAccount()
        {
            AccountNumber = clsAccountsData.AddNewAccount(this.ClientID, this.Password, this.Balance, this.AccountCurrency, this.IsActive);

            return AccountNumber != -1;
        }

        private bool _UpdateAccount()
        {
            return clsAccountsData.UpdateAccount(this.AccountNumber, this.ClientID, this.Password, this.Balance, this.AccountCurrency, this.IsActive);
        }

        static public bool DeleteAccount(int AccountNumber)
        {
            return clsAccountsData.DeleteAccount(AccountNumber);
        }

        static public bool IsAccountExist(int AccountNumber)
        {
            return clsAccountsData.IsAccountExist(AccountNumber);
        }

        static public bool IsAccountExistByPersonID(int PersonID)
        {
            return clsAccountsData.IsAccountExistByPersonID(PersonID);
        }

        public bool Create(int PersonID, int CreatedByUserID)
        {
            clsClients NewClient = new clsClients();
            NewClient.PersonID = PersonID;

            if (!NewClient.Save())
                return false;


            this.ClientID = NewClient.ClientID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.OpeningDate = DateTime.Now;
            this.IsActive = true;

            if (this.Save())
            {
                base.SetAccountIDtoTheApp(this.AccountNumber);
                return true;
            }

            return false;

        }
        public bool Save()
        {
            base._Mode = (clsOpenNewAccountApplications.enMode)this._Mode;
            if(!base.Save()) return false;


            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewAccount())
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
                        return _UpdateAccount();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

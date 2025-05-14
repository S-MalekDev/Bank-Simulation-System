using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsAccountCurrencies : clsCurrencies
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _AccountCurrencyID;

        public int AccountCurrencyID { get { return _AccountCurrencyID; } }

        public clsAccountCurrencies()
        {
            _AccountCurrencyID = -1;
            _CurrencyID = -1;
            CurrencyName = string.Empty;
            Currency = string.Empty;
            CurrencySymbol = string.Empty;
            ExchangeRatePerUSD = default;

            _Mode = enMode.AddNew;
        }

        protected clsAccountCurrencies(int AccountCurrencyID, byte CurrencyID, string CurrencyName, string Currency, string CurrencySymbol, Double ExchangeRatePerUSD)
          : base(CurrencyID, CurrencyName, Currency, CurrencySymbol, ExchangeRatePerUSD)
        {
            _AccountCurrencyID = AccountCurrencyID;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllAccountCurrencies()
        {
            return clsAccountCurrenciesData.GetAllAccountCurrencies();
        }

        static public clsAccountCurrencies Find(int AccountCurrencyID)
        {

            byte CurrencyID = 0;
            string CurrencyName = "";
            string Currency = "";
            string CurrencySymbol = "";
            Double ExchangeRatePerUSD = default;

            if (clsAccountCurrenciesData.GetAccountCurrencyInfoByID(AccountCurrencyID, ref CurrencyID))
            {
                if(clsCurrenciesData.GetCurrencyInfoByID(CurrencyID,ref CurrencyName, ref Currency, ref CurrencySymbol, ref ExchangeRatePerUSD))
                {
                    return new clsAccountCurrencies(AccountCurrencyID, CurrencyID, CurrencyName, Currency,  CurrencySymbol,  ExchangeRatePerUSD);
                }
            
            }
            {
                return null;
            }

        }

        static public clsAccountCurrencies FindByCurrency(string Currency)
        {
            int CurrencyID = -1;
            int AccountCurrencyID = -1;
            string CurrencyName = string.Empty;
            string CurrencySymbol = string.Empty;
            Double ExchangeRatePerUSD = default;

            if (clsCurrenciesData.GetCurrencyInfoByCurrency(ref CurrencyID, ref CurrencyName, Currency, ref CurrencySymbol, ref ExchangeRatePerUSD))
            {
                if(clsAccountCurrenciesData.GetAccountCurrencyInfoByCurrencyID(ref AccountCurrencyID,(byte)CurrencyID))
                {
                    return new clsAccountCurrencies( AccountCurrencyID, (byte)CurrencyID,  CurrencyName,  Currency,  CurrencySymbol,  ExchangeRatePerUSD);
                }
            }
          
                return null;
        }

        private bool _AddNewAccountCurrency()
        {
            _AccountCurrencyID = clsAccountCurrenciesData.AddNewAccountCurrency((byte)this.CurrencyID);

            return _AccountCurrencyID != -1;
        }

        private bool _UpdateAccountCurrency()
        {
            return clsAccountCurrenciesData.UpdateAccountCurrency(this.AccountCurrencyID,(byte) this.CurrencyID);
        }

        static public bool DeleteAccountCurrency(int AccountCurrencyID)
        {
            return clsAccountCurrenciesData.DeleteAccountCurrency(AccountCurrencyID);
        }

        static public bool IsAccountCurrencyExist(int AccountCurrencyID)
        {
            return clsAccountCurrenciesData.IsAccountCurrencyExist(AccountCurrencyID);
        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewAccountCurrency())
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
                        return _UpdateAccountCurrency();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }



}

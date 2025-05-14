using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsCurrencies
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode;

        protected int _CurrencyID;

        public int CurrencyID { get { return _CurrencyID; } }
        public string CurrencyName { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public Double ExchangeRatePerUSD { get; set; }


        public clsCurrencies()
        {
            _CurrencyID = -1;
            CurrencyName = string.Empty;
            Currency = string.Empty;
            CurrencySymbol = string.Empty;
            ExchangeRatePerUSD = default;

            _Mode = enMode.AddNew;
        }

        protected clsCurrencies(int CurrencyID, string CurrencyName, string Currency, string CurrencySymbol, Double ExchangeRatePerUSD)
        {
            _CurrencyID = CurrencyID;
            this.CurrencyName = CurrencyName;
            this.Currency = Currency;
            this.CurrencySymbol = CurrencySymbol;
            this.ExchangeRatePerUSD = ExchangeRatePerUSD;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllCurrencies()
        {
            return clsCurrenciesData.GetAllCurrencies();
        }

        static public clsCurrencies Find(int CurrencyID)
        {

            string CurrencyName = string.Empty;
            string Currency = string.Empty;
            string CurrencySymbol = string.Empty;
            Double ExchangeRatePerUSD = default;


            if (clsCurrenciesData.GetCurrencyInfoByID(CurrencyID, ref CurrencyName, ref Currency, ref CurrencySymbol, ref ExchangeRatePerUSD))
            {
                return new clsCurrencies(CurrencyID, CurrencyName, Currency, CurrencySymbol, ExchangeRatePerUSD);
            }
            else
            {
                return null;
            }

        }
        static public clsCurrencies Find(string CurrencyCode)
        {
            int CurrencyID = -1;
            string CurrencyName = string.Empty;
            string CurrencySymbol = string.Empty;
            Double ExchangeRatePerUSD = default;


            if (clsCurrenciesData.GetCurrencyInfoByID(ref CurrencyID, ref CurrencyName, CurrencyCode, ref CurrencySymbol, ref ExchangeRatePerUSD))
            {
                return new clsCurrencies(CurrencyID, CurrencyName, CurrencyCode, CurrencySymbol, ExchangeRatePerUSD);
            }
            else
            {
                return null;
            }

        }
        private bool _AddNewCurrency()
        {
            _CurrencyID = clsCurrenciesData.AddNewCurrency(this.CurrencyName, this.Currency, this.CurrencySymbol, this.ExchangeRatePerUSD);

            return _CurrencyID != -1;
        }

        private bool _UpdateCurrency()
        {
            return clsCurrenciesData.UpdateCurrency(this.CurrencyID, this.CurrencyName, this.Currency, this.CurrencySymbol, this.ExchangeRatePerUSD);
        }

        static public bool DeleteCurrency(int CurrencyID)
        {
            return clsCurrenciesData.DeleteCurrency(CurrencyID);
        }

        static public bool IsCurrencyExist(int CurrencyID)
        {
            return clsCurrenciesData.IsCurrencyExist(CurrencyID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewCurrency())
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
                        return _UpdateCurrency();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }
}

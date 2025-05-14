using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsCountries
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private byte _CountryID;

        public byte CountryID { get { return _CountryID; } }
        public string CountryName { get; set; }
        public string Nationality { get; set; }
        public string PhoneCode { get; set; }
        public byte CurrencyID { get; set; }


        public clsCountries()
        {
            _CountryID = 0;
            CountryName = string.Empty;
            Nationality = string.Empty;
            PhoneCode = string.Empty;
            CurrencyID = 0;

            _Mode = enMode.AddNew;
        }

        private clsCountries(byte CountryID, string CountryName, string Nationality, string PhoneCode, byte CurrencyID)
        {
            _CountryID = CountryID;
            this.CountryName = CountryName;
            this.Nationality = Nationality;
            this.PhoneCode = PhoneCode;
            this.CurrencyID = CurrencyID;

            _Mode = enMode.Update;
        }

        static public DataTable GetListOfNationalities()
        {
            return clsCountriesData.GetListOfNationalities();
        }

        static public DataTable GetListOfCountriesName()
        {
            return clsCountriesData.GetListOfCountriesName();
        }

        static public byte GetCountryID_ByNationalityText(string Nationality)
        {
            return clsCountriesData.GetCountryID_ByNationalityText(Nationality); 
        }

        static public byte GetCountryID_ByCountryNameText(string CountryName)
        {
            return clsCountriesData.GetCountryID_ByCountryNameText(CountryName);

        }

        static public clsCountries Find(byte CountryID)
        {

            string CountryName = string.Empty;
            string Nationality = string.Empty;
            string PhoneCode = string.Empty;
            byte CurrencyID = 0;


            if (clsCountriesData.GetCountryInfoByID(CountryID, ref CountryName, ref Nationality, ref PhoneCode, ref CurrencyID))
            {
                return new clsCountries(CountryID, CountryName, Nationality, PhoneCode, CurrencyID);
            }
            else
            {
                return null;
            }

        }

        static public clsCountries FindByCountryName(string CountryName)
        {
            byte CountryID = 0;
            string Nationality = string.Empty;
            string PhoneCode = string.Empty;
            byte CurrencyID = 0;


            if (clsCountriesData.GetCountryInfoByCountryName(ref CountryID,CountryName, ref Nationality, ref PhoneCode, ref CurrencyID))
            {
                return new clsCountries(CountryID, CountryName, Nationality, PhoneCode, CurrencyID);
            }
            else
            {
                return null;
            }

        }
        private bool _AddNewCountry()
        {
            _CountryID = clsCountriesData.AddNewCountry(this.CountryName, this.Nationality, this.PhoneCode, this.CurrencyID);

            return _CountryID != 0;
        }

        private bool _UpdateCountry()
        {
            return clsCountriesData.UpdateCountry(this.CountryID, this.CountryName, this.Nationality, this.PhoneCode, this.CurrencyID);
        }

        static public bool DeleteCountry(byte CountryID)
        {
            return clsCountriesData.DeleteCountry(CountryID);
        }

        static public bool IsCountryExist(byte CountryID)
        {
            return clsCountriesData.IsCountryExist(CountryID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewCountry())
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
                        return _UpdateCountry();

                    }
                default:
                    {
                        return false;
                    }
            }

        }


    }



}

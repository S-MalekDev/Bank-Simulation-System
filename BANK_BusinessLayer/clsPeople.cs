using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BANK_DataAccessLayer;

namespace BANK_BusinessLayer
{

    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MedName { get; set; }
        public string LastName { get; set; }
        public bool Gendor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalNumber { get; set; }
        public byte Nationality { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte CountryOfResidence { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(MedName))
                    return FirstName + " " + LastName;

                else //if MedName != ""; 
                    return FirstName + " " + MedName + " " + LastName;
            }
        }

        public clsCountries NationalityInfo;

        public clsCountries CountryResidenceInfo;

        public clsPeople()
        {
            PersonID = -1;
            FirstName = string.Empty;
            MedName = string.Empty;
            LastName = string.Empty;
            Gendor = false;
            DateOfBirth = DateTime.Now;
            NationalNumber = string.Empty;
            Nationality = 0;
            Email = string.Empty;
            Phone = string.Empty;
            CountryOfResidence = 0;
            Address = string.Empty;
            ImagePath = string.Empty;

            NationalityInfo = null;
            CountryResidenceInfo = null;
            _Mode = enMode.AddNew;
        }

        protected clsPeople(int PersonID, string FirstName, string MedName, string LastName, bool Gendor, DateTime DateOfBirth
            , string NationalNumber, byte Nationality, string Email, string Phone, byte CountryOfResidence, string Address
            , string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.MedName = MedName;
            this.LastName = LastName;
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.NationalNumber = NationalNumber;
            this.Nationality = Nationality;
            this.Email = Email;
            this.Phone = Phone;
            this.CountryOfResidence = CountryOfResidence;
            this.Address = Address;
            this.ImagePath = ImagePath;

            NationalityInfo = clsCountries.Find(Nationality);
            CountryResidenceInfo = clsCountries.Find(CountryOfResidence);
            _Mode = enMode.Update;
        }

        static public DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        static public clsPeople Find(int PersonID)
        {

            string FirstName = string.Empty;
            string MedName = string.Empty;
            string LastName = string.Empty;
            bool Gendor = false;
            DateTime DateOfBirth = DateTime.Now;
            string NationalNumber = string.Empty;
            byte Nationality = 0;
            string Email = string.Empty;
            string Phone = string.Empty;
            byte CountryOfResidence = 0;
            string Address = string.Empty;
            string ImagePath = string.Empty;


            if (clsPeopleData.GetPersonInfoByID(PersonID, ref FirstName, ref MedName, ref LastName, ref Gendor, ref DateOfBirth, ref NationalNumber, ref Nationality, ref Email, ref Phone, ref CountryOfResidence, ref Address, ref ImagePath))
            {
                return new clsPeople(PersonID, FirstName, MedName, LastName, Gendor, DateOfBirth, NationalNumber, Nationality, Email, Phone, CountryOfResidence, Address, ImagePath);
            }
            else
            {
                return null;
            }

        }

        static public clsPeople Find(string NationalNumber)
        {
            int PersonID = -1;
            string FirstName = string.Empty;
            string MedName = string.Empty;
            string LastName = string.Empty;
            bool Gendor = false;
            DateTime DateOfBirth = DateTime.Now;
            byte Nationality = 0;
            string Email = string.Empty;
            string Phone = string.Empty;
            byte CountryOfResidence = 0;
            string Address = string.Empty;
            string ImagePath = string.Empty;


            if (clsPeopleData.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref MedName, ref LastName, ref Gendor, ref DateOfBirth, NationalNumber, ref Nationality, ref Email, ref Phone, ref CountryOfResidence, ref Address, ref ImagePath))
            {
                return new clsPeople(PersonID, FirstName, MedName, LastName, Gendor, DateOfBirth, NationalNumber, Nationality, Email, Phone, CountryOfResidence, Address, ImagePath);
            }
            else
            {
                return null;
            }

        }

        static public DataTable GetPeopleListByPersonIDLikeTheNumber(string TextOfNum)
        {
            return clsPeopleData.GetPeopleListByPersonIDLikeTheNumber(TextOfNum);
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPeopleData.AddNewPerson(this.FirstName, this.MedName, this.LastName, this.Gendor, this.DateOfBirth, this.NationalNumber, this.Nationality, this.Email, this.Phone, this.CountryOfResidence, this.Address, this.ImagePath);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.FirstName, this.MedName, this.LastName, this.Gendor, this.DateOfBirth, this.NationalNumber, this.Nationality, this.Email, this.Phone, this.CountryOfResidence, this.Address, this.ImagePath);
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }

        public bool Delete()
        {
            return clsPeopleData.DeletePerson(this.PersonID);
        }

        static public bool IsPersonExistByPersonID(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }

        static public bool IsPersonExistByNationalNo(string NationalNumber)
        {
            return clsPeopleData.IsPersonExistByNationalNo(NationalNumber);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
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
                        return _UpdatePerson();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }

}


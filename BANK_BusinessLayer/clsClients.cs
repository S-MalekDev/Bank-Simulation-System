using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsClients:clsPeople
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _ClientID;

        public int ClientID { get { return _ClientID; } }

        public clsClients()
        {
            _ClientID = -1;
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

        private clsClients(int ClientID, int PersonID, string FirstName, string MedName, string LastName, bool Gendor, DateTime DateOfBirth
            , string NationalNumber, byte Nationality, string Email, string Phone, byte CountryOfResidence, string Address
            , string ImagePath)
            :base( PersonID,  FirstName,  MedName,  LastName,  Gendor,  DateOfBirth
            ,  NationalNumber,  Nationality,  Email,  Phone,  CountryOfResidence,  Address
            ,  ImagePath)
        {

            _ClientID = ClientID;
            _Mode = enMode.Update;
        }

        static public DataTable GetAllClients()
        {
            return clsClientsData.GetAllClients();
        }
        
        static public DataTable GetClientsListByColumnAndTextLike(string ColumnName, string TextLike)
        {
            return clsClientsData.GetClientsListByColumnAndTextLike(ColumnName, TextLike);
        }

        static public clsClients Find(int ClientID)
        {

            int PersonID = -1;
            string FirstName = string.Empty;
            string MedName= string.Empty;
            string LastName= string.Empty;
            bool Gendor = false;
            DateTime DateOfBirth = default;
            string NationalNumber= string.Empty;
            byte Nationality= 0;
            string Email= string.Empty;
            string Phone= string.Empty;
            byte CountryOfResidence = 0;
            string Address = string.Empty;
            string ImagePath= string.Empty;

            


            if (clsClientsData.GetClientInfoByID(ClientID, ref PersonID))
            {
                if(clsPeopleData.GetPersonInfoByID( PersonID, ref FirstName, ref MedName, ref LastName, ref Gendor, ref DateOfBirth
                   , ref NationalNumber, ref Nationality, ref Email, ref Phone, ref CountryOfResidence, ref Address
                   , ref ImagePath))
                {
                           return new clsClients(ClientID, PersonID, FirstName, MedName, LastName, Gendor, DateOfBirth
                  , NationalNumber, Nationality, Email, Phone, CountryOfResidence, Address
                  , ImagePath);
                }
            }

            return null;

        }

        private bool _AddNewClient()
        {
            _ClientID = clsClientsData.AddNewClient(this.PersonID);

            return _ClientID != -1;
        }

        private bool _UpdateClient()
        {
            return clsClientsData.UpdateClient(this.ClientID, this.PersonID);
        }

        static public bool DeleteClient(int ClientID)
        {
            return clsClientsData.DeleteClient(ClientID);
        }

        static public bool IsClientExist(int ClientID)
        {
            return clsClientsData.IsClientExist(ClientID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewClient())
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
                        return _UpdateClient();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }

}

using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsOpenNewAccountApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode;

        protected int _AppID;

        public int AppID { get { return _AppID; } }

        public int AccountNumber { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime OpeningDate { get; set; }
        public clsUsers UserInfo { get; set; }      


        public clsOpenNewAccountApplications()
        {
            _AppID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            OpeningDate = DateTime.Now;
            AccountNumber = default;


            UserInfo = null;

            _Mode = enMode.AddNew;
        }

        protected clsOpenNewAccountApplications(int AppID, int PersonID, int CreatedByUserID, DateTime OpeningDate, int AccountNumber)
        {
            _AppID = AppID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.OpeningDate = OpeningDate;
            this.AccountNumber = AccountNumber;

            UserInfo = clsUsers.FindByUserID(CreatedByUserID);
            _Mode = enMode.Update;
        }

        static public DataTable GetAllOpenNewAccountApplications()
        {
            return clsOpenNewAccountApplicationsData.GetAllOpenNewAccountApplications();
        }

        static public clsOpenNewAccountApplications Find(int AppID)
        {

            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime OpeningDate = DateTime.Now;
            int AccountNumber = default;


            if (clsOpenNewAccountApplicationsData.GetOpenNewAccountAppInfoByID(AppID, ref PersonID, ref CreatedByUserID, ref OpeningDate, ref AccountNumber))
            {
                return new clsOpenNewAccountApplications(AppID, PersonID, CreatedByUserID, OpeningDate, AccountNumber);
            }
            else
            {
                return null;
            }

        }

        protected bool SetAccountIDtoTheApp(int AccountNumber)
        {
            return clsOpenNewAccountApplicationsData.SetAccountIDtoTheApp(this.AppID, AccountNumber);
        }

        private bool _AddNewOpenNewAccountApp()
        {
            _AppID = clsOpenNewAccountApplicationsData.AddNewOpenNewAccountApp(this.PersonID, this.CreatedByUserID, this.OpeningDate, this.AccountNumber);

            return _AppID != -1;
        }

        private bool _UpdateOpenNewAccountApp()
        {
            return clsOpenNewAccountApplicationsData.UpdateOpenNewAccountApp(this.AppID, this.PersonID, this.CreatedByUserID, this.OpeningDate, this.AccountNumber);
        }

        static public bool DeleteOpenNewAccountApp(int AppID)
        {
            return clsOpenNewAccountApplicationsData.DeleteOpenNewAccountApp(AppID);
        }

        static public bool IsOpenNewAccountAppExist(int AppID)
        {
            return clsOpenNewAccountApplicationsData.IsOpenNewAccountAppExist(AppID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewOpenNewAccountApp())
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
                        return _UpdateOpenNewAccountApp();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }

}

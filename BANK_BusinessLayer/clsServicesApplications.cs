using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsServicesApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;

        public int ServiceAppID { get; set; }
        public int ClientID { get; set; }
        public int UserID { get; set; }
        public clsServices.enService Service { get; set; }
        public DateTime RequestDate { get; set; }

        public clsClients ClientInfo { get; set; }
        public clsUsers UserInfo { get; set; }
        public clsServices ServiceInfo { get; set; }


        public clsServicesApplications()
        {
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

        protected clsServicesApplications(int ServiceAppID, int ClientID, int UserID, clsServices.enService Service, DateTime RequestDate)
        {
            this.ServiceAppID = ServiceAppID;
            this.ClientID = ClientID;
            this.UserID = UserID;
            this.Service = Service;
            this.RequestDate = RequestDate;

            ClientInfo = clsClients.Find(ClientID);
            UserInfo = clsUsers.FindByUserID(UserID);
            ServiceInfo = clsServices.Find(Service);
            Mode = enMode.Update;
        }

        static public DataTable GetAllServicesApplications()
        {
            return clsServicesApplicationsData.GetAllServicesApplications();
        }

        static public clsServicesApplications Find(int ServiceAppID)
        {

            int ClientID = -1;
            int UserID = -1;
            byte ServiceID = 0;
            DateTime RequestDate = DateTime.Now;


            if (clsServicesApplicationsData.GetServicesAppInfoByID(ServiceAppID, ref ClientID, ref UserID, ref ServiceID, ref RequestDate))
            {
                return new clsServicesApplications(ServiceAppID, ClientID, UserID,(clsServices.enService) ServiceID, RequestDate);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewServicesApp()
        {
            this.ServiceAppID = clsServicesApplicationsData.AddNewServicesApp(this.ClientID, this.UserID,(byte) this.Service, this.RequestDate);

            return this.ServiceAppID != -1;
        }

        private bool _UpdateServicesApp()
        {
            return clsServicesApplicationsData.UpdateServicesApp(this.ServiceAppID, this.ClientID, this.UserID,(byte) this.Service, this.RequestDate);
        }

        static public bool DeleteServicesApp(int ServiceAppID)
        {
            return clsServicesApplicationsData.DeleteServicesApp(ServiceAppID);
        }

        static public bool IsServicesAppExist(int ServiceAppID)
        {
            return clsServicesApplicationsData.IsServicesAppExist(ServiceAppID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewServicesApp())
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
                        return _UpdateServicesApp();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }



}

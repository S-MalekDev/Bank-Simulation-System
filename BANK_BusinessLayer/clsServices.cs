using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsServices
    {
        public enum enService { Transactions  = 1, BalanceStatement =2 }
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private enService _Service;
        public enService Service { get { return _Service; } }
        public string ServiceDescription { get; set; }
        public string ServiceTitle { get; set; }
        public decimal Fees { get; set; }


        public clsServices()
        {
            _Service = enService.Transactions;
            ServiceTitle = string.Empty;
            ServiceDescription = string.Empty;
            Fees = -1;

            _Mode = enMode.AddNew;
        }

        private clsServices(enService Service, string ServiceTitle,string ServiceDescription, decimal Fees)
        {
            _Service = Service;
            this.ServiceTitle = ServiceTitle;
            this.Fees = Fees;
            this.ServiceDescription = ServiceDescription;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllServices()
        {
            return clsServicesData.GetAllServices();
        }

        static public clsServices Find(enService Service)
        {

            string ServiceTitle = string.Empty;
            string ServiceDescription = string.Empty;
            decimal Fees = -1;


            if (clsServicesData.GetServiceInfoByID((byte)Service, ref ServiceTitle,ref ServiceDescription, ref Fees))
            {
                return new clsServices(Service, ServiceTitle, ServiceDescription, Fees);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewService()
        {
            int Result = clsServicesData.AddNewService(this.ServiceTitle,this.ServiceDescription, this.Fees);

            if (Result != -1)
                _Service = (enService)Result;

            return Result != -1;
        }

        private bool _UpdateService()
        {
            return clsServicesData.UpdateService((byte)this._Service, this.ServiceTitle,this.ServiceDescription, this.Fees);
        }

        static public bool DeleteService(enService Service)
        {
            return clsServicesData.DeleteService((byte)Service);
        }

        static public bool IsServiceExist(enService Service)
        {
            return clsServicesData.IsServiceExist((byte)Service);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewService())
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
                        return _UpdateService();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }

}

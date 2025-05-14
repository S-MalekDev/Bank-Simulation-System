using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsTransferTypes
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public enum enTransferType { InternalTransfer =1, ExternalTransfer =2 }


        public enTransferType TransferType { get; set; }
        public string TransferName { get; set; }
        public decimal TransferFees { get; set; }
        public string TransferDescription { get; set; }


        public clsTransferTypes()
        {
            TransferType = default;
            TransferName = string.Empty;
            TransferFees = -1;
            TransferDescription = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsTransferTypes(enTransferType TransferType, string TransferName, decimal TransferFees, string TransferDescription)
        {
            this.TransferType = TransferType;
            this.TransferName = TransferName;
            this.TransferFees = TransferFees;
            this.TransferDescription = TransferDescription;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllTransferTypes()
        {
            return clsTransferTypesData.GetAllTransferTypes();
        }

        static public clsTransferTypes Find(enTransferType TransferType)
        {

            string TransferName = string.Empty;
            decimal TransferFees = -1;
            string TransferDescription = string.Empty;


            if (clsTransferTypesData.GetTransferTypeInfoByID((byte)TransferType, ref TransferName, ref TransferFees, ref TransferDescription))
            {
                return new clsTransferTypes((enTransferType)TransferType, TransferName, TransferFees, TransferDescription);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewTransferType()
        {
            int Result = clsTransferTypesData.AddNewTransferType(this.TransferName, this.TransferFees, this.TransferDescription);

            if (Result != -1)
                this.TransferType = (enTransferType)Result;

            return Result != -1;
        }

        private bool _UpdateTransferType()
        {
            return clsTransferTypesData.UpdateTransferType((byte)this.TransferType, this.TransferName, this.TransferFees, this.TransferDescription);
        }

        static public bool DeleteTransferType(enTransferType TransferType)
        {
            return clsTransferTypesData.DeleteTransferType((byte)TransferType);
        }

        static public bool IsTransferTypeExist(enTransferType TransferType)
        {
            return clsTransferTypesData.IsTransferTypeExist((byte)TransferType);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTransferType())
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
                        return _UpdateTransferType();

                    }
                default:
                    {
                        return false;
                    }
            }

        }

    }

}

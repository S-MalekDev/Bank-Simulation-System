using BANK_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_BusinessLayer
{
    public class clsTransactionTypes
    {
        public enum enTransactionTypes { Withdraw  = 1, Deposit  = 2, Transfer  = 3 }
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;


        public enTransactionTypes TransactionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }


        public clsTransactionTypes()
        {
            TransactionType = default;
            Name = string.Empty;
            Description = string.Empty;
            Fees = -1;

            _Mode = enMode.AddNew;
        }

        private clsTransactionTypes(enTransactionTypes TransactionType, string Name, string Description, decimal Fees)
        {
            this.TransactionType = TransactionType;
            this.Name = Name;
            this.Description = Description;
            this.Fees = Fees;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllTransactionTypes()
        {
            return clsTransactionTypesData.GetAllTransactionTypes();
        }

        static public clsTransactionTypes Find(enTransactionTypes TransactionType)
        {

            string Name = string.Empty;
            string Description = string.Empty;
            decimal Fees = -1;


            if (clsTransactionTypesData.GetTransactionTypeInfoByID((byte)TransactionType, ref Name, ref Description, ref Fees))
            {
                return new clsTransactionTypes(TransactionType, Name, Description, Fees);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewTransactionType()
        {
            int Result = clsTransactionTypesData.AddNewTransactionType(this.Name, this.Description, this.Fees);

            if(Result != -1)
                this.TransactionType = (enTransactionTypes)Result;

            return Result != -1;
        }

        private bool _UpdateTransactionType()
        {
            return clsTransactionTypesData.UpdateTransactionType((byte)this.TransactionType, this.Name, this.Description, this.Fees);
        }

        static public bool DeleteTransactionType(enTransactionTypes TransactionType)
        {
            return clsTransactionTypesData.DeleteTransactionType((byte)TransactionType);
        }

        static public bool IsTransactionTypeExist(enTransactionTypes TransactionType)
        {
            return clsTransactionTypesData.IsTransactionTypeExist((byte)TransactionType);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTransactionType())
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
                        return _UpdateTransactionType();

                    }
                default:
                    {
                        return false;
                    }
            }

        }


    }



}

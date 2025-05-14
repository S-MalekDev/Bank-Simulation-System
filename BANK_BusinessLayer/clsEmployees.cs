using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANK_DataAccessLayer;
using static BANK_BusinessLayer.clsEmployees;

namespace BANK_BusinessLayer
{
    public class clsEmployees 
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode;

        protected int _EmployeeID;

        public int EmployeeID { get { return _EmployeeID; } }
        public int PersonID { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int JobPosition { get; set; }
        public decimal Salary { get; set; }
        public clsPeople PersonInfo {  get; set; } 
        public clsBankingJobs JobInfo { get; set; }
        public clsEmployees()
        {
            _EmployeeID = -1;
            PersonID = -1;
            EmploymentDate = DateTime.Now;
            JobPosition = -1;
            Salary = -1;

            PersonInfo = null;
            JobInfo = null;

            _Mode = enMode.AddNew;
        }

        protected clsEmployees(int EmployeeID, int PersonID, DateTime EmploymentDate, int JobPosition, decimal Salary)
            
        {
            _EmployeeID = EmployeeID;
            this.PersonID = PersonID;
            this.EmploymentDate = EmploymentDate;
            this.JobPosition = JobPosition;
            this.Salary = Salary;

            PersonInfo = clsPeople.Find(PersonID);
            JobInfo = clsBankingJobs.Find(JobPosition);
            _Mode = enMode.Update;
        }


        static public DataTable GetAllEmployees()
        {
            return clsEmployeesData.GetAllEmployees();
        }

        static public clsEmployees Find(int EmployeeID)
        {
            int PersonID = -1;
            DateTime EmploymentDate = DateTime.Now;
            int JobPosition = -1;
            decimal Salary = -1;



            if (clsEmployeesData.GetEmployeeInfoByID(EmployeeID, ref PersonID, ref EmploymentDate, ref JobPosition, ref Salary))
            {
                
                return new clsEmployees(EmployeeID, PersonID, EmploymentDate, JobPosition, Salary);
                
            }

            return null;

        }

        private bool _AddNewEmployee()
        {
            _EmployeeID = clsEmployeesData.AddNewEmployee(this.PersonID, this.EmploymentDate, this.JobPosition, this.Salary);

            return _EmployeeID != -1;
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeesData.UpdateEmployee(this.EmployeeID, this.PersonID, this.EmploymentDate, this.JobPosition, this.Salary);
        }

        static public bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeesData.DeleteEmployee(EmployeeID);
        }

        static public bool IsEmployeeExist(int EmployeeID)
        {
            return clsEmployeesData.IsEmployeeExist(EmployeeID);
        }

        public bool Save()
        {
           
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewEmployee())
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
                        return _UpdateEmployee();

                    }
                default:
                    {
                        return false;
                    }
            }

        }


    }

}

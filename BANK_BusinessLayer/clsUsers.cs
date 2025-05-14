using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BANK_DataAccessLayer;

namespace BANK_BusinessLayer
{
    public class clsUsers : clsEmployees
    {
        public enum enUserAccountStatu{Deactive = 0, Active = 1};
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _UserID;

        public int UserID { get { return _UserID; } }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }


        public clsUsers()
        {
            PersonID = -1;
            _EmployeeID = -1;
            PersonID = -1;
            EmploymentDate = DateTime.Now;
            JobPosition = -1;
            Salary = -1;

            JobInfo = null;

            _UserID = -1;
            Username = string.Empty;
            Password = string.Empty;
            Permissions = -1;
            IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, string Username, string Password, int Permissions, bool IsActive, int EmployeeID
            , int PersonID, DateTime EmploymentDate, int JobPosition, decimal Salary)
           : base( EmployeeID, PersonID,  EmploymentDate,  JobPosition,  Salary)
        {
            _UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }

        static public DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }


        static public DataTable GetUsersListByUserIDLikeTheNumber(string TextOfNum)
        {
            return clsUsersData.GetUsersListByUserIDLikeTheNumber(TextOfNum);
        }

        static public DataTable GetUsersListByEmployeeIDLikeTheNumber(string TextOfNum)
        {
            return clsUsersData.GetUsersListByEmployeeIDLikeTheNumber(TextOfNum);
        }

        static public clsUsers FindByUserID(int UserID)
        {

            int EmployeeID = -1;
            DateTime EmploymentDate = default;
            int JobPosition = -1;
            decimal Salary = -1;
            int PersonID = -1;

            
            string Username = string.Empty;
            string Password = string.Empty;
            int Permissions = -1;
            bool IsActive = false;


            if (clsUsersData.GetUserInfoByID(UserID, ref EmployeeID, ref Username, ref Password, ref Permissions, ref IsActive))
            {
                if(clsEmployeesData.GetEmployeeInfoByID(EmployeeID,ref PersonID,ref EmploymentDate, ref JobPosition, ref Salary))
                {
                    return new clsUsers(UserID, Username, Password, Permissions, IsActive, EmployeeID
             , PersonID, EmploymentDate, JobPosition, Salary);
                }
                
            }

            return null;
            
        }

        static public clsUsers FindByPersonID(int PersonID)
        {
            int EmployeeID = -1;
            DateTime EmploymentDate = default;
            int JobPosition = -1;
            decimal Salary = -1;           

            int UserID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            int Permissions = -1;
            bool IsActive = false;


             if (clsEmployeesData.GetEmployeeInfoByPersonID(ref EmployeeID, PersonID, ref EmploymentDate, ref JobPosition, ref Salary))
             {
                 if (clsUsersData.GetUserInfoByEmployeeID(ref UserID, EmployeeID, ref Username, ref Password, ref Permissions, ref IsActive))
                 {

                    return new clsUsers(UserID, Username, Password, Permissions, IsActive, EmployeeID
            , PersonID, EmploymentDate, JobPosition, Salary);
                }
                 

             }
            
            
                return null;
            
        }

        static public clsUsers FindUserByUsernameAndPassword(string Username,string Password)
        {
            int PersonID = -1;
            int EmployeeID = -1;
            DateTime EmploymentDate = default;
            int JobPosition = -1;
            decimal Salary = -1;

            int UserID = -1;
            int Permissions = -1;
            bool IsActive = false;

            if (clsUsersData.GetUserInfoByUsernameAndPassword(ref UserID, ref EmployeeID, Username, Password, ref Permissions, ref IsActive))
            {
                if (clsEmployeesData.GetEmployeeInfoByID( EmployeeID, ref PersonID, ref EmploymentDate, ref JobPosition, ref Salary))
                {
                    return new clsUsers(UserID, Username, Password, Permissions, IsActive, EmployeeID
            , PersonID, EmploymentDate, JobPosition, Salary);
                }
               
            }

            return null;
            
        }

        private bool _AddNewUser()
        {
            _UserID = clsUsersData.AddNewUser(this.EmployeeID, this.Username, this.Password, this.Permissions, this.IsActive);

            return _UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUsersData.UpdateUser(this.UserID, this.EmployeeID, this.Username, this.Password, this.Permissions, this.IsActive);
        }

        static public bool DeleteUser(int UserID)
        {
            clsUsers User = clsUsers.FindByUserID(UserID);

            if(User == null)
                return false;

            int EmployeeID = User.EmployeeID;

            if (!clsUsersData.DeleteUser(UserID))
                return false;

            return clsEmployees.DeleteEmployee(EmployeeID);
        }

        static public bool IsUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }

        static public bool IsTheUserHasEmail(int UserID)
        {
            return clsUsersData.IsTheUserHasEmail(UserID);
        }

        static public bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        static public bool IsUserActive(int UserID)
        {
            return clsUsersData.IsUserActive(UserID);
        }

        static public bool SetUserAccountStatus(int UserID,enUserAccountStatu Status)
        {
            return clsUsersData.SetUserAccountStatus(UserID, Convert.ToBoolean(Status));
        }

        static public bool IsUsernameExist(string UserName)
        {
            return clsUsersData.IsUsernameExist(UserName);
        }

        public bool UpdatePassword(string NewPassword)
        {
            return clsUsersData.UpdatePassword(this.UserID,NewPassword);
        }

        public bool Save()
        {
            base._Mode = (clsEmployees.enMode)this._Mode;
            if(!base.Save())
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
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
                        return _UpdateUser();

                    }
                default:
                    {
                        return false;
                    }
            }

        }


    }



}

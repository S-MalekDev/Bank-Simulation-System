using BANK_BusinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    internal class clsGlobal
    {
        public enum enUserPermissions
        {
            ClientsListView= 1, AccountsListView=2,AddNewAccountOrClient=4,WithdrawProcess=8,DepositProcess=16
                ,TransferInternally=32, TransferExternally=64,ShowClientInfo=128,ShowAccountDetails=256
                ,UsersListView=512,AddNewUser=1024,UpdateUser=2048,DeleteUser=4096,ChangePasswordUser=8192
                ,ShowUserInfo=16384,PeopleListView=32768,AddNewPerson=65536,UpdatePerson=131072,DeletePerson=262144
                ,ShowPersonInfo=524288,UpdateClientInfo = 1048576,ActiveDeactiveUser = 2097152, ShowClientHistory = 4194304
                ,ManageServices =8388608,ManageTransactionTypes=16777216, ManageTransferTypes =33554432
        }

        static public clsUsers CurrentUser;

        static private bool DoesRegistryExist(string ProjectRegistrySubKeyPath, string ProjectName)
        {
            string RegistryPath = Path.Combine(ProjectRegistrySubKeyPath.Replace(@"HKEY_CURRENT_USER\", ""), ProjectName);

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
            {
                if (key != null) return true;
                else return false;
            }

        }
        static private bool DeleteLoginInfoIfExist(string RegistryPath, string RegistryName)
        {          
            try
            {
                using (RegistryKey Key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    using (RegistryKey SubKey = Key.OpenSubKey(RegistryPath.Replace(@"HKEY_CURRENT_USER\", ""), true))
                    {
                        if (SubKey != null)
                        {
                            SubKey.DeleteValue(RegistryName);
                            return true;
                        }

                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        static public bool RememberUsernameAndPassword(string Username, string Password,bool RememberIt)
        {
            string RegistryName = "Login Info";
            string ProjectName = ConfigurationManager.AppSettings["Project Name"];
            string ProjectRegistrySubKeyPath = ConfigurationManager.AppSettings["Project Registry Sub Key Path"];
            string RegistryPath = Path.Combine(ProjectRegistrySubKeyPath, ProjectName);

            if (!RememberIt)
            {
                return DeleteLoginInfoIfExist(RegistryPath, RegistryName);
            }

            string RegistryValue = Username + "#//#" + Password;

            try
            {
                Registry.SetValue(RegistryPath, RegistryName, RegistryValue,RegistryValueKind.String);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        static public bool RetrieveLoginInfo(ref string Username,ref string Password)
        {
            string RegistryName = "Login Info";
            string ProjectName = ConfigurationManager.AppSettings["Project Name"];
            string ProjectRegistrySubKeyPath = ConfigurationManager.AppSettings["Project Registry Sub Key Path"];
            string RegistryPath = Path.Combine(ProjectRegistrySubKeyPath, ProjectName);

            if (!DoesRegistryExist(ProjectRegistrySubKeyPath, ProjectName))
                return false;

            try
            {
                string Result = Registry.GetValue(RegistryPath, RegistryName,null).ToString();
                if (Result != null)
                {
                    string[] LoginInfoParts = Result.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    Username = LoginInfoParts[0];
                    Password = LoginInfoParts[1];
                    return true;
                }
            }
            catch(Exception)
            {
                return false;
            }
            return false;
        }
    }
}

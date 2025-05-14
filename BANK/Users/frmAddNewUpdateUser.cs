using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BANK.clsGlobal;

namespace BANK
{
    public partial class frmAddNewUpdateUser : Form
    {
        private int JobID = 337; //The JobID of the job title System User in Data base;

        private int _UserID = -1;
        private int _PersonID = -1;
        private clsUsers _User;
        private int _UserPermissions = -1;
        private enum enMode { AddNew = 0,Update = 1 }
        private enMode _Mode;

        private enMode Mode
        {
            set
            {
                _Mode = value;
                switch(_Mode)
                {
                    case enMode.AddNew:
                        {
                            this.Text = "Add New User";
                            lblFormTitle.Text = "Add New User";
                            btnNext.Enabled = false;
                            lblPassword.Visible = true;
                            lblConfirmPassword.Visible = true;
                            pbPassword.Visible = true;
                            pbConfirmPassword.Visible = true;
                            mtbPassword.Visible= true;
                            mtbConfirmPassword.Visible = true;
                            ctrlShowPersonInfoByFilter1.FilterEnabeled = true;
                            btnSave.Enabled = false;
                            lblEmploymentDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                            break;
                        }
                        case enMode.Update:
                        {
                            this.Text = "Update The User";
                            lblFormTitle.Text = "Edit User's Data";
                            btnNext.Enabled = true;
                            lblPassword.Visible = false;
                            lblConfirmPassword.Visible = false;
                            pbPassword.Visible = false;
                            pbConfirmPassword.Visible = false;
                            mtbPassword.Visible = false;
                            mtbConfirmPassword.Visible = false;
                            ctrlShowPersonInfoByFilter1.FilterEnabeled = false;
                            btnSave.Enabled = true;
                            break;
                        }
                }
            }
            get { return _Mode; }
        }

        public frmAddNewUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddNewUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = enMode.Update;
        }


        private void _LoadTheUserEmployeeDataFromTheFormToAnObject()
        {
            if(Mode == enMode.Update)
            {
                _User.Salary = decimal.Parse(tbSalary.Text);
                _User.Username = tbUsername.Text.Trim();
                _User.Permissions = _UserPermissions;
                _User.IsActive = chbIsActive.Checked;
                return;
            }
                
            _User.PersonID = _PersonID;
            _User.EmploymentDate = DateTime.Now;
            _User.JobPosition = JobID;        
            _User.Password = clsUtil.ComputeHash(mtbPassword.Text.Trim());
            _User.Salary = decimal.Parse(tbSalary.Text);
            _User.Username = tbUsername.Text.Trim();
            _User.Permissions = _UserPermissions;
            _User.IsActive = chbIsActive.Checked;
        }

        private void LoadUserPermissionsToTheForm()
        {
            if(_User.Permissions == -1)
            {
                chbFullAccess.Checked = true;
                return;
            }
            chbFullAccess.Checked = false;
            

            chbClientsListView.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ClientsListView) == (int)clsGlobal.enUserPermissions.ClientsListView);
            chbAccountsListView.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.AccountsListView) == (int)clsGlobal.enUserPermissions.AccountsListView);
            chbAddNewAccountOrClient.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.AddNewAccountOrClient) == (int)clsGlobal.enUserPermissions.AddNewAccountOrClient);
            chbUpdateClient.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.UpdateClientInfo) == (int)clsGlobal.enUserPermissions.UpdateClientInfo);
            chbWithdrawProcess.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.WithdrawProcess) == (int)clsGlobal.enUserPermissions.WithdrawProcess);
            chbDepositProcess.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.DepositProcess) == (int)clsGlobal.enUserPermissions.DepositProcess);
            chbTransferExternally.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.TransferExternally) == (int)clsGlobal.enUserPermissions.TransferExternally);
            chbTransferInternally.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.TransferInternally) == (int)clsGlobal.enUserPermissions.TransferInternally);
            chbShowAccountDetails.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ShowAccountDetails) == (int)clsGlobal.enUserPermissions.ShowAccountDetails);
            chbShowClientInfo.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ShowClientInfo) == (int)clsGlobal.enUserPermissions.ShowClientInfo);
            chbUsersListView.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.UsersListView) == (int)clsGlobal.enUserPermissions.UsersListView);
            chbAddNewUser.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.AddNewUser) == (int)clsGlobal.enUserPermissions.AddNewUser);
            chbUpdateUser.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.UpdateUser) == (int)clsGlobal.enUserPermissions.UpdateUser);
            chbDeleteUser.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.DeleteUser) == (int)clsGlobal.enUserPermissions.DeleteUser);
            chbChangePasswordUser.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ChangePasswordUser) == (int)clsGlobal.enUserPermissions.ChangePasswordUser);
            chbShowUserInfo.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ShowUserInfo) == (int)clsGlobal.enUserPermissions.ShowUserInfo);
            chbPeopleListView.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.PeopleListView) == (int)clsGlobal.enUserPermissions.PeopleListView);
            chbAddNewPerson.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.AddNewPerson) == (int)clsGlobal.enUserPermissions.AddNewPerson);
            chbUpdatePerson.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.UpdatePerson) == (int)clsGlobal.enUserPermissions.UpdatePerson);
            chbDeletePerson.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.DeletePerson) == (int)clsGlobal.enUserPermissions.DeletePerson);
            chbShowPersonInfo.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ShowPersonInfo) == (int)clsGlobal.enUserPermissions.ShowPersonInfo);
            chbActiveDeactiveUser.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ActiveDeactiveUser) == (int)clsGlobal.enUserPermissions.ActiveDeactiveUser);
            chbShowClientHistory.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ShowClientHistory) == (int)clsGlobal.enUserPermissions.ShowClientHistory);
            chbManageServices.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ManageServices) == (int)clsGlobal.enUserPermissions.ManageServices);
            chbManageTransactionTypes.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ManageTransactionTypes) == (int)clsGlobal.enUserPermissions.ManageTransactionTypes);
            chbManageTransferTypes.Checked = ((_User.Permissions & (int)clsGlobal.enUserPermissions.ManageTransferTypes) == (int)clsGlobal.enUserPermissions.ManageTransferTypes);
        }

        private void _LoadTheUserDataOnTheForm()
        {
            _User = clsUsers.FindByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"There is an error, the user with id = {_UserID} is not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.Close();
                return;
            }

            ctrlShowPersonInfoByFilter1.ShowPersonInfo(_User.PersonID);
            lblUserID.Text = _UserID.ToString();
            lblEmployeeID.Text = _User.EmployeeID.ToString();
            lblEmploymentDate.Text = _User.EmploymentDate.ToString("dd-MMM-yyyy");
            tbSalary.Text = _User.Salary.ToString();
            tbUsername.Text = _User.Username.ToString();
            LoadUserPermissionsToTheForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(_UserPermissions == 0)
            {
                MessageBox.Show("You can't continue save the data if the user doesn't have any permissions!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

            if (Mode == enMode.AddNew)
                _User = new clsUsers();

            _LoadTheUserEmployeeDataFromTheFormToAnObject();

            if (_User.Save())
            {
                MessageBox.Show("The user's data saved saccessfully.", "Saved success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = $"[ {(_UserID = _User.UserID ).ToString("D2")} ]";
                lblEmployeeID.Text = $"[ {_User.EmployeeID.ToString("D2")} ]";

                Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("An error occurred while registering the user's information!!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddNewUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlShowPersonInfoByFilter1.FilterTexbBoxFocus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUser.SelectedTab = tcUser.TabPages["tpUserInfo"];
            tbUsername.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcUser.SelectedTab = tcUser.TabPages["tpEmployeeInfo"];

            if (_UserID == -1)
                ctrlShowPersonInfoByFilter1.FilterTexbBoxFocus();
        }

        private void ctrlShowPersonInfoByFilter1_OnPersonSelected_1(int obj)
        {
            _PersonID = obj;
            btnNext.Enabled = true;
            btnSave.Enabled = true ;

            if( clsUsers.IsUserExistByPersonID(_PersonID))
            {
                btnSave.Enabled = false;
                btnNext.Enabled = false;

                clsUsers UserInfo = clsUsers.FindByPersonID(_PersonID);


                MessageBox.Show($"The person selected is already an user in the system and his id = {UserInfo.UserID}","Not allowed"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Warning);

                lblEmployeeID.Text = $"[ {UserInfo.EmployeeID.ToString("D2")} ]";
                lblEmploymentDate.Text = UserInfo.EmploymentDate.ToString("dd-MMM-yyyy");
                tbSalary.Text = UserInfo.Salary.ToString();
            }
            else
            {
                lblEmployeeID.Text = "[ ?? ]";
                lblEmploymentDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                tbSalary.Clear();
            }

        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if(e.Cancel=(clsUsers.IsUsernameExist(tbUsername.Text) && Mode == enMode.AddNew))
            {
                errorProvider1.SetError(tbUsername, "The username you entered is already exist");
            }
            else if(e.Cancel = string.IsNullOrEmpty(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "The field of username is required!");
            }
            else if (e.Cancel = (clsUsers.IsUsernameExist(tbUsername.Text) 
                && Mode == enMode.Update 
                && tbUsername.Text != _User.Username))
            {
                errorProvider1.SetError(tbUsername, "The username you entered is already used by anoter user!");
            }
            else
                errorProvider1.SetError(tbUsername, null);
        }

        private void tbSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(tbSalary, "You cann't enter letters, only digit are allowed.");
            }
            else
            {
                errorProvider1.SetError(tbSalary, null);
            }
        }

        private void tbSalary_Validating(object sender, CancelEventArgs e)
        {

            if (e.Cancel = (string.IsNullOrEmpty(tbSalary.Text)))
                errorProvider1.SetError(tbSalary, "The field of salary is required!");

            else if (e.Cancel = (float.Parse(tbSalary.Text) <= 0))
                errorProvider1.SetError(tbSalary, "You cannot enter a value less than or equal to zero.");

            else errorProvider1.SetError(tbSalary, null);
        }

        private void mtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (Mode == enMode.Update)
                return;
            
            if (e.Cancel = (string.IsNullOrEmpty(mtbPassword.Text)))
                errorProvider1.SetError(mtbPassword, "The field of password is required!");
            else
                errorProvider1.SetError(mtbPassword, null);
        }

        private void mtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (Mode == enMode.Update)
                return;

            if (e.Cancel = (string.IsNullOrEmpty(mtbConfirmPassword.Text)))
                errorProvider1.SetError(mtbConfirmPassword, "You should to confirm the password.");
            else if(e.Cancel = (mtbConfirmPassword.Text.ToLower().Trim() != mtbPassword.Text.ToLower().Trim()))
                errorProvider1.SetError(mtbConfirmPassword, "Password does not match!.");
            else
                errorProvider1.SetError(mtbConfirmPassword, null);
        }

        private void mtbPassword_TextChanged(object sender, EventArgs e)
        {
            mtbConfirmPassword.Enabled = (!string.IsNullOrEmpty(mtbPassword.Text));
        }

        private void frmAddNewUpdateUser_Load(object sender, EventArgs e)
        {
           lblJobTitle.Text =  clsBankingJobs.Find(JobID).JobTitle;

            if (Mode == enMode.Update)
                _LoadTheUserDataOnTheForm();
        }

        private void _RestartTheCheckBoxesPersmissionsToDefault()
        {
            chbClientsListView.Checked = false;
            chbAccountsListView.Checked = false;
            chbAddNewAccountOrClient.Checked = false;
            chbUpdateClient.Checked = false;
            chbWithdrawProcess.Checked = false;
            chbDepositProcess.Checked = false;
            chbTransferExternally.Checked = false;
            chbTransferInternally.Checked = false;
            chbShowAccountDetails.Checked = false;
            chbShowClientInfo.Checked = false;
            chbUsersListView.Checked = false;
            chbAddNewUser.Checked = false;
            chbUpdateUser.Checked = false;
            chbDeleteUser.Checked = false;
            chbChangePasswordUser.Checked = false;
            chbShowUserInfo.Checked = false;
            chbPeopleListView.Checked = false;
            chbAddNewPerson.Checked = false;
            chbUpdatePerson.Checked = false;
            chbDeletePerson.Checked = false;
            chbShowPersonInfo.Checked = false;
        }

        private void chbFullAccess_CheckedChanged(object sender, EventArgs e)
        {
            gbPermissions.Visible = !chbFullAccess.Checked;

            if(chbFullAccess.Checked == false)
            {
                _RestartTheCheckBoxesPersmissionsToDefault();
            }

            _UserPermissions = chbFullAccess.Checked? -1:0;
        }

        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            
            if(chb.Checked)
                _UserPermissions += int.Parse(chb.Tag.ToString());
            
            else
                _UserPermissions -= int.Parse(chb.Tag.ToString());
        }

        private void chbAddNewUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAddNewUser.Checked)
            {
                _UserPermissions += int.Parse(chbAddNewUser.Tag.ToString());
                chbAddNewPerson.Checked = true;
                chbAddNewPerson.Enabled = false;

            }
            else
            {
                _UserPermissions -= int.Parse(chbAddNewUser.Tag.ToString());
                chbAddNewPerson.Enabled = (!chbAddNewUser.Checked && !chbAddNewAccountOrClient.Checked);
            }

            
        }

        private void chbAddNewAccountOrClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAddNewAccountOrClient.Checked)
            {
                _UserPermissions += int.Parse(chbAddNewAccountOrClient.Tag.ToString());
                chbAddNewPerson.Checked = true;
                chbAddNewPerson.Enabled = false;
            }
            else
            {
                _UserPermissions -= int.Parse(chbAddNewAccountOrClient.Tag.ToString());
                chbAddNewPerson.Enabled = (!chbAddNewUser.Checked && !chbAddNewAccountOrClient.Checked);
            }
        }

        private void chbUpdateClient_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}

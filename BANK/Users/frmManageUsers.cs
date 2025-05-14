using BANK.Properties;
using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class frmManageUsers : Form
    {


        public frmManageUsers()
        {
            InitializeComponent();
        }
        private DataTable dtUsersList;
        private enum enFilter { None = 0, UserID = 1, EmployeeID = 2, FullName = 3, Username = 4, IsActive = 5 }
        private enFilter _SelectedFilter;

        private enum enIsActiveFilter { All = 0,Yes = 1,No = 2 }
        private enIsActiveFilter _SelectedIsActiveFilter;
        private void _GetUsersList()
        {
            dtUsersList = clsUsers.GetAllUsers();
            dgvUsersList.DataSource = dtUsersList;
        }
        private void _ShowCountUsers()
        {
            lblNumberRecords.Text = dgvUsersList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvUsersList()
        {
            if (dgvUsersList.ColumnCount > 0)
            {
                dgvUsersList.Columns["User ID"].Width = 100;
                dgvUsersList.Columns["Employee ID"].Width = 140;
                dgvUsersList.Columns["Full Name"].Width = 300;
                dgvUsersList.Columns["Gendor"].Width = 120;
                dgvUsersList.Columns["Employment Date"].Width = 200;
                dgvUsersList.Columns["Username"].Width = 120;
                dgvUsersList.Columns["Email"].Width = 270;
                dgvUsersList.Columns["Phone"].Width = 160;
                dgvUsersList.Columns["Salary"].Width = 150;
                dgvUsersList.Columns["Status"].Width = 140;
            }
        }
        private void _LoadUsersList()
        {
            _GetUsersList();
            _GetColumnsWidthModifications_dgvUsersList();
            _ShowCountUsers();
        }
        private void _RefreshUsersList()
        {
            _LoadUsersList();
        }
        private void _SelectTheDefaultFilters()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.None);
            cbIsActiveFilter.SelectedIndex = (byte)(_SelectedIsActiveFilter = enIsActiveFilter.All);
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadUsersList();
            _SelectTheDefaultFilters();
        }

        


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshUsersList();
            _SelectedFilter = (enFilter)(cbFilter.SelectedIndex);

            if (cbIsActiveFilter.Visible = (_SelectedFilter == enFilter.IsActive))
            {
                tbFilterText.Visible = false;
                return;
            }

            if (tbFilterText.Visible = (_SelectedFilter != enFilter.None) && (_SelectedFilter != enFilter.IsActive))
            {
                tbFilterText.Clear();
                tbFilterText.Focus();
                errorProvider1.Clear();
            }
            
        }


        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterText.Text))
            {
                _RefreshUsersList();
                return;
            }


            if (_SelectedFilter == enFilter.UserID)
            {
                dgvUsersList.DataSource = clsUsers.GetUsersListByUserIDLikeTheNumber(tbFilterText.Text);
                _GetColumnsWidthModifications_dgvUsersList();
            }
            else if(_SelectedFilter == enFilter.EmployeeID)
            {
                dgvUsersList.DataSource = clsUsers.GetUsersListByEmployeeIDLikeTheNumber(tbFilterText.Text);
                _GetColumnsWidthModifications_dgvUsersList();
            }
            else //if(_SelectedFilter == enFilter.FullName//enFilter.Username)
            {
                dgvUsersList.DataSource = dtUsersList;
                dtUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFilter.SelectedItem, tbFilterText.Text);
            }

            _ShowCountUsers();
        }


        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_SelectedFilter != enFilter.UserID && _SelectedFilter != enFilter.EmployeeID)
                return;

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(tbFilterText, "You cann't enter letters, only digit are allowed.");
            }
            else
            {
                errorProvider1.SetError(tbFilterText, null);
            }
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.DeleteUser) != (int)clsGlobal.enUserPermissions.DeleteUser)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int UserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

            if (!clsUsers.IsUserExist(UserID))
            {
                MessageBox.Show($"The user with id = {UserID} is not found", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _RefreshUsersList();
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the user with id = {UserID} ?", "Confermed delete"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show($"The user with id = {UserID} is deleted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show($"Error: The user is not deleted!"
                        , "Deletion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _RefreshUsersList();
            }
        }

        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Send email is not allowed!", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CallPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Phone call is not allowed!", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedIsActiveFilter = (enIsActiveFilter)cbIsActiveFilter.SelectedIndex;
            switch(_SelectedIsActiveFilter)
            {
                case enIsActiveFilter.All:
                    {
                        _RefreshUsersList();
                        break;
                    }
                case enIsActiveFilter.Yes:
                    {
                        dtUsersList.DefaultView.RowFilter = "Status = 'Active'";
                        break;
                    }
                case enIsActiveFilter.No:
                    {
                        dtUsersList.DefaultView.RowFilter = "Status = 'Deactive'";
                        break;
                    }
            }
            _ShowCountUsers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewUser) != (int)clsGlobal.enUserPermissions.AddNewUser)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdateUser frm = new frmAddNewUpdateUser();    
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.UpdateUser) != (int)clsGlobal.enUserPermissions.UpdateUser)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdateUser frm = new frmAddNewUpdateUser((int)dgvUsersList.CurrentRow.Cells["User ID"].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void cmsUsersList_Opening(object sender, CancelEventArgs e)
        {
            //Handling Enabled And Desibled Send Email Context Menu Strip Tool
            sendEmailToolStripMenuItem.Enabled = clsUsers.IsTheUserHasEmail((int)dgvUsersList.CurrentRow.Cells["User ID"].Value);

            // Handling Image and Text of Activate Deactivate An User Context Menu Strip Tool 
            if (clsUsers.IsUserActive((int)dgvUsersList.CurrentRow.Cells["User ID"].Value))
            {
                DeactivateActivateToolStripMenuItem.Text = "Deactivate";
                DeactivateActivateToolStripMenuItem.Image = Resources.Deactivate_user_32;
            }
            else
            {
                DeactivateActivateToolStripMenuItem.Text = "Activate";
                DeactivateActivateToolStripMenuItem.Image = Resources.Activate_User_32;
            }

            DeactivateActivateToolStripMenuItem.Enabled = DeleteToolStripMenuItem.Enabled = (clsGlobal.CurrentUser.UserID != (int)dgvUsersList.CurrentRow.Cells["User ID"].Value);
            cmsUsersList.Enabled = ((int)dgvUsersList.CurrentRow.Cells["User ID"].Value != 21)|| (clsGlobal.CurrentUser.UserID == 21);// 21 is ID of the amine user.
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewUser) != (int)clsGlobal.enUserPermissions.AddNewUser)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdateUser frm = new frmAddNewUpdateUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowUserInfo) != (int)clsGlobal.enUserPermissions.ShowUserInfo)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowUserInfo frm = new frmShowUserInfo((int)dgvUsersList.CurrentRow.Cells["User ID"].Value);
            frm.ShowDialog();
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ChangePasswordUser) != (int)clsGlobal.enUserPermissions.ChangePasswordUser)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmChangeUserPassword frm = new frmChangeUserPassword((int)dgvUsersList.CurrentRow.Cells["User ID"].Value);
            frm.ShowDialog();
        }

        private void DeactivateActivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ActiveDeactiveUser) != (int)clsGlobal.enUserPermissions.ActiveDeactiveUser)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int UserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value; 

            string OperationTitle = clsUsers.IsUserActive(UserID) ? "deactivate" : "activate";

            if (MessageBox.Show($"Are you sure you want to {OperationTitle} the account of user with id = [{UserID}]?",$"Confirme {OperationTitle}"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                return;
            }

            bool IsStatusUserAccountUpdated = 
                clsUsers.IsUserActive(UserID)? clsUsers.SetUserAccountStatus(UserID,clsUsers.enUserAccountStatu.Deactive)
                : clsUsers.SetUserAccountStatus(UserID,clsUsers.enUserAccountStatu.Active);

            if (IsStatusUserAccountUpdated)
            {
                MessageBox.Show($"The user account with id = [{UserID}] {OperationTitle}d successfully.", "Updated success."
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshUsersList();
            }
            else
            {
                MessageBox.Show($"The user account with id = [{UserID}] {OperationTitle}d successfully.", "Updated success."
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


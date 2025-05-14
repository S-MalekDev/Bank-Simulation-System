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
    public partial class frmChangeUserPassword : Form
    {
        int _UserID;
        clsUsers User;
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.ShowUserInfo(_UserID);
            User = ctrlShowUserInfo1.UserInfo;

            if (User == null)
            {
           
               MessageBox.Show($"The user with id = {_UserID} is not found!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
               return;
           
            }
        }
        private void mtbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = (string.IsNullOrEmpty(mtbCurrentPassword.Text)))
                errorProvider1.SetError(mtbCurrentPassword, "The field is required!");

            else if (e.Cancel = (clsUtil.ComputeHash((mtbCurrentPassword.Text).Trim()) != User.Password.Trim()))
                errorProvider1.SetError(mtbCurrentPassword, "The password you entered is not match with selected user's password!");

            else errorProvider1.SetError(mtbCurrentPassword, null);

        }
        private void mtbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = (string.IsNullOrEmpty(mtbNewPassword.Text)))
                errorProvider1.SetError(mtbNewPassword, "The field is required!");



            else errorProvider1.SetError(mtbNewPassword, null);
        }

        private void mtbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = (string.IsNullOrEmpty(mtbConfirmPassword.Text)))
                errorProvider1.SetError(mtbConfirmPassword, "The field is required!");

            else if (e.Cancel = (mtbConfirmPassword.Text.ToLower().Trim() != mtbNewPassword.Text.ToLower().Trim()))
                errorProvider1.SetError(mtbConfirmPassword, "The password you entered is not match with the new password in the field over!");

            else errorProvider1.SetError(mtbConfirmPassword, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(User.UpdatePassword(clsUtil.ComputeHash(mtbNewPassword.Text.Trim())))
            {
                MessageBox.Show("The password changed successfully.", ""
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                mtbCurrentPassword.Clear();
                mtbNewPassword.Clear();
                mtbConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show("Changed password is failed!", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangeUserPassword_Activated(object sender, EventArgs e)
        {
            mtbCurrentPassword.Focus();
        }
    }
}

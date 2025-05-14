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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbUsername.Text))
                errorProvider1.SetError(tbUsername, "The username field is required to login!");
            else 
                errorProvider1.SetError(tbUsername,null); 
        }

        private void mtbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(mtbPassword.Text))
                errorProvider1.SetError(mtbPassword, "The password field is required to login!");
            else
                errorProvider1.SetError(mtbPassword, null);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if((clsGlobal.CurrentUser = clsUsers.FindUserByUsernameAndPassword(tbUsername.Text.Trim(),clsUtil.ComputeHash(mtbPassword.Text.Trim()))) == null)
            {
                MessageBox.Show("Error: incorrect (username / password)!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsGlobal.CurrentUser.IsActive == false)
            {
                MessageBox.Show("Error: the account you try enter with it is inactive, you cannot login!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsGlobal.RememberUsernameAndPassword(tbUsername.Text.Trim(),mtbPassword.Text.Trim(),chbRememberMe.Checked))
            {
                MessageBox.Show("An error occurred when logging in.!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(chbRememberMe.Checked == false)
            {
                tbUsername.Clear();
                mtbPassword.Clear();
            }

            frmMain frm = new frmMain(this);
            this.Hide();
            frm.ShowDialog();
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if(clsGlobal.RetrieveLoginInfo(ref Username, ref Password))
            {
                tbUsername.Text = Username;
                mtbPassword.Text = Password;
            }

        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            tbUsername.SelectAll() ;
        }

        private void mtbPassword_Enter(object sender, EventArgs e)
        {
            mtbPassword.SelectAll() ;
        }
    }
}

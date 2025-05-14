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
    public partial class ctrlShowUserInfo : UserControl
    {
        private clsUsers _User = null;
        public clsUsers UserInfo { get { return _User; } } 
        public int UserID { get { return (_User != null) ? _User.UserID : -1; } }


        public ctrlShowUserInfo()
        {
            InitializeComponent();
        }

        private void _UpLoadTheUserInfoOnTheControl()
        {
            ctrlShowEmployeeInfo1.ShowEmployeeInfo(_User.EmployeeID);
            lblUesrID.Text = $"[ {_User.UserID.ToString("D2")} ]";
            lblUsername.Text = _User.Username;
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No" ;
        }

        public void ShowUserInfo(int UserID)
        {
            _User = clsUsers.FindByUserID(UserID);

            if (_User == null)
            {
                MessageBox.Show($"The user with id = {UserID} is not found!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadTheUserInfoOnTheControl();
        }
    }
}

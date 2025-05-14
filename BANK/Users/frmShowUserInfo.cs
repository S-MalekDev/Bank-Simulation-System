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
    public partial class frmShowUserInfo : Form
    {
        private int _UserID;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;   
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlShowUserInfo1.ShowUserInfo(_UserID);
        }
    }
}

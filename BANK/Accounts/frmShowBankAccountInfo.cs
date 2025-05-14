using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BANK
{
    public partial class frmShowBankAccountInfo : Form
    {
        private int _AccountID = -1;
        public frmShowBankAccountInfo(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
        }

        private void frmShowBankAccountInfo_Load(object sender, EventArgs e)
        {
            ctrlShowBankAccountInfo1.ShowBankAccountInfoByAccountID(_AccountID);
            if(ctrlShowBankAccountInfo1.AccountID == -1)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

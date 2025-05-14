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
    public partial class frmShowClientInfo : Form
    {
        private int _AccountNumber = -1;
        private int _ClientID = -1;
        enum enShowItBy { AccountNumber =0, ClientID = 1 }
        private enShowItBy _ShowItBy;
        public frmShowClientInfo(int ClientOrAccountID, bool IsAccountNumber = false)
        {
            InitializeComponent();
            if(IsAccountNumber)
            {
                _AccountNumber = ClientOrAccountID;
                _ShowItBy = enShowItBy.AccountNumber;
            }
            else
            {
                _ClientID = ClientOrAccountID;
                _ShowItBy = enShowItBy.ClientID;
            }
        }

        private void frmShowClientInfo_Load(object sender, EventArgs e)
        {
            if (_ShowItBy == enShowItBy.AccountNumber)
                ctrlShowClientInfo1.ShowClientInfobyAccountID(_AccountNumber);

            else if (_ShowItBy == enShowItBy.ClientID)
                ctrlShowClientInfo1.ShowClientInfobyClientID(_ClientID);
        }
    }
}

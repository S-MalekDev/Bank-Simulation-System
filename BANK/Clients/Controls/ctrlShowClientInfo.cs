using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class ctrlShowClientInfo : UserControl
    {
        private clsAccounts _Account = null;

        public clsAccounts AccountInfo { get { return _Account; } }
        public int AccountID { get { return (_Account != null) ? _Account.AccountNumber : -1; } }
        public clsClients ClientInfo { get { return _Account.ClientInfo; } }
        public int ClientID { get { return (_Account != null) ? _Account.ClientID : -1; } }

        private bool _AccountFieldsVisible = true;
        public bool AccountFieldsVisible
        {
            set
            {
                _AccountFieldsVisible = value;
                pnlAccountFields.Visible = _AccountFieldsVisible;
            }
            
        }
            

        private Color _BackColor;
        public Color ControlBackColor 
        {
            set
            {
                _BackColor = value;
                this.BackColor =_BackColor;
                gbClientInfo.BackColor = _BackColor;
                ctrlShowPersonInfo1.ControlBackColor = _BackColor;
            }
            get { return _BackColor; }
        }

        private Color _ForeColor;
        public Color ContorlForeColor
        {
            set
            {
                _ForeColor = value;
                this.ForeColor = _ForeColor;
                gbClientInfo.ForeColor = _ForeColor;
                pb1.BackColor = _ForeColor;
                pb2.BackColor = _ForeColor;
                pb3.BackColor = ForeColor;
                ctrlShowPersonInfo1.ControlForeColor = _ForeColor;

            }
            get { return _BackColor; }
        }
        public ctrlShowClientInfo()
        {
            InitializeComponent();
        }

        private void _UpLoadTheClientInfoOnTheControl()
        {
            ctrlShowPersonInfo1.ShowPersonInfo(_Account.PersonID);
            lblClientID.Text = $"[ {_Account.ClientID.ToString("D2")} ]";
            lblAccountNumber.Text = $"[ {_Account.AccountNumber.ToString("D2")} ]";
            lblJoiningDate.Text = _Account.OpeningDate.ToString("dd-MMM-yyyy");

        }

        public void ShowClientInfobyAccountID(int AccountID)
        {
            _Account = clsAccounts.FindByAccountNumber(AccountID);

            if (_Account == null)
            {
                MessageBox.Show($"The account with id = {AccountID} is not found!", "Missing"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadTheClientInfoOnTheControl();
        }

        public void ShowClientInfobyClientID(int ClientID)
        {
            _Account = clsAccounts.FindByClientID(ClientID);

            if (_Account == null)
            {
                MessageBox.Show($"The client with id = {ClientID} is not found!", "Missing"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadTheClientInfoOnTheControl();
        }

        public void ShowClientInfobyPersonID(int PersonID)
        {
            _Account = clsAccounts.FindByPersonID(PersonID);

            if (_Account == null)
            {
                if (!clsPeople.IsPersonExistByPersonID(PersonID))
                {
                    MessageBox.Show($"Doesn't exist a person with id = {PersonID} in the system!", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"The person with id = {PersonID} is not a client in the system!", ""
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            _UpLoadTheClientInfoOnTheControl();
        }
    }
}

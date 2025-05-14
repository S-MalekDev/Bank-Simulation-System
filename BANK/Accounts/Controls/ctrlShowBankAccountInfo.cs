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
    public partial class ctrlShowBankAccountInfo : UserControl
    {
        private clsAccounts _Account= null;
        public clsAccounts AccountInfo { get { return _Account; } }
        public int AccountID { get { return (_Account != null) ? _Account.AccountNumber : -1; } }

        public bool _ClientFieldsVisible = false;
        public bool ClientFieldsVisible
        {
            set
            {
                _ClientFieldsVisible = value;
                pnlClientFields.Visible = _ClientFieldsVisible;
            }

        }
        public ctrlShowBankAccountInfo()
        {
            InitializeComponent();
        }

        private void _UpLoadTheAccountInfoOnTheControl()
        {
            lblAccountNumber.Text = $"[ {_Account.AccountNumber.ToString("D2")} ]";
            lblAccountCurrency.Text = _Account.CurrnecyInfo.CurrencyName;
            lblOpeningDate.Text = _Account.OpeningDate.ToString("dd-MMM-yyyy");
            lblCreatedByUser.Text = _Account.UserInfo.Username;
            lblIsActive.Text = (_Account.IsActive==true) ? "Yes" : "No";
            lblClientID.Text = $"[ {_Account.ClientID.ToString("D2")} ]"; 
            lblClientFullName.Text = _Account.ClientInfo.FullName;
            lblNationality.Text = _Account.ClientInfo.NationalityInfo.Nationality;
            lblNationalNumber.Text = _Account.ClientInfo.NationalNumber;
            lblBalance.Text = _Account.Balance.ToString() + " " + _Account.CurrnecyInfo.CurrencySymbol;
        }
        public void ShowBankAccountInfoByAccountID(int AccountID)
        {
            _Account = clsAccounts.FindByAccountNumber(AccountID);

            if(_Account == null)
            {
                MessageBox.Show($"The account with id = {AccountID} is not found!", "Missing"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadTheAccountInfoOnTheControl();
        }
        public void ShowBankAccountInfoByClientID(int ClientID)
        {
            _Account = clsAccounts.FindByClientID(ClientID);

            if (_Account == null)
            {
                MessageBox.Show($"The client with id = {ClientID} is not found!", "Missing"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadTheAccountInfoOnTheControl();
        }
        public void ShowBankAccountInfoByPersonID(int PersonID)
        {
            _Account = clsAccounts.FindByPersonID(PersonID);

            if (_Account == null)
            {
                if(clsPeople.IsPersonExistByPersonID(PersonID))
                {
                    if (!clsClients.IsPersonExistByPersonID(PersonID))
                    {
                        MessageBox.Show($"The person with id = {PersonID} is not a client in the systme yet!", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                MessageBox.Show($"The person with id = {PersonID} is not found!", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UpLoadTheAccountInfoOnTheControl();
        }

        public void Clear()
        {
            lblAccountNumber.Text = $"[??]";
            lblAccountCurrency.Text = "???";
            lblOpeningDate.Text = "???";
            lblCreatedByUser.Text = "???";
            lblIsActive.Text = "???";
            lblClientID.Text = $"[??]";
            lblClientFullName.Text = "???";
            lblNationality.Text = "???";
            lblNationalNumber.Text = "???";
            lblBalance.Text = "00";
        }

    }
}

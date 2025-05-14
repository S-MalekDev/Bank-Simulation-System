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
    public partial class ctrlShowBankAccountInfoByFilter : UserControl
    {
        public event Action<int> OnAccountSelected;
        protected virtual void AccountSelected(int ClientID)
        {
            Action<int> Handler = OnAccountSelected;
            if (OnAccountSelected != null)
                OnAccountSelected(ClientID);
        }

        public enum enFilter { PersonID = 0, ClientID = 1, AccountNumber = 2 }
        private enFilter _SelectedFilter;

        public enFilter SelectedFilter
        {
            get
            {
                return _SelectedFilter;
            }
            set
            {
                _SelectedFilter = value;
            }
        }

        private clsAccounts _Account = null;

        public clsAccounts AccountInfo { get { return _Account; } }
        public int AccountID { get { return (_Account != null) ? _Account.AccountNumber : -1; } }

        public bool FilterEnabeled
        {
            set { gbFilter.Enabled = value; }
            get { return gbFilter.Enabled; }
        }
        public ctrlShowBankAccountInfoByFilter()
        {
            InitializeComponent();
        }

        public void FilterTexbBoxFocus()
        {
            tbFilterText.Focus();
        }

        private void _GetDefaultSelectedFilter()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.AccountNumber);
        }

        private void ctrlShowBankAccountInfoByFilter_Load(object sender, EventArgs e)
        {
            _GetDefaultSelectedFilter();
            FilterTexbBoxFocus();
        }

        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindAnAccount.PerformClick();


            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                errorProvider1.SetError(tbFilterText, "You cann't enter letters, only digit are allowed.");
            else errorProvider1.SetError(tbFilterText, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedFilter = (enFilter)cbFilter.SelectedIndex;

            tbFilterText.Clear();
            errorProvider1.Clear();
            tbFilterText.Focus();
        }
        private void btnFindAccount_Click(object sender, EventArgs e)
        {
            if (_SelectedFilter == enFilter.AccountNumber)
                ctrlShowBankAccountInfo1.ShowBankAccountInfoByAccountID(int.Parse(tbFilterText.Text));
            else if (_SelectedFilter == enFilter.ClientID)
                ctrlShowBankAccountInfo1.ShowBankAccountInfoByClientID(int.Parse(tbFilterText.Text));
            else if (_SelectedFilter == enFilter.PersonID)
                ctrlShowBankAccountInfo1.ShowBankAccountInfoByPersonID(int.Parse(tbFilterText.Text));


            _Account = ctrlShowBankAccountInfo1.AccountInfo;

            if (_Account != null)
            {
                if (OnAccountSelected != null)
                    OnAccountSelected(_Account.AccountNumber);
            }
        }
        public void ShowAccountInfoByAccountID(int AccountID)
        {
            cbFilter.SelectedIndex = (byte)enFilter.AccountNumber;
            tbFilterText.Text = AccountID.ToString();
            ctrlShowBankAccountInfo1.ShowBankAccountInfoByAccountID(AccountID);

            _Account = ctrlShowBankAccountInfo1.AccountInfo;

            if (_Account != null)
            {
                if (OnAccountSelected != null)
                    OnAccountSelected(_Account.AccountNumber);
            }
        }
        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if (FilterEnabeled)
                btnFindAnAccount.Enabled = (!string.IsNullOrEmpty(tbFilterText.Text));
        }

        public void Clear()
        {
            tbFilterText.Text = string.Empty;
            cbFilter.SelectedIndex = (byte)enFilter.AccountNumber;
            ctrlShowBankAccountInfo1.Clear();
        }
    }
}

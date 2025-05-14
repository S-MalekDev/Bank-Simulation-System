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
    public partial class ctrlShowFullBankAccountInfobyFilter : UserControl
    {
        public event Action<int> OnAccountSelected;
        protected virtual void AccountSelected(int PersonID)
        {
            Action<int> Handler = OnAccountSelected;
            if (OnAccountSelected != null)
                OnAccountSelected(PersonID);
        }

        public  bool IsAnAccountSelected()
        {
            return _Account != null;
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                ctrlShowClientInfobyFilter1.FilterEnabeled = _FilterEnabled;
            }
        }


        private clsAccounts _Account = null;
        public clsAccounts AccountInfo { get { return _Account; } }
        
        public ctrlShowFullBankAccountInfobyFilter()
        {
            InitializeComponent();
        }

        public void FilterTextBoxFocus()
        {
            ctrlShowClientInfobyFilter1.FilterTexbBoxFocus();
        }
        private void ctrlShowAccountInfobyFilter_Load(object sender, EventArgs e)
        {
            ctrlShowBankAccountInfo1.ClientFieldsVisible = false;
            ctrlShowClientInfobyFilter1.AccountFieldsVisible = false;
        }

        private void ctrlShowClientInfobyFilter1_OnClientSelected(int obj)
        {
            int ClientID = obj;
            _Account = clsAccounts.FindByClientID(ClientID);
            if (_Account == null)
            {
                MessageBox.Show($"The client with id = {ClientID} is not found!","Missing",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            ctrlShowBankAccountInfo1.ShowBankAccountInfoByAccountID(_Account.AccountNumber);

            if (ctrlShowBankAccountInfo1.AccountInfo != null)
            {
                if (OnAccountSelected != null)
                    OnAccountSelected(ctrlShowBankAccountInfo1.AccountID);
            }
        }

        public void ShowBankAccountDetailsByAccountID(int AccountID)
        {
            _Account = clsAccounts.FindByAccountNumber(AccountID);

            if (_Account == null)
            {
                MessageBox.Show($"The AccountInfo with id = {AccountID} is not found!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlShowClientInfobyFilter1.ShowClientInfoByAccountID(_Account.AccountNumber);
        }
    }
}

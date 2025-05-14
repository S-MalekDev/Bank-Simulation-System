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
    public partial class frmAddNewBankAccount : Form
    {
        private clsAccounts NewAccount;
        private int _PersonID = -1;
        public frmAddNewBankAccount()
        {
            InitializeComponent();
        }

        public frmAddNewBankAccount(int PersonID)
        {
            InitializeComponent();
            ctrlShowPersonInfoByFilter1.ShowPersonInfo(PersonID);
            ctrlShowPersonInfoByFilter1.FilterEnabeled = false;
        }

        private void _LoadPossibleAccountCurrenciesIn_cbPossibleCurrencies()
        {
            DataTable dtPossibleCurrencies = clsAccountCurrencies.GetAllAccountCurrencies();
            foreach(DataRow CurrencyRow in dtPossibleCurrencies.Rows)
            {
                cbPossibleCurrencies.Items.Add(CurrencyRow["Currency"] + $" ( {CurrencyRow["CurrencySymbol"]} )");
            }
        }

        private void _SelectDefaultCurrency_cbPossibleCurrencies()
        {
            cbPossibleCurrencies.SelectedIndex = cbPossibleCurrencies.FindString("USD ( $ )");
        }
        private void _LoadPossibleAccountCurrenciesAndSelectDefaultCurrency()
        {
            _LoadPossibleAccountCurrenciesIn_cbPossibleCurrencies();
            _SelectDefaultCurrency_cbPossibleCurrencies();
        }
        private void _PrepareFormToOpeningANewBankAccount()
        {
            _LoadPossibleAccountCurrenciesAndSelectDefaultCurrency();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            lblOpeningDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

        }
        private void frmAddNewBankAccount_Load(object sender, EventArgs e)
        {
            _PrepareFormToOpeningANewBankAccount();
        }

        private void tbBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(tbBalance, "You cann't enter letters, only digit are allowed.");
            }
            else
            {
                errorProvider1.SetError(tbBalance, null);
            }
        }

        private void tbBalance_Validating(object sender, CancelEventArgs e)
        {
            if(e.Cancel = string.IsNullOrEmpty(tbBalance.Text))
            {
                errorProvider1.SetError(tbBalance, "The balance field is required!");
            }
            else if(e.Cancel = decimal.Parse(tbBalance.Text)< 50)
            {
                errorProvider1.SetError(tbBalance, "You cannot opening an account with balace < 50 !");
            }
            else errorProvider1.SetError(tbBalance, null);
            
        }

        private byte _GetTheCurrencyChoosedID()
        {
            string CurrencyChoosed = cbPossibleCurrencies.SelectedItem.ToString();
            string Currency = CurrencyChoosed.Substring(0, CurrencyChoosed.IndexOf("(")-1);

            return(byte) clsAccountCurrencies.FindByCurrency(Currency.Trim()).AccountCurrencyID;
        }

        private void _LoadNewAccountInfoFromTheFormToInObject()
        {
            NewAccount = new clsAccounts();
            NewAccount.Password = clsUtil.GenerateABankAccountPasswored(10);
            NewAccount.Balance = decimal.Parse(tbBalance.Text);
            NewAccount.AccountCurrency = _GetTheCurrencyChoosedID();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("AccountInfo opening requirements must be met!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsAccounts.IsAccountExistByPersonID(_PersonID))
            {
                MessageBox.Show("The person selected has already an account!", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _LoadNewAccountInfoFromTheFormToInObject();

            if(NewAccount.Create(_PersonID, clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("The account opened successfully", ""
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblAccountNumber.Text = $"[ {NewAccount.AccountNumber.ToString("D2")} ]";
            }

        }

        private void ctrlShowPersonInfoByFilter1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            
            if(!(btnSave.Enabled = !clsAccounts.IsAccountExistByPersonID(_PersonID)))
            {
                MessageBox.Show("The person selected has already an account!","Not allowed"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}

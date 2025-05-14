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
    public partial class frmExternalTransferOperations : Form
    {
        private clsExternalTransferOperations _ExternalTransferOperation;
        private clsAccounts _AccountSender;
        private decimal _AmountWillbeRecieved;

        private clsServices _Service = clsServices.Find(clsServices.enService.Transactions);
        private clsTransferTypes _TranferType = clsTransferTypes.Find(clsTransferTypes.enTransferType.ExternalTransfer);
        private clsTransactionTypes _TransactionType = clsTransactionTypes.Find(clsTransactionTypes.enTransactionTypes.Transfer);
        decimal _TotalTransactionFeesPerDollar = 0;
        public frmExternalTransferOperations()
        {
            InitializeComponent();
        }
        public frmExternalTransferOperations(int AccountID)
        {
            InitializeComponent();
            ctrlShowFullBankAccountInfobyFilter1.ShowBankAccountDetailsByAccountID(AccountID);
            ctrlShowFullBankAccountInfobyFilter1.FilterEnabled = false;
        }

        private void _PrepareTheFormWithTheknownValues()
        {
            
            if(_TotalTransactionFeesPerDollar == 0)
            {
                _TotalTransactionFeesPerDollar = _Service.Fees + _TranferType.TransferFees + _TransactionType.Fees;
                lblOperationFees.Text = _TotalTransactionFeesPerDollar.ToString() + " $";
            }

            rtbOperationDescription.Text = _TranferType.TransferDescription;
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            lblServiceType.Text = _Service.ServiceTitle;
            lblTransactionType.Text = _TransactionType.Name;
            lblTransferType.Text = _TranferType.TransferName;
            lblRequestDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

        }
        private void frmExternalTransferOperations_Activated(object sender, EventArgs e)
        {
            if (ctrlShowFullBankAccountInfobyFilter1.FilterEnabled == true)
                ctrlShowFullBankAccountInfobyFilter1.FilterTextBoxFocus();
            else
                tbReceiverFullName.Focus();
        }

        private void frmExternalTransferOperations_Load(object sender, EventArgs e)
        {
            _PrepareTheFormWithTheknownValues();
        }

        private void ctrlShowFullBankAccountInfobyFilter1_OnAccountSelected(int obj)
        {
            if (_TotalTransactionFeesPerDollar == 0)
                _TotalTransactionFeesPerDollar = _Service.Fees + _TranferType.TransferFees + _TransactionType.Fees;
            
            _AccountSender = ctrlShowFullBankAccountInfobyFilter1.AccountInfo;
            lblSenderClientFullName.Text = _AccountSender.ClientInfo.FullName;
            lblOperationFees.Text = Math.Round((_TotalTransactionFeesPerDollar / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4).ToString() + " "+_AccountSender.CurrnecyInfo.CurrencySymbol;
            tbAmount.Enabled = true;
            tbReceiverFullName.Enabled = true;
            tbBankName.Enabled = true;
            tbIBANName.Enabled = true;
            tbReceiverFullName.Focus();
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnTransfer.PerformClick();

            if ((e.KeyChar == (char)46 && !decimal.TryParse(tbAmount.Text, out decimal amount)) || e.KeyChar == (char)46 && tbAmount.Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != (char)46))
            {
                errorProvider1.SetError(tbAmount, "You cann't enter letters, only digit are allowed.");
            }

            else errorProvider1.SetError(tbAmount, null);

        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(tbAmount.Text))
            {
                lblAmountWillbeReceive.Text = "00.0000 " + _AccountSender.CurrnecyInfo.CurrencySymbol;
                btnTransfer.Enabled = false;
            }
            else if (Convert.ToDecimal(tbAmount.Text) == 0)
            {
                lblAmountWillbeReceive.Text = "00.0000 " + _AccountSender.CurrnecyInfo.CurrencySymbol;
                btnTransfer.Enabled = false;
            }
            else
            {
                lblAmountWillbeReceive.Text = (Convert.ToDecimal(tbAmount.Text) - Math.Round((_TotalTransactionFeesPerDollar
                    / 
                    Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4)).ToString() 
                    + " " + _AccountSender.CurrnecyInfo.CurrencySymbol;

                
                btnTransfer.Enabled = true;
            }
        }
        private void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            //Validation for text boxes ,bank, IBAN number and reciever full name;

            TextBox tb = ((TextBox)sender);

            if (e.Cancel = string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "The field is required!");
            }

            else errorProvider1.SetError(tb, null);
            
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbAmount.Text))
            {
                errorProvider1.SetError(tbAmount, "The field is required!");
            }
            else if(e.Cancel = (Convert.ToDecimal(tbAmount.Text)< Math.Round((_TotalTransactionFeesPerDollar 
                / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4)))
            {
                errorProvider1.SetError(tbAmount, $"You can't transfer an amount less to {lblOperationFees.Text} !");
            }

            else errorProvider1.SetError(tbAmount, null);
        }
        private void _LoadTheInfoTransferToAnObject()
        {

            _ExternalTransferOperation = new clsExternalTransferOperations();
            _ExternalTransferOperation.CurrencyOfTransferID = (byte)_AccountSender.CurrnecyInfo.AccountCurrencyID;
            _ExternalTransferOperation.BankName = tbBankName.Text;
            _ExternalTransferOperation.RecipientFullName = tbReceiverFullName.Text;
            _ExternalTransferOperation.status = clsExternalTransferOperations.enStatus.Completed;
            _ExternalTransferOperation.IBAN_Number = tbIBANName.Text;
            _ExternalTransferOperation.Fees = Math.Round((_TotalTransactionFeesPerDollar / (decimal)_AccountSender.CurrnecyInfo.ExchangeRatePerUSD), 4);
            _ExternalTransferOperation.Amount = Math.Round(Convert.ToDecimal(tbAmount.Text), 4) - _ExternalTransferOperation.Fees;
            _ExternalTransferOperation.TransferType = _TranferType.TransferType;
            _ExternalTransferOperation.TransactionType = _TransactionType.TransactionType;
            _ExternalTransferOperation.ClientID = _AccountSender.ClientID;
            _ExternalTransferOperation.UserID = clsGlobal.CurrentUser.UserID;
            _ExternalTransferOperation.Service = _Service.Service;
            _ExternalTransferOperation.ArrivalDate = DateTime.Now.AddDays(1);
            _ExternalTransferOperation.RequestDate = DateTime.Now;


        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal AmountRequired = Math.Round(Convert.ToDecimal(tbAmount.Text) + (_TotalTransactionFeesPerDollar / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4);
            if (_AccountSender.Balance < AmountRequired)
            {
                decimal MaxAmountCanBeWithdrawn = Math.Round(_AccountSender.Balance - (_TotalTransactionFeesPerDollar / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4);
                MessageBox.Show($"You can't continue the operation while Insufficient balance!, the maximum amount that can be " +
                $"transfert from the account it has number [{_AccountSender.AccountNumber}] is {MaxAmountCanBeWithdrawn} {_AccountSender.CurrnecyInfo.CurrencySymbol}.", "Error"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to continue transfer?"       
                , $"Confirme transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _LoadTheInfoTransferToAnObject();

            if (_ExternalTransferOperation.Save())
            {
                MessageBox.Show($"The transfer operation was completed successfully.", "Transaction succeeded"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblOperationID.Text = $"[ {_ExternalTransferOperation.OperationID.ToString("D2")} ]";
                ctrlShowFullBankAccountInfobyFilter1.ShowBankAccountDetailsByAccountID(_AccountSender.AccountNumber);
                ctrlShowFullBankAccountInfobyFilter1.FilterEnabled = false;

                tbAmount.Clear();
                tbAmount.Enabled = false;
                tbReceiverFullName.Enabled = false;
                tbIBANName.Enabled = false;
                tbBankName.Enabled = false;
                
            }
            else
            {
                MessageBox.Show($"The transfer operation failed!", "Transaction failed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnTransfer.Enabled = false;
        }


    }
}

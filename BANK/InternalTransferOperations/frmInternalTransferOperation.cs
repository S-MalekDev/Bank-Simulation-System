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
    public partial class frmInternalTransferOperation : Form
    {
        private clsInternalTransferOperations _InternalTransferOperation;
        private clsAccounts _AccountSender;
        private clsAccounts _AccountReceiver;
        private decimal _AmountWillBeReceive = 0;

        private clsServices _Service = clsServices.Find(clsServices.enService.Transactions);
        private clsTransferTypes _TranferType = clsTransferTypes.Find(clsTransferTypes.enTransferType.InternalTransfer);
        private clsTransactionTypes _TransactionType = clsTransactionTypes.Find(clsTransactionTypes.enTransactionTypes.Transfer);
        decimal _TotalTransactionFeesPerDollar = 0;

        
         
        public frmInternalTransferOperation()
        {
            InitializeComponent();
        }
        public frmInternalTransferOperation(int AccountID)
        {
            InitializeComponent();
            ctrlShowBankAccountInfoOfSenderClient.ShowAccountInfoByAccountID(AccountID);
            ctrlShowBankAccountInfoOfSenderClient.FilterEnabeled = false;
            
        }

        private void _PrepareTheFormWithTheknownValues()
        {
            if (_TotalTransactionFeesPerDollar == 0)
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

        private void frmInternalTransferOperation_Load(object sender, EventArgs e)
        {
            _PrepareTheFormWithTheknownValues();
        }

        private void ctrlShowBankAccountInfoOfSenderClient_OnAccountSelected(int obj)
        {
            if (_AccountReceiver != null)
            {
                if (obj == _AccountReceiver.AccountNumber)
                {
                    MessageBox.Show("The account you have selected is set as a receiver and cannot be used to sender money!", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ctrlShowBankAccountInfoOfSenderClient.Clear();
                    lblTheSenderClient.Text = "[???]";
                    lblSenderAccountCurrency.Text = "[???]";
                    lblOperationFees.Text = _TotalTransactionFeesPerDollar.ToString() + " $";
                    lblAmountWillbeReceive.Text = "00";
                    _AccountSender = null;
                    tbAmount.Enabled = false;
                    btnTransfer.Enabled = false;

                    return;
                }
            }
            _AccountSender = ctrlShowBankAccountInfoOfSenderClient.AccountInfo;
            lblSenderAccountCurrency.Text = _AccountSender.CurrnecyInfo.CurrencyName;
            lblTheSenderClient.Text = _AccountSender.ClientInfo.FullName;

            _TotalTransactionFeesPerDollar = _Service.Fees + _TranferType.TransferFees + _TransactionType.Fees;
            lblOperationFees.Text = $"{Math.Round((_TotalTransactionFeesPerDollar / (decimal)_AccountSender.CurrnecyInfo.ExchangeRatePerUSD), 4)} {_AccountSender.CurrnecyInfo.CurrencySymbol}";
            
            if (tbAmount.Enabled = (_AccountSender != null && _AccountReceiver != null))
            {
                tbAmount.Clear();
                tbAmount.Focus();
                return;
            }
            
            ctrlShowBankAccountInfoOfReceiverClient.FilterTexbBoxFocus();
        }

        private void ctrlShowBankAccountInfoOfReceiverClient_OnAccountSelected(int obj)
        {
            if (_AccountSender != null)
            {
                if (obj == _AccountSender.AccountNumber)
                {
                    MessageBox.Show("The account you have selected is set as a sender and cannot be used to receive money!", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    lblReceiverClient.Text = "[???]";
                    lblReceiverAccountCurrency.Text = "[???]";
                    lblAmountWillbeReceive.Text = "00";
                    _AccountReceiver = null;
                    tbAmount.Enabled = false;
                    btnTransfer.Enabled = false;
                    ctrlShowBankAccountInfoOfReceiverClient.Clear();
                    ctrlShowBankAccountInfoOfReceiverClient.FilterTexbBoxFocus();

                    return;
                }
            }
            _AccountReceiver = ctrlShowBankAccountInfoOfReceiverClient.AccountInfo;
            lblReceiverAccountCurrency.Text = _AccountReceiver.CurrnecyInfo.CurrencyName;
            lblReceiverClient.Text = _AccountReceiver.ClientInfo.FullName;

            if (tbAmount.Enabled = (_AccountSender != null && _AccountReceiver != null))
            {
                tbAmount.Clear();
                tbAmount.Focus();
                return;
            }

            ctrlShowBankAccountInfoOfSenderClient.FilterTexbBoxFocus();
        }

        private void frmInternalTransferOperation_Activated(object sender, EventArgs e)
        {
            if(ctrlShowBankAccountInfoOfSenderClient.FilterEnabeled != false)
                ctrlShowBankAccountInfoOfSenderClient.FilterTexbBoxFocus();
            else
                ctrlShowBankAccountInfoOfReceiverClient.FilterTexbBoxFocus();
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnTransfer.PerformClick();

            if ((e.KeyChar == (char)46 && !decimal.TryParse(tbAmount.Text,out decimal amount))|| e.KeyChar == (char)46 && tbAmount.Text.Contains('.')) 
            {
               e.Handled = true;
                return;
            }

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& (e.KeyChar != (char)46))
            {
                errorProvider1.SetError(tbAmount, "You cann't enter letters, only digit are allowed.");
            }

            else errorProvider1.SetError(tbAmount, null);

        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbAmount.Text))
            {
                lblAmountWillbeReceive.Text = "00.0000 " + _AccountReceiver.CurrnecyInfo.CurrencySymbol;
                btnTransfer.Enabled = false;
            }
            else if (Convert.ToDecimal(tbAmount.Text)==0)
            {
                lblAmountWillbeReceive.Text = "00.0000 " + _AccountReceiver.CurrnecyInfo.CurrencySymbol;
                btnTransfer.Enabled = false;
            }
            else
            {
                decimal ConvertAmountToDollarAmount = Convert.ToDecimal(tbAmount.Text) * Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD);
                _AmountWillBeReceive = Math.Round(ConvertAmountToDollarAmount / (decimal)_AccountReceiver.CurrnecyInfo.ExchangeRatePerUSD, 4);
                lblAmountWillbeReceive.Text = $"{_AmountWillBeReceive} {_AccountReceiver.CurrnecyInfo.CurrencySymbol}";
                btnTransfer.Enabled = true;
            }
        }

        private void _LoadTheInfoTransferToAnObject()
        {
            _InternalTransferOperation = new clsInternalTransferOperations();
            _InternalTransferOperation.CurrencyOfTransfer = (byte)_AccountSender.CurrnecyInfo.AccountCurrencyID;
            _InternalTransferOperation.CurrencyOfAmountReceived = (byte)_AccountReceiver.CurrnecyInfo.AccountCurrencyID;
            _InternalTransferOperation.Amount = Math.Round(Convert.ToDecimal(tbAmount.Text),4);
            _InternalTransferOperation.AmountReceived = _AmountWillBeReceive;
            _InternalTransferOperation.Fees = Math.Round((_TotalTransactionFeesPerDollar / (decimal)_AccountSender.CurrnecyInfo.ExchangeRatePerUSD),4);
            _InternalTransferOperation.TransferToClientID = _AccountReceiver.ClientID;
            _InternalTransferOperation.IsSucceedit = true;
            _InternalTransferOperation.TransferType = _TranferType.TransferType;
            _InternalTransferOperation.TransactionType = _TransactionType.TransactionType;
            _InternalTransferOperation.ClientID = _AccountSender.ClientID;
            _InternalTransferOperation.UserID = clsGlobal.CurrentUser.UserID;
            _InternalTransferOperation.Service = _Service.Service;
            _InternalTransferOperation.RequestDate = DateTime.Now;
            

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            
            
            decimal AmountRequired = Math.Round(Convert.ToDecimal(tbAmount.Text) + (_TotalTransactionFeesPerDollar / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4);

            if (_AccountSender.Balance < AmountRequired)
            {
                decimal MaxAmountCanBeWithdrawn = Math.Round(_AccountSender.Balance - (_TotalTransactionFeesPerDollar / Convert.ToDecimal(_AccountSender.CurrnecyInfo.ExchangeRatePerUSD)), 4);
                MessageBox.Show($"You can't continue the operation while Insufficient balance!, the maximum amount that can be " +
                $"transfert from the account it has number [{_AccountSender.AccountNumber}] is {MaxAmountCanBeWithdrawn} {_AccountSender.CurrnecyInfo.CurrencySymbol}.", "Error"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to continue transfer the amount [ {Convert.ToDecimal(tbAmount.Text)} {_AccountSender.CurrnecyInfo.CurrencySymbol} ] " +
                $"to the account it has number = [ {_AccountReceiver.AccountNumber} ]"
                , $"Confirme transfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _LoadTheInfoTransferToAnObject();

            if(_InternalTransferOperation.Save())
            {
                MessageBox.Show($"The transfer operation was completed successfully.", "Transaction succeeded"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblOperationID.Text = $"[ {_InternalTransferOperation.OperationID.ToString("D2")} ]";
                ctrlShowBankAccountInfoOfSenderClient.ShowAccountInfoByAccountID(_AccountSender.AccountNumber);
                ctrlShowBankAccountInfoOfSenderClient.FilterEnabeled = false;
                ctrlShowBankAccountInfoOfReceiverClient.ShowAccountInfoByAccountID(_AccountReceiver.AccountNumber);
                ctrlShowBankAccountInfoOfReceiverClient.FilterEnabeled = false;
                tbAmount.Clear();
                tbAmount.Enabled = false;
            }
            else
            {
                MessageBox.Show($"The transfer operation failed!", "Transaction failed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

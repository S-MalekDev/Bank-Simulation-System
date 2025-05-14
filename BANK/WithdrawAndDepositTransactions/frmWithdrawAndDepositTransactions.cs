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
using static BANK_BusinessLayer.clsTransactionTypes;

namespace BANK
{
    public partial class frmWithdrawAndDepositTransactions : Form
    {
        private clsWithdrawAndDepositOperations _Operation;
        private clsAccounts _Account;
        private clsTransactionTypes.enTransactionTypes _TransactionTypes
        {
            set 
            { 
                switch(value)
                {
                    case clsTransactionTypes.enTransactionTypes.Withdraw:
                        {
                            Mode = enMode.Withdraw;
                            rbDeposit.Enabled = false;
                            break;
                        }
                    case clsTransactionTypes.enTransactionTypes.Deposit:
                        {
                            Mode = enMode.Deposit;
                            rbWithdraw.Enabled = false;
                            break;
                        }
                }
            }
        }
        public enum enMode { Withdraw = 1, Deposit = 2 }
        private enMode _Mode;

        private string ModeText { get { return (Mode == enMode.Withdraw) ? "Withdraw" : "Deposit"; } }
        public enMode Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;

              
                switch (_Mode)
                {
                    case enMode.Withdraw:
                        {
                            lblFormTitle.Text = "Withdraw Operation";
                            rbWithdraw.Checked = true;
                            gbTransaction.Text = "Withdraw Operation";
                            clsTransactionTypes transactionTypes = clsTransactionTypes.Find(clsTransactionTypes.enTransactionTypes.Withdraw);
                            rtbOperationDescription.Text= transactionTypes.Description;
                            lblTransactionType.Text = transactionTypes.Name;
                            lblOperationFees.Text = $"{_OperationFeesPerDollar = (transactionTypes.Fees + clsServices.Find(clsServices.enService.Transactions).Fees)} $";
                            btnOperation.Text = "Withdraw";
                            btnOperation.Image = Image.FromFile(@"C:\Users\DELL\Desktop\BANK Project\PROJECT Emages & Icones\withdrawal.png");
                            break;
                        }
                    case enMode.Deposit:
                        {
                            lblFormTitle.Text = "Deposit Operation";
                            rbDeposit.Checked = true;
                            gbTransaction.Text = "Deposit Operation";
                            clsTransactionTypes transactionTypes = clsTransactionTypes.Find(clsTransactionTypes.enTransactionTypes.Deposit);
                            rtbOperationDescription.Text = transactionTypes.Description;
                            lblTransactionType.Text = transactionTypes.Name;
                            lblOperationFees.Text = $"{_OperationFeesPerDollar = (transactionTypes.Fees + clsServices.Find(clsServices.enService.Transactions).Fees)} $";
                            btnOperation.Text = "Deposit";
                            btnOperation.Image = Image.FromFile(@"C:\Users\DELL\Desktop\BANK Project\PROJECT Emages & Icones\deposit.png");
                            break;
                        }
                }
            }
        }

        private decimal _OperationFeesPerDollar;

        private decimal _OperationFeesPerAccountCurrency;

        public frmWithdrawAndDepositTransactions(clsTransactionTypes.enTransactionTypes Type, int AccountID)
        {
            InitializeComponent();
            _TransactionTypes = Type;
            ctrlShowAccountInfobyFilter1.ShowBankAccountDetailsByAccountID(AccountID);
            ctrlShowAccountInfobyFilter1.FilterEnabled = false;
        }
        public frmWithdrawAndDepositTransactions()
        {
            InitializeComponent();
            Mode = enMode.Withdraw;
        }
        
        private void _LoadTheInfoOfTheTransfertOperation()
        {
            _Operation = new clsWithdrawAndDepositOperations();

            _Operation.UserID = clsGlobal.CurrentUser.UserID;
            _Operation.ClientID = _Account.ClientID;
            _Operation.Service = clsServices.enService.Transactions;
            _Operation.TransactionType = (Mode == enMode.Withdraw) ? clsTransactionTypes.enTransactionTypes.Withdraw : clsTransactionTypes.enTransactionTypes.Deposit;
            _Operation.RequestDate = DateTime.Now;
            _Operation.Amount = Convert.ToDecimal(tbAmount.Text);

            if (_Account.CurrnecyInfo.CurrencySymbol != "$")
                _Operation.OperationFees = _OperationFeesPerAccountCurrency;
            else
                _Operation.OperationFees = _OperationFeesPerDollar;

            _Operation.PreviousBalance = _Account.Balance;

            _Operation.BalanceAfterTransaction = _Account.Balance - _Operation.OperationFees;
            _Operation.BalanceAfterTransaction = (Mode == enMode.Withdraw) ? (_Operation.BalanceAfterTransaction - _Operation.Amount) : (_Operation.BalanceAfterTransaction + _Operation.Amount);
        }

        private void _RefreshTheForm()
        {
            ctrlShowAccountInfobyFilter1.ShowBankAccountDetailsByAccountID(_Account.AccountNumber);
            tbAmount.Clear();
        }

        private void _GetTextOfThelblOperationFees()
        {
            if (_Account.CurrnecyInfo.CurrencySymbol != "$")
                lblOperationFees.Text = $"{_OperationFeesPerAccountCurrency = Math.Round(_OperationFeesPerDollar / Convert.ToDecimal(_Account.CurrnecyInfo.ExchangeRatePerUSD), 4)} {_Account.CurrnecyInfo.CurrencySymbol}";
            else
                lblOperationFees.Text = $"{_OperationFeesPerDollar} {_Account.CurrnecyInfo.CurrencySymbol}";
        }

        private void _PrepareTheFormToMakeTheOperation()
        {
            _Account = ctrlShowAccountInfobyFilter1.AccountInfo;

            lblBalanceAfter.Text = $"{_Account.Balance} {_Account.CurrnecyInfo.CurrencySymbol}";

            _GetTextOfThelblOperationFees();
        }



        private void frmWithdrawAndDepositTransactions_Load(object sender, EventArgs e)
        {
                
            lblCreatedByUser.Text = clsGlobal.CurrentUser.Username;
            lblServiceType.Text = clsServices.Find(clsServices.enService.Transactions).ServiceTitle;
            lblRequestDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        }

        private void ctrlShowAccountInfobyFilter1_OnAccountSelected(int obj)
        {
            tbAmount.Enabled = true;
            tbAmount.Clear();
            tbAmount.Focus();
            _PrepareTheFormToMakeTheOperation();
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            decimal amountAfterOperation;


            if (string.IsNullOrEmpty(tbAmount.Text))
            {
                amountAfterOperation = _Account.Balance;
                btnOperation.Enabled = false;
                
            }
            else if(Convert.ToDecimal(tbAmount.Text)==0)
            {
                amountAfterOperation = _Account.Balance;
                btnOperation.Enabled = false;
            }
            else
            {
                amountAfterOperation = _Account.Balance - ((_Account.CurrnecyInfo.CurrencySymbol == "$") ? _OperationFeesPerDollar : _OperationFeesPerAccountCurrency);
                amountAfterOperation = (Mode == enMode.Withdraw) ? (amountAfterOperation - Convert.ToDecimal(tbAmount.Text)) : (amountAfterOperation + Convert.ToDecimal(tbAmount.Text));
                btnOperation.Enabled = (_Account != null);
            }

            lblBalanceAfter.Text = $"{amountAfterOperation} {_Account.CurrnecyInfo.CurrencySymbol}"; 
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
                btnOperation.PerformClick();

            if ((e.KeyChar == (char)46 && !decimal.TryParse(tbAmount.Text, out decimal amount)) || (e.KeyChar == (char)46 && tbAmount.Text.Contains('.')))
            {
                e.Handled = true;
                return;
            }

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)&& e.KeyChar != (char)46)
            {
                errorProvider1.SetError(tbAmount, "You cann't enter letters, only digit are allowed.");
            }
            else errorProvider1.SetError(tbAmount, null);
            
        }

        private void rbWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            tbAmount.Clear();
            tbAmount.Focus();

            if (rbWithdraw.Checked)
                Mode = enMode.Withdraw;

            if (_Account != null)
                _GetTextOfThelblOperationFees(); 
        }

        private void rbDeposit_CheckedChanged(object sender, EventArgs e)
        {
            tbAmount.Clear();
            tbAmount.Focus();

            if (rbDeposit.Checked)
                Mode = enMode.Deposit;

            if (_Account != null)
                _GetTextOfThelblOperationFees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {

            if(Mode == enMode.Withdraw)
            {
                decimal AmountRequired =Math.Round(Convert.ToDecimal(tbAmount.Text) + (_OperationFeesPerDollar / Convert.ToDecimal(_Account.CurrnecyInfo.ExchangeRatePerUSD)),4);
                
                if(_Account.Balance< AmountRequired)
                {
                    decimal MaxAmountCanBeWithdrawn = Math.Round(_Account.Balance - (_OperationFeesPerDollar / Convert.ToDecimal(_Account.CurrnecyInfo.ExchangeRatePerUSD)),4);
                    
                    MessageBox.Show($"You can't continue the operation while Insufficient balance!, the maximum amount that can be " +
                        $"withdraw from the account it has number [{_Account.AccountNumber}] is {MaxAmountCanBeWithdrawn} {_Account.CurrnecyInfo.CurrencySymbol}.", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            

            string LinkingTool = (Mode == enMode.Withdraw) ? "from" : "to";
            if (MessageBox.Show($"Are you sure you want to continue {ModeText.ToLower()} the amount [ {Convert.ToDecimal(tbAmount.Text)} {_Account.CurrnecyInfo.CurrencySymbol} ] " +
                $"{LinkingTool} the account it has number = [ {_Account.AccountNumber} ]"
                ,$"Confirme {ModeText.ToLower()}",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _LoadTheInfoOfTheTransfertOperation();


            if(_Operation.Save())
            {
                
                MessageBox.Show($"The {ModeText.ToLower()} operation was completed successfully.", "Transaction succeeded"
                    , MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblOperationID.Text = $"[ {_Operation.OperationID.ToString("D2")} ]";
            }
            else
            {
                MessageBox.Show($"The {ModeText.ToLower()} operation failed!", "Transaction failed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefreshTheForm();
        }

        private void frmWithdrawAndDepositTransactions_Activated(object sender, EventArgs e)
        {
            if (ctrlShowAccountInfobyFilter1.FilterEnabled)
                ctrlShowAccountInfobyFilter1.FilterTextBoxFocus();
        }

    }
}

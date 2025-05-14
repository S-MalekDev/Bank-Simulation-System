using BANK.Properties;
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
    public partial class frmShowWithdrawDepositRowDetails: Form
    {

        private clsWithdrawAndDepositOperations _WithdrawDepositeOperationInfo;

        private clsTransactionTypes.enTransactionTypes _TransactionTypeValue;
        private clsTransactionTypes.enTransactionTypes _TransactionType
        {
            set
            {
                _TransactionTypeValue = value;
                switch(_TransactionTypeValue)
                {
                    case clsTransactionTypes.enTransactionTypes.Withdraw:
                        {
                            pbWithdrawDeposit.Image = Resources.Client_Withdaw_history_512;
                            pbTransactionType.Image = Image.FromFile(@"C:\Users\DELL\Desktop\BANK Project\PROJECT Emages & Icones\Withdraw 32.png");
                            this.Text = "Withdraw details";
                            break;
                        }
                    case clsTransactionTypes.enTransactionTypes.Deposit:
                        {
                            pbWithdrawDeposit.Image = Resources.Client_Deposit_History_512 ;
                            pbTransactionType.Image = Image.FromFile(@"C:\Users\DELL\Desktop\BANK Project\PROJECT Emages & Icones\Deposit 32.png");
                            this.Text = "Deposit details";
                            break;
                        }
                }
            }
        }
        
        public frmShowWithdrawDepositRowDetails(int ID)
        {
            InitializeComponent();

            _WithdrawDepositeOperationInfo = clsWithdrawAndDepositOperations.Find(ID);

            if(_WithdrawDepositeOperationInfo != null)
            {
                _TransactionType = _WithdrawDepositeOperationInfo.TransactionType;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string _GetTransactionTypeText(clsTransactionTypes.enTransactionTypes transactionType)
        {
            return (transactionType == clsTransactionTypes.enTransactionTypes.Withdraw) ? "Withdraw" : "Deposit";
        }
        private void frmShowWithdrawDepositRowDetails_Load(object sender, EventArgs e)
        {
            if (_WithdrawDepositeOperationInfo == null)
                return;

            lblOperationID.Text = _WithdrawDepositeOperationInfo.OperationID.ToString();
            lblClientID.Text = _WithdrawDepositeOperationInfo.ClientID.ToString();
            lblClientFullName.Text = _WithdrawDepositeOperationInfo.ClientInfo.FullName;
            lblTransactionType.Text = _GetTransactionTypeText(_WithdrawDepositeOperationInfo.TransactionType);
            lblTransactionDate.Text = _WithdrawDepositeOperationInfo.RequestDate.ToString("dd-MMM-yyyy");
            lblTransactionTime.Text = _WithdrawDepositeOperationInfo.RequestDate.ToString("hh:mm tt");
            lblDoneByUser.Text = _WithdrawDepositeOperationInfo.UserInfo.Username;
            lblUserFullName.Text = _WithdrawDepositeOperationInfo.UserInfo.PersonInfo.FullName;

            clsAccounts ClientAccount = clsAccounts.FindByClientID(_WithdrawDepositeOperationInfo.ClientID);
            lblAccountNumber.Text = ClientAccount.AccountNumber.ToString();
            lblTransactionCurrency.Text = ClientAccount.CurrnecyInfo.CurrencyName;

            lblTransactionAmount.Text = _WithdrawDepositeOperationInfo.Amount.ToString() +" "+ ClientAccount.CurrnecyInfo.CurrencySymbol;
            lblTransactionFee.Text = _WithdrawDepositeOperationInfo.OperationFees.ToString() + " " + ClientAccount.CurrnecyInfo.CurrencySymbol;
            lblPreviousBalance.Text = _WithdrawDepositeOperationInfo.PreviousBalance.ToString() + " " + ClientAccount.CurrnecyInfo.CurrencySymbol;
            lblBalanceAfterTransaction.Text = _WithdrawDepositeOperationInfo.BalanceAfterTransaction.ToString() + " " + ClientAccount.CurrnecyInfo.CurrencySymbol;

        }
    }
}

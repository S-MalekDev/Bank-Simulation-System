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
    public partial class frmShowInternalTransactionRowDetails: Form
    {
        private clsInternalTransferOperations _InternalTranferOperation;
        public frmShowInternalTransactionRowDetails(int ID)
        {
            InitializeComponent();
            _InternalTranferOperation = clsInternalTransferOperations.Find(ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadInternalTransferOperationOnTheForm()
        {
            if (_InternalTranferOperation == null)
                return;

            clsAccounts SenderAccount = clsAccounts.FindByClientID(_InternalTranferOperation.ClientID);
            clsAccounts ReceiverAccount = clsAccounts.FindByClientID(_InternalTranferOperation.RecipientClientInfo.ClientID);
            lblSenderClientID.Text = _InternalTranferOperation.ClientID.ToString();
            lblSenderAccount.Text = SenderAccount.AccountNumber.ToString();
            lblSenderClientFullName.Text = _InternalTranferOperation.ClientInfo.FullName;
            lblSenderAccountCurrency.Text = SenderAccount.CurrnecyInfo.CurrencyName;

            lblReceiverClientID.Text = _InternalTranferOperation.RecipientClientInfo.ClientID.ToString();
            lblReceiverClientFullName.Text = _InternalTranferOperation.RecipientClientInfo.FullName;
            lblReceiverAccount.Text = ReceiverAccount.AccountNumber.ToString();
            lblReceiverAccountCurrency.Text = ReceiverAccount.CurrnecyInfo.CurrencyName;

            lblOperationID.Text = _InternalTranferOperation.OperationID.ToString();
            lblTrasferAmount.Text = _InternalTranferOperation.Amount.ToString() + " " + SenderAccount.CurrnecyInfo.CurrencySymbol;
            lblTransactionFee.Text = _InternalTranferOperation.Fees.ToString() + " " + SenderAccount.CurrnecyInfo.CurrencySymbol;
            lblAmountReceived.Text = _InternalTranferOperation.AmountReceived.ToString() + " " + ReceiverAccount.CurrnecyInfo.CurrencySymbol;
            lblDoneByUser.Text = _InternalTranferOperation.UserInfo.Username;
            lblUserFullName.Text = _InternalTranferOperation.UserInfo.PersonInfo.FullName;
            lblTransactionDate.Text = _InternalTranferOperation.RequestDate.ToString("dd-MMM-yyyy");
            lblTransactionTime.Text = _InternalTranferOperation.RequestDate.ToString("hh:mm tt");
            lblIsSucceeded.Text = _InternalTranferOperation.IsSucceedit ? "Yes" : "No";
        }
        private void frmShowInternalTransactionRowDetails_Load(object sender, EventArgs e)
        {
            _LoadInternalTransferOperationOnTheForm();
        }
    }
}

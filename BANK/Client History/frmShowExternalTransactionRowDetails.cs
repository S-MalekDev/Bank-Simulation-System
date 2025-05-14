using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class frmShowExternalTransactionRowDetails: Form
    {
        private clsExternalTransferOperations _ExternalTransferOperation;
        public frmShowExternalTransactionRowDetails(int ID)
        {
            InitializeComponent();
            _ExternalTransferOperation = clsExternalTransferOperations.Find(ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadExternalTransferOperationInfoOnTheForm()
        {
            if (_ExternalTransferOperation == null)
                return;

            clsAccounts SenderAccount = clsAccounts.FindByClientID(_ExternalTransferOperation.ClientID);

            lblSenderClientID.Text = _ExternalTransferOperation.ClientID.ToString();
            lblSenderClientFullName.Text = _ExternalTransferOperation.ClientInfo.FullName;
            lblSenderAccount.Text = SenderAccount.AccountNumber.ToString();
            lblSenderAccountCurrency.Text = SenderAccount.CurrnecyInfo.CurrencyName;

            lblReceiverFullName.Text = _ExternalTransferOperation.RecipientFullName;
            lblBankName.Text = _ExternalTransferOperation.BankName;
            lblIbanNumber.Text = _ExternalTransferOperation.IBAN_Number;

            lblOperationID.Text = _ExternalTransferOperation.OperationID.ToString();
            lblTrasferAmount.Text = (_ExternalTransferOperation.Amount + _ExternalTransferOperation.Fees).ToString() + " " + SenderAccount.CurrnecyInfo.CurrencySymbol;
            lblTransactionFee.Text = _ExternalTransferOperation.Fees.ToString() + " " + SenderAccount.CurrnecyInfo.CurrencySymbol;
            lblRequesStatus.Text = _ExternalTransferOperation.GetStatusText();
            lblTransactionTime.Text = _ExternalTransferOperation.RequestDate.ToString("hh:mm tt");
            lblDoneByUser.Text = _ExternalTransferOperation.UserInfo.Username;
            lblUserFullName.Text = _ExternalTransferOperation.UserInfo.PersonInfo.FullName;
            lblSendingDate.Text = _ExternalTransferOperation.RequestDate.ToString("dd-MMM-yyyy");
            lblArivalDate.Text = _ExternalTransferOperation.ArrivalDate.ToString("dd-MMM-yyyy");
        }

        private void frmShowExternalTransactionRowDetails_Load(object sender, EventArgs e)
        {
            _LoadExternalTransferOperationInfoOnTheForm();
        }
    }
}

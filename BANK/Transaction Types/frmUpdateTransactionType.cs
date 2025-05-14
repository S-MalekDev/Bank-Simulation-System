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
    public partial class frmUpdateTransactionType : Form
    {
        private clsTransactionTypes _TransactionType;
        private int _TransactionTypeID;
        public frmUpdateTransactionType(int TransactionTypeID)
        {
            InitializeComponent();
            _TransactionTypeID = TransactionTypeID;
        }

        private void _LoadTheServiceDataToTheForm()
        {
            _TransactionType = clsTransactionTypes.Find((clsTransactionTypes.enTransactionTypes)_TransactionTypeID);

            if (_TransactionType == null)
            {
                MessageBox.Show($"The transaction type with id = {_TransactionTypeID} is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text = $"[{_TransactionTypeID.ToString("D2")}]";
            tbName.Text = _TransactionType.Name;
            tbDescription.Text = _TransactionType.Description;
            tbFees.Text = _TransactionType.Fees.ToString();
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbName.Text))
            {
                errorProvider1.SetError(tbName, "The service name field is required!");
            }
            else errorProvider1.SetError(tbName, null);
        }

        private void tbDescription_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbDescription.Text))
            {
                errorProvider1.SetError(tbDescription, "The service description field is required!");
            }
            else errorProvider1.SetError(tbDescription, null);
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbFees.Text))
            {
                errorProvider1.SetError(tbFees, "The service fee field is required!");
            }
            else errorProvider1.SetError(tbFees, null);
        }


        private void _LoadUpdatedDataFromFormtoTheObject()
        {
            _TransactionType.Name = tbName.Text;
            _TransactionType.Description = tbDescription.Text;
            _TransactionType.Fees = Convert.ToDecimal(tbFees.Text);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadUpdatedDataFromFormtoTheObject();

            if (_TransactionType.Save())
            {
                MessageBox.Show("The data saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: saved data failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmUpdateTransactionType_Load(object sender, EventArgs e)
        {
            _LoadTheServiceDataToTheForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

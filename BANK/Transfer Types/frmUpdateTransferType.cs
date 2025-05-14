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
    public partial class frmUpdateTransferType : Form
    {
        public frmUpdateTransferType(int TransferTypeID)
        {
            InitializeComponent();
            _TransferTypeID = TransferTypeID;
        }
        private clsTransferTypes _TransferType;
        private int _TransferTypeID;


        private void _LoadTheServiceDataToTheForm()
        {
            _TransferType = clsTransferTypes.Find((clsTransferTypes.enTransferType)_TransferTypeID);

            if (_TransferType == null)
            {
                MessageBox.Show($"The transfer type with id = {_TransferTypeID} is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text = $"[{_TransferTypeID.ToString("D2")}]";
            tbName.Text = _TransferType.TransferName;
            tbDescription.Text = _TransferType.TransferDescription;
            tbFees.Text = _TransferType.TransferFees.ToString();
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSave.PerformClick();

            if ((e.KeyChar == (char)46 && !decimal.TryParse(tbFees.Text, out decimal amount)) || (e.KeyChar == (char)46 && tbFees.Text.Contains('.')))
            {
                e.Handled = true;
                return;
            }

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)46)
            {
                errorProvider1.SetError(tbFees, "You cann't enter letters, only digit are allowed.");
            }
            else errorProvider1.SetError(tbFees, null);

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
            _TransferType.TransferName = tbName.Text;
            _TransferType.TransferDescription = tbDescription.Text;
            _TransferType.TransferFees = Convert.ToDecimal(tbFees.Text);

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

            if (_TransferType.Save())
            {
                MessageBox.Show("The data saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: saved data failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmUpdateTransferType_Load(object sender, EventArgs e)
        {
            _LoadTheServiceDataToTheForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

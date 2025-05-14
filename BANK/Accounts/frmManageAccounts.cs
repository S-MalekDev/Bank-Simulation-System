using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class frmManageAccounts : Form
    {
        public frmManageAccounts()
        {
            InitializeComponent();
        }
        private DataTable dtAccountsList;
        private enum enFilter { None = 0, AccountNumber = 1, ClientID = 2, ClientFullName = 3, IsActive = 4 }
        
        private enFilter _SelectedFilter;

        private enum enIsActiveFilter { All = 0, Yes = 1, No = 2 }
        private enIsActiveFilter _SelectedIsActiveFilter;
        private void _GetAccountsList()
        {
            dtAccountsList = clsAccounts.GetAllAccounts();
            dgvAccountsList.DataSource = dtAccountsList;
        }
        private void _ShowCountAccounts()
        {
            lblNumberRecords.Text = dgvAccountsList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvAccountsList()
        {
            if (dgvAccountsList.ColumnCount > 0)
            {
                dgvAccountsList.Columns["Account No"].Width = 140;
                dgvAccountsList.Columns["Client ID"].Width = 140;
                dgvAccountsList.Columns["Client Full Name"].Width = 350;
                dgvAccountsList.Columns["Openning Date"].Width = 160;
                dgvAccountsList.Columns["Balance"].Width = 200;
                dgvAccountsList.Columns["Currency"].Width = 120;
                dgvAccountsList.Columns["Is Active"].Width = 140;
            }
        }
        private void _LoadAccountsList()
        {
            _GetAccountsList();
            _GetColumnsWidthModifications_dgvAccountsList();
            _ShowCountAccounts();
        }
        private void _RefreshAccountsList()
        {
            _LoadAccountsList();
        }
        private void _SelectTheDefaultFilters()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.None);
            cbIsActiveFilter.SelectedIndex = (byte)(_SelectedIsActiveFilter = enIsActiveFilter.All);
        }


        private void frmManageAccounts_Load(object sender, EventArgs e)
        {
            _LoadAccountsList();
            _SelectTheDefaultFilters();
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewAccountOrClient) != (int)clsGlobal.enUserPermissions.AddNewAccountOrClient)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewBankAccount frm = new frmAddNewBankAccount();
            frm.ShowDialog();
            _RefreshAccountsList();
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewAccountOrClient) != (int)clsGlobal.enUserPermissions.AddNewAccountOrClient)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewBankAccount frm = new frmAddNewBankAccount();
            frm.ShowDialog();
            _RefreshAccountsList();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowAccountDetails) != (int)clsGlobal.enUserPermissions.ShowAccountDetails)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowBankAccountInfo frm = new frmShowBankAccountInfo((int)dgvAccountsList.CurrentRow.Cells["Account No"].Value);
            frm.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshAccountsList();
            _SelectedFilter = (enFilter)(cbFilter.SelectedIndex);

            if (cbIsActiveFilter.Visible = (_SelectedFilter == enFilter.IsActive))
            {
                tbFilterText.Visible = false;
                return;
            }

            if (tbFilterText.Visible = (_SelectedFilter != enFilter.None) && (_SelectedFilter != enFilter.IsActive))
            {
                tbFilterText.Clear();
                tbFilterText.Focus();
                errorProvider1.Clear();
            }

        }


        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterText.Text))
            {
                _RefreshAccountsList();
                return;
            }


            if (_SelectedFilter == enFilter.AccountNumber)
            {
                dgvAccountsList.DataSource = clsAccounts.GetAccountsListByAccountNumberLikeTheNumber(tbFilterText.Text);
                _GetColumnsWidthModifications_dgvAccountsList();
            }
            else if (_SelectedFilter == enFilter.ClientID)
            {
                dgvAccountsList.DataSource = clsAccounts.GetAccountsListByClientIDLikeTheNumber(tbFilterText.Text);
                _GetColumnsWidthModifications_dgvAccountsList();
            }
            else //if(_SelectedFilter == enFilter.FullName//enFilter.Username)
            {
                dgvAccountsList.DataSource = dtAccountsList;
                dtAccountsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFilter.SelectedItem, tbFilterText.Text);
            }

            _ShowCountAccounts();
        }

        
        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_SelectedFilter != enFilter.AccountNumber && _SelectedFilter != enFilter.ClientID)
                return;

            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(tbFilterText, "You cann't enter letters, only digit are allowed.");
            }
            else
            {
                errorProvider1.SetError(tbFilterText, null);
            }
        }

      

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedIsActiveFilter = (enIsActiveFilter)cbIsActiveFilter.SelectedIndex;
            switch (_SelectedIsActiveFilter)
            {
                case enIsActiveFilter.All:
                    {
                        _RefreshAccountsList();
                        break;
                    }
                case enIsActiveFilter.Yes:
                    {
                        dtAccountsList.DefaultView.RowFilter = string.Format("[{0}] = 1", "Is Active");
                        break;
                    }
                case enIsActiveFilter.No:
                    {
                        dtAccountsList.DefaultView.RowFilter = string.Format("[{0}] = 0", "Is Active");
                        break;
                    }
            }
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.WithdrawProcess) != (int)clsGlobal.enUserPermissions.WithdrawProcess)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmWithdrawAndDepositTransactions frm = new frmWithdrawAndDepositTransactions
                (clsTransactionTypes.enTransactionTypes.Withdraw, (int)dgvAccountsList.CurrentRow.Cells["Account No"].Value);
            frm.ShowDialog();
            _RefreshAccountsList();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.DepositProcess) != (int)clsGlobal.enUserPermissions.DepositProcess)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmWithdrawAndDepositTransactions frm = new frmWithdrawAndDepositTransactions
                (clsTransactionTypes.enTransactionTypes.Deposit, (int)dgvAccountsList.CurrentRow.Cells["Account No"].Value);
            frm.ShowDialog();
            _RefreshAccountsList();
        }

        private void transferInternalyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.TransferInternally) != (int)clsGlobal.enUserPermissions.TransferInternally)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmInternalTransferOperation frm = new frmInternalTransferOperation((int)dgvAccountsList.CurrentRow.Cells["Account No"].Value);
            frm .ShowDialog();
            _RefreshAccountsList();
        }

        private void transferExternalyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.TransferExternally) != (int)clsGlobal.enUserPermissions.TransferExternally)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmExternalTransferOperations frm = new frmExternalTransferOperations((int)dgvAccountsList.CurrentRow.Cells["Account No"].Value);
            frm .ShowDialog();
            _RefreshAccountsList();
        }

        private void showClientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowClientInfo) != (int)clsGlobal.enUserPermissions.ShowClientInfo)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowClientInfo frm = new frmShowClientInfo((int)dgvAccountsList.CurrentRow.Cells["Client ID"].Value);
            frm.ShowDialog();
        }
    }
}

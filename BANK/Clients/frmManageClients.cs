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
    public partial class frmManageClients : Form
    {
        public frmManageClients()
        {
            InitializeComponent();
        }

        private DataTable dtClientsList;
        private enum enFilter { None = 0, ClientID = 1, PersonID = 2, AccountNo = 3, ClientFullName = 4, Nationality = 5 }
        private enFilter _SelectedFilter;

        private void _GetClientsList()
        {
            dtClientsList = clsClients.GetAllClients();
            dgvClientsList.DataSource = dtClientsList;
        }
        private void _ShowCountClients()
        {
            lblNumberRecords.Text = dgvClientsList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvClientsList()
        {
            if (dgvClientsList.ColumnCount > 0)
            {
                dgvClientsList.Columns["Client ID"].Width = 100;
                dgvClientsList.Columns["Person ID"].Width = 120;
                dgvClientsList.Columns["Client Full Name"].Width = 350;
                dgvClientsList.Columns["Nationality"].Width = 140;
                dgvClientsList.Columns["Joining Date"].Width = 160;
                dgvClientsList.Columns["Account No"].Width = 120;
                dgvClientsList.Columns["Account Currency"].Width = 180;
                dgvClientsList.Columns["Email"].Width = 300;
                dgvClientsList.Columns["Phone"].Width = 180;
            }
        }
        private void _LoadClientsList()
        {
            _GetClientsList();
            _GetColumnsWidthModifications_dgvClientsList();
            _ShowCountClients();
        }
        private void _RefreshClientsList()
        {
            _LoadClientsList();
        }
        private void _SelectTheDefaultFilters()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.None);
        }

        private void frmManageClients_Load(object sender, EventArgs e)
        {
            _LoadClientsList();
            _SelectTheDefaultFilters();
        }
        //---------------------------------------------------------

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshClientsList();
            _SelectedFilter = (enFilter)(cbFilter.SelectedIndex);


            if (tbFilterText.Visible = (_SelectedFilter != enFilter.None))
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
                _RefreshClientsList();
                return;
            }


            if (_SelectedFilter == enFilter.ClientID || _SelectedFilter == enFilter.PersonID || _SelectedFilter == enFilter.AccountNo)
            {
                dgvClientsList.DataSource = clsClients.GetClientsListByColumnAndTextLike(cbFilter.SelectedItem.ToString(), tbFilterText.Text);
                _GetColumnsWidthModifications_dgvClientsList();
            }
            else //if(_SelectedFilter == enFilter.ClientFullName// enFilter.Nationality)
            {
                dgvClientsList.DataSource = dtClientsList;
                dtClientsList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFilter.SelectedItem, tbFilterText.Text);
            }

            _ShowCountClients();
        }


        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_SelectedFilter != enFilter.ClientID && _SelectedFilter != enFilter.PersonID && _SelectedFilter != enFilter.AccountNo)
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



        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Send email is not allowed!", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CallPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Phone call is not allowed!", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowClientInfo) != (int)clsGlobal.enUserPermissions.ShowClientInfo)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowClientInfo frm = new frmShowClientInfo((int)dgvClientsList.CurrentRow.Cells["Client ID"].Value);
            frm.ShowDialog();
        }

        private void BankAccountDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowAccountDetails) != (int)clsGlobal.enUserPermissions.ShowAccountDetails)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowBankAccountInfo frm = new frmShowBankAccountInfo((int)dgvClientsList.CurrentRow.Cells["Account No"].Value);
            frm.ShowDialog();
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
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
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
            _RefreshClientsList();
        }

        private void updateClientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.UpdateClientInfo) != (int)clsGlobal.enUserPermissions.UpdateClientInfo)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson((int)dgvClientsList.CurrentRow.Cells["Person ID"].Value);
            frm.ShowDialog();
        }
    }
}

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
    public partial class frmManageTransactionTypes : Form
    {
        public frmManageTransactionTypes()
        {
            InitializeComponent();
        }

        private DataTable dtTransactionTypesList;
        private void _GetTransactionTypesList()
        {
            dtTransactionTypesList = clsTransactionTypes.GetAllTransactionTypes();
            dgvTransactionTypesList.DataSource = dtTransactionTypesList;
        }
        private void _ShowCountTransactionTypes()
        {
            lblNumberRecords.Text = dgvTransactionTypesList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvTransactionTypesList()
        {
            if (dgvTransactionTypesList.ColumnCount > 0)
            {
                dgvTransactionTypesList.Columns["ID"].Width = 80;
                dgvTransactionTypesList.Columns["Transaction Name"].Width = 200;
                dgvTransactionTypesList.Columns["Description"].Width = 517;
                dgvTransactionTypesList.Columns["Fees"].Width = 120;
            }
        }
        private void _LoadTransactionTypesList()
        {
            _GetTransactionTypesList();
            _GetColumnsWidthModifications_dgvTransactionTypesList();
            _ShowCountTransactionTypes();
        }
        private void _RefreshTransactionTypesList()
        {
            _LoadTransactionTypesList();
        }

        private void frmManageTransactionTypes_Load(object sender, EventArgs e)
        {
            _LoadTransactionTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmUpdateTransactionType frm = new frmUpdateTransactionType((int)dgvTransactionTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageTransactionTypes_Load(null, null);
        }
    }
}

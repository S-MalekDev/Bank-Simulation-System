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
    public partial class frmManageTransferTypes : Form
    {
        public frmManageTransferTypes()
        {
            InitializeComponent();
        }
        private DataTable dtTransferTypesList;
        private void _GetTransactionTypesList()
        {
            dtTransferTypesList = clsTransferTypes.GetAllTransferTypes();
            dgvTransferTypesList.DataSource = dtTransferTypesList;
        }
        private void _ShowCountTransferTypes()
        {
            lblNumberRecords.Text = dgvTransferTypesList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvTransferTypesList()
        {
            if (dgvTransferTypesList.ColumnCount > 0)
            {
                dgvTransferTypesList.Columns["ID"].Width = 80;
                dgvTransferTypesList.Columns["Transfer Name"].Width = 200;
                dgvTransferTypesList.Columns["Description"].Width = 517;
                dgvTransferTypesList.Columns["Fees"].Width = 120;
            }
        }
        private void _LoadTransferTypesList()
        {
            _GetTransactionTypesList();
            _GetColumnsWidthModifications_dgvTransferTypesList();
            _ShowCountTransferTypes();
        }
        private void _RefreshTransferTypesList()
        {
            _LoadTransferTypesList();
        }
        private void frmManageTransferTypes_Load(object sender, EventArgs e)
        {
            _LoadTransferTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTransferType frm = new frmUpdateTransferType(Convert.ToInt32(dgvTransferTypesList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            frmManageTransferTypes_Load(null,null);
        }
    }
}

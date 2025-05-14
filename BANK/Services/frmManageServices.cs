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
    public partial class frmManageServices : Form
    {
        public frmManageServices()
        {
            InitializeComponent();
        }

        private DataTable dtServicesList;
        private void _GetSercicesList()
        {
            dtServicesList = clsServices.GetAllServices();
            dgvServicesList.DataSource = dtServicesList;
        }
        private void _ShowCountServices()
        {
            lblNumberRecords.Text = dgvServicesList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvServicesList()
        {
            if (dgvServicesList.ColumnCount > 0)
            {
                dgvServicesList.Columns["ID"].Width = 80;
                dgvServicesList.Columns["Title"].Width = 200;
                dgvServicesList.Columns["Description"].Width = 517;
                dgvServicesList.Columns["Fees"].Width = 120;
            }
        }
        private void _LoadServicesList()
        {
            _GetSercicesList();
            _GetColumnsWidthModifications_dgvServicesList();
            _ShowCountServices();
        }
        private void _RefreshServicesList()
        {
            _LoadServicesList();
        }

        private void frmManageServices_Load(object sender, EventArgs e)
        {
            _LoadServicesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmUpdateService frm = new frmUpdateService((int)dgvServicesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageServices_Load(null,null);
        }
    }
}

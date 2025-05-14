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
    public partial class frmManagePeople : Form
    {
        private DataTable dtPeopleList;
        private enum enFilter { None = 0, ID = 1, NationalNo = 2, FirstName = 3 }
        private enFilter _SelectedFilter;
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _GetPeopleList()
        {
            dtPeopleList = clsPeople.GetAllPeople();
            dgvPeopleList.DataSource = dtPeopleList;
        }
        private void _ShowCountPeople()
        {
            lblNumberRecords.Text = dgvPeopleList.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvPeopleList()
        {
            if (dgvPeopleList.ColumnCount > 0)
            {
                dgvPeopleList.Columns["ID"].Width = 100;
                dgvPeopleList.Columns["National No"].Width = 140;
                dgvPeopleList.Columns["First Name"].Width = 150;
                dgvPeopleList.Columns["Med Name"].Width = 150;
                dgvPeopleList.Columns["Last Name"].Width = 150;
                dgvPeopleList.Columns["Gendor"].Width = 100;
                dgvPeopleList.Columns["Date Of Birth"].Width = 160;
                dgvPeopleList.Columns["Nationality"].Width = 200;
            }
        }
        private void _LoadPeopleList()
        {
            _GetPeopleList();
            _GetColumnsWidthModifications_dgvPeopleList();
            _ShowCountPeople();
        }
        private void _RefreshPeopleList()
        {
            _LoadPeopleList();
        }
        private void _SelectTheDefaultFilter()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.None);
        }



        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadPeopleList();
            _SelectTheDefaultFilter();
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedFilter = (enFilter)(cbFilter.SelectedIndex);

            if (tbFilterText.Visible = (_SelectedFilter != enFilter.None))
            {
                tbFilterText.Clear();
                tbFilterText.Focus();
                errorProvider1.Clear();
            }
            else
            {
                _RefreshPeopleList();
            }
        }


        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbFilterText.Text))
            {
                _RefreshPeopleList();
                return;
            }


            if(_SelectedFilter == enFilter.ID)
            {
                dgvPeopleList.DataSource = clsPeople.GetPeopleListByPersonIDLikeTheNumber(tbFilterText.Text);
                _GetColumnsWidthModifications_dgvPeopleList();
            }
            else //if (_SelectedFilter == enFilter.Email // Phone // First Name// National NO)
            {
                dgvPeopleList.DataSource = dtPeopleList;
                dtPeopleList.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",cbFilter.SelectedItem, tbFilterText.Text);
            }

            _ShowCountPeople();
        }


        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_SelectedFilter != enFilter.ID)
                return;


            if(e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                errorProvider1.SetError(tbFilterText, "You cann't enter letters, only digit are allowed.");
            }
            else
            {
                errorProvider1.SetError(tbFilterText, null);
            }
        }


        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewPerson) != (int)clsGlobal.enUserPermissions.AddNewPerson)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewPerson) != (int)clsGlobal.enUserPermissions.AddNewPerson)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson();
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.UpdatePerson) != (int)clsGlobal.enUserPermissions.UpdatePerson)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson((int)dgvPeopleList.CurrentRow.Cells["ID"].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowPersonInfo) != (int)clsGlobal.enUserPermissions.ShowPersonInfo)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowPersonInfo frm = new frmShowPersonInfo((int)dgvPeopleList.CurrentRow.Cells["ID"].Value);
            frm.ShowDialog();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.DeletePerson) != (int)clsGlobal.enUserPermissions.DeletePerson)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int PersonID = (int)dgvPeopleList.CurrentRow.Cells["ID"].Value;
            clsPeople Person = clsPeople.Find(PersonID);

            if(Person == null)
            {
                MessageBox.Show($"The person with id = {PersonID} is not found", ""
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _RefreshPeopleList();
                return;
            }

            if(MessageBox.Show($"Are you sure you want to delete the person with id = {PersonID} ?", "Confermed delete"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string PersonImagePath = Person.ImagePath;
                if(Person.Delete())
                {
                    clsUtil.DeleteFile(PersonImagePath);
                    MessageBox.Show($"The person with id = {PersonID} is deleted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show($"The person with id = {PersonID} is linked with another data in the system, you cann't deleted!"
                        , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void openNewBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
               &&
               (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AddNewAccountOrClient) != (int)clsGlobal.enUserPermissions.AddNewAccountOrClient)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clsAccounts.IsAccountExistByPersonID((int)dgvPeopleList.CurrentRow.Cells["ID"].Value))
            {
                MessageBox.Show("The person selected has already an account!", "Not allowed"
                     , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmAddNewBankAccount frm = new frmAddNewBankAccount((int)dgvPeopleList.CurrentRow.Cells["ID"].Value);
            frm.ShowDialog();
        }

        private void cmsPeopleList_Opening(object sender, CancelEventArgs e)
        {
            openNewBankAccountToolStripMenuItem.Enabled = !clsAccounts.IsAccountExistByPersonID((int)dgvPeopleList.CurrentRow.Cells["ID"].Value);
        }
    }
}

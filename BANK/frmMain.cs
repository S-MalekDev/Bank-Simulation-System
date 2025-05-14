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
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frmlogin)
        {
            InitializeComponent();
            _frmLogin= frmlogin;
        }

        private void amsPeople_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.PeopleListView) != (int)clsGlobal.enUserPermissions.PeopleListView)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.UsersListView) != (int)clsGlobal.enUserPermissions.UsersListView)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }




        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private enum enCloseType { CloseForm = 0, LogOut = 1 } 
        private enCloseType _SlectedCloseType = enCloseType.CloseForm;
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_SlectedCloseType == enCloseType.CloseForm)
            {
                _frmLogin.Close();
            }
        }

        private void loginOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _SlectedCloseType = enCloseType.LogOut;

            this.Close();
            _frmLogin.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.AccountsListView) != (int)clsGlobal.enUserPermissions.AccountsListView)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManageAccounts frm = new frmManageAccounts();
            frm.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ClientsListView) != (int)clsGlobal.enUserPermissions.ClientsListView)
            {
                MessageBox.Show("You don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmManageClients frm = new frmManageClients();
            frm.ShowDialog();
        }

        private void withdrawDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if user doesn't have a permission to withdraw process that means that he also doesn't have a permission to deposit process.
            if(clsGlobal.CurrentUser.Permissions == -1 
                ||

                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.WithdrawProcess) == (int)clsGlobal.enUserPermissions.WithdrawProcess
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.DepositProcess) == (int)clsGlobal.enUserPermissions.DepositProcess)
            {
                frmWithdrawAndDepositTransactions frm = new frmWithdrawAndDepositTransactions();
                frm.ShowDialog();
            }

            else
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
               
        }

        private void internalTransferOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions &(int) clsGlobal.enUserPermissions.TransferInternally)!= (int)clsGlobal.enUserPermissions.TransferInternally)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            frmInternalTransferOperation frm = new frmInternalTransferOperation();
            frm.ShowDialog();
        }

        private void externalTransferOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.TransferExternally) != (int)clsGlobal.enUserPermissions.TransferExternally)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                frmExternalTransferOperations frm = new frmExternalTransferOperations();
            frm.ShowDialog();
        }

        private void balanceStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ShowClientHistory) != (int)clsGlobal.enUserPermissions.ShowClientHistory)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmClientHistory frm = new frmClientHistory();
            frm.ShowDialog();
        }

        private void manageServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ManageServices) != (int)clsGlobal.enUserPermissions.ManageServices)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmManageServices frm = new frmManageServices();
            frm.ShowDialog();
        }

        private void manageTransactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ManageTransactionTypes) != (int)clsGlobal.enUserPermissions.ManageTransactionTypes)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManageTransactionTypes frm = new frmManageTransactionTypes();
            frm.ShowDialog();

        }

        private void manageTransferTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.ManageTransferTypes) != (int)clsGlobal.enUserPermissions.ManageTransferTypes)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmManageTransferTypes frm = new frmManageTransferTypes();
            frm.ShowDialog();
        }
    }
}

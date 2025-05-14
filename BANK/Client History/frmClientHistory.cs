using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK
{
    public partial class frmClientHistory: Form
    {
        private Nullable<int> SelectedClientID = null;
        enum enFilterWithdrawDeposite { None = 0, ID = 1, TransactionType = 2, Amount =3, Date = 4 }
        private enFilterWithdrawDeposite _enFilterWithdrawDeposite;
        enum enFilterTransactionTypes { All = 0, Withdraw = 1,Deposit = 2 }
        private enFilterTransactionTypes _enFilterTransactionType;

        enum enFilterExternalTransactions { None = 0, ID = 1, Amount = 2, Date = 3, Status = 4 }
        private enFilterExternalTransactions _enFilterExternalTransactions;

        enum enFilterStatus{All = 0, New = 1, Canceled = 2, Completed = 3 }
        private enFilterStatus _enFilterStatus;
        enum enFilterInternalTransactions { None = 0, ID = 1, Amount = 2, Date = 3, IsSucceeded = 4 }
        private enFilterInternalTransactions _enFilterInternalTransactions;
        enum enFilterIsSucceeded { All = 0, Yes = 1, No = 2 }
        private enFilterIsSucceeded _enFilterIsSucceeded;
        public frmClientHistory()
        {
            InitializeComponent();
        }

        private DataTable dtSelectedClientWithdrawDepositData;
        private DataTable dtSelectedClientInternalTransactionsData;
        private DataTable dtSelectedClientExternalTransactionsData;

        //--Withdraw And Deposite Private Methodes
        private void _ShowWithdrawDepositeClientHistoryData()
        {
            dgvWithdrawDepositTransactions.DataSource = dtSelectedClientWithdrawDepositData;
        }
        private void _ShowCountRows_WithdrawDepositTransactions()
        {
            lblWithdrawDepositTransactionsNumberRows.Text = dgvWithdrawDepositTransactions.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvWithdrawDepositTransactions()
        {
            if (dgvWithdrawDepositTransactions.ColumnCount > 0)
            {
                dgvWithdrawDepositTransactions.Columns["ID"].Width = 100;
                dgvWithdrawDepositTransactions.Columns["Transaction Type"].Width = 180;
                dgvWithdrawDepositTransactions.Columns["Amount"].Width = 267;
                dgvWithdrawDepositTransactions.Columns["Date"].Width = 140;
                dgvWithdrawDepositTransactions.Columns["Time"].Width = 80;    
            }
        }
        private void _GetWithdrawDepositeDataFromDataBase()
        {
            if (!SelectedClientID.HasValue)
                return;

            dtSelectedClientWithdrawDepositData = clsWithdrawAndDepositOperations.GetAllWithdrawAndDepositOperations(Convert.ToInt32(SelectedClientID));
        }
        private void _LoadWithdrawDepositClientHistoryList()
        {
            _GetWithdrawDepositeDataFromDataBase();
            _ShowWithdrawDepositeClientHistoryData();
            _GetColumnsWidthModifications_dgvWithdrawDepositTransactions();
            _ShowCountRows_WithdrawDepositTransactions();
            _GetDefaultFilterWithdrawDeposite();
        }
        private void _GetDefaultFilterWithdrawDeposite()
        {
            cbFilterWithdrawDeposit.SelectedItem = null;
            cbFilterWithdrawDeposit.SelectedIndex = (int)enFilterWithdrawDeposite.None;
        }
        private void _RefreshTbFilterWithdrawDeposite()
        {
            tbFilterTextWithdrawDeposit.Clear();
            tbFilterTextWithdrawDeposit.Focus();
        }
        private void _RefreshWithdrawDepositeDataGridView()
        {
            _GetWithdrawDepositeDataFromDataBase();       
            _ShowWithdrawDepositeClientHistoryData();
            _GetColumnsWidthModifications_dgvWithdrawDepositTransactions();
            _ShowCountRows_WithdrawDepositTransactions();
        }
        private void _GetDefaultFilterTransactionType_WithdrawDeposit()
        {
            cbTransactionTypesFilterWithdrawDeposit.SelectedIndex = (int)(_enFilterTransactionType = enFilterTransactionTypes.All);
        }

        //__Internal Transfer Operations Private Methodes
        private void _ShowInternalTransferOperationsClientHistoryData()
        {
            dgvInternalTransferTransactions.DataSource = dtSelectedClientInternalTransactionsData;
        }
        private void _ShowCountRows_InternalTransferOperations()
        {
            lblInternalOperationsNumberRows.Text = dgvInternalTransferTransactions.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvInternalTransferTransactions()
        {
            if (dgvInternalTransferTransactions.ColumnCount > 0)
            {
                dgvInternalTransferTransactions.Columns["ID"].Width = 100;
                dgvInternalTransferTransactions.Columns["Amount"].Width = 267;
                dgvInternalTransferTransactions.Columns["Date"].Width = 140;
                dgvInternalTransferTransactions.Columns["Time"].Width = 80;
                dgvInternalTransferTransactions.Columns["Is Succeeded"].Width = 180;
            }
        }
        private void _GetInternalTransactionsDataFromDataBase()
        {
            if (!SelectedClientID.HasValue)
                return;

            dtSelectedClientInternalTransactionsData = clsInternalTransferOperations.GetAllInternalTransferOperations(Convert.ToInt32(SelectedClientID));
        }
        private void _LoadInternalTransferOperationsClientHistoryList()
        {
            _GetInternalTransactionsDataFromDataBase();
            _ShowInternalTransferOperationsClientHistoryData();
            _GetColumnsWidthModifications_dgvInternalTransferTransactions();
            _ShowCountRows_InternalTransferOperations();
            _GetDefaultFilterInternalTransactions();
        }
        private void _GetDefaultFilterInternalTransactions()
        {
            cbInternalTransactions.SelectedItem = null;
            cbInternalTransactions.SelectedIndex = (int)enFilterInternalTransactions.None;
        }
        private void _RefreshTbFilterInternalTransactions()
        {
            tbFilterInternalTransactions.Clear();
            tbFilterInternalTransactions.Focus();
        }
        private void _GetDefaultFilterIsSucceeded_InternalTransactions()
        {
            cbIsSucceededFilterInternalTransactions.SelectedIndex = (int)(_enFilterIsSucceeded = enFilterIsSucceeded.All);
        }
        private void _RefreshInternalTransactionsDataGridView()
        {
            _GetInternalTransactionsDataFromDataBase();
            _ShowInternalTransferOperationsClientHistoryData();
            _GetColumnsWidthModifications_dgvInternalTransferTransactions();
            _ShowCountRows_InternalTransferOperations();
        }


        //--External Transfer Operation Private Methodes
        private void _ShowExternalTransferOperationsClientHistoryData()
        {
            dgvExternalTransferTransactions.DataSource = dtSelectedClientExternalTransactionsData;
        }
        private void _ShowCountRows_ExternalTransferOperations()
        {
            lblExternalOperationsNumberRows.Text = dgvExternalTransferTransactions.RowCount.ToString("D2");
        }
        private void _GetColumnsWidthModifications_dgvExternalTransferTransactions()
        {
            if (dgvExternalTransferTransactions.ColumnCount > 0)
            {
                dgvExternalTransferTransactions.Columns["ID"].Width = 100;
                dgvExternalTransferTransactions.Columns["Amount"].Width = 267;
                dgvExternalTransferTransactions.Columns["Date"].Width = 140;
                dgvExternalTransferTransactions.Columns["Time"].Width = 80;
                dgvExternalTransferTransactions.Columns["Status"].Width = 180;
            }
        }
        private void _GetExternalTransactionsDataFromDataBase()
        {
            if (!SelectedClientID.HasValue)
                return;

            dtSelectedClientExternalTransactionsData = clsExternalTransferOperations.GetAllExternalTransferOperations(Convert.ToInt32(SelectedClientID));
        }
        private void _LoadExternalTransferOperationsClientHistoryList()
        {
            _GetExternalTransactionsDataFromDataBase();
            _ShowExternalTransferOperationsClientHistoryData();
            _GetColumnsWidthModifications_dgvExternalTransferTransactions();
            _ShowCountRows_ExternalTransferOperations();
            _GetDefaultFilterExternalTransactions();


        }
        private void _GetDefaultFilterExternalTransactions()
        {
            cbExternalTransactions.SelectedItem = null;
            cbExternalTransactions.SelectedIndex = (int)enFilterExternalTransactions.None;
        }
        private void _RefreshTbFilterExternalTransactions()
        {
            tbFilterExternalTransactions.Clear();
            tbFilterExternalTransactions.Focus();
        }
        private void _GetDefaultFilterStatus_ExternalTransactions()
        {
            cbStatusFilterExternalTransactions.SelectedIndex = (int)(_enFilterStatus = enFilterStatus.All);
        }
        private void _RefreshExternalTransactionsDataGridView()
        {
            _GetExternalTransactionsDataFromDataBase();
            _ShowExternalTransferOperationsClientHistoryData();
            _GetColumnsWidthModifications_dgvExternalTransferTransactions();
            _ShowCountRows_ExternalTransferOperations();
        }

        //-------------
        private void _SelectDefaultFilters()
        {
            _GetDefaultFilterWithdrawDeposite();
            _GetDefaultFilterInternalTransactions();
            _GetDefaultFilterExternalTransactions();
        }
        private void _GetDefaultDateTimePickersValue()
        {
            DateTime Today = DateTime.Now;
            dtpTimeFilterWithdrawDeposit.Value = dtpTimeFilterWithdrawDeposit.MaxDate = Today;
            dtpTimeFilterExternalTransactions.Value = dtpTimeFilterExternalTransactions.MaxDate = Today;
            dtpTimeFilterInternalTransactions.Value = dtpTimeFilterInternalTransactions.MaxDate = Today;
        }
        private void _GetDifferentColorToButtonActivated()
        {
            btnWithdrawDepositeType.BackColor = Color.FromArgb(91, 250, 252);
            btnInternalTransferType.BackColor = Color.FromArgb(91, 250, 252);
            btnExternalHistoryType.BackColor = Color.FromArgb(91, 250, 252);


            if (tcClientHistory.SelectedTab == tcClientHistory.TabPages["tpWithdrawDeposit"])
            {
                btnWithdrawDepositeType.BackColor = Color.FromArgb(11, 164, 218);
                return;
            }


            if(tcClientHistory.SelectedTab == tcClientHistory.TabPages["tpInternalTransfer"])
            {
                btnInternalTransferType.BackColor = Color.FromArgb(11, 164, 218);
                return;
            }

            if(tcClientHistory.SelectedTab == tcClientHistory.TabPages["tpExternalTransfer"])
            {
                btnExternalHistoryType.BackColor = Color.FromArgb(11, 164, 218);
                return;
            }
        }
        private void _SelectDefaultHistoryPage()
        {
            tcClientHistory.SelectedTab = null;
            tcClientHistory.SelectedTab = tcClientHistory.TabPages["tpWithdrawDeposit"];
            
        }

        //-------------
        private void frmClientHistory_Load(object sender, EventArgs e)
        {
            _SelectDefaultFilters();
            _SelectDefaultHistoryPage();
        }

        private void btnWithdrawDepositeType_Click(object sender, EventArgs e)
        {
            _GetDefaultFilterWithdrawDeposite();

            tcClientHistory.SelectedTab = tcClientHistory.TabPages["tpWithdrawDeposit"];
        }

        private void btnInternalTransferType_Click(object sender, EventArgs e)
        {
            _GetDefaultFilterInternalTransactions();

            tcClientHistory.SelectedTab = tcClientHistory.TabPages["tpInternalTransfer"];
        }

        private void btnExternalHistoryType_Click(object sender, EventArgs e)
        {
            _GetDefaultFilterExternalTransactions();

            tcClientHistory.SelectedTab = tcClientHistory.TabPages["tpExternalTransfer"];
        }

        private void ctrlShowFullBankAccountInfobyFilter1_OnAccountSelected(int obj)
        {
            SelectedClientID = ctrlShowFullBankAccountInfobyFilter1.AccountInfo.ClientID;
            _LoadWithdrawDepositClientHistoryList();
            _LoadInternalTransferOperationsClientHistoryList();
            _LoadExternalTransferOperationsClientHistoryList();
        }

        private void frmClientHistory_Activated(object sender, EventArgs e)
        {
            ctrlShowFullBankAccountInfobyFilter1.FilterTextBoxFocus();
        }

        private void cbFilterWithdrawDeposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterWithdrawDeposite = (enFilterWithdrawDeposite)cbFilterWithdrawDeposit.SelectedIndex;

            tbFilterTextWithdrawDeposit.Visible = (_enFilterWithdrawDeposite == enFilterWithdrawDeposite.Amount || _enFilterWithdrawDeposite == enFilterWithdrawDeposite.ID);
            cbTransactionTypesFilterWithdrawDeposit.Visible = _enFilterWithdrawDeposite == enFilterWithdrawDeposite.TransactionType;
            dtpTimeFilterWithdrawDeposit.Visible = _enFilterWithdrawDeposite == enFilterWithdrawDeposite.Date;

            errorProvider1.SetError(tbFilterTextWithdrawDeposit, null);

            _RefreshWithdrawDepositeDataGridView();

            switch (_enFilterWithdrawDeposite)
            {
                case enFilterWithdrawDeposite.None:
                    {
                        
                        break;
                    }
                case enFilterWithdrawDeposite.ID:
                    {
                        _RefreshTbFilterWithdrawDeposite();
                        break;
                    }
                case enFilterWithdrawDeposite.Amount:
                    {
                        _RefreshTbFilterWithdrawDeposite();
                        break;
                    }
                case enFilterWithdrawDeposite.TransactionType:
                    {
                        _GetDefaultFilterTransactionType_WithdrawDeposit();
                        break;
                    }
                case enFilterWithdrawDeposite.Date:
                    {
                        _GetDefaultDateTimePickersValue();
                        break;
                    }
            }
        }

        private void cbExternalTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterExternalTransactions = (enFilterExternalTransactions)cbExternalTransactions.SelectedIndex;

            tbFilterExternalTransactions.Visible = (_enFilterExternalTransactions == enFilterExternalTransactions.Amount || _enFilterExternalTransactions == enFilterExternalTransactions.ID);
            cbStatusFilterExternalTransactions.Visible = _enFilterExternalTransactions == enFilterExternalTransactions.Status;
            dtpTimeFilterExternalTransactions.Visible = _enFilterExternalTransactions == enFilterExternalTransactions.Date;

            errorProvider1.SetError(tbFilterExternalTransactions, null);

            _RefreshExternalTransactionsDataGridView();

            switch (_enFilterExternalTransactions)
            {
                case enFilterExternalTransactions.None:
                    {
                        
                        break;
                    }
                case enFilterExternalTransactions.ID:
                    {
                        _RefreshTbFilterExternalTransactions();
                        break;
                    }
                case enFilterExternalTransactions.Amount:
                    {
                        _RefreshTbFilterExternalTransactions();
                        break;
                    }
                case enFilterExternalTransactions.Date:
                    {
                        _GetDefaultDateTimePickersValue();
                        break;
                    }
                case enFilterExternalTransactions.Status:
                    {
                        _GetDefaultFilterStatus_ExternalTransactions();
                        break;
                    }
            }
        }

        private void cbInternalTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterInternalTransactions = (enFilterInternalTransactions)cbInternalTransactions.SelectedIndex;

            tbFilterInternalTransactions.Visible = (_enFilterInternalTransactions == enFilterInternalTransactions.Amount || _enFilterInternalTransactions == enFilterInternalTransactions.ID);
            cbIsSucceededFilterInternalTransactions.Visible = _enFilterInternalTransactions == enFilterInternalTransactions.IsSucceeded;
            dtpTimeFilterInternalTransactions.Visible = _enFilterInternalTransactions == enFilterInternalTransactions.Date;

            errorProvider1.SetError(tbFilterInternalTransactions, null);

            _RefreshInternalTransactionsDataGridView();

            switch (_enFilterInternalTransactions)
            {
                case enFilterInternalTransactions.None:
                    {
                        break;
                    }
                case enFilterInternalTransactions.ID:
                    {
                        _RefreshTbFilterInternalTransactions();
                        break;
                    }
                case enFilterInternalTransactions.Amount:
                    {
                        _RefreshTbFilterInternalTransactions();
                        break;
                    }
                case enFilterInternalTransactions.Date:
                    {
                        _GetDefaultDateTimePickersValue();
                        break;
                    }
                case enFilterInternalTransactions.IsSucceeded:
                    {
                        _GetDefaultFilterIsSucceeded_InternalTransactions();
                        break;
                    }
            }
        }

        private void tbFilterTextWithdrawDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(_enFilterWithdrawDeposite)
            {
                case enFilterWithdrawDeposite.ID:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                        break;
                    }
                case enFilterWithdrawDeposite.Amount:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar)
                                 && 
                                     !char.IsDigit(e.KeyChar) 
                                 &&
                                     (e.KeyChar != '.' 
                                            || 
                                     (e.KeyChar == '.' && tbFilterTextWithdrawDeposit.Text.Contains('.'))));
                        break;
                    }
            }

            if (e.Handled == true) errorProvider1.SetError(tbFilterTextWithdrawDeposit, "The field allows only digits.");
            else errorProvider1.SetError(tbFilterTextWithdrawDeposit, null);

        }

        private void tbFilterTextWithdrawDeposit_MouseDown(object sender, MouseEventArgs e)
        {
            tbFilterTextWithdrawDeposit.SelectAll();
        }

        private void tbFilterInternalTransactions_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (_enFilterInternalTransactions)
            {
                case enFilterInternalTransactions.ID:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                        break;
                    }
                case enFilterInternalTransactions.Amount:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar)
                                 &&
                                     !char.IsDigit(e.KeyChar)
                                 &&
                                     (e.KeyChar != '.'
                                            ||
                                     (e.KeyChar == '.' && tbFilterInternalTransactions.Text.Contains('.'))));
                        break;
                    }
            }

            if (e.Handled == true) errorProvider1.SetError(tbFilterInternalTransactions, "The field allows only digits.");
            else errorProvider1.SetError(tbFilterInternalTransactions, null);
        }

        private void tbFilterInternalTransactions_MouseDown(object sender, MouseEventArgs e)
        {
            tbFilterInternalTransactions.SelectAll();
        }
        
        private void tbFilterExternalTransactions_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (_enFilterExternalTransactions)
            {
                case enFilterExternalTransactions.ID:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                        break;
                    }
                case enFilterExternalTransactions.Amount:
                    {
                        e.Handled = (!char.IsControl(e.KeyChar)
                                 &&
                                     !char.IsDigit(e.KeyChar)
                                 &&
                                     (e.KeyChar != '.'
                                            ||
                                     (e.KeyChar == '.' && tbFilterExternalTransactions.Text.Contains('.'))));
                        break;
                    }
            }

            if (e.Handled == true) errorProvider1.SetError(tbFilterExternalTransactions, "The field allows only digits.");
            else errorProvider1.SetError(tbFilterExternalTransactions, null);
        }

        private void tbFilterExternalTransactions_MouseDown(object sender, MouseEventArgs e)
        {
            tbFilterExternalTransactions.SelectAll();
        }

        private void tcClientHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _GetDifferentColorToButtonActivated();
        }

        private void cbTransactionTypesFilterWithdrawDeposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterTransactionType = (enFilterTransactionTypes)cbTransactionTypesFilterWithdrawDeposit.SelectedIndex;

            if (dtSelectedClientWithdrawDepositData== null) return;

            switch(_enFilterTransactionType)
            {
                case enFilterTransactionTypes.All:
                    {
                        dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = "";
                        
                        break;
                    }
                case enFilterTransactionTypes.Withdraw:
                    {
                        dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = "[Transaction Type] = 'Withdraw'";
                        break;
                    }
                case enFilterTransactionTypes.Deposit:
                    {
                        dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = "[Transaction Type] = 'Deposit'";
                        break;
                    }
            }

            _ShowCountRows_WithdrawDepositTransactions();
        }

        private void cbIsSucceededFilterInternalTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterIsSucceeded = (enFilterIsSucceeded)cbIsSucceededFilterInternalTransactions.SelectedIndex;

            if (dtSelectedClientInternalTransactionsData == null) return;

            switch (_enFilterIsSucceeded)
            {
                case enFilterIsSucceeded.All:
                    {
                        dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = "";

                        break;
                    }
                case enFilterIsSucceeded.Yes:
                    {
                        dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = "[Is Succeeded] = 'Succeeded'";
                        break;
                    }
                case enFilterIsSucceeded.No:
                    {
                        dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = "[Is Succeeded] = 'Failed'";
                        break;
                    }
            }

            _ShowCountRows_InternalTransferOperations();
        }

        private void cbStatusFilterExternalTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _enFilterStatus = (enFilterStatus)cbStatusFilterExternalTransactions.SelectedIndex;

            if (dtSelectedClientExternalTransactionsData == null) return;

            switch (_enFilterStatus)
            {
                case enFilterStatus.All:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = "";

                        break;
                    }
                case enFilterStatus.New:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = "[Status] = 'New'";
                        break;
                    }
                case enFilterStatus.Canceled:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = "[Status] = 'Canceled'";
                        break;
                    }
                case enFilterStatus.Completed:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = "[Status] = 'Completed'";
                        break;
                    }
            }

            _ShowCountRows_ExternalTransferOperations();
        }

        private void dtpTimeFilterExternalTransactions_ValueChanged(object sender, EventArgs e)
        {
            if(dtSelectedClientExternalTransactionsData.Rows.Count == 0) return;

            DateTime SelectedDate = dtpTimeFilterExternalTransactions.Value;
            dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = $"Date = '{SelectedDate.ToString("dd-MM-yyyy")}'";

            _ShowCountRows_ExternalTransferOperations();
        }

        private void dtpTimeFilterInternalTransactions_ValueChanged(object sender, EventArgs e)
        {
            if (dtSelectedClientInternalTransactionsData.Rows.Count == 0) return;

            DateTime SelectedDate = dtpTimeFilterInternalTransactions.Value;
            dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = $"Date = '{SelectedDate.ToString("dd-MM-yyyy")}'";

            _ShowCountRows_InternalTransferOperations();
        }

        private void dtpTimeFilterWithdrawDeposit_ValueChanged(object sender, EventArgs e)
        {
            if (dtSelectedClientWithdrawDepositData.Rows.Count == 0) return;

            DateTime SelectedDate = dtpTimeFilterWithdrawDeposit.Value;
            dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = $"Date = '{SelectedDate.ToString("dd-MM-yyyy")}'";

            _ShowCountRows_WithdrawDepositTransactions();
        }

        private void tbFilterTextWithdrawDeposit_TextChanged(object sender, EventArgs e)
        {

            if (dtSelectedClientWithdrawDepositData.Rows.Count == 0)
                return;

            if (string.IsNullOrEmpty(tbFilterTextWithdrawDeposit.Text))
            {
                _RefreshWithdrawDepositeDataGridView();
                return;
            }

            switch(_enFilterWithdrawDeposite)
            {
                case enFilterWithdrawDeposite.ID:
                {
                        dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = $"ID LIKE '%{tbFilterTextWithdrawDeposit.Text}%'";
                        break;
                }
                case enFilterWithdrawDeposite.Amount:
                {
                    dtSelectedClientWithdrawDepositData.DefaultView.RowFilter = $"Amount LIKE '%{tbFilterTextWithdrawDeposit.Text}%'";
                    break;
                }
            }

            _ShowCountRows_WithdrawDepositTransactions();
        }

        private void tbFilterInternalTransactions_TextChanged(object sender, EventArgs e)
        {
            if (dtSelectedClientInternalTransactionsData.Rows.Count == 0)
                return;

            if (string.IsNullOrEmpty(tbFilterInternalTransactions.Text))
            {
                _RefreshInternalTransactionsDataGridView();
                return;
            }
            switch (_enFilterInternalTransactions)
            {
                case enFilterInternalTransactions.ID:
                    {
                        dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = $"ID LIKE '%{tbFilterInternalTransactions.Text}%'";
                        break;
                    }
                case enFilterInternalTransactions.Amount:
                    {
                        dtSelectedClientInternalTransactionsData.DefaultView.RowFilter = $"Amount LIKE '%{tbFilterInternalTransactions.Text}%'";
                        break;
                    }
            }

            _ShowCountRows_InternalTransferOperations();
        }

        private void tbFilterExternalTransactions_TextChanged(object sender, EventArgs e)
        {
            if (dtSelectedClientExternalTransactionsData.Rows.Count == 0)
                return;

            if (string.IsNullOrEmpty(tbFilterExternalTransactions.Text))
            {
                _RefreshExternalTransactionsDataGridView();
                return;
            }

            switch (_enFilterExternalTransactions)
            {
                case enFilterExternalTransactions.ID:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = $"ID LIKE '%{tbFilterExternalTransactions.Text}%'";
                        break;
                    }
                case enFilterExternalTransactions.Amount:
                    {
                        dtSelectedClientExternalTransactionsData.DefaultView.RowFilter = $"Amount LIKE '%{tbFilterExternalTransactions.Text}%'";
                        break;
                    }
            }

            _ShowCountRows_ExternalTransferOperations();
        }

        private void newExternalTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.TransferExternally) != (int)clsGlobal.enUserPermissions.TransferExternally)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int AccountID = ctrlShowFullBankAccountInfobyFilter1.AccountInfo.AccountNumber;
            frmExternalTransferOperations frmExternalTransferOperations = new frmExternalTransferOperations(AccountID);
            frmExternalTransferOperations.ShowDialog();
            _RefreshExternalTransactionsDataGridView();
        }

        private void newInternalTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.TransferInternally) != (int)clsGlobal.enUserPermissions.TransferInternally)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int AccountID = ctrlShowFullBankAccountInfobyFilter1.AccountInfo.AccountNumber;
            frmInternalTransferOperation frm = new frmInternalTransferOperation(AccountID);
            frm.ShowDialog();
           _RefreshInternalTransactionsDataGridView();
        }

        private void newWithdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.WithdrawProcess) != (int)clsGlobal.enUserPermissions.WithdrawProcess)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int AccountID = ctrlShowFullBankAccountInfobyFilter1.AccountInfo.AccountNumber;
            frmWithdrawAndDepositTransactions frm = new frmWithdrawAndDepositTransactions(clsTransactionTypes.enTransactionTypes.Withdraw, AccountID);
            frm.ShowDialog();
            _RefreshWithdrawDepositeDataGridView();
        }

        private void newDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != -1
                &&
                (clsGlobal.CurrentUser.Permissions & (int)clsGlobal.enUserPermissions.DepositProcess) != (int)clsGlobal.enUserPermissions.DepositProcess)
            {
                MessageBox.Show("you don't have permission to access!, contact your manager if you want more of details.", "Not allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int AccountID = ctrlShowFullBankAccountInfobyFilter1.AccountInfo.AccountNumber;
            frmWithdrawAndDepositTransactions frm = new frmWithdrawAndDepositTransactions(clsTransactionTypes.enTransactionTypes.Deposit, AccountID);
            frm.ShowDialog();
            _RefreshWithdrawDepositeDataGridView();
        }

        private void Any_cms_Opening(object sender, CancelEventArgs e)
        {
            newWithdrawToolStripMenuItem.Enabled = newDepositToolStripMenuItem.Enabled = newInternalTransferToolStripMenuItem.Enabled
                = newExternalTransferToolStripMenuItem.Enabled = showDetailsExternalTransactionToolStripMenuItem.Visible = showDetailsInternalTransactionToolStripMenuItem1.Visible
                =showDetailsWithdrawDepositToolStripMenuItem2.Visible = (ctrlShowFullBankAccountInfobyFilter1.IsAnAccountSelected());

            if(ctrlShowFullBankAccountInfobyFilter1.IsAnAccountSelected())
            {
                showDetailsExternalTransactionToolStripMenuItem.Visible = (dgvExternalTransferTransactions.Rows.Count >0);
                showDetailsInternalTransactionToolStripMenuItem1.Visible =(dgvInternalTransferTransactions.Rows.Count>0) ;
                showDetailsWithdrawDepositToolStripMenuItem2.Visible = (dgvWithdrawDepositTransactions.Rows.Count>0);
            }


        }

        private void showDetailsToolStripMenuItem_WithdrawDeposit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvWithdrawDepositTransactions.CurrentRow.Cells["ID"].Value);
            frmShowWithdrawDepositRowDetails frm = new frmShowWithdrawDepositRowDetails(ID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_InternalTransaction_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvInternalTransferTransactions.CurrentRow.Cells["ID"].Value);
            frmShowInternalTransactionRowDetails frm = new frmShowInternalTransactionRowDetails(ID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_ExternalTransaction_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvExternalTransferTransactions.CurrentRow.Cells["ID"].Value);
            frmShowExternalTransactionRowDetails frm = new frmShowExternalTransactionRowDetails(ID);
            frm.ShowDialog();
        }
    }
}

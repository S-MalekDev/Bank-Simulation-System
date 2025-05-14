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
    public partial class ctrlShowClientInfobyFilter : UserControl
    {
        public event Action<int> OnClientSelected;
        protected virtual void ClientSelected(int ClientID)
        {
            Action<int> Handler = OnClientSelected;
            if (OnClientSelected != null)
                OnClientSelected(ClientID);
        }

        public enum enFilter { PersonID = 0, ClientID = 1, AccountNumber = 2 }
        private enFilter _SelectedFilter = enFilter.ClientID;

        public enFilter SelectedFilter
        {
            get
            {
                return _SelectedFilter;
            }
            set
            {
                _SelectedFilter = value;
            }
        }
            
        public bool AccountFieldsVisible
        {
            set 
            { 
                ctrlShowClientInfo1.AccountFieldsVisible = value;
            }
        }

        private clsAccounts _Account = null;

        public clsAccounts AccountInfo { get { return _Account; } }
        public int AccountID { get { return (_Account != null) ? _Account.AccountNumber : -1; } }
        public clsClients ClientInfo { get { return _Account.ClientInfo; } }
        public int ClientID { get { return (_Account != null) ? _Account.ClientID : -1; } }

        public bool FilterEnabeled
        {
            set { gbFilter.Enabled = value; }
            get { return gbFilter.Enabled; }
        }
        public ctrlShowClientInfobyFilter()
        {
            InitializeComponent();
        }

        private Color _BackColor;
        public Color ControlBackColor
        {
            set
            {
                _BackColor = value;
                this.BackColor = _BackColor;
                gbFilter.BackColor = _BackColor;
                tbFilterText.ForeColor = _BackColor;
                ctrlShowClientInfo1.ControlBackColor = _BackColor;
            }
            get { return _BackColor; }
        }

        private Color _ForeColor = DefaultForeColor;
        public Color ControlForeColor
        {
            set
            {
                _ForeColor = value;
                this.ForeColor = _ForeColor;
                gbFilter.ForeColor = _ForeColor;
                ctrlShowClientInfo1.ContorlForeColor = _ForeColor;
            }

            get { return _ForeColor; }
        }

        public void FilterTexbBoxFocus()
        {
            tbFilterText.Focus();
        }

        private void _GetDefaultSelectedFilter()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter);
        }

        private void ctrlShowClientInfobyFilter_Load(object sender, EventArgs e)
        {
            _GetDefaultSelectedFilter();
            FilterTexbBoxFocus();
        }


        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindClient.PerformClick();


            if (e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                errorProvider1.SetError(tbFilterText, "You cann't enter letters, only digit are allowed.");
            else errorProvider1.SetError(tbFilterText, null);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SelectedFilter = (enFilter)cbFilter.SelectedIndex;

            tbFilterText.Clear();
            errorProvider1.Clear();
            tbFilterText.Focus();
        }

        private void btnFindClient_Click(object sender, EventArgs e)
        {
            if (_SelectedFilter == enFilter.ClientID)
                ctrlShowClientInfo1.ShowClientInfobyClientID(int.Parse(tbFilterText.Text));
            else if (_SelectedFilter == enFilter.AccountNumber)
                ctrlShowClientInfo1.ShowClientInfobyAccountID(int.Parse(tbFilterText.Text));
            else if(_SelectedFilter == enFilter.PersonID)
                ctrlShowClientInfo1.ShowClientInfobyPersonID(int.Parse(tbFilterText.Text));


            _Account = ctrlShowClientInfo1.AccountInfo;

            if (_Account != null )
            {
                if (OnClientSelected != null)
                    OnClientSelected(_Account.ClientID);
            }
        }

        public void ShowClientInfoByClientID(int ClientID)
        {
            cbFilter.SelectedIndex = (byte)enFilter.ClientID;
            tbFilterText.Text = ClientID.ToString();
            ctrlShowClientInfo1.ShowClientInfobyClientID(ClientID);

            _Account = ctrlShowClientInfo1.AccountInfo;

            if (_Account != null )
            {
                if (OnClientSelected != null)
                    OnClientSelected(_Account.ClientID);
            }
        }


        public void ShowClientInfoByAccountID(int AccountID)
        {
            cbFilter.SelectedIndex = (byte)enFilter.AccountNumber;
            tbFilterText.Text = AccountID.ToString();
            ctrlShowClientInfo1.ShowClientInfobyAccountID(AccountID);

            _Account = ctrlShowClientInfo1.AccountInfo;

            if (_Account != null )
            {
                if (OnClientSelected != null)
                    OnClientSelected(_Account.ClientID);
            }
        }

        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if (FilterEnabeled)
                btnFindClient.Enabled = (!string.IsNullOrEmpty(tbFilterText.Text));
        }

    }
}

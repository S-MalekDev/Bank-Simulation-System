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
    public partial class ctrlShowPersonInfoByFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int>Handler = OnPersonSelected;
            if (OnPersonSelected != null)
                OnPersonSelected(PersonID);
        }
        private enum enFilter { PersonID = 0, NationalNo= 1}
        private enFilter _SelectedFilter;

        private clsPeople _Person = null;

        public clsPeople PersonInfo { get { return _Person; } }
        public int PersonID { get { return (_Person != null) ? _Person.PersonID : -1; } }

        public bool FilterEnabeled
        {
            set { gbFilter.Enabled = value; }
            get { return gbFilter.Enabled; }
        }

        private Color _BackColor;
        public Color ControlBackColor
        {
            set
            {
                _BackColor = value;
                this.BackColor = _BackColor;
                tbFilterText.ForeColor = _BackColor;
                ctrlShowPersonInfo1.ControlBackColor = _BackColor;
            }
            get { return _BackColor; }
        }

        private Color _ForeColor;
        public Color ControlForeColor
        {
            set
            {
                _ForeColor = value;
                this.ForeColor = _ForeColor;
                gbFilter.ForeColor = _ForeColor;
                ctrlShowPersonInfo1.ControlForeColor = _ForeColor;
            }

            get { return _ForeColor; }
        }

        public ctrlShowPersonInfoByFilter()
        {
            InitializeComponent();
        }

        public void FilterTexbBoxFocus()
        {
            tbFilterText.Focus();
        }

        private void _GetDefaultSelectedFilter()
        {
            cbFilter.SelectedIndex = (byte)(_SelectedFilter = enFilter.PersonID);
        }

        private void ctrlShowPersonInfoByFilter_Load(object sender, EventArgs e)
        {
            _GetDefaultSelectedFilter();
            FilterTexbBoxFocus();
        }

        private void tbFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindPerson.PerformClick();

            if (_SelectedFilter != enFilter.PersonID)
                return;

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

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (_SelectedFilter == enFilter.PersonID)
                ctrlShowPersonInfo1.ShowPersonInfo(int.Parse(tbFilterText.Text));
            else
                ctrlShowPersonInfo1.ShowPersonInfo(tbFilterText.Text);

            _Person = ctrlShowPersonInfo1.PersonInfo;

            if (_Person != null && FilterEnabeled == true)
            {
                if (OnPersonSelected != null)
                    OnPersonSelected(_Person.PersonID);
            }
        }

        public void ShowPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = (byte)enFilter.PersonID;
            tbFilterText.Text = PersonID.ToString();
            ctrlShowPersonInfo1.ShowPersonInfo(PersonID);

            _Person = ctrlShowPersonInfo1.PersonInfo;

            if (_Person != null && FilterEnabeled == true)
            {
                if (OnPersonSelected != null)
                    OnPersonSelected(_Person.PersonID);
            }
        }

        private void PersonBackData(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = (byte)enFilter.PersonID;
            tbFilterText.Text = PersonID.ToString();
            btnFindPerson.PerformClick();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson();
            frm.BackData += PersonBackData;
            frm.ShowDialog();
        }

        private void tbFilterText_TextChanged(object sender, EventArgs e)
        {
            if (FilterEnabeled)
                btnFindPerson.Enabled = (!string.IsNullOrEmpty(tbFilterText.Text));
        }
    }
}

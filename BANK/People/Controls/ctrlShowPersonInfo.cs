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
using System.IO;
using BANK.Properties;

namespace BANK
{
    public partial class ctrlShowPersonInfo : UserControl
    {
        private clsPeople _Person = null;

        public clsPeople PersonInfo { get { return _Person; } }
        public int PersonID { get { return (_Person!=null)?_Person.PersonID: -1; } }

        private Color _BackColor ;
        public Color ControlBackColor
        {
            set 
            { 
                _BackColor = value;
                this.BackColor = _BackColor;
                gbPersonInformation.BackColor = _BackColor;
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
                gbPersonInformation.ForeColor = _ForeColor;
                lblFullName.ForeColor = _ForeColor;

                pb1.BackColor = _ForeColor;
                pb2.BackColor = _ForeColor;
                pb3.BackColor = _ForeColor;
                pb4.BackColor = _ForeColor;
                pb5.BackColor = _ForeColor;
                pbGendor.BackColor = _ForeColor;
                pb7.BackColor = _ForeColor;
                pb8.BackColor = _ForeColor;
                pb9.BackColor = _ForeColor;
                pb10.BackColor = _ForeColor;

            }

            get { return _ForeColor; }
        }
        public ctrlShowPersonInfo()
        {
            InitializeComponent();
        }

        private void _LoadThePictureOfGendor()
        {
            if (_Person.Gendor == true)
                pbGendor.Image = Resources.Gendor_Male_72;

            else //if (rbFemal.Checked)
                pbGendor.Image = Resources.Gendor_Femal_72;
        }

        private void _GetDefaultPictureByGendor()
        {
            if (_Person.Gendor == true)
                pbPersonImage.Image = Resources.Man_Default_Pictuer;

            else //if (rbFemal.Checked)
                pbPersonImage.Image = Resources.Woman_Default_Picture;
        } 

        private void _LoadThePersonImageIsExist()
        {
            if(string.IsNullOrEmpty(_Person.ImagePath))
            {
                _GetDefaultPictureByGendor();
                return;
            }
            
            if(File.Exists(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                MessageBox.Show("The person profile picture is missing","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                _GetDefaultPictureByGendor();
            }
            
        }

        private void _UpLoadThePersonInfoOnTheControl()
        {
            lblPersonID.Text = $"[ {_Person.PersonID.ToString("D2")} ]" ;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = (_Person.Gendor == true) ? "Male" : "Female";
            _LoadThePictureOfGendor();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
            lblNationalNum.Text = _Person.NationalNumber.ToString();
            lblNationality.Text = _Person.NationalityInfo.Nationality;
            lblEmail.Text = !string.IsNullOrEmpty(_Person.Email) ? _Person.Email : "Not set.";
            lblPhone.Text =_Person.Phone ;
            lblCountryResidence.Text = _Person.CountryResidenceInfo.CountryName;
            lblAddress.Text = _Person.Address;
            _LoadThePersonImageIsExist();
        }

        public void ShowPersonInfo(int PersonID)
        {
            _Person = clsPeople.Find(PersonID);

            if(_Person==null)
            {
                MessageBox.Show($"The person with id = {PersonID} is not found!","Missing",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            _UpLoadThePersonInfoOnTheControl();
        }

        public void ShowPersonInfo(string NationalNo)
        {
            _Person = clsPeople.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show($"The person with National No = {NationalNo} is not found!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _UpLoadThePersonInfoOnTheControl();
        }

    }
}

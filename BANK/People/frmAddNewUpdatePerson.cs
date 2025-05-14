using BANK_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BANK.Properties;

namespace BANK
{
    public partial class frmAddNewUpdatePerson : Form
    {
        public delegate void BackDataHandler(object sender, int PersonID);
        public event BackDataHandler BackData;

        private int _PersonID = -1;
        private clsPeople _Person = null;
        public enum enMode { AddNew=0, Update=1 }
        private enMode _enMode;
        public enMode Mode
        {
            get { return _enMode; }
            set 
            { 
                _enMode = value; 
                switch(_enMode)
                {
                    case enMode.AddNew:
                    {
                        this.Text = "Add New Person";
                        lblFormTitle.Text = "Add New Person";
                        break;
                    }
                    case enMode.Update:
                    {
                        this.Text = "Update Person's Data";
                        lblFormTitle.Text = "Update Person's Data";
                        break;
                    }
                    
                }
            }
        }
        public frmAddNewUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddNewUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            Mode = enMode.Update;
        }

        private void _GetTheDefaultValues()
        {
            _LoadDataToComboBoxesAndGetDefaultValues();
            _GetDefaultDateOfBirth();
            _GetDefaultPictureByGendor();
        }
        private void _LoadDataToComboBoxesAndGetDefaultValues()
        {
            _LoadCountriesNameListDataInTheComboBox();
            _SelectDefaultCountryOfResidence();

            _LoadNationalitiesListDataInTheComboBox();
            _SelectDefaultNationality();
        }
        private void _SelectDefaultCountryOfResidence()
        {
            cbCountryOfRecidence.SelectedIndex = cbCountryOfRecidence.FindString("Algeria");
        }
        private void _SelectDefaultNationality()
        {
            cbNationality.SelectedIndex = cbNationality.FindString("Algerian");
        }
        private void _LoadNationalitiesListDataInTheComboBox()
        {
            DataTable dtNationalities = clsCountries.GetListOfNationalities();

            foreach(DataRow Row in dtNationalities.Rows)
            {
                cbNationality.Items.Add(Row["Nationality"].ToString());
            }
        }
        private void _LoadCountriesNameListDataInTheComboBox()
        {
            DataTable dtCountries = clsCountries.GetListOfCountriesName();

            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountryOfRecidence.Items.Add(Row["CountryName"].ToString());
            }
        }
        private void _GetDefaultDateOfBirth()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        private void _GetDefaultPictureByGendor()
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Man_Default_Pictuer;

            else //if (rbFemal.Checked)
                pbPersonImage.Image = Resources.Woman_Default_Picture;
        }
        private bool _HandlePersonPicture()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    if (File.Exists(_Person.ImagePath))
                        File.Delete(_Person.ImagePath);
                }

                if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                {
                    string ImagePath = pbPersonImage.ImageLocation;

                    if (clsUtil.CopieImageToImagesProjectFolder(ref ImagePath))
                    {
                        pbPersonImage.ImageLocation = ImagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("The person's image copied is feiled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }

            return true;
        }
        private void _LoadThePersonDataFromTheFormToAnObject()
        {
               
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.MedName = (!string.IsNullOrEmpty(tbMedName.Text)) ? clsUtil.UpperTheFirtLetterFrom(tbMedName.Text) : string.Empty;
            _Person.LastName = clsUtil.UpperTheFirtLetterFrom(tbLastName.Text);
            _Person.Gendor = (rbMale.Checked)?true:false; // true or 1 for male // false or 0 for femal.
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalNumber = clsUtil.UpperTheFirtLetterFrom(tbNationalNumber.Text);
            _Person.Nationality = clsCountries.GetCountryID_ByNationalityText(cbNationality.SelectedItem.ToString());
            _Person.Email = (!string.IsNullOrEmpty(tbEmail.Text))?tbEmail.Text.Trim(): string.Empty;

            if(!string.IsNullOrEmpty(mtbPhone.Text))
            {
                string PhoneCode = clsCountries.FindByCountryName(cbCountryOfRecidence.SelectedItem.ToString()).PhoneCode;
                _Person.Phone = "+"+PhoneCode + " " + mtbPhone.Text;
            }

            _Person.CountryOfResidence = clsCountries.GetCountryID_ByCountryNameText(cbCountryOfRecidence.SelectedItem.ToString());
            _Person.Address = tbAddress.Text.Trim();

            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                _Person.ImagePath = pbPersonImage.ImageLocation;

        }
        private void _LoadPersonPictureIfExistOnTheForm()
        {
            if(!File.Exists(_Person.ImagePath))
            {
                MessageBox.Show("The picture of the person Selected is missing! :-(", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _GetDefaultPictureByGendor();
                return;
            }
            pbPersonImage.ImageLocation = _Person.ImagePath;
            btnRemoveImage.Visible = true;
        }
        private void _LoadThePictureProfileOfThePerson()
        {
            if (string.IsNullOrEmpty(_Person.ImagePath))
            {
                _GetDefaultPictureByGendor();
            }
            else
            {
                _LoadPersonPictureIfExistOnTheForm();

            }
        }
        private void _UploadDataFromThePersonOnTheForm()
        {
            _Person = clsPeople.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"The person with id = {_PersonID} is not exist!", "Data not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = $"[ {_Person.PersonID.ToString("D2")} ]";
            tbFirstName.Text = _Person.FirstName;
            tbMedName.Text = _Person.MedName;
            tbLastName.Text = _Person.LastName;
            cbNationality.SelectedItem = _Person.NationalityInfo.Nationality;
            tbEmail.Text = _Person.Email;
            tbNationalNumber.Text = _Person.NationalNumber;

            string PhoneCode = clsCountries.Find(_Person.CountryOfResidence).PhoneCode;
            mtbPhone.Text = _Person.Phone.Replace("+"+PhoneCode,"").Trim();

            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountryOfRecidence.SelectedItem = _Person.CountryResidenceInfo.CountryName;
            rbFemal.Checked = !(rbMale.Checked = (_Person.Gendor == true));
            tbAddress.Text = _Person.Address;
            _LoadThePictureProfileOfThePerson();
            
        }


        private void frmAddNewUpdatePerson_Load(object sender, EventArgs e)
        {
            _GetTheDefaultValues();

            if (Mode == enMode.Update)
            {
                _UploadDataFromThePersonOnTheForm();
            }
        }



        private void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            //Validationg First Name// Last Name// Address

            if (e.Cancel = string.IsNullOrEmpty(((TextBox)sender).Text))
                errorProvider1.SetError(((TextBox)sender), $"The {((TextBox)sender).Tag.ToString()} field is required!");
            else
                errorProvider1.SetError(((TextBox)sender),null);
        }


        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbEmail.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, null);
                return;
            }
            


            string Email = tbEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\.\-]+)((\.(\w){2,3})+)$");
            if (e.Cancel = !regex.IsMatch(Email))
            {
                errorProvider1.SetError(tbEmail, "The email format is incorrect!");
                return;
            }
            else
                errorProvider1.SetError(tbEmail, null);
        }


        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = string.IsNullOrEmpty(tbNationalNumber.Text))
            {
                errorProvider1.SetError(tbNationalNumber, "The national number field is required!");
                return;
            }

            if(e.Cancel = (clsPeople.IsPersonExistByNationalNo(tbNationalNumber.Text) && Mode == enMode.AddNew))
            {
                errorProvider1.SetError(tbNationalNumber, "This national number is already exist!");
                return;
            }
            if(Mode == enMode.Update 
                && 
                clsPeople.IsPersonExistByNationalNo(tbNationalNumber.Text) 
                && 
                tbNationalNumber.Text.ToLower().Trim() != _Person.NationalNumber.ToLower().Trim())
            {
                errorProvider1.SetError(tbNationalNumber, "This national number is not allowed because it used by another person!");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tbNationalNumber, null);
        }


        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                _GetDefaultPictureByGendor();
        }


        private void btnUploadAnImage_Click(object sender, EventArgs e)
        {

            if (btnRemoveImage.Visible = openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;
            }
        }


        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _GetDefaultPictureByGendor();
            btnRemoveImage.Visible = false;
        }


        private void btnRemoveImage_VisibleChanged(object sender, EventArgs e)
        {
            btnUploadAnImage.Visible = !btnRemoveImage.Visible;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some field required are not valid put the muse over the icon(s) to read message error.","Error."
                    ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.AddNew)
                _Person = new clsPeople();

            if (!_HandlePersonPicture())
                return;

             _LoadThePersonDataFromTheFormToAnObject();

            if(_Person.Save())
            {
                MessageBox.Show("The person's data saved saccessfully.","Saved success.",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblPersonID.Text = $"[ {(_PersonID = _Person.PersonID).ToString("D2")} ]";

                if (Mode == enMode.AddNew)
                    BackData?.Invoke(this,_PersonID);

                Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("An error occurred while registering the person's information!!", "Error."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mtbPhone_Validating(object sender, CancelEventArgs e)
        {
            if (e.Cancel = (string.IsNullOrEmpty(mtbPhone.Text)))
                errorProvider1.SetError(mtbPhone, "The phone number field is required!");

            else if (!mtbPhone.MaskCompleted)
                errorProvider1.SetError(mtbPhone, "The phone number format is not completed!");

            else
                errorProvider1.SetError(mtbPhone, null);
        }

        private void mtbPhone_Enter(object sender, EventArgs e)
        {
            mtbPhone.Focus();
        }
    }
}

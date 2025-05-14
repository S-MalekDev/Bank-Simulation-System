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
    public partial class ctrlShowEmployeeInfo : UserControl
    {
        private clsEmployees _Employee = null;
        public clsEmployees EmployeeInfo { get { return _Employee; } }
        public int EmployeeID { get { return (_Employee != null) ? _Employee.EmployeeID : -1; } }


        public ctrlShowEmployeeInfo()
        {
            InitializeComponent();
        }

        private void _UpLoadTheEmployeeInfoOnTheControl()
        {
            ctrlShowPersonInfo1.ShowPersonInfo(_Employee.PersonID);
            lblEmployeeID.Text = $"[ {_Employee.EmployeeID.ToString("D2")} ]";
            lblEmploymentDate.Text = _Employee.EmploymentDate.ToString("dd-MMM-yyyy");
            lblSalary.Text = _Employee.Salary.ToString() + " $";
            lblJobPosition.Text = _Employee.JobInfo.JobTitle;
        }

        public void ShowEmployeeInfo(int EmployeeID)
        {
            _Employee = clsEmployees.Find(EmployeeID);

            if (_Employee == null)
            {
                MessageBox.Show($"The Employee with id = {EmployeeID} is not found!", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            _UpLoadTheEmployeeInfoOnTheControl();
        }
    }
}

﻿using System;
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
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID = -1;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            ctrlShowPersonInfo1.ShowPersonInfo(_PersonID);
        }
    }
}

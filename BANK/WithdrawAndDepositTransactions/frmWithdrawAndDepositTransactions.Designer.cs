namespace BANK
{
    partial class frmWithdrawAndDepositTransactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWithdrawAndDepositTransactions));
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.gbTransaction = new System.Windows.Forms.GroupBox();
            this.lblBalanceAfter = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.btnOperation = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rtbOperationDescription = new System.Windows.Forms.RichTextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.lblOperationFees = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbGendor = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDeposit = new System.Windows.Forms.RadioButton();
            this.rbWithdraw = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShowAccountInfobyFilter1 = new BANK.ctrlShowFullBankAccountInfobyFilter();
            this.lblOperationID = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Century Schoolbook", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblFormTitle.Location = new System.Drawing.Point(532, 20);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(448, 47);
            this.lblFormTitle.TabIndex = 5;
            this.lblFormTitle.Text = "Withdraw Operation";
            // 
            // gbTransaction
            // 
            this.gbTransaction.Controls.Add(this.lblOperationID);
            this.gbTransaction.Controls.Add(this.pictureBox12);
            this.gbTransaction.Controls.Add(this.label2);
            this.gbTransaction.Controls.Add(this.lblBalanceAfter);
            this.gbTransaction.Controls.Add(this.pictureBox1);
            this.gbTransaction.Controls.Add(this.label6);
            this.gbTransaction.Controls.Add(this.tbAmount);
            this.gbTransaction.Controls.Add(this.btnOperation);
            this.gbTransaction.Controls.Add(this.btnClose);
            this.gbTransaction.Controls.Add(this.rtbOperationDescription);
            this.gbTransaction.Controls.Add(this.pictureBox8);
            this.gbTransaction.Controls.Add(this.label16);
            this.gbTransaction.Controls.Add(this.label4);
            this.gbTransaction.Controls.Add(this.lblServiceType);
            this.gbTransaction.Controls.Add(this.pictureBox4);
            this.gbTransaction.Controls.Add(this.label3);
            this.gbTransaction.Controls.Add(this.lblCreatedByUser);
            this.gbTransaction.Controls.Add(this.lblTransactionType);
            this.gbTransaction.Controls.Add(this.lblOperationFees);
            this.gbTransaction.Controls.Add(this.lblRequestDate);
            this.gbTransaction.Controls.Add(this.pictureBox11);
            this.gbTransaction.Controls.Add(this.label14);
            this.gbTransaction.Controls.Add(this.pictureBox6);
            this.gbTransaction.Controls.Add(this.pbGendor);
            this.gbTransaction.Controls.Add(this.label10);
            this.gbTransaction.Controls.Add(this.label9);
            this.gbTransaction.Controls.Add(this.pictureBox2);
            this.gbTransaction.Controls.Add(this.label5);
            this.gbTransaction.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.gbTransaction.Location = new System.Drawing.Point(1013, 205);
            this.gbTransaction.Name = "gbTransaction";
            this.gbTransaction.Size = new System.Drawing.Size(489, 616);
            this.gbTransaction.TabIndex = 7;
            this.gbTransaction.TabStop = false;
            this.gbTransaction.Text = "Withdrow Operation";
            // 
            // lblBalanceAfter
            // 
            this.lblBalanceAfter.AutoSize = true;
            this.lblBalanceAfter.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceAfter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblBalanceAfter.Location = new System.Drawing.Point(223, 493);
            this.lblBalanceAfter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBalanceAfter.Name = "lblBalanceAfter";
            this.lblBalanceAfter.Size = new System.Drawing.Size(34, 25);
            this.lblBalanceAfter.TabIndex = 119;
            this.lblBalanceAfter.Text = "00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 493);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label6.Location = new System.Drawing.Point(21, 497);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 21);
            this.label6.TabIndex = 117;
            this.label6.Text = "The Balance After:";
            // 
            // tbAmount
            // 
            this.tbAmount.Enabled = false;
            this.tbAmount.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.tbAmount.Location = new System.Drawing.Point(227, 443);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(233, 32);
            this.tbAmount.TabIndex = 3;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // btnOperation
            // 
            this.btnOperation.Enabled = false;
            this.btnOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.btnOperation.Image = ((System.Drawing.Image)(resources.GetObject("btnOperation.Image")));
            this.btnOperation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOperation.Location = new System.Drawing.Point(314, 562);
            this.btnOperation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Size = new System.Drawing.Size(159, 45);
            this.btnOperation.TabIndex = 4;
            this.btnOperation.Text = "Withdraw";
            this.btnOperation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOperation.UseVisualStyleBackColor = true;
            this.btnOperation.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(138, 562);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 45);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rtbOperationDescription
            // 
            this.rtbOperationDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.rtbOperationDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbOperationDescription.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOperationDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.rtbOperationDescription.Location = new System.Drawing.Point(25, 49);
            this.rtbOperationDescription.Name = "rtbOperationDescription";
            this.rtbOperationDescription.Size = new System.Drawing.Size(458, 137);
            this.rtbOperationDescription.TabIndex = 113;
            this.rtbOperationDescription.TabStop = false;
            this.rtbOperationDescription.Text = "";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(192, 450);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(25, 25);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 102;
            this.pictureBox8.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label16.Location = new System.Drawing.Point(111, 454);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 21);
            this.label16.TabIndex = 101;
            this.label16.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 98;
            this.label4.Text = "Description:";
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblServiceType.Location = new System.Drawing.Point(223, 282);
            this.lblServiceType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(37, 21);
            this.lblServiceType.TabIndex = 97;
            this.lblServiceType.Text = "???";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(192, 278);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 96;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label3.Location = new System.Drawing.Point(69, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 94;
            this.label3.Text = "Service Type:";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblCreatedByUser.Location = new System.Drawing.Point(223, 239);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(37, 21);
            this.lblCreatedByUser.TabIndex = 93;
            this.lblCreatedByUser.Text = "???";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblTransactionType.Location = new System.Drawing.Point(223, 325);
            this.lblTransactionType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(37, 21);
            this.lblTransactionType.TabIndex = 92;
            this.lblTransactionType.Text = "???";
            // 
            // lblOperationFees
            // 
            this.lblOperationFees.AutoSize = true;
            this.lblOperationFees.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblOperationFees.Location = new System.Drawing.Point(223, 411);
            this.lblOperationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOperationFees.Name = "lblOperationFees";
            this.lblOperationFees.Size = new System.Drawing.Size(30, 21);
            this.lblOperationFees.TabIndex = 91;
            this.lblOperationFees.Text = "00";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblRequestDate.Location = new System.Drawing.Point(223, 368);
            this.lblRequestDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(37, 21);
            this.lblRequestDate.TabIndex = 90;
            this.lblRequestDate.Text = "???";
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(192, 235);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(25, 25);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 89;
            this.pictureBox11.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label14.Location = new System.Drawing.Point(36, 239);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 21);
            this.label14.TabIndex = 88;
            this.label14.Text = "Created By User:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(192, 364);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 87;
            this.pictureBox6.TabStop = false;
            // 
            // pbGendor
            // 
            this.pbGendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pbGendor.Image = ((System.Drawing.Image)(resources.GetObject("pbGendor.Image")));
            this.pbGendor.Location = new System.Drawing.Point(192, 407);
            this.pbGendor.Name = "pbGendor";
            this.pbGendor.Size = new System.Drawing.Size(25, 25);
            this.pbGendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGendor.TabIndex = 86;
            this.pbGendor.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label10.Location = new System.Drawing.Point(62, 368);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 21);
            this.label10.TabIndex = 85;
            this.label10.Text = "Request Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label9.Location = new System.Drawing.Point(47, 411);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 21);
            this.label9.TabIndex = 84;
            this.label9.Text = "Operation Fees:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(192, 321);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 83;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label5.Location = new System.Drawing.Point(28, 325);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 21);
            this.label5.TabIndex = 82;
            this.label5.Text = "Transaction Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDeposit);
            this.groupBox1.Controls.Add(this.rbWithdraw);
            this.groupBox1.Font = new System.Drawing.Font("Century Schoolbook", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.groupBox1.Location = new System.Drawing.Point(1013, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Types";
            // 
            // rbDeposit
            // 
            this.rbDeposit.AutoSize = true;
            this.rbDeposit.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold);
            this.rbDeposit.Location = new System.Drawing.Point(290, 55);
            this.rbDeposit.Name = "rbDeposit";
            this.rbDeposit.Size = new System.Drawing.Size(155, 39);
            this.rbDeposit.TabIndex = 2;
            this.rbDeposit.TabStop = true;
            this.rbDeposit.Text = "Deposit";
            this.rbDeposit.UseVisualStyleBackColor = true;
            this.rbDeposit.CheckedChanged += new System.EventHandler(this.rbDeposit_CheckedChanged);
            // 
            // rbWithdraw
            // 
            this.rbWithdraw.AutoSize = true;
            this.rbWithdraw.Checked = true;
            this.rbWithdraw.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold);
            this.rbWithdraw.Location = new System.Drawing.Point(51, 55);
            this.rbWithdraw.Name = "rbWithdraw";
            this.rbWithdraw.Size = new System.Drawing.Size(191, 39);
            this.rbWithdraw.TabIndex = 1;
            this.rbWithdraw.TabStop = true;
            this.rbWithdraw.Text = "Withdraw";
            this.rbWithdraw.UseVisualStyleBackColor = true;
            this.rbWithdraw.CheckedChanged += new System.EventHandler(this.rbWithdraw_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Location = new System.Drawing.Point(1509, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(3, 833);
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(3, 833);
            this.pictureBox5.TabIndex = 52;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox7.Location = new System.Drawing.Point(3, 830);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(1506, 3);
            this.pictureBox7.TabIndex = 53;
            this.pictureBox7.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowAccountInfobyFilter1
            // 
            this.ctrlShowAccountInfobyFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ctrlShowAccountInfobyFilter1.FilterEnabled = true;
            this.ctrlShowAccountInfobyFilter1.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.ctrlShowAccountInfobyFilter1.Location = new System.Drawing.Point(3, 61);
            this.ctrlShowAccountInfobyFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShowAccountInfobyFilter1.Name = "ctrlShowAccountInfobyFilter1";
            this.ctrlShowAccountInfobyFilter1.Size = new System.Drawing.Size(1017, 766);
            this.ctrlShowAccountInfobyFilter1.TabIndex = 0;
            this.ctrlShowAccountInfobyFilter1.TabStop = false;
            this.ctrlShowAccountInfobyFilter1.OnAccountSelected += new System.Action<int>(this.ctrlShowAccountInfobyFilter1_OnAccountSelected);
            // 
            // lblOperationID
            // 
            this.lblOperationID.AutoSize = true;
            this.lblOperationID.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperationID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.lblOperationID.Location = new System.Drawing.Point(222, 196);
            this.lblOperationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOperationID.Name = "lblOperationID";
            this.lblOperationID.Size = new System.Drawing.Size(51, 21);
            this.lblOperationID.TabIndex = 179;
            this.lblOperationID.Text = "[???]";
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(191, 192);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(25, 25);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 178;
            this.pictureBox12.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.label2.Location = new System.Drawing.Point(92, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 177;
            this.label2.Text = "Operation:";
            // 
            // frmWithdrawAndDepositTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ClientSize = new System.Drawing.Size(1512, 833);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTransaction);
            this.Controls.Add(this.ctrlShowAccountInfobyFilter1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWithdrawAndDepositTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Withdraw Operation";
            this.Activated += new System.EventHandler(this.frmWithdrawAndDepositTransactions_Activated);
            this.Load += new System.EventHandler(this.frmWithdrawAndDepositTransactions_Load);
            this.gbTransaction.ResumeLayout(false);
            this.gbTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private ctrlShowFullBankAccountInfobyFilter ctrlShowAccountInfobyFilter1;
        private System.Windows.Forms.GroupBox gbTransaction;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblTransactionType;
        private System.Windows.Forms.Label lblOperationFees;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pbGendor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox rtbOperationDescription;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Button btnOperation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBalanceAfter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDeposit;
        private System.Windows.Forms.RadioButton rbWithdraw;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblOperationID;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label2;
    }
}
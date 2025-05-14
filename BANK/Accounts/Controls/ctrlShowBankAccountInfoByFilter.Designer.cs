namespace BANK
{
    partial class ctrlShowBankAccountInfoByFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlShowBankAccountInfoByFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindAnAccount = new System.Windows.Forms.Button();
            this.tbFilterText = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShowBankAccountInfo1 = new BANK.ctrlShowBankAccountInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.gbFilter.Controls.Add(this.btnFindAnAccount);
            this.gbFilter.Controls.Add(this.tbFilterText);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.gbFilter.Location = new System.Drawing.Point(5, -2);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(997, 86);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindAnAccount
            // 
            this.btnFindAnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindAnAccount.Enabled = false;
            this.btnFindAnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnFindAnAccount.Image")));
            this.btnFindAnAccount.Location = new System.Drawing.Point(543, 19);
            this.btnFindAnAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFindAnAccount.Name = "btnFindAnAccount";
            this.btnFindAnAccount.Size = new System.Drawing.Size(72, 59);
            this.btnFindAnAccount.TabIndex = 3;
            this.btnFindAnAccount.UseVisualStyleBackColor = true;
            this.btnFindAnAccount.Click += new System.EventHandler(this.btnFindAccount_Click);
            // 
            // tbFilterText
            // 
            this.tbFilterText.Location = new System.Drawing.Point(177, 34);
            this.tbFilterText.Name = "tbFilterText";
            this.tbFilterText.Size = new System.Drawing.Size(335, 28);
            this.tbFilterText.TabIndex = 1;
            this.tbFilterText.TextChanged += new System.EventHandler(this.tbFilterText_TextChanged);
            this.tbFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterText_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "Person ID",
            "Client ID",
            "Account Number"});
            this.cbFilter.Location = new System.Drawing.Point(8, 33);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(163, 29);
            this.cbFilter.TabIndex = 0;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlShowBankAccountInfo1
            // 
            this.ctrlShowBankAccountInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ctrlShowBankAccountInfo1.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.ctrlShowBankAccountInfo1.Location = new System.Drawing.Point(1, 85);
            this.ctrlShowBankAccountInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShowBankAccountInfo1.Name = "ctrlShowBankAccountInfo1";
            this.ctrlShowBankAccountInfo1.Size = new System.Drawing.Size(1009, 298);
            this.ctrlShowBankAccountInfo1.TabIndex = 4;
            // 
            // ctrlShowBankAccountInfoByFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.Controls.Add(this.ctrlShowBankAccountInfo1);
            this.Controls.Add(this.gbFilter);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlShowBankAccountInfoByFilter";
            this.Size = new System.Drawing.Size(1008, 384);
            this.Load += new System.EventHandler(this.ctrlShowBankAccountInfoByFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindAnAccount;
        private System.Windows.Forms.TextBox tbFilterText;
        private System.Windows.Forms.ComboBox cbFilter;
        private ctrlShowBankAccountInfo ctrlShowBankAccountInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

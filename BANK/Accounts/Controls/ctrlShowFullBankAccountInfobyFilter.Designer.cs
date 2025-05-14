namespace BANK
{
    partial class ctrlShowFullBankAccountInfobyFilter
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
            this.ctrlShowBankAccountInfo1 = new BANK.ctrlShowBankAccountInfo();
            this.ctrlShowClientInfobyFilter1 = new BANK.ctrlShowClientInfobyFilter();
            this.SuspendLayout();
            // 
            // ctrlShowBankAccountInfo1
            // 
            this.ctrlShowBankAccountInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ctrlShowBankAccountInfo1.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.ctrlShowBankAccountInfo1.Location = new System.Drawing.Point(5, 466);
            this.ctrlShowBankAccountInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShowBankAccountInfo1.Name = "ctrlShowBankAccountInfo1";
            this.ctrlShowBankAccountInfo1.Size = new System.Drawing.Size(1009, 298);
            this.ctrlShowBankAccountInfo1.TabIndex = 1;
            // 
            // ctrlShowClientInfobyFilter1
            // 
            this.ctrlShowClientInfobyFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ctrlShowClientInfobyFilter1.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.ctrlShowClientInfobyFilter1.ControlForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ctrlShowClientInfobyFilter1.FilterEnabeled = true;
            this.ctrlShowClientInfobyFilter1.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.ctrlShowClientInfobyFilter1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ctrlShowClientInfobyFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowClientInfobyFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShowClientInfobyFilter1.Name = "ctrlShowClientInfobyFilter1";
            this.ctrlShowClientInfobyFilter1.SelectedFilter = BANK.ctrlShowClientInfobyFilter.enFilter.AccountNumber;
            this.ctrlShowClientInfobyFilter1.Size = new System.Drawing.Size(1014, 477);
            this.ctrlShowClientInfobyFilter1.TabIndex = 0;
            this.ctrlShowClientInfobyFilter1.OnClientSelected += new System.Action<int>(this.ctrlShowClientInfobyFilter1_OnClientSelected);
            // 
            // ctrlShowAccountInfobyFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(51)))), ((int)(((byte)(118)))));
            this.Controls.Add(this.ctrlShowBankAccountInfo1);
            this.Controls.Add(this.ctrlShowClientInfobyFilter1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctrlShowAccountInfobyFilter";
            this.Size = new System.Drawing.Size(1016, 766);
            this.Load += new System.EventHandler(this.ctrlShowAccountInfobyFilter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowClientInfobyFilter ctrlShowClientInfobyFilter1;
        private ctrlShowBankAccountInfo ctrlShowBankAccountInfo1;
    }
}

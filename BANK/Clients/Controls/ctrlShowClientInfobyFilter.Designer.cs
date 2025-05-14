namespace BANK
{
    partial class ctrlShowClientInfobyFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlShowClientInfobyFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindClient = new System.Windows.Forms.Button();
            this.tbFilterText = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlShowClientInfo1 = new BANK.ctrlShowClientInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindClient);
            this.gbFilter.Controls.Add(this.tbFilterText);
            this.gbFilter.Controls.Add(this.cbFilter);
            this.gbFilter.Location = new System.Drawing.Point(8, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(997, 86);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindClient
            // 
            this.btnFindClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindClient.Enabled = false;
            this.btnFindClient.Image = ((System.Drawing.Image)(resources.GetObject("btnFindClient.Image")));
            this.btnFindClient.Location = new System.Drawing.Point(543, 19);
            this.btnFindClient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFindClient.Name = "btnFindClient";
            this.btnFindClient.Size = new System.Drawing.Size(72, 59);
            this.btnFindClient.TabIndex = 3;
            this.btnFindClient.UseVisualStyleBackColor = true;
            this.btnFindClient.Click += new System.EventHandler(this.btnFindClient_Click);
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
            // ctrlShowClientInfo1
            // 
            this.ctrlShowClientInfo1.ContorlForeColor = System.Drawing.Color.Empty;
            this.ctrlShowClientInfo1.ControlBackColor = System.Drawing.Color.Empty;
            this.ctrlShowClientInfo1.Font = new System.Drawing.Font("Century Schoolbook", 10F, System.Drawing.FontStyle.Bold);
            this.ctrlShowClientInfo1.Location = new System.Drawing.Point(2, 87);
            this.ctrlShowClientInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlShowClientInfo1.Name = "ctrlShowClientInfo1";
            this.ctrlShowClientInfo1.Size = new System.Drawing.Size(1010, 385);
            this.ctrlShowClientInfo1.TabIndex = 0;
            // 
            // ctrlShowClientInfobyFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlShowClientInfo1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlShowClientInfobyFilter";
            this.Size = new System.Drawing.Size(1014, 477);
            this.Load += new System.EventHandler(this.ctrlShowClientInfobyFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowClientInfo ctrlShowClientInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnFindClient;
        private System.Windows.Forms.TextBox tbFilterText;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

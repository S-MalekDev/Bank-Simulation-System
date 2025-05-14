namespace BANK
{
    partial class frmManageTransferTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageTransferTypes));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNumberRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTransferTypesList = new System.Windows.Forms.DataGridView();
            this.cmsTransferTypesList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferTypesList)).BeginInit();
            this.cmsTransferTypesList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 564);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 21);
            this.label3.TabIndex = 44;
            this.label3.Text = "Number Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(231, 237);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 47);
            this.label1.TabIndex = 41;
            this.label1.Text = "Manage Transfer Types";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(384, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // lblNumberRecords
            // 
            this.lblNumberRecords.AutoSize = true;
            this.lblNumberRecords.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberRecords.Location = new System.Drawing.Point(173, 564);
            this.lblNumberRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberRecords.Name = "lblNumberRecords";
            this.lblNumberRecords.Size = new System.Drawing.Size(30, 21);
            this.lblNumberRecords.TabIndex = 45;
            this.lblNumberRecords.Text = "00";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(797, 564);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 45);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTransferTypesList
            // 
            this.dgvTransferTypesList.AllowUserToAddRows = false;
            this.dgvTransferTypesList.AllowUserToDeleteRows = false;
            this.dgvTransferTypesList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTransferTypesList.ColumnHeadersHeight = 30;
            this.dgvTransferTypesList.ContextMenuStrip = this.cmsTransferTypesList;
            this.dgvTransferTypesList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvTransferTypesList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransferTypesList.Location = new System.Drawing.Point(12, 298);
            this.dgvTransferTypesList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransferTypesList.MultiSelect = false;
            this.dgvTransferTypesList.Name = "dgvTransferTypesList";
            this.dgvTransferTypesList.ReadOnly = true;
            this.dgvTransferTypesList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTransferTypesList.RowHeadersWidth = 25;
            this.dgvTransferTypesList.RowTemplate.Height = 24;
            this.dgvTransferTypesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferTypesList.ShowCellErrors = false;
            this.dgvTransferTypesList.ShowCellToolTips = false;
            this.dgvTransferTypesList.ShowEditingIcon = false;
            this.dgvTransferTypesList.ShowRowErrors = false;
            this.dgvTransferTypesList.Size = new System.Drawing.Size(944, 256);
            this.dgvTransferTypesList.TabIndex = 43;
            this.dgvTransferTypesList.TabStop = false;
            // 
            // cmsTransferTypesList
            // 
            this.cmsTransferTypesList.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTransferTypesList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTransferTypesList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateToolStripMenuItem});
            this.cmsTransferTypesList.Name = "cmsPeopleList";
            this.cmsTransferTypesList.Size = new System.Drawing.Size(156, 42);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UpdateToolStripMenuItem.Image")));
            this.UpdateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(155, 38);
            this.UpdateToolStripMenuItem.Text = "Update";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // frmManageTransferTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 623);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNumberRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTransferTypesList);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageTransferTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Transfer Types";
            this.Load += new System.EventHandler(this.frmManageTransferTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferTypesList)).EndInit();
            this.cmsTransferTypesList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumberRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTransferTypesList;
        private System.Windows.Forms.ContextMenuStrip cmsTransferTypesList;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
    }
}
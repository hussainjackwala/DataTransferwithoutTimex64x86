namespace DataTransfer
{
    partial class FrmMapFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMapFields));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LvMap = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSourceField = new System.Windows.Forms.Label();
            this.lblMasterField = new System.Windows.Forms.Label();
            this.cmdSetMaster = new System.Windows.Forms.Button();
            this.bfnClear = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnmap = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.LvSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.CboSourceTables = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LvDestination = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel7 = new System.Windows.Forms.Panel();
            this.CboDestinationTables = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnChangeDbInfo = new System.Windows.Forms.Button();
            this.CboDbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIELD MAPPING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LvMap);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 297);
            this.panel1.TabIndex = 1;
            // 
            // LvMap
            // 
            this.LvMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.LvMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvMap.FullRowSelect = true;
            this.LvMap.GridLines = true;
            this.LvMap.Location = new System.Drawing.Point(0, 38);
            this.LvMap.Name = "LvMap";
            this.LvMap.Size = new System.Drawing.Size(871, 257);
            this.LvMap.TabIndex = 4;
            this.LvMap.UseCompatibleStateImageBehavior = false;
            this.LvMap.View = System.Windows.Forms.View.Details;
            this.LvMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LvMap_KeyDown);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Source Field Name";
            this.columnHeader5.Width = 362;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destination Field Name";
            this.columnHeader6.Width = 321;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Data Type";
            this.columnHeader7.Width = 128;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSourceField);
            this.panel4.Controls.Add(this.lblMasterField);
            this.panel4.Controls.Add(this.cmdSetMaster);
            this.panel4.Controls.Add(this.bfnClear);
            this.panel4.Controls.Add(this.btnsave);
            this.panel4.Controls.Add(this.btnmap);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(871, 38);
            this.panel4.TabIndex = 0;
            // 
            // lblSourceField
            // 
            this.lblSourceField.AutoSize = true;
            this.lblSourceField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceField.Location = new System.Drawing.Point(412, 16);
            this.lblSourceField.Name = "lblSourceField";
            this.lblSourceField.Size = new System.Drawing.Size(0, 15);
            this.lblSourceField.TabIndex = 5;
            // 
            // lblMasterField
            // 
            this.lblMasterField.AutoSize = true;
            this.lblMasterField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterField.Location = new System.Drawing.Point(573, 16);
            this.lblMasterField.Name = "lblMasterField";
            this.lblMasterField.Size = new System.Drawing.Size(0, 15);
            this.lblMasterField.TabIndex = 4;
            // 
            // cmdSetMaster
            // 
            this.cmdSetMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmdSetMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSetMaster.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSetMaster.ForeColor = System.Drawing.Color.White;
            this.cmdSetMaster.Location = new System.Drawing.Point(242, 6);
            this.cmdSetMaster.Name = "cmdSetMaster";
            this.cmdSetMaster.Size = new System.Drawing.Size(119, 25);
            this.cmdSetMaster.TabIndex = 3;
            this.cmdSetMaster.Text = "Set Master Field";
            this.cmdSetMaster.UseVisualStyleBackColor = false;
            this.cmdSetMaster.Click += new System.EventHandler(this.cmdSetMaster_Click);
            // 
            // bfnClear
            // 
            this.bfnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bfnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bfnClear.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bfnClear.ForeColor = System.Drawing.Color.White;
            this.bfnClear.Location = new System.Drawing.Point(11, 6);
            this.bfnClear.Name = "bfnClear";
            this.bfnClear.Size = new System.Drawing.Size(95, 25);
            this.bfnClear.TabIndex = 2;
            this.bfnClear.Text = "Clear Mapping";
            this.bfnClear.UseVisualStyleBackColor = false;
            this.bfnClear.Click += new System.EventHandler(this.bfnClear_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(765, 6);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(95, 25);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnmap
            // 
            this.btnmap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnmap.Enabled = false;
            this.btnmap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmap.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmap.ForeColor = System.Drawing.Color.White;
            this.btnmap.Location = new System.Drawing.Point(129, 6);
            this.btnmap.Name = "btnmap";
            this.btnmap.Size = new System.Drawing.Size(95, 25);
            this.btnmap.TabIndex = 0;
            this.btnmap.Text = "Map Field";
            this.btnmap.UseVisualStyleBackColor = false;
            this.btnmap.Click += new System.EventHandler(this.btnmap_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.LvSource);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 284);
            this.panel2.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(317, 1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(95, 25);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // LvSource
            // 
            this.LvSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvSource.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvSource.FullRowSelect = true;
            this.LvSource.GridLines = true;
            this.LvSource.Location = new System.Drawing.Point(0, 55);
            this.LvSource.Name = "LvSource";
            this.LvSource.Size = new System.Drawing.Size(416, 229);
            this.LvSource.TabIndex = 2;
            this.LvSource.UseCompatibleStateImageBehavior = false;
            this.LvSource.View = System.Windows.Forms.View.Details;
            this.LvSource.Click += new System.EventHandler(this.LvSource_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field Name";
            this.columnHeader1.Width = 261;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 115;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.CboSourceTables);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(416, 27);
            this.panel6.TabIndex = 3;
            // 
            // CboSourceTables
            // 
            this.CboSourceTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CboSourceTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSourceTables.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSourceTables.FormattingEnabled = true;
            this.CboSourceTables.Location = new System.Drawing.Point(78, 0);
            this.CboSourceTables.Name = "CboSourceTables";
            this.CboSourceTables.Size = new System.Drawing.Size(338, 24);
            this.CboSourceTables.TabIndex = 3;
            this.CboSourceTables.SelectedIndexChanged += new System.EventHandler(this.CboSourceTables_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "TABLES:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "SOURCE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LvDestination);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(416, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(457, 284);
            this.panel3.TabIndex = 3;
            // 
            // LvDestination
            // 
            this.LvDestination.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.LvDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvDestination.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvDestination.FullRowSelect = true;
            this.LvDestination.GridLines = true;
            this.LvDestination.Location = new System.Drawing.Point(0, 55);
            this.LvDestination.Name = "LvDestination";
            this.LvDestination.Size = new System.Drawing.Size(457, 229);
            this.LvDestination.TabIndex = 3;
            this.LvDestination.UseCompatibleStateImageBehavior = false;
            this.LvDestination.View = System.Windows.Forms.View.Details;
            this.LvDestination.Click += new System.EventHandler(this.LvDestination_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Field Name";
            this.columnHeader3.Width = 261;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 115;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.CboDestinationTables);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 28);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(457, 27);
            this.panel7.TabIndex = 5;
            // 
            // CboDestinationTables
            // 
            this.CboDestinationTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CboDestinationTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDestinationTables.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboDestinationTables.FormattingEnabled = true;
            this.CboDestinationTables.Location = new System.Drawing.Point(78, 0);
            this.CboDestinationTables.Name = "CboDestinationTables";
            this.CboDestinationTables.Size = new System.Drawing.Size(379, 24);
            this.CboDestinationTables.TabIndex = 3;
            this.CboDestinationTables.SelectedIndexChanged += new System.EventHandler(this.CboDestinationTables_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "TABLES:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnChangeDbInfo);
            this.panel5.Controls.Add(this.CboDbType);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(457, 28);
            this.panel5.TabIndex = 4;
            // 
            // btnChangeDbInfo
            // 
            this.btnChangeDbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeDbInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeDbInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeDbInfo.ForeColor = System.Drawing.Color.White;
            this.btnChangeDbInfo.Location = new System.Drawing.Point(334, 2);
            this.btnChangeDbInfo.Name = "btnChangeDbInfo";
            this.btnChangeDbInfo.Size = new System.Drawing.Size(111, 23);
            this.btnChangeDbInfo.TabIndex = 3;
            this.btnChangeDbInfo.Text = "Change DB Info";
            this.btnChangeDbInfo.UseVisualStyleBackColor = false;
            this.btnChangeDbInfo.Visible = false;
            this.btnChangeDbInfo.Click += new System.EventHandler(this.btnChangeDbInfo_Click);
            // 
            // CboDbType
            // 
            this.CboDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboDbType.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboDbType.FormattingEnabled = true;
            this.CboDbType.Location = new System.Drawing.Point(161, 2);
            this.CboDbType.Name = "CboDbType";
            this.CboDbType.Size = new System.Drawing.Size(167, 24);
            this.CboDbType.TabIndex = 2;
            this.CboDbType.SelectedIndexChanged += new System.EventHandler(this.CboDbType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "DESTINATION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMapFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(873, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMapFields";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fields Mapping";
            this.Load += new System.EventHandler(this.FrmMapFields_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView LvSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView LvDestination;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView LvMap;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnmap;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox CboDbType;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnChangeDbInfo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox CboSourceTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox CboDestinationTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bfnClear;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cmdSetMaster;
        private System.Windows.Forms.Label lblMasterField;
        private System.Windows.Forms.Label lblSourceField;
    }
}
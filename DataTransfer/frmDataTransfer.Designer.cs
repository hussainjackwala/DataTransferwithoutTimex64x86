namespace DataTransfer
{
    partial class frmDataTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataTransfer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.btnDataTransfer = new System.Windows.Forms.Button();
            this.btn_FetchData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbldbInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DG1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 474);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail List For Data Transfer";
            // 
            // DG1
            // 
            this.DG1.AllowUserToAddRows = false;
            this.DG1.AllowUserToDeleteRows = false;
            this.DG1.BackgroundColor = System.Drawing.Color.White;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG1.Location = new System.Drawing.Point(3, 17);
            this.DG1.Name = "DG1";
            this.DG1.RowHeadersVisible = false;
            this.DG1.Size = new System.Drawing.Size(1274, 454);
            this.DG1.TabIndex = 0;
            // 
            // btnDataTransfer
            // 
            this.btnDataTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDataTransfer.Enabled = false;
            this.btnDataTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataTransfer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataTransfer.ForeColor = System.Drawing.Color.White;
            this.btnDataTransfer.Location = new System.Drawing.Point(162, 5);
            this.btnDataTransfer.Name = "btnDataTransfer";
            this.btnDataTransfer.Size = new System.Drawing.Size(115, 33);
            this.btnDataTransfer.TabIndex = 7;
            this.btnDataTransfer.Text = "Start Transfer";
            this.btnDataTransfer.UseVisualStyleBackColor = false;
            this.btnDataTransfer.Click += new System.EventHandler(this.btnDataTransfer_Click);
            // 
            // btn_FetchData
            // 
            this.btn_FetchData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_FetchData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FetchData.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FetchData.ForeColor = System.Drawing.Color.White;
            this.btn_FetchData.Location = new System.Drawing.Point(10, 5);
            this.btn_FetchData.Name = "btn_FetchData";
            this.btn_FetchData.Size = new System.Drawing.Size(145, 33);
            this.btn_FetchData.TabIndex = 6;
            this.btn_FetchData.Text = "Fetch Data";
            this.btn_FetchData.UseVisualStyleBackColor = false;
            this.btn_FetchData.Click += new System.EventHandler(this.btn_FetchData_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDataTransfer);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.btn_FetchData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 42);
            this.panel1.TabIndex = 12;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(285, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Fetch Data";
            // 
            // lbldbInfo
            // 
            this.lbldbInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbldbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbldbInfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldbInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldbInfo.Location = new System.Drawing.Point(0, 0);
            this.lbldbInfo.Name = "lbldbInfo";
            this.lbldbInfo.Size = new System.Drawing.Size(1284, 37);
            this.lbldbInfo.TabIndex = 2;
            this.lbldbInfo.Text = "DATA TRANSFER";
            this.lbldbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDataTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 562);
            this.Controls.Add(this.lbldbInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDataTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Transfer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataTransfer_FormClosing);
            this.Load += new System.EventHandler(this.frmDataTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDataTransfer;
        private System.Windows.Forms.Button btn_FetchData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView DG1;
        public System.Windows.Forms.Label lbldbInfo;
    }
}
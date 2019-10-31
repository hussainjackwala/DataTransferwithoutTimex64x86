namespace DataTransfer
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.Pbimg = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_DataTransfer = new System.Windows.Forms.Button();
            this.btn_FieldMapping = new System.Windows.Forms.Button();
            this.Tm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Pbimg)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pbimg
            // 
            this.Pbimg.BackgroundImage = global::DataTransfer.Properties.Resources.logo;
            this.Pbimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Pbimg.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pbimg.Location = new System.Drawing.Point(0, 0);
            this.Pbimg.Name = "Pbimg";
            this.Pbimg.Size = new System.Drawing.Size(656, 121);
            this.Pbimg.TabIndex = 0;
            this.Pbimg.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Exit);
            this.panel3.Controls.Add(this.btn_DataTransfer);
            this.panel3.Controls.Add(this.btn_FieldMapping);
            this.panel3.Location = new System.Drawing.Point(149, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 140);
            this.panel3.TabIndex = 1;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Location = new System.Drawing.Point(110, 79);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(145, 33);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_DataTransfer
            // 
            this.btn_DataTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_DataTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DataTransfer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DataTransfer.ForeColor = System.Drawing.Color.White;
            this.btn_DataTransfer.Location = new System.Drawing.Point(189, 28);
            this.btn_DataTransfer.Name = "btn_DataTransfer";
            this.btn_DataTransfer.Size = new System.Drawing.Size(145, 33);
            this.btn_DataTransfer.TabIndex = 8;
            this.btn_DataTransfer.Text = "Data Transfer";
            this.btn_DataTransfer.UseVisualStyleBackColor = false;
            this.btn_DataTransfer.Click += new System.EventHandler(this.btn_DataTransfer_Click);
            // 
            // btn_FieldMapping
            // 
            this.btn_FieldMapping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_FieldMapping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FieldMapping.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FieldMapping.ForeColor = System.Drawing.Color.White;
            this.btn_FieldMapping.Location = new System.Drawing.Point(26, 28);
            this.btn_FieldMapping.Name = "btn_FieldMapping";
            this.btn_FieldMapping.Size = new System.Drawing.Size(145, 33);
            this.btn_FieldMapping.TabIndex = 7;
            this.btn_FieldMapping.Text = " Field Mapping";
            this.btn_FieldMapping.UseVisualStyleBackColor = false;
            this.btn_FieldMapping.Click += new System.EventHandler(this.btn_FieldMapping_Click);
            // 
            // Tm
            // 
            this.Tm.Tick += new System.EventHandler(this.Tm_Tick);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 312);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Pbimg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminPanel";
            this.Text = "Data Transfer";
            ((System.ComponentModel.ISupportInitialize)(this.Pbimg)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.PictureBox Pbimg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_DataTransfer;
        private System.Windows.Forms.Button btn_FieldMapping;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Timer Tm;
    }
}
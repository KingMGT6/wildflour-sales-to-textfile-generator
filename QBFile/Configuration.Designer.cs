namespace QBFile
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtrmwinpath = new System.Windows.Forms.TextBox();
            this.txtfolderpath = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsavefolder = new System.Windows.Forms.Button();
            this.btnrmwinfolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbranchname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbdesc = new System.Windows.Forms.ComboBox();
            this.cmbstore = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "RmWin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Folder:";
            // 
            // txtrmwinpath
            // 
            this.txtrmwinpath.Location = new System.Drawing.Point(96, 24);
            this.txtrmwinpath.Name = "txtrmwinpath";
            this.txtrmwinpath.Size = new System.Drawing.Size(253, 22);
            this.txtrmwinpath.TabIndex = 4;
            // 
            // txtfolderpath
            // 
            this.txtfolderpath.Location = new System.Drawing.Point(96, 54);
            this.txtfolderpath.Name = "txtfolderpath";
            this.txtfolderpath.Size = new System.Drawing.Size(253, 22);
            this.txtfolderpath.TabIndex = 5;
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(12, 239);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(403, 34);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "====== UPDATE ======";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnsavefolder);
            this.groupBox2.Controls.Add(this.btnrmwinfolder);
            this.groupBox2.Controls.Add(this.txtrmwinpath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtfolderpath);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 89);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnsavefolder
            // 
            this.btnsavefolder.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsavefolder.Location = new System.Drawing.Point(351, 54);
            this.btnsavefolder.Name = "btnsavefolder";
            this.btnsavefolder.Size = new System.Drawing.Size(33, 23);
            this.btnsavefolder.TabIndex = 14;
            this.btnsavefolder.Text = "...";
            this.btnsavefolder.UseVisualStyleBackColor = true;
            this.btnsavefolder.Click += new System.EventHandler(this.btnsavefolder_Click);
            // 
            // btnrmwinfolder
            // 
            this.btnrmwinfolder.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrmwinfolder.Location = new System.Drawing.Point(351, 24);
            this.btnrmwinfolder.Name = "btnrmwinfolder";
            this.btnrmwinfolder.Size = new System.Drawing.Size(33, 23);
            this.btnrmwinfolder.TabIndex = 13;
            this.btnrmwinfolder.Text = "...";
            this.btnrmwinfolder.UseVisualStyleBackColor = true;
            this.btnrmwinfolder.Click += new System.EventHandler(this.btnrmwinfolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbranchname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbdesc);
            this.groupBox1.Controls.Add(this.cmbstore);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 138);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // txtbranchname
            // 
            this.txtbranchname.Location = new System.Drawing.Point(142, 26);
            this.txtbranchname.Name = "txtbranchname";
            this.txtbranchname.Size = new System.Drawing.Size(242, 22);
            this.txtbranchname.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Branch Name:";
            // 
            // cmbdesc
            // 
            this.cmbdesc.FormattingEnabled = true;
            this.cmbdesc.Location = new System.Drawing.Point(96, 97);
            this.cmbdesc.Name = "cmbdesc";
            this.cmbdesc.Size = new System.Drawing.Size(288, 24);
            this.cmbdesc.TabIndex = 5;
            // 
            // cmbstore
            // 
            this.cmbstore.FormattingEnabled = true;
            this.cmbstore.Location = new System.Drawing.Point(96, 62);
            this.cmbstore.Name = "cmbstore";
            this.cmbstore.Size = new System.Drawing.Size(288, 24);
            this.cmbstore.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Desc.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Store:";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(426, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnsave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Configuration";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrmwinpath;
        private System.Windows.Forms.TextBox txtfolderpath;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnrmwinfolder;
        private System.Windows.Forms.Button btnsavefolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbstore;
        private System.Windows.Forms.ComboBox cmbdesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbranchname;
    }
}
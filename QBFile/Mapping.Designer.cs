namespace QBFile
{
    partial class Mapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mapping));
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.dgvMOP = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvrmcat = new System.Windows.Forms.DataGridView();
            this.dgvrmmop = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrmcat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrmmop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCategory
            // 
            this.dgvCategory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCategory.Location = new System.Drawing.Point(12, 30);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowTemplate.Height = 24;
            this.dgvCategory.Size = new System.Drawing.Size(395, 178);
            this.dgvCategory.TabIndex = 0;
            // 
            // dgvMOP
            // 
            this.dgvMOP.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMOP.Location = new System.Drawing.Point(429, 30);
            this.dgvMOP.Name = "dgvMOP";
            this.dgvMOP.RowTemplate.Height = 24;
            this.dgvMOP.Size = new System.Drawing.Size(395, 178);
            this.dgvMOP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Payment Types";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(221, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(395, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "====== CLICK HERE TO UPDATE ======";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvrmcat
            // 
            this.dgvrmcat.Location = new System.Drawing.Point(12, 214);
            this.dgvrmcat.Name = "dgvrmcat";
            this.dgvrmcat.ReadOnly = true;
            this.dgvrmcat.RowTemplate.Height = 24;
            this.dgvrmcat.Size = new System.Drawing.Size(395, 178);
            this.dgvrmcat.TabIndex = 5;
            // 
            // dgvrmmop
            // 
            this.dgvrmmop.Location = new System.Drawing.Point(429, 214);
            this.dgvrmmop.Name = "dgvrmmop";
            this.dgvrmmop.ReadOnly = true;
            this.dgvrmmop.RowTemplate.Height = 24;
            this.dgvrmmop.Size = new System.Drawing.Size(395, 178);
            this.dgvrmmop.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(413, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 362);
            this.label3.TabIndex = 7;
            // 
            // Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(837, 438);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvrmmop);
            this.Controls.Add(this.dgvrmcat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMOP);
            this.Controls.Add(this.dgvCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mapping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QB Naming Convention";
            this.Load += new System.EventHandler(this.Mapping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrmcat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrmmop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.DataGridView dgvMOP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvrmcat;
        private System.Windows.Forms.DataGridView dgvrmmop;
        private System.Windows.Forms.Label label3;
    }
}
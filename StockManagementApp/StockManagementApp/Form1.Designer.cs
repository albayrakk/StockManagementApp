namespace StockManagementApp
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateCustomers = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.btnCustomerPanel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateCustomers
            // 
            this.btnGenerateCustomers.Location = new System.Drawing.Point(84, 33);
            this.btnGenerateCustomers.Name = "btnGenerateCustomers";
            this.btnGenerateCustomers.Size = new System.Drawing.Size(186, 30);
            this.btnGenerateCustomers.TabIndex = 0;
            this.btnGenerateCustomers.Text = "Rastgele Müşteri Oluştur";
            this.btnGenerateCustomers.UseVisualStyleBackColor = true;
            this.btnGenerateCustomers.Click += new System.EventHandler(this.btnGenerateCustomers_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 82);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.Size = new System.Drawing.Size(392, 278);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.Location = new System.Drawing.Point(513, 39);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(131, 23);
            this.btnAdminPanel.TabIndex = 2;
            this.btnAdminPanel.Text = "Admin Paneli";
            this.btnAdminPanel.UseVisualStyleBackColor = true;
            this.btnAdminPanel.Click += new System.EventHandler(this.btnAdminPanel_Click);
            // 
            // btnCustomerPanel
            // 
            this.btnCustomerPanel.Location = new System.Drawing.Point(513, 105);
            this.btnCustomerPanel.Name = "btnCustomerPanel";
            this.btnCustomerPanel.Size = new System.Drawing.Size(131, 23);
            this.btnCustomerPanel.TabIndex = 3;
            this.btnCustomerPanel.Text = "Müşteri Paneli";
            this.btnCustomerPanel.UseVisualStyleBackColor = true;
            this.btnCustomerPanel.Click += new System.EventHandler(this.btnCustomerPanel_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCustomerPanel);
            this.Controls.Add(this.btnAdminPanel);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnGenerateCustomers);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.Button btnCustomerPanel;
    }
}


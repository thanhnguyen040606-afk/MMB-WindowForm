namespace WindowsFormsApp1
{
    partial class frmKiemKe
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
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatCSV = new System.Windows.Forms.Button();
            this.dgvKiemKe = new System.Windows.Forms.DataGridView();
            this.lblTongKet = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Location = new System.Drawing.Point(12, 15);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(470, 16);
            this.lblHuongDan.TabIndex = 0;
            this.lblHuongDan.Text = "Nhập số đếm thực tế vào cột được tô vàng, chương trình sẽ tự tính chênh lệch.";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Location = new System.Drawing.Point(660, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 30);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXuatCSV
            // 
            this.btnXuatCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatCSV.Location = new System.Drawing.Point(778, 8);
            this.btnXuatCSV.Name = "btnXuatCSV";
            this.btnXuatCSV.Size = new System.Drawing.Size(110, 30);
            this.btnXuatCSV.TabIndex = 2;
            this.btnXuatCSV.Text = "Xuất CSV";
            this.btnXuatCSV.UseVisualStyleBackColor = true;
            this.btnXuatCSV.Click += new System.EventHandler(this.btnXuatCSV_Click);
            // 
            // dgvKiemKe
            // 
            this.dgvKiemKe.AllowUserToAddRows = false;
            this.dgvKiemKe.AllowUserToDeleteRows = false;
            this.dgvKiemKe.AllowUserToResizeRows = false;
            this.dgvKiemKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKiemKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemKe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvKiemKe.Location = new System.Drawing.Point(12, 45);
            this.dgvKiemKe.MultiSelect = false;
            this.dgvKiemKe.Name = "dgvKiemKe";
            this.dgvKiemKe.RowHeadersVisible = false;
            this.dgvKiemKe.RowTemplate.Height = 24;
            this.dgvKiemKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvKiemKe.Size = new System.Drawing.Size(876, 395);
            this.dgvKiemKe.TabIndex = 3;
            this.dgvKiemKe.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKiemKe_CellEndEdit);
            this.dgvKiemKe.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvKiemKe_DataError);
            // 
            // lblTongKet
            // 
            this.lblTongKet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongKet.AutoSize = true;
            this.lblTongKet.Location = new System.Drawing.Point(12, 453);
            this.lblTongKet.Name = "lblTongKet";
            this.lblTongKet.Size = new System.Drawing.Size(0, 16);
            this.lblTongKet.TabIndex = 4;
            // 
            // frmKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblTongKet);
            this.Controls.Add(this.dgvKiemKe);
            this.Controls.Add(this.btnXuatCSV);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.lblHuongDan);
            this.Name = "frmKiemKe";
            this.Text = "Kiểm kê vật tư";
            this.Load += new System.EventHandler(this.frmKiemKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatCSV;
        private System.Windows.Forms.DataGridView dgvKiemKe;
        private System.Windows.Forms.Label lblTongKet;
    }
}

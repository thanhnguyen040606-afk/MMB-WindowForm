namespace WindowsFormsApp1
{
    partial class frmQuanLyVatTu
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
            this.TVNhomsVattu = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.themNhomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suaNhomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoaNhomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstvVatTu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxMaNhom = new System.Windows.Forms.ComboBox();
            this.txtTonToithieu = new System.Windows.Forms.TextBox();
            this.txtDonviTinh = new System.Windows.Forms.TextBox();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnNhapCSV = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TVNhomsVattu
            // 
            this.TVNhomsVattu.ContextMenuStrip = this.contextMenuStrip1;
            this.TVNhomsVattu.Location = new System.Drawing.Point(12, 12);
            this.TVNhomsVattu.Name = "TVNhomsVattu";
            this.TVNhomsVattu.Size = new System.Drawing.Size(241, 259);
            this.TVNhomsVattu.TabIndex = 0;
            this.TVNhomsVattu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVNhomsVattu_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themNhomToolStripMenuItem,
            this.suaNhomToolStripMenuItem,
            this.xoaNhomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 76);
            // 
            // themNhomToolStripMenuItem
            // 
            this.themNhomToolStripMenuItem.Name = "themNhomToolStripMenuItem";
            this.themNhomToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.themNhomToolStripMenuItem.Text = "Thêm nhóm";
            this.themNhomToolStripMenuItem.Click += new System.EventHandler(this.themNhomToolStripMenuItem_Click);
            // 
            // suaNhomToolStripMenuItem
            // 
            this.suaNhomToolStripMenuItem.Name = "suaNhomToolStripMenuItem";
            this.suaNhomToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.suaNhomToolStripMenuItem.Text = "Sửa nhóm";
            this.suaNhomToolStripMenuItem.Click += new System.EventHandler(this.suaNhomToolStripMenuItem_Click);
            // 
            // xoaNhomToolStripMenuItem
            // 
            this.xoaNhomToolStripMenuItem.Name = "xoaNhomToolStripMenuItem";
            this.xoaNhomToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.xoaNhomToolStripMenuItem.Text = "Xóa nhóm";
            this.xoaNhomToolStripMenuItem.Click += new System.EventHandler(this.xoaNhomToolStripMenuItem_Click);
            // 
            // lstvVatTu
            // 
            this.lstvVatTu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstvVatTu.FullRowSelect = true;
            this.lstvVatTu.GridLines = true;
            this.lstvVatTu.HideSelection = false;
            this.lstvVatTu.Location = new System.Drawing.Point(274, 12);
            this.lstvVatTu.Name = "lstvVatTu";
            this.lstvVatTu.Size = new System.Drawing.Size(514, 259);
            this.lstvVatTu.TabIndex = 1;
            this.lstvVatTu.UseCompatibleStateImageBehavior = false;
            this.lstvVatTu.View = System.Windows.Forms.View.Details;
            this.lstvVatTu.SelectedIndexChanged += new System.EventHandler(this.lstvVatTu_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã VT";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên VT";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn vị tính";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tồn tối thiểu";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã nhóm";
            this.columnHeader5.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxMaNhom);
            this.groupBox1.Controls.Add(this.txtTonToithieu);
            this.groupBox1.Controls.Add(this.txtDonviTinh);
            this.groupBox1.Controls.Add(this.txtTenVT);
            this.groupBox1.Controls.Add(this.txtMaVT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cbxMaNhom
            // 
            this.cbxMaNhom.FormattingEnabled = true;
            this.cbxMaNhom.Location = new System.Drawing.Point(468, 45);
            this.cbxMaNhom.Name = "cbxMaNhom";
            this.cbxMaNhom.Size = new System.Drawing.Size(121, 24);
            this.cbxMaNhom.TabIndex = 9;
            this.cbxMaNhom.SelectedIndexChanged += new System.EventHandler(this.cbxMaNhom_SelectedIndexChanged);
            // 
            // txtTonToithieu
            // 
            this.txtTonToithieu.Location = new System.Drawing.Point(468, 15);
            this.txtTonToithieu.Name = "txtTonToithieu";
            this.txtTonToithieu.Size = new System.Drawing.Size(121, 22);
            this.txtTonToithieu.TabIndex = 8;
            // 
            // txtDonviTinh
            // 
            this.txtDonviTinh.Location = new System.Drawing.Point(84, 71);
            this.txtDonviTinh.Name = "txtDonviTinh";
            this.txtDonviTinh.Size = new System.Drawing.Size(116, 22);
            this.txtDonviTinh.TabIndex = 7;
            this.txtDonviTinh.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(84, 43);
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.Size = new System.Drawing.Size(221, 22);
            this.txtTenVT.TabIndex = 6;
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(84, 15);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(116, 22);
            this.txtMaVT.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tồn tối thiểu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã nhóm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên vật tư:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã vật tư:";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(21, 396);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 42);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(120, 396);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 42);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(218, 396);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 42);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnNhapCSV
            // 
            this.btnNhapCSV.Location = new System.Drawing.Point(316, 396);
            this.btnNhapCSV.Name = "btnNhapCSV";
            this.btnNhapCSV.Size = new System.Drawing.Size(92, 42);
            this.btnNhapCSV.TabIndex = 6;
            this.btnNhapCSV.Text = "Nhập CSV";
            this.btnNhapCSV.UseVisualStyleBackColor = true;
            this.btnNhapCSV.Click += new System.EventHandler(this.btnNhapCSV_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(512, 406);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(276, 22);
            this.txtTimKiem.TabIndex = 10;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(414, 396);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(92, 42);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frmQuanLyVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnNhapCSV);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstvVatTu);
            this.Controls.Add(this.TVNhomsVattu);
            this.Name = "frmQuanLyVatTu";
            this.Text = "frmQuanLyVatTu";
            this.Load += new System.EventHandler(this.frmQuanLyVatTu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TVNhomsVattu;
        private System.Windows.Forms.ListView lstvVatTu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDonviTinh;
        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMaNhom;
        private System.Windows.Forms.TextBox txtTonToithieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnNhapCSV;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem themNhomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suaNhomToolStripMenuItem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ToolStripMenuItem xoaNhomToolStripMenuItem;
    }
}
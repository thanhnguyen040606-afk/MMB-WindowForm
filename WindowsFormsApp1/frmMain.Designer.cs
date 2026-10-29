namespace WindowsFormsApp1
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hethongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vatTuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiepVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpPhiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpPhiếuXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tonKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kiemKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuaSoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xepNgangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xepDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xepChongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dongCuaSoHienTaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dongTatCaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hethongToolStripMenuItem,
            this.danhMucToolStripMenuItem,
            this.nghiepVuToolStripMenuItem,
            this.baoCaoToolStripMenuItem,
            this.cuaSoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hethongToolStripMenuItem
            // 
            this.hethongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangXuatToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.hethongToolStripMenuItem.Name = "hethongToolStripMenuItem";
            this.hethongToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hethongToolStripMenuItem.Text = "Hệ thống";
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.dangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // danhMucToolStripMenuItem
            // 
            this.danhMucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vatTuToolStripMenuItem,
            this.nhaCungCapToolStripMenuItem});
            this.danhMucToolStripMenuItem.Name = "danhMucToolStripMenuItem";
            this.danhMucToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.danhMucToolStripMenuItem.Text = "Danh mục";
            // 
            // vatTuToolStripMenuItem
            // 
            this.vatTuToolStripMenuItem.Name = "vatTuToolStripMenuItem";
            this.vatTuToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.vatTuToolStripMenuItem.Text = "Vật tư";
            this.vatTuToolStripMenuItem.Click += new System.EventHandler(this.vatTuToolStripMenuItem_Click);
            // 
            // nhaCungCapToolStripMenuItem
            // 
            this.nhaCungCapToolStripMenuItem.Name = "nhaCungCapToolStripMenuItem";
            this.nhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.nhaCungCapToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.nhaCungCapToolStripMenuItem_Click);
            // 
            // nghiepVuToolStripMenuItem
            // 
            this.nghiepVuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lậpPhiếuNhậpToolStripMenuItem,
            this.lậpPhiếuXuấtToolStripMenuItem});
            this.nghiepVuToolStripMenuItem.Name = "nghiepVuToolStripMenuItem";
            this.nghiepVuToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.nghiepVuToolStripMenuItem.Text = "Nghiệp vụ";
            // 
            // lậpPhiếuNhậpToolStripMenuItem
            // 
            this.lậpPhiếuNhậpToolStripMenuItem.Name = "lậpPhiếuNhậpToolStripMenuItem";
            this.lậpPhiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.lậpPhiếuNhậpToolStripMenuItem.Text = "Lập phiếu nhập";
            // 
            // lậpPhiếuXuấtToolStripMenuItem
            // 
            this.lậpPhiếuXuấtToolStripMenuItem.Name = "lậpPhiếuXuấtToolStripMenuItem";
            this.lậpPhiếuXuấtToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.lậpPhiếuXuấtToolStripMenuItem.Text = "Lập phiếu xuất";
            // 
            // baoCaoToolStripMenuItem
            // 
            this.baoCaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tonKhoToolStripMenuItem,
            this.kiemKeToolStripMenuItem});
            this.baoCaoToolStripMenuItem.Name = "baoCaoToolStripMenuItem";
            this.baoCaoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.baoCaoToolStripMenuItem.Text = "Báo cáo";
            // 
            // tonKhoToolStripMenuItem
            // 
            this.tonKhoToolStripMenuItem.Name = "tonKhoToolStripMenuItem";
            this.tonKhoToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.tonKhoToolStripMenuItem.Text = "Tồn kho";
            // 
            // kiemKeToolStripMenuItem
            // 
            this.kiemKeToolStripMenuItem.Name = "kiemKeToolStripMenuItem";
            this.kiemKeToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.kiemKeToolStripMenuItem.Text = "Kiểm kê";
            // 
            // cuaSoToolStripMenuItem
            // 
            this.cuaSoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xepNgangToolStripMenuItem,
            this.xepDocToolStripMenuItem,
            this.xepChongToolStripMenuItem,
            this.toolStripSeparator1,
            this.dongCuaSoHienTaiToolStripMenuItem,
            this.dongTatCaToolStripMenuItem});
            this.cuaSoToolStripMenuItem.Name = "cuaSoToolStripMenuItem";
            this.cuaSoToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.cuaSoToolStripMenuItem.Text = "Cửa sổ";
            // 
            // xepNgangToolStripMenuItem
            // 
            this.xepNgangToolStripMenuItem.Name = "xepNgangToolStripMenuItem";
            this.xepNgangToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.xepNgangToolStripMenuItem.Text = "Xếp ngang";
            this.xepNgangToolStripMenuItem.Click += new System.EventHandler(this.xepNgangToolStripMenuItem_Click);
            // 
            // xepDocToolStripMenuItem
            // 
            this.xepDocToolStripMenuItem.Name = "xepDocToolStripMenuItem";
            this.xepDocToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.xepDocToolStripMenuItem.Text = "Xếp dọc";
            this.xepDocToolStripMenuItem.Click += new System.EventHandler(this.xepDocToolStripMenuItem_Click);
            // 
            // xepChongToolStripMenuItem
            // 
            this.xepChongToolStripMenuItem.Name = "xepChongToolStripMenuItem";
            this.xepChongToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.xepChongToolStripMenuItem.Text = "Xếp chồng";
            this.xepChongToolStripMenuItem.Click += new System.EventHandler(this.xepChongToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // dongCuaSoHienTaiToolStripMenuItem
            // 
            this.dongCuaSoHienTaiToolStripMenuItem.Name = "dongCuaSoHienTaiToolStripMenuItem";
            this.dongCuaSoHienTaiToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.dongCuaSoHienTaiToolStripMenuItem.Text = "Đóng cửa sổ hiện tại";
            this.dongCuaSoHienTaiToolStripMenuItem.Click += new System.EventHandler(this.dongCuaSoHienTaiToolStripMenuItem_Click);
            // 
            // dongTatCaToolStripMenuItem
            // 
            this.dongTatCaToolStripMenuItem.Name = "dongTatCaToolStripMenuItem";
            this.dongTatCaToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.dongTatCaToolStripMenuItem.Text = "Đóng tất cả";
            this.dongTatCaToolStripMenuItem.Click += new System.EventHandler(this.dongTatCaToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(141, 20);
            this.toolStripStatusLabel1.Text = "Trạng thái: Sẵn sàng";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hethongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vatTuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaCungCapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghiepVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpPhiếuNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpPhiếuXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baoCaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tonKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kiemKeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuaSoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xepNgangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xepDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xepChongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dongCuaSoHienTaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dongTatCaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer1;
    }
}
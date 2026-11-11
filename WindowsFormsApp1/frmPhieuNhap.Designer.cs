namespace WindowsFormsApp1
{
    partial class frmPhieuNhap
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
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.groupChiTiet = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lvChiTiet = new System.Windows.Forms.ListView();
            this.colCTMaVT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTTenVT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTDonViTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTThanhTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnThemDong = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTonHienTai = new System.Windows.Forms.Label();
            this.cboVatTu = new System.Windows.Forms.ComboBox();
            this.lblVatTu = new System.Windows.Forms.Label();
            this.groupDanhSach = new System.Windows.Forms.GroupBox();
            this.btnPhieuMoi = new System.Windows.Forms.Button();
            this.btnXuatTxt = new System.Windows.Forms.Button();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnMoPhieu = new System.Windows.Forms.Button();
            this.lvPhieu = new System.Windows.Forms.ListView();
            this.colPNSoPhieu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPNNgayLap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPNNhaCungCap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPNNguoiLap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPNTongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPNTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.lblCheDo = new System.Windows.Forms.Label();
            this.groupThongTin.SuspendLayout();
            this.groupChiTiet.SuspendLayout();
            this.groupDanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.txtGhiChu);
            this.groupThongTin.Controls.Add(this.lblGhiChu);
            this.groupThongTin.Controls.Add(this.txtNguoiLap);
            this.groupThongTin.Controls.Add(this.lblNguoiLap);
            this.groupThongTin.Controls.Add(this.cboNhaCungCap);
            this.groupThongTin.Controls.Add(this.lblNhaCungCap);
            this.groupThongTin.Controls.Add(this.dtpNgayLap);
            this.groupThongTin.Controls.Add(this.lblNgayLap);
            this.groupThongTin.Controls.Add(this.txtSoPhieu);
            this.groupThongTin.Controls.Add(this.lblSoPhieu);
            this.groupThongTin.Location = new System.Drawing.Point(14, 12);
            this.groupThongTin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupThongTin.Size = new System.Drawing.Size(1098, 138);
            this.groupThongTin.TabIndex = 0;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin phiếu nhập";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(384, 80);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(708, 26);
            this.txtGhiChu.TabIndex = 9;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGhiChu.Location = new System.Drawing.Point(288, 82);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(85, 25);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(128, 80);
            this.txtNguoiLap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.ReadOnly = true;
            this.txtNguoiLap.Size = new System.Drawing.Size(146, 26);
            this.txtNguoiLap.TabIndex = 7;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNguoiLap.Location = new System.Drawing.Point(16, 82);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(100, 25);
            this.lblNguoiLap.TabIndex = 6;
            this.lblNguoiLap.Text = "Người lập:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(746, 34);
            this.cboNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(346, 28);
            this.cboNhaCungCap.TabIndex = 5;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhaCungCap.Location = new System.Drawing.Point(593, 35);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(139, 25);
            this.lblNhaCungCap.TabIndex = 4;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(399, 34);
            this.dtpNgayLap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.ShowUpDown = true;
            this.dtpNgayLap.Size = new System.Drawing.Size(180, 26);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgayLap.Location = new System.Drawing.Point(288, 35);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(95, 25);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(128, 34);
            this.txtSoPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(146, 26);
            this.txtSoPhieu.TabIndex = 1;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoPhieu.Location = new System.Drawing.Point(16, 35);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(96, 25);
            this.lblSoPhieu.TabIndex = 0;
            this.lblSoPhieu.Text = "Số phiếu:";
            // 
            // groupChiTiet
            // 
            this.groupChiTiet.Controls.Add(this.lblTongTien);
            this.groupChiTiet.Controls.Add(this.lvChiTiet);
            this.groupChiTiet.Controls.Add(this.btnXoaDong);
            this.groupChiTiet.Controls.Add(this.btnThemDong);
            this.groupChiTiet.Controls.Add(this.txtDonGia);
            this.groupChiTiet.Controls.Add(this.lblDonGia);
            this.groupChiTiet.Controls.Add(this.txtSoLuong);
            this.groupChiTiet.Controls.Add(this.lblSoLuong);
            this.groupChiTiet.Controls.Add(this.lblTonHienTai);
            this.groupChiTiet.Controls.Add(this.cboVatTu);
            this.groupChiTiet.Controls.Add(this.lblVatTu);
            this.groupChiTiet.Location = new System.Drawing.Point(14, 158);
            this.groupChiTiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupChiTiet.Name = "groupChiTiet";
            this.groupChiTiet.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupChiTiet.Size = new System.Drawing.Size(1098, 375);
            this.groupChiTiet.TabIndex = 1;
            this.groupChiTiet.TabStop = false;
            this.groupChiTiet.Text = "Chi tiết vật tư nhập";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTien.Location = new System.Drawing.Point(16, 335);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(146, 25);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // lvChiTiet
            // 
            this.lvChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCTMaVT,
            this.colCTTenVT,
            this.colCTDonViTinh,
            this.colCTSoLuong,
            this.colCTDonGia,
            this.colCTThanhTien});
            this.lvChiTiet.FullRowSelect = true;
            this.lvChiTiet.GridLines = true;
            this.lvChiTiet.HideSelection = false;
            this.lvChiTiet.Location = new System.Drawing.Point(16, 122);
            this.lvChiTiet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvChiTiet.Name = "lvChiTiet";
            this.lvChiTiet.Size = new System.Drawing.Size(1066, 199);
            this.lvChiTiet.TabIndex = 9;
            this.lvChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // colCTMaVT
            // 
            this.colCTMaVT.Text = "Mã vật tư";
            this.colCTMaVT.Width = 90;
            // 
            // colCTTenVT
            // 
            this.colCTTenVT.Text = "Tên vật tư";
            this.colCTTenVT.Width = 260;
            // 
            // colCTDonViTinh
            // 
            this.colCTDonViTinh.Text = "ĐVT";
            this.colCTDonViTinh.Width = 80;
            // 
            // colCTSoLuong
            // 
            this.colCTSoLuong.Text = "Số lượng";
            this.colCTSoLuong.Width = 80;
            // 
            // colCTDonGia
            // 
            this.colCTDonGia.Text = "Đơn giá";
            this.colCTDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCTDonGia.Width = 120;
            // 
            // colCTThanhTien
            // 
            this.colCTThanhTien.Text = "Thành tiền";
            this.colCTThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCTThanhTien.Width = 140;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(617, 75);
            this.btnXoaDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(124, 35);
            this.btnXoaDong.TabIndex = 8;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnThemDong
            // 
            this.btnThemDong.Location = new System.Drawing.Point(481, 75);
            this.btnThemDong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemDong.Name = "btnThemDong";
            this.btnThemDong.Size = new System.Drawing.Size(124, 35);
            this.btnThemDong.TabIndex = 7;
            this.btnThemDong.Text = "Thêm dòng";
            this.btnThemDong.UseVisualStyleBackColor = true;
            this.btnThemDong.Click += new System.EventHandler(this.btnThemDong_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(333, 81);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(134, 26);
            this.txtDonGia.TabIndex = 6;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDonGia.Location = new System.Drawing.Point(232, 82);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(85, 25);
            this.lblDonGia.TabIndex = 5;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(128, 81);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(90, 26);
            this.txtSoLuong.TabIndex = 4;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuong.Location = new System.Drawing.Point(16, 82);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(96, 25);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblTonHienTai
            // 
            this.lblTonHienTai.AutoSize = true;
            this.lblTonHienTai.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTonHienTai.Location = new System.Drawing.Point(450, 38);
            this.lblTonHienTai.Name = "lblTonHienTai";
            this.lblTonHienTai.Size = new System.Drawing.Size(104, 20);
            this.lblTonHienTai.TabIndex = 2;
            this.lblTonHienTai.Text = "Tồn hiện tại: -";
            // 
            // cboVatTu
            // 
            this.cboVatTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.Location = new System.Drawing.Point(97, 35);
            this.cboVatTu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.Size = new System.Drawing.Size(337, 28);
            this.cboVatTu.TabIndex = 1;
            this.cboVatTu.SelectedIndexChanged += new System.EventHandler(this.cboVatTu_SelectedIndexChanged);
            // 
            // lblVatTu
            // 
            this.lblVatTu.AutoSize = true;
            this.lblVatTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblVatTu.Location = new System.Drawing.Point(16, 38);
            this.lblVatTu.Name = "lblVatTu";
            this.lblVatTu.Size = new System.Drawing.Size(69, 25);
            this.lblVatTu.TabIndex = 0;
            this.lblVatTu.Text = "Vật tư:";
            // 
            // groupDanhSach
            // 
            this.groupDanhSach.Controls.Add(this.btnPhieuMoi);
            this.groupDanhSach.Controls.Add(this.btnXuatTxt);
            this.groupDanhSach.Controls.Add(this.btnHuyPhieu);
            this.groupDanhSach.Controls.Add(this.btnMoPhieu);
            this.groupDanhSach.Controls.Add(this.lvPhieu);
            this.groupDanhSach.Location = new System.Drawing.Point(14, 540);
            this.groupDanhSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupDanhSach.Name = "groupDanhSach";
            this.groupDanhSach.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupDanhSach.Size = new System.Drawing.Size(1098, 262);
            this.groupDanhSach.TabIndex = 2;
            this.groupDanhSach.TabStop = false;
            this.groupDanhSach.Text = "Danh sách phiếu nhập đã lập";
            // 
            // btnPhieuMoi
            // 
            this.btnPhieuMoi.Location = new System.Drawing.Point(817, 180);
            this.btnPhieuMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPhieuMoi.Name = "btnPhieuMoi";
            this.btnPhieuMoi.Size = new System.Drawing.Size(266, 42);
            this.btnPhieuMoi.TabIndex = 4;
            this.btnPhieuMoi.Text = "Lập phiếu mới";
            this.btnPhieuMoi.UseVisualStyleBackColor = true;
            this.btnPhieuMoi.Click += new System.EventHandler(this.btnPhieuMoi_Click);
            // 
            // btnXuatTxt
            // 
            this.btnXuatTxt.Location = new System.Drawing.Point(817, 130);
            this.btnXuatTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatTxt.Name = "btnXuatTxt";
            this.btnXuatTxt.Size = new System.Drawing.Size(266, 42);
            this.btnXuatTxt.TabIndex = 3;
            this.btnXuatTxt.Text = "Xuất phiếu ra TXT";
            this.btnXuatTxt.UseVisualStyleBackColor = true;
            this.btnXuatTxt.Click += new System.EventHandler(this.btnXuatTxt_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.Location = new System.Drawing.Point(817, 80);
            this.btnHuyPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(266, 42);
            this.btnHuyPhieu.TabIndex = 2;
            this.btnHuyPhieu.Text = "Hủy phiếu";
            this.btnHuyPhieu.UseVisualStyleBackColor = true;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // btnMoPhieu
            // 
            this.btnMoPhieu.Location = new System.Drawing.Point(817, 30);
            this.btnMoPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoPhieu.Name = "btnMoPhieu";
            this.btnMoPhieu.Size = new System.Drawing.Size(266, 42);
            this.btnMoPhieu.TabIndex = 1;
            this.btnMoPhieu.Text = "Mở / Xem phiếu";
            this.btnMoPhieu.UseVisualStyleBackColor = true;
            this.btnMoPhieu.Click += new System.EventHandler(this.btnMoPhieu_Click);
            // 
            // lvPhieu
            // 
            this.lvPhieu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPNSoPhieu,
            this.colPNNgayLap,
            this.colPNNhaCungCap,
            this.colPNNguoiLap,
            this.colPNTongTien,
            this.colPNTrangThai});
            this.lvPhieu.FullRowSelect = true;
            this.lvPhieu.GridLines = true;
            this.lvPhieu.HideSelection = false;
            this.lvPhieu.Location = new System.Drawing.Point(16, 30);
            this.lvPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvPhieu.MultiSelect = false;
            this.lvPhieu.Name = "lvPhieu";
            this.lvPhieu.Size = new System.Drawing.Size(787, 214);
            this.lvPhieu.TabIndex = 0;
            this.lvPhieu.UseCompatibleStateImageBehavior = false;
            this.lvPhieu.View = System.Windows.Forms.View.Details;
            // 
            // colPNSoPhieu
            // 
            this.colPNSoPhieu.Text = "Số phiếu";
            this.colPNSoPhieu.Width = 85;
            // 
            // colPNNgayLap
            // 
            this.colPNNgayLap.Text = "Ngày lập";
            this.colPNNgayLap.Width = 125;
            // 
            // colPNNhaCungCap
            // 
            this.colPNNhaCungCap.Text = "Nhà cung cấp";
            this.colPNNhaCungCap.Width = 210;
            // 
            // colPNNguoiLap
            // 
            this.colPNNguoiLap.Text = "Người lập";
            this.colPNNguoiLap.Width = 90;
            // 
            // colPNTongTien
            // 
            this.colPNTongTien.Text = "Tổng tiền";
            this.colPNTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPNTongTien.Width = 100;
            // 
            // colPNTrangThai
            // 
            this.colPNTrangThai.Text = "Trạng thái";
            this.colPNTrangThai.Width = 80;
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuuPhieu.Location = new System.Drawing.Point(14, 815);
            this.btnLuuPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(180, 52);
            this.btnLuuPhieu.TabIndex = 3;
            this.btnLuuPhieu.Text = "Lưu phiếu";
            this.btnLuuPhieu.UseVisualStyleBackColor = true;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // lblCheDo
            // 
            this.lblCheDo.AutoSize = true;
            this.lblCheDo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCheDo.Location = new System.Drawing.Point(214, 830);
            this.lblCheDo.Name = "lblCheDo";
            this.lblCheDo.Size = new System.Drawing.Size(167, 20);
            this.lblCheDo.TabIndex = 4;
            this.lblCheDo.Text = "Chế độ: Lập phiếu mới";
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 882);
            this.Controls.Add(this.lblCheDo);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.groupDanhSach);
            this.Controls.Add(this.groupChiTiet);
            this.Controls.Add(this.groupThongTin);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPhieuNhap";
            this.Text = "Lập phiếu nhập";
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            this.Activated += new System.EventHandler(this.frmPhieuNhap_Activated);
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.groupChiTiet.ResumeLayout(false);
            this.groupChiTiet.PerformLayout();
            this.groupDanhSach.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.Label lblNguoiLap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.GroupBox groupChiTiet;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.ListView lvChiTiet;
        private System.Windows.Forms.ColumnHeader colCTMaVT;
        private System.Windows.Forms.ColumnHeader colCTTenVT;
        private System.Windows.Forms.ColumnHeader colCTDonViTinh;
        private System.Windows.Forms.ColumnHeader colCTSoLuong;
        private System.Windows.Forms.ColumnHeader colCTDonGia;
        private System.Windows.Forms.ColumnHeader colCTThanhTien;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnThemDong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTonHienTai;
        private System.Windows.Forms.ComboBox cboVatTu;
        private System.Windows.Forms.Label lblVatTu;
        private System.Windows.Forms.GroupBox groupDanhSach;
        private System.Windows.Forms.Button btnPhieuMoi;
        private System.Windows.Forms.Button btnXuatTxt;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnMoPhieu;
        private System.Windows.Forms.ListView lvPhieu;
        private System.Windows.Forms.ColumnHeader colPNSoPhieu;
        private System.Windows.Forms.ColumnHeader colPNNgayLap;
        private System.Windows.Forms.ColumnHeader colPNNhaCungCap;
        private System.Windows.Forms.ColumnHeader colPNNguoiLap;
        private System.Windows.Forms.ColumnHeader colPNTongTien;
        private System.Windows.Forms.ColumnHeader colPNTrangThai;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Label lblCheDo;
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmPhieuNhap : Form
    {
        private List<VatTu> danhSachVatTu = new List<VatTu>();
        private List<NhaCungCap> danhSachNCC = new List<NhaCungCap>();
        private List<Phieu> danhSachPhieu = new List<Phieu>();
        private List<ChiTietPhieu> chiTiet = new List<ChiTietPhieu>();
        private Phieu phieuDangSua = null;
        private Dictionary<string, int> tonKho = new Dictionary<string, int>();

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            danhSachVatTu = KhoHelper.DocVatTu();
            danhSachNCC = KhoHelper.DocNhaCungCap();
            tonKho = PhieuRepository.TinhTonKho();

            cboVatTu.Items.Clear();
            foreach (var vt in danhSachVatTu)
            {
                cboVatTu.Items.Add(vt);
            }

            cboNhaCungCap.Items.Clear();
            foreach (var ncc in danhSachNCC)
            {
                cboNhaCungCap.Items.Add(ncc);
            }

            txtNguoiLap.Text = AppGlobal.UserDangNhap != null ? AppGlobal.UserDangNhap.TenDangNhap : "";

            HienThiDanhSachPhieu();
            TaoPhieuMoi();
        }

        private void HienThiDanhSachPhieu()
        {
            danhSachPhieu = PhieuRepository.DocPhieu(Phieu.LoaiNhap);
            lvPhieu.Items.Clear();

            for (int i = danhSachPhieu.Count - 1; i >= 0; i--)
            {
                Phieu p = danhSachPhieu[i];
                ListViewItem item = new ListViewItem(p.SoPhieu);
                item.SubItems.Add(p.NgayLap.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(p.TenNCC);
                item.SubItems.Add(p.NguoiLap);
                item.SubItems.Add(p.TongTien.ToString("N0"));
                item.SubItems.Add(p.TrangThai);
                item.Tag = p;

                if (p.DaHuy)
                {
                    item.ForeColor = Color.Gray;
                }

                lvPhieu.Items.Add(item);
            }
        }

        private void HienThiChiTiet()
        {
            lvChiTiet.Items.Clear();
            decimal tongTien = 0;

            foreach (var ct in chiTiet)
            {
                ListViewItem item = new ListViewItem(ct.MaVT);
                item.SubItems.Add(ct.TenVT);
                item.SubItems.Add(ct.DonViTinh);
                item.SubItems.Add(ct.SoLuong.ToString());
                item.SubItems.Add(ct.DonGia.ToString("N0"));
                item.SubItems.Add(ct.ThanhTien.ToString("N0"));
                lvChiTiet.Items.Add(item);

                tongTien += ct.ThanhTien;
            }

            lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " đ";
        }

        private void TaoPhieuMoi()
        {
            phieuDangSua = null;
            chiTiet = new List<ChiTietPhieu>();
            lvPhieu.SelectedItems.Clear();

            txtSoPhieu.Text = PhieuRepository.TaoSoPhieuMoi(Phieu.LoaiNhap);
            dtpNgayLap.Value = DateTime.Now;
            cboNhaCungCap.SelectedIndex = -1;
            txtGhiChu.Clear();
            cboVatTu.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            lblTonHienTai.Text = "Tồn hiện tại: -";

            HienThiChiTiet();
            DatCheDo(false);
            lblCheDo.Text = "Chế độ: Lập phiếu mới";
        }

        private void DatCheDo(bool chiXem)
        {
            cboNhaCungCap.Enabled = !chiXem;
            dtpNgayLap.Enabled = !chiXem;
            txtGhiChu.ReadOnly = chiXem;
            cboVatTu.Enabled = !chiXem;
            txtSoLuong.ReadOnly = chiXem;
            txtDonGia.ReadOnly = chiXem;
            btnThemDong.Enabled = !chiXem;
            btnXoaDong.Enabled = !chiXem;
            btnLuuPhieu.Enabled = !chiXem;
        }

        private Phieu LayPhieuDangChon()
        {
            if (lvPhieu.SelectedItems.Count > 0)
            {
                return lvPhieu.SelectedItems[0].Tag as Phieu;
            }

            return phieuDangSua;
        }

        private void cboVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTonKho();
        }

        private void frmPhieuNhap_Activated(object sender, EventArgs e)
        {
            CapNhatTonKho();
        }

        private void CapNhatTonKho()
        {
            tonKho = PhieuRepository.TinhTonKho();

            VatTu vt = cboVatTu.SelectedItem as VatTu;
            if (vt == null)
            {
                lblTonHienTai.Text = "Tồn hiện tại: -";
                return;
            }

            int ton = tonKho.ContainsKey(vt.Ma) ? tonKho[vt.Ma] : 0;
            lblTonHienTai.Text = $"Tồn hiện tại: {ton} {vt.DonViTinh}";
        }

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            VatTu vt = cboVatTu.SelectedItem as VatTu;
            if (vt == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư cần nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Focus();
                return;
            }

            decimal donGia;
            if (!KhoHelper.ThuDocSo(txtDonGia.Text, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Focus();
                return;
            }

            foreach (var ct in chiTiet)
            {
                if (ct.MaVT == vt.Ma)
                {
                    MessageBox.Show($"Vật tư '{vt.Ten}' đã có trong phiếu. Vui lòng xóa dòng cũ trước khi thêm lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            chiTiet.Add(new ChiTietPhieu
            {
                MaVT = vt.Ma,
                TenVT = vt.Ten,
                DonViTinh = vt.DonViTinh,
                SoLuong = soLuong,
                DonGia = donGia
            });

            HienThiChiTiet();

            txtSoLuong.Clear();
            txtDonGia.Clear();
            CapNhatTonKho();
            cboVatTu.Focus();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lvChiTiet.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng vật tư cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            chiTiet.RemoveAt(lvChiTiet.SelectedIndices[0]);
            HienThiChiTiet();
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (phieuDangSua != null && phieuDangSua.DaHuy)
            {
                MessageBox.Show("Phiếu đã hủy nên không thể sửa. Vui lòng lập phiếu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhaCungCap ncc = cboNhaCungCap.SelectedItem as NhaCungCap;
            if (ncc == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }

            if (chiTiet.Count == 0)
            {
                MessageBox.Show("Phiếu nhập phải có ít nhất một dòng vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool laPhieuMoi = phieuDangSua == null;

            if (laPhieuMoi && danhSachPhieu.Exists(x => x.SoPhieu == txtSoPhieu.Text.Trim()))
            {
                txtSoPhieu.Text = PhieuRepository.TaoSoPhieuMoi(Phieu.LoaiNhap);
            }

            Phieu phieu = laPhieuMoi
                ? new Phieu
                {
                    LoaiPhieu = Phieu.LoaiNhap,
                    SoPhieu = txtSoPhieu.Text.Trim(),
                    TrangThai = Phieu.TrangThaiDaLap
                }
                : phieuDangSua;

            phieu.NgayLap = dtpNgayLap.Value;
            phieu.MaNCC = ncc.MaNCC;
            phieu.TenNCC = ncc.TenNCC;
            phieu.NguoiLap = txtNguoiLap.Text.Trim();
            phieu.GhiChu = txtGhiChu.Text.Trim();
            phieu.ChiTiet = new List<ChiTietPhieu>();
            foreach (var ct in chiTiet)
            {
                phieu.ChiTiet.Add(ct.SaoChep());
            }

            try
            {
                PhieuRepository.LuuPhieu(phieu);
            }
            catch (Exception ex)
            {
                KhoHelper.GhiLog("Lỗi khi lưu phiếu nhập", ex);
                MessageBox.Show("Lỗi khi lưu phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tonKho = PhieuRepository.TinhTonKho();
            HienThiDanhSachPhieu();
            MessageBox.Show(laPhieuMoi ? $"Đã lập phiếu nhập {phieu.SoPhieu}!" : $"Đã cập nhật phiếu {phieu.SoPhieu}!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaoPhieuMoi();
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            Phieu phieu = LayPhieuDangChon();
            if (phieu == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu trong danh sách để xem/sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            phieuDangSua = phieu;
            txtSoPhieu.Text = phieu.SoPhieu;
            dtpNgayLap.Value = phieu.NgayLap.Year < 1900 ? DateTime.Now : phieu.NgayLap;

            cboNhaCungCap.SelectedIndex = -1;
            for (int i = 0; i < cboNhaCungCap.Items.Count; i++)
            {
                if (((NhaCungCap)cboNhaCungCap.Items[i]).MaNCC == phieu.MaNCC)
                {
                    cboNhaCungCap.SelectedIndex = i;
                    break;
                }
            }

            txtNguoiLap.Text = phieu.NguoiLap;
            txtGhiChu.Text = phieu.GhiChu;

            chiTiet = new List<ChiTietPhieu>();
            foreach (var ct in phieu.ChiTiet)
            {
                chiTiet.Add(ct.SaoChep());
            }

            HienThiChiTiet();
            cboVatTu.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            lblTonHienTai.Text = "Tồn hiện tại: -";

            if (phieu.DaHuy)
            {
                DatCheDo(true);
                lblCheDo.Text = "Chế độ: Xem phiếu đã hủy";
                MessageBox.Show("Phiếu này đã bị hủy nên chỉ được xem, không thể sửa hay lưu lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DatCheDo(false);
                lblCheDo.Text = "Chế độ: Sửa phiếu " + phieu.SoPhieu;
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            Phieu phieu = LayPhieuDangChon();
            if (phieu == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần hủy trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (phieu.DaHuy)
            {
                MessageBox.Show($"Phiếu {phieu.SoPhieu} đã được hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy phiếu nhập {phieu.SoPhieu}?\nSau khi hủy, phiếu sẽ không còn ảnh hưởng đến tồn kho và không thể sửa lại.",
                "Xác nhận hủy phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            phieu.TrangThai = Phieu.TrangThaiDaHuy;

            try
            {
                PhieuRepository.LuuPhieu(phieu);
            }
            catch (Exception ex)
            {
                KhoHelper.GhiLog("Lỗi khi hủy phiếu nhập", ex);
                MessageBox.Show("Lỗi khi hủy phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tonKho = PhieuRepository.TinhTonKho();
            HienThiDanhSachPhieu();
            TaoPhieuMoi();
            MessageBox.Show($"Đã hủy phiếu {phieu.SoPhieu}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXuatTxt_Click(object sender, EventArgs e)
        {
            Phieu phieu = LayPhieuDangChon();
            if (phieu == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xuất ra TXT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Tập tin văn bản (*.txt)|*.txt";
            saveFile.Title = "Xuất phiếu nhập ra TXT";
            saveFile.FileName = phieu.SoPhieu + ".txt";

            if (saveFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                PhieuRepository.XuatRaTxt(phieu, saveFile.FileName);
                MessageBox.Show("Đã xuất phiếu ra file:\n" + saveFile.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                KhoHelper.GhiLog("Lỗi khi xuất phiếu nhập ra TXT", ex);
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhieuMoi_Click(object sender, EventArgs e)
        {
            TaoPhieuMoi();
        }
    }
}

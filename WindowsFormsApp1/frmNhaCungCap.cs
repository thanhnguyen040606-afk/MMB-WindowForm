using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmNhaCungCap : Form
    {

        List<NhaCungCap> danhSachNCC = new List<NhaCungCap>();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            {
                DocDuLieuNCC();
                HienThiListViewNCC();
            }
        }
        private void DocDuLieuNCC()
        {
            danhSachNCC.Clear();
            string duongDan = Path.Combine(AppGlobal.DataFolder, "nhacungcap.txt");
            try
            {
                if (File.Exists(duongDan))
                {
                    using (StreamReader sr = new StreamReader(duongDan))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length >= 4)
                            {
                                danhSachNCC.Add(new NhaCungCap
                                {
                                    MaNCC = parts[0],
                                    TenNCC = parts[1],
                                    DiaChi = parts[2],
                                    SoDienThoai = parts[3]
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GhiDuLieuNCC()
        {
            string duongDan = Path.Combine(AppGlobal.DataFolder, "nhacungcap.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(duongDan, false, System.Text.Encoding.UTF8))
                {
                    foreach (var ncc in danhSachNCC)
                    {
                        sw.WriteLine($"{ncc.MaNCC};{ncc.TenNCC};{ncc.DiaChi};{ncc.SoDienThoai}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiListViewNCC()
        {
            lvNhaCungCap.Items.Clear();
            foreach (var ncc in danhSachNCC)
            {
                ListViewItem item = new ListViewItem(ncc.MaNCC);
                item.SubItems.Add(ncc.TenNCC);
                item.SubItems.Add(ncc.DiaChi);
                item.SubItems.Add(ncc.SoDienThoai);
                lvNhaCungCap.Items.Add(item);
            }
        }

        private void XoaTrang()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMaNCC.ReadOnly = false; // Mở khóa lại ô Mã NCC khi làm mới
            txtMaNCC.Focus();
        }

        private void lvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNhaCungCap.SelectedItems.Count > 0)
            {
                ListViewItem item = lvNhaCungCap.SelectedItems[0];
                txtMaNCC.Text = item.SubItems[0].Text;
                txtTenNCC.Text = item.SubItems[1].Text;
                txtDiaChi.Text = item.SubItems[2].Text;
                txtSDT.Text = item.SubItems[3].Text;
                txtMaNCC.ReadOnly = true; // Khóa ô Mã NCC khi đang chọn dòng để tránh sửa nhầm Mã
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMoi = txtMaNCC.Text.Trim();

            // Kiểm tra trùng mã
            foreach (var ncc in danhSachNCC)
            {
                if (string.Equals(ncc.MaNCC, maMoi, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Mã nhà cung cấp '{maMoi}' đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNCC.Focus();
                    return;
                }
            }

            danhSachNCC.Add(new NhaCungCap
            {
                MaNCC = maMoi,
                TenNCC = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim()
            });

            GhiDuLieuNCC();
            HienThiListViewNCC();
            XoaTrang();
            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvNhaCungCap.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ma = txtMaNCC.Text.Trim();
            foreach (var ncc in danhSachNCC)
            {
                if (ncc.MaNCC == ma)
                {
                    ncc.TenNCC = txtTenNCC.Text.Trim();
                    ncc.DiaChi = txtDiaChi.Text.Trim();
                    ncc.SoDienThoai = txtSDT.Text.Trim();
                    break;
                }
            }

            GhiDuLieuNCC();
            HienThiListViewNCC();
            XoaTrang();
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhaCungCap.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp '{txtMaNCC.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string ma = txtMaNCC.Text.Trim();
                danhSachNCC.RemoveAll(x => x.MaNCC == ma);

                GhiDuLieuNCC();
                HienThiListViewNCC();
                XoaTrang();
                MessageBox.Show("Đã xóa nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrang();
        }
    }
}

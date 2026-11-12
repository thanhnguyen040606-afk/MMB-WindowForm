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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class frmQuanLyVatTu : Form
    {
        List<NhomVatTu> danhSachNhom = new List<NhomVatTu>();
        List<VatTu> danhSachVatTu = new List<VatTu>();
        private void DocDuLieu()
        {
            string duongDanNhom = Path.Combine(AppGlobal.DataFolder, "nhomvattu.txt");
            string duongDanVatTu = Path.Combine(AppGlobal.DataFolder, "vattu.txt");

            try
            {
                if (File.Exists(duongDanNhom))
                {
                    using (StreamReader sr = new StreamReader(duongDanNhom))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length >= 2) 
                            {
                                danhSachNhom.Add(new NhomVatTu { MaNhom = parts[0], TenNhom = parts[1] });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc nhomvattu.txt - {ex.Message}\n");
            }

            try
            {
                if (File.Exists(duongDanVatTu))
                {
                    using (StreamReader sr = new StreamReader(duongDanVatTu))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length >= 5)
                            {
                                int ton;
                                int.TryParse(parts[4], out ton); 
                                danhSachVatTu.Add(new VatTu
                                {
                                    Ma = parts[0],
                                    Ten = parts[1],
                                    DonViTinh = parts[2],
                                    MaNhom = parts[3],
                                    TonToiThieu = ton
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc vattu.txt - {ex.Message}\n");
            }
        }
        
        private void HienThiTreeView()
        {
            TVNhomsVattu.Nodes.Clear(); 
            TreeNode root = new TreeNode("Tất cả nhóm vật tư");

            foreach (var nhom in danhSachNhom)
            {
                TreeNode node = new TreeNode(nhom.TenNhom);
                node.Tag = nhom.MaNhom;
                root.Nodes.Add(node);
            }

            TVNhomsVattu.Nodes.Add(root);
            TVNhomsVattu.ExpandAll();
        }

        private void HienThiListView(List<VatTu> danhSach)
        {
            lstvVatTu.Items.Clear(); 
            foreach (var vt in danhSach)
            {
                ListViewItem item = new ListViewItem(vt.Ma);
                item.SubItems.Add(vt.Ten);
                item.SubItems.Add(vt.DonViTinh);
                item.SubItems.Add(vt.TonToiThieu.ToString());
                item.SubItems.Add(vt.MaNhom);

                lstvVatTu.Items.Add(item);
            }
        }

        private void GhiDuLieuVatTu()
        {
            string duongDanVatTu = Path.Combine(AppGlobal.DataFolder, "vattu.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(duongDanVatTu, false, System.Text.Encoding.UTF8))
                {
                    foreach (var vt in danhSachVatTu)
                    {
                        sw.WriteLine($"{vt.Ma};{vt.Ten};{vt.DonViTinh};{vt.MaNhom};{vt.TonToiThieu}");
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi ghi file vattu.txt - {ex.Message}\n");
                MessageBox.Show("Có lỗi khi lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HienThiComboBox()
        {
            cbxMaNhom.Items.Clear();
            foreach (var nhom in danhSachNhom)
            {
                cbxMaNhom.Items.Add(nhom.MaNhom);
            }
        }
        private void GhiDuLieuNhom()
        {
            string duongDan = Path.Combine(AppGlobal.DataFolder, "nhomvattu.txt");
            try
            {
                using (StreamWriter sw = new StreamWriter(duongDan, false, System.Text.Encoding.UTF8))
                {
                    foreach (var nhom in danhSachNhom)
                    {
                        sw.WriteLine($"{nhom.MaNhom};{nhom.TenNhom}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu file nhóm: " + ex.Message);
            }
        }
        private void XoaTrang()
        {
            lstvVatTu.SelectedItems.Clear();
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonviTinh.Clear();
            txtTonToithieu.Clear();
            cbxMaNhom.SelectedIndex = -1;
            txtMaVT.ReadOnly = false;
            txtMaVT.Focus();              
        }
        public frmQuanLyVatTu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLyVatTu_Load(object sender, EventArgs e)
        {
            DocDuLieu();
            HienThiTreeView();
            HienThiComboBox();
            HienThiListView(danhSachVatTu); 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtMaVT.Text) || string.IsNullOrWhiteSpace(txtTenVT.Text) ||
                string.IsNullOrWhiteSpace(txtDonviTinh.Text) || string.IsNullOrWhiteSpace(txtTonToithieu.Text) ||
                string.IsNullOrWhiteSpace(cbxMaNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tonToiThieu;
            if (!int.TryParse(txtTonToithieu.Text, out tonToiThieu))
            {
                MessageBox.Show("Tồn tối thiểu phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTonToithieu.Focus(); 
                return;
            }

            string maVT = txtMaVT.Text.Trim();
            foreach (var vt in danhSachVatTu)
            {
                if (string.Equals(vt.Ma, maVT, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã vật tư này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaVT.Focus();
                    return;
                }
            }

            VatTu vtMoi = new VatTu
            {
                Ma = maVT,
                Ten = txtTenVT.Text.Trim(),
                DonViTinh = txtDonviTinh.Text.Trim(),
                MaNhom = cbxMaNhom.Text.Trim(),
                TonToiThieu = tonToiThieu
            };
            danhSachVatTu.Add(vtMoi);

            HienThiListView(danhSachVatTu);
            GhiDuLieuVatTu();

            MessageBox.Show("Thêm vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            XoaTrang();
        }

        private void lstvVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvVatTu.SelectedItems.Count > 0)
            {
                ListViewItem item = lstvVatTu.SelectedItems[0];
                txtMaVT.Text = item.SubItems[0].Text;
                txtTenVT.Text = item.SubItems[1].Text;
                txtDonviTinh.Text = item.SubItems[2].Text;
                txtTonToithieu.Text = item.SubItems[3].Text;
                cbxMaNhom.Text = item.SubItems[4].Text;
                txtMaVT.ReadOnly = true;
            }
            else
            {
                txtMaVT.ReadOnly = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lstvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một vật tư trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenVT.Text) || string.IsNullOrWhiteSpace(txtDonviTinh.Text) ||
                string.IsNullOrWhiteSpace(txtTonToithieu.Text) || string.IsNullOrWhiteSpace(cbxMaNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tonToiThieu;
            if (!int.TryParse(txtTonToithieu.Text, out tonToiThieu))
            {
                MessageBox.Show("Tồn tối thiểu phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTonToithieu.Focus();
                return;
            }

            string maVT = txtMaVT.Text.Trim();
            bool timThay = false;

            foreach (var vt in danhSachVatTu)
            {
                if (vt.Ma == maVT)
                {
                    vt.Ten = txtTenVT.Text.Trim();
                    vt.DonViTinh = txtDonviTinh.Text.Trim();
                    vt.MaNhom = cbxMaNhom.Text.Trim();
                    vt.TonToiThieu = tonToiThieu;
                    timThay = true;
                    break; 
                }
            }

            if (timThay)
            {
                HienThiListView(danhSachVatTu); 
                GhiDuLieuVatTu();               
                MessageBox.Show("Cập nhật vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XoaTrang();
            }
            else
            {
                MessageBox.Show($"Không tìm thấy vật tư có mã '{maVT}' để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một vật tư trên bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maVT = txtMaVT.Text.Trim();
                VatTu vtCanXoa = null;

                foreach (var vt in danhSachVatTu)
                {
                    if (vt.Ma == maVT)
                    {
                        vtCanXoa = vt;
                        break;
                    }
                }

                if (vtCanXoa != null)
                {
                    danhSachVatTu.Remove(vtCanXoa); 
                    
                    txtMaVT.Clear(); txtTenVT.Clear(); txtDonviTinh.Clear(); txtTonToithieu.Clear(); cbxMaNhom.SelectedIndex = -1;

                    HienThiListView(danhSachVatTu); 
                    GhiDuLieuVatTu();               
                    MessageBox.Show("Xóa vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaTrang();
                }
            }
        }

        private void cbxMaNhom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TVNhomsVattu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Tag == null)
            {
                HienThiListView(danhSachVatTu);
            }
            else
            {
                string maNhomDuocChon = e.Node.Tag.ToString();

                List<VatTu> danhSachLoc = new List<VatTu>();

                foreach (var vt in danhSachVatTu)
                {
                    if (vt.MaNhom == maNhomDuocChon)
                    {
                        danhSachLoc.Add(vt);
                    }
                }

                HienThiListView(danhSachLoc);
            }
        }

        private void btnNhapCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin Text (*.txt)|*.txt";
            openFile.Title = "Chọn tập tin danh mục vật tư cần nhập";

            if (openFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int soLuongThem;
            try
            {
                soLuongThem = NhapDanhMucTuFile(openFile.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongThem > 0)
            {
                HienThiListView(danhSachVatTu);
                GhiDuLieuVatTu();
                MessageBox.Show($"Đã nhập thành công {soLuongThem} vật tư mới từ file!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có vật tư nào được thêm (file trống, sai định dạng hoặc tất cả mã đã tồn tại).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int NhapDanhMucTuFile(string duongDan)
        {
            int soLuongThem = 0;

            using (StreamReader sr = new StreamReader(duongDan))
            {
                string line;
                bool daKiemTraDongDau = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Hỗ trợ cả CSV dấu ';' (định dạng của app) và dấu ',' (Excel)
                    char dauPhanCach = line.IndexOf(';') >= 0 ? ';' : ',';
                    string[] parts = line.Split(dauPhanCach);
                    if (parts.Length < 5)
                    {
                        continue;
                    }

                    for (int i = 0; i < parts.Length; i++)
                    {
                        parts[i] = parts[i].Trim().Trim('"');
                    }

                    string maVT = parts[0];
                    if (string.IsNullOrWhiteSpace(maVT))
                    {
                        continue;
                    }

                    if (!daKiemTraDongDau)
                    {
                        daKiemTraDongDau = true;
                        if (LaDongTieuDe(maVT))
                        {
                            // Có cột STT nghĩa là file xuất từ báo cáo, không phải danh mục
                            if (string.Equals(maVT, "STT", StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }

                            continue;
                        }
                    }

                    bool biTrung = false;
                    foreach (var vt in danhSachVatTu)
                    {
                        if (string.Equals(vt.Ma, maVT, StringComparison.OrdinalIgnoreCase))
                        {
                            biTrung = true;
                            break;
                        }
                    }

                    if (!biTrung)
                    {
                        int ton;
                        int.TryParse(parts[4], out ton);
                        danhSachVatTu.Add(new VatTu
                        {
                            Ma = maVT,
                            Ten = parts[1],
                            DonViTinh = parts[2],
                            MaNhom = parts[3],
                            TonToiThieu = ton
                        });
                        soLuongThem++;
                    }
                }
            }

            return soLuongThem;
        }

        private bool LaDongTieuDe(string giaTriDauTien)
        {
            return string.Equals(giaTriDauTien, "STT", StringComparison.OrdinalIgnoreCase)
                || string.Equals(giaTriDauTien, "Mã VT", StringComparison.OrdinalIgnoreCase)
                || string.Equals(giaTriDauTien, "Ma VT", StringComparison.OrdinalIgnoreCase)
                || string.Equals(giaTriDauTien, "Mã vật tư", StringComparison.OrdinalIgnoreCase)
                || string.Equals(giaTriDauTien, "Ma vat tu", StringComparison.OrdinalIgnoreCase);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower(); 

            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiListView(danhSachVatTu);
                return;
            }

            List<VatTu> danhSachKetQua = new List<VatTu>();

            foreach (var vt in danhSachVatTu)
            {
                if (vt.Ma.ToLower().Contains(tuKhoa) || vt.Ten.ToLower().Contains(tuKhoa))
                {
                    danhSachKetQua.Add(vt);
                }
            }

            HienThiListView(danhSachKetQua);

            if (danhSachKetQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy vật tư nào khớp với từ khóa!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void themNhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinNhom frm = new frmThongTinNhom();
            frm.LaSua = false; 

            if (frm.ShowDialog() == DialogResult.OK) 
            {
                foreach (var nhom in danhSachNhom)
                {
                    if (nhom.MaNhom == frm.MaNhom)
                    {
                        MessageBox.Show("Mã nhóm này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                danhSachNhom.Add(new NhomVatTu { MaNhom = frm.MaNhom, TenNhom = frm.TenNhom });
                GhiDuLieuNhom();
                HienThiTreeView();
                HienThiComboBox();
            }
        }

        private void suaNhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TVNhomsVattu.SelectedNode != null && TVNhomsVattu.SelectedNode.Tag != null)
            {
                string maCu = TVNhomsVattu.SelectedNode.Tag.ToString();

                frmThongTinNhom frm = new frmThongTinNhom();
                frm.LaSua = true; 
                frm.MaNhom = maCu;
                frm.TenNhom = TVNhomsVattu.SelectedNode.Text;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    foreach (var nhom in danhSachNhom)
                    {
                        if (nhom.MaNhom == maCu)
                        {
                            nhom.TenNhom = frm.TenNhom;
                            break;
                        }
                    }

                    GhiDuLieuNhom();
                    HienThiTreeView();
                }
            }
        }

        private void xoaNhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            if (TVNhomsVattu.SelectedNode != null && TVNhomsVattu.SelectedNode.Tag != null)
            {
                string maNhom = TVNhomsVattu.SelectedNode.Tag.ToString();

                foreach (var vt in danhSachVatTu)
                {
                    if (vt.MaNhom == maNhom)
                    {
                        MessageBox.Show("Nhóm này đang chứa vật tư, không thể xóa! Vui lòng xóa hết vật tư của nhóm này trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm '{TVNhomsVattu.SelectedNode.Text}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa khỏi List
                    for (int i = 0; i < danhSachNhom.Count; i++)
                    {
                        if (danhSachNhom[i].MaNhom == maNhom)
                        {
                            danhSachNhom.RemoveAt(i);
                            break;
                        }
                    }

                    GhiDuLieuNhom();    
                    HienThiTreeView();  
                    HienThiComboBox();  
                    MessageBox.Show("Đã xóa nhóm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        
        }
    }
}

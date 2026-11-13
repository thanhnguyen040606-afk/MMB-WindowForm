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
    public partial class frmMain : Form
    {
        private static readonly string[] TepDuLieu =
        {
            "vattu.txt",
            "nhomvattu.txt",
            "nhacungcap.txt",
            "phieunhap.txt",
            "phieuxuat.txt",
            "users.txt"
        };

        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (AppGlobal.UserDangNhap != null)
            {
                toolStripStatusLabel2.Text = $"Trạng thái: Đã đăng nhập - {AppGlobal.UserDangNhap.TenDangNhap} ({AppGlobal.UserDangNhap.VaiTro})";

                if (AppGlobal.UserDangNhap.VaiTro == "NhanVien")
                {
                    baoCaoToolStripMenuItem.Visible = false;

                }
                else if (AppGlobal.UserDangNhap.VaiTro == "QuanTri")
                {
                    baoCaoToolStripMenuItem.Visible = true;
                }
            }
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppGlobal.UserDangNhap = null;

                this.Hide();

                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog();

                this.Close();
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Close();
        }

        private void saoLuuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog chon = new FolderBrowserDialog())
            {
                chon.Description = "Chọn thư mục lưu bản sao dữ liệu";
                chon.ShowNewFolderButton = true;

                if (chon.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    int soTep;
                    string thuMucSaoLuu = SaoLuuDuLieu(chon.SelectedPath, out soTep);

                    MessageBox.Show(
                        $"Đã sao lưu {soTep} tệp dữ liệu vào:\n{thuMucSaoLuu}",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    KhoHelper.GhiLog("Lỗi sao lưu dữ liệu", ex);
                    MessageBox.Show(
                        "Lỗi khi sao lưu dữ liệu: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void khoiPhucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog chon = new FolderBrowserDialog())
            {
                chon.Description = "Chọn thư mục sao lưu cần khôi phục";
                chon.ShowNewFolderButton = false;

                if (chon.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                int soTep = 0;
                foreach (string tenTep in TepDuLieu)
                {
                    if (File.Exists(Path.Combine(chon.SelectedPath, tenTep)))
                    {
                        soTep++;
                    }
                }

                if (soTep == 0)
                {
                    MessageBox.Show(
                        "Thư mục đã chọn không chứa tệp dữ liệu hợp lệ của chương trình.",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DialogResult xacNhan = MessageBox.Show(
                    $"Khôi phục {soTep} tệp và ghi đè dữ liệu hiện tại?\nThao tác này không thể hoàn tác.",
                    "Xác nhận khôi phục",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (xacNhan != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    KhoiPhucDuLieu(chon.SelectedPath, soTep);

                    MessageBox.Show(
                        $"Đã khôi phục {soTep} tệp dữ liệu.\nHãy đóng và mở lại các cửa sổ để nạp dữ liệu mới.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    KhoHelper.GhiLog("Lỗi khôi phục dữ liệu", ex);
                    MessageBox.Show(
                        "Lỗi khi khôi phục dữ liệu: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void vatTuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmQuanLyVatTu) 
                {
                    frm.Activate(); 
                    return;         
                }
            }

            frmQuanLyVatTu frmQLVT = new frmQuanLyVatTu();
            frmQLVT.MdiParent = this; 
            frmQLVT.Show();           
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmNhaCungCap) 
                {
                    frm.Activate();
                    return;         
                }
            }

            frmNhaCungCap frmNCC = new frmNhaCungCap();
            frmNCC.MdiParent = this; 
            frmNCC.Show();          
        }

        private void lapPhieuNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmPhieuNhap)
                {
                    frm.Activate();
                    return;
                }
            }

            frmPhieuNhap frmPN = new frmPhieuNhap();
            frmPN.MdiParent = this;
            frmPN.Show();
        }

        private void lapPhieuXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmPhieuXuat)
                {
                    frm.Activate();
                    return;
                }
            }

            frmPhieuXuat frmPX = new frmPhieuXuat();
            frmPX.MdiParent = this;
            frmPX.Show();
        }

        private void xepNgangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void xepDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void xepChongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void dongCuaSoHienTaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void dongTatCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void tonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmBaoCaoTonKho)
                {
                    frm.Activate();
                    return;
                }
            }

            frmBaoCaoTonKho frmBaoCao = new frmBaoCaoTonKho();
            frmBaoCao.MdiParent = this;
            frmBaoCao.Show();
        }

        private void kiemKeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is frmKiemKe)
                {
                    frm.Activate();
                    return;
                }
            }

            frmKiemKe frmKiemKeMoi = new frmKiemKe();
            frmKiemKeMoi.MdiParent = this;
            frmKiemKeMoi.Show();
        }

        private static string SaoLuuDuLieu(string thuMucDich, out int soTep)
        {
            string thuMucSaoLuu = Path.Combine(
                thuMucDich,
                "SaoLuu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            Directory.CreateDirectory(thuMucSaoLuu);

            soTep = 0;
            foreach (string tenTep in TepDuLieu)
            {
                string nguon = Path.Combine(AppGlobal.DataFolder, tenTep);
                if (File.Exists(nguon))
                {
                    File.Copy(nguon, Path.Combine(thuMucSaoLuu, tenTep), true);
                    soTep++;
                }
            }

            KhoHelper.GhiLog($"Sao lưu dữ liệu: {soTep} tệp -> {thuMucSaoLuu}");
            return thuMucSaoLuu;
        }

        private static void KhoiPhucDuLieu(string thuMucNguon, int soTep)
        {
            Directory.CreateDirectory(AppGlobal.DataFolder);

            foreach (string tenTep in TepDuLieu)
            {
                string nguon = Path.Combine(thuMucNguon, tenTep);
                if (File.Exists(nguon))
                {
                    File.Copy(nguon, Path.Combine(AppGlobal.DataFolder, tenTep), true);
                }
            }

            KhoHelper.GhiLog($"Khôi phục dữ liệu: {soTep} tệp <- {thuMucNguon}");
        }
    }
}

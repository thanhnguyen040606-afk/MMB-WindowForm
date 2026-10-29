using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
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
    }
}

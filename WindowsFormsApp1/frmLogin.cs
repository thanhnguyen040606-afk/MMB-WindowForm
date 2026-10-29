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
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {

        private int soLanSai = 0; 
        public frmLogin()   

        {   
            InitializeComponent();
            LoadRegistry(); 
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }
       
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim(); 
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath = Path.Combine(AppGlobal.DataFolder, "users.txt");
            bool isSuccess = false;

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length >= 3)
                        {
                            if (parts[0] == username && parts[1] == password)
                            {
                                AppGlobal.UserDangNhap = new NguoiDung
                                {
                                    TenDangNhap = parts[0],
                                    MatKhau = parts[1],
                                    VaiTro = parts[2]
                                };
                                isSuccess = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc file đăng nhập - {ex.Message}\n");
            }

            if (isSuccess)
            {
                LuuRegistry(chkGhiNhoDangNhap.Checked, username, password); 
                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                soLanSai++;
                if (soLanSai >= 3)
                {
                    MessageBox.Show("Bạn đã nhập sai 3 lần. Ứng dụng sẽ thoát!", "Khóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Sai tên đăng nhập hoặc mật khẩu! (Còn {3 - soLanSai} lần thử)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LuuRegistry(bool ghiNho, string user, string pass)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\QuanLyKhoVatTu");
            if (ghiNho)
            {
                key.SetValue("Username", user);
                key.SetValue("Password", pass);
                key.SetValue("Remember", "True");
            }
            else
            {
                key.SetValue("Username", "");
                key.SetValue("Password", "");
                key.SetValue("Remember", "False");
            }
            key.Close();
        }

        private void LoadRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\QuanLyKhoVatTu");
            if (key != null)
            {
                string isRemember = (string)key.GetValue("Remember", "False");
                if (isRemember == "True")
                {
                    txtTenDangNhap.Text = (string)key.GetValue("Username", "");
                    txtMatKhau.Text = (string)key.GetValue("Password", "");
                    chkGhiNhoDangNhap.Checked = true;
                }
                key.Close();
            }
        }
        private void chkGhiNhoDangNhap_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Close();
        }
    }
    
}

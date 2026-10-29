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
    public partial class frmThongTinNhom : Form
    {

        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public bool LaSua { get; set; } = false; 
        public frmThongTinNhom()
        {
            InitializeComponent();
        }

        private void frmThongTinNhom_Load(object sender, EventArgs e)
        {
            if (LaSua)
            {
                txtMaNhomTTN.Text = MaNhom;
                txtTenNhomTTN.Text = TenNhom;
                txtMaNhomTTN.ReadOnly = true;
            }
        }

        private void btnLuuTTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNhomTTN.Text) || string.IsNullOrWhiteSpace(txtTenNhomTTN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã nhóm và Tên nhóm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MaNhom = txtMaNhomTTN.Text.Trim();
            TenNhom = txtTenNhomTTN.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

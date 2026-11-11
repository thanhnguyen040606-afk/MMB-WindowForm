using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmBaoCaoTonKho : Form
    {
        private List<DongNhapXuatTon> ketQua = new List<DongNhapXuatTon>();

        public frmBaoCaoTonKho()
        {
            InitializeComponent();
            TaoCot();
        }

        private void TaoCot()
        {
            dgvBaoCao.Columns.Clear();

            dgvBaoCao.Columns.Add(TaoCotChu("MaVT", "Mã VT", 60));
            dgvBaoCao.Columns.Add(TaoCotChu("TenVT", "Tên vật tư", 190));
            dgvBaoCao.Columns.Add(TaoCotChu("DonViTinh", "ĐVT", 60));
            dgvBaoCao.Columns.Add(TaoCotSo("TonDau", "Tồn đầu", 70));
            dgvBaoCao.Columns.Add(TaoCotSo("Nhap", "Nhập", 70));
            dgvBaoCao.Columns.Add(TaoCotSo("Xuat", "Xuất", 70));
            dgvBaoCao.Columns.Add(TaoCotSo("TonCuoi", "Tồn cuối", 75));
            dgvBaoCao.Columns.Add(TaoCotSo("TonToiThieu", "Tồn tối thiểu", 85));
        }

        private DataGridViewTextBoxColumn TaoCotChu(string ten, string tieuDe, int doRong)
        {
            DataGridViewTextBoxColumn cot = new DataGridViewTextBoxColumn();
            cot.Name = ten;
            cot.HeaderText = tieuDe;
            cot.FillWeight = doRong;
            cot.SortMode = DataGridViewColumnSortMode.NotSortable;
            return cot;
        }

        private DataGridViewTextBoxColumn TaoCotSo(string ten, string tieuDe, int doRong)
        {
            DataGridViewTextBoxColumn cot = TaoCotChu(ten, tieuDe, doRong);
            cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            return cot;
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            DateTime homNay = DateTime.Now;
            dtpTuNgay.Value = new DateTime(homNay.Year, homNay.Month, 1);
            dtpDenNgay.Value = homNay;

            XemBaoCao();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void XemBaoCao()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ketQua = BaoCaoRepository.TinhNhapXuatTon(dtpTuNgay.Value, dtpDenNgay.Value);
            HienThiBaoCao();
        }

        private void HienThiBaoCao()
        {
            dgvBaoCao.Rows.Clear();
            int stt = 1;
            int soVatTuDuoiToiThieu = 0;

            foreach (var dong in ketQua)
            {
                int chiSo = dgvBaoCao.Rows.Add(
                    stt,
                    dong.MaVT,
                    dong.TenVT,
                    dong.DonViTinh,
                    dong.TonDau,
                    dong.Nhap,
                    dong.Xuat,
                    dong.TonCuoi,
                    dong.TonToiThieu);

                DataGridViewRow row = dgvBaoCao.Rows[chiSo];
                row.Tag = dong;

                if (dong.DuoiTonToiThieu)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    soVatTuDuoiToiThieu++;
                }

                stt++;
            }

            lblTongKet.Text = $"Tổng cộng: {ketQua.Count} vật tư - {soVatTuDuoiToiThieu} vật tư dưới tồn tối thiểu.";
            lblTongKet.ForeColor = soVatTuDuoiToiThieu > 0 ? Color.Red : Color.Black;
        }

        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            if (ketQua.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu báo cáo để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Tập tin CSV (*.csv)|*.csv";
            saveFile.Title = "Xuất báo cáo nhập - xuất - tồn ra CSV";
            saveFile.FileName = $"BaoCaoNhapXuatTon_{dtpTuNgay.Value:yyyyMMdd}_{dtpDenNgay.Value:yyyyMMdd}.csv";

            if (saveFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BÁO CÁO NHẬP - XUẤT - TỒN");
                sb.AppendLine($"Từ ngày: {dtpTuNgay.Value:dd/MM/yyyy};Đến ngày: {dtpDenNgay.Value:dd/MM/yyyy}");
                sb.AppendLine("STT;Mã VT;Tên vật tư;Đơn vị tính;Tồn đầu;Nhập;Xuất;Tồn cuối;Tồn tối thiểu;Ghi chú");

                int stt = 1;
                int soVatTuDuoiToiThieu = 0;

                foreach (var dong in ketQua)
                {
                    string ghiChu = "";
                    if (dong.DuoiTonToiThieu)
                    {
                        ghiChu = "Dưới tồn tối thiểu";
                        soVatTuDuoiToiThieu++;
                    }

                    sb.AppendLine(string.Join(";",
                        stt.ToString(),
                        Sach(dong.MaVT),
                        Sach(dong.TenVT),
                        Sach(dong.DonViTinh),
                        dong.TonDau.ToString(),
                        dong.Nhap.ToString(),
                        dong.Xuat.ToString(),
                        dong.TonCuoi.ToString(),
                        dong.TonToiThieu.ToString(),
                        ghiChu));

                    stt++;
                }

                sb.AppendLine();
                sb.AppendLine($"Tổng cộng: {ketQua.Count} vật tư - {soVatTuDuoiToiThieu} vật tư dưới tồn tối thiểu.");

                File.WriteAllText(saveFile.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất báo cáo ra file:\n" + saveFile.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Sach(string giaTri)
        {
            if (string.IsNullOrEmpty(giaTri))
            {
                return "";
            }

            return giaTri.Replace(";", ",").Replace("\r", " ").Replace("\n", " ").Trim();
        }

        private void dgvBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

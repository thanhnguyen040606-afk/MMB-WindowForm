using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmKiemKe : Form
    {
        private const int CotTonSoSach = 3;
        private const int CotThucTe = 4;
        private const int CotChenhLech = 5;
        private const int CotTonToiThieu = 6;

        private List<VatTu> danhSachVatTu = new List<VatTu>();
        private Dictionary<string, int> tonKho = new Dictionary<string, int>();

        public frmKiemKe()
        {
            InitializeComponent();
            TaoCot();
        }

        private void TaoCot()
        {
            dgvKiemKe.Columns.Clear();

            dgvKiemKe.Columns.Add(TaoCotChu("MaVT", "Mã VT", 60, true));
            dgvKiemKe.Columns.Add(TaoCotChu("TenVT", "Tên vật tư", 190, true));
            dgvKiemKe.Columns.Add(TaoCotChu("DonViTinh", "ĐVT", 60, true));
            dgvKiemKe.Columns.Add(TaoCotSo("TonSoSach", "Tồn sổ sách", 80, true));
            dgvKiemKe.Columns.Add(TaoCotSo("ThucTe", "Số đếm thực tế", 95, false));
            dgvKiemKe.Columns.Add(TaoCotSo("ChenhLech", "Chênh lệch", 80, true));
            dgvKiemKe.Columns.Add(TaoCotSo("TonToiThieu", "Tồn tối thiểu", 85, true));

            dgvKiemKe.Columns[CotThucTe].DefaultCellStyle.BackColor = Color.LightYellow;
        }

        private DataGridViewTextBoxColumn TaoCotChu(string ten, string tieuDe, int doRong, bool chiDoc)
        {
            DataGridViewTextBoxColumn cot = new DataGridViewTextBoxColumn();
            cot.Name = ten;
            cot.HeaderText = tieuDe;
            cot.FillWeight = doRong;
            cot.ReadOnly = chiDoc;
            cot.SortMode = DataGridViewColumnSortMode.NotSortable;
            return cot;
        }

        private DataGridViewTextBoxColumn TaoCotSo(string ten, string tieuDe, int doRong, bool chiDoc)
        {
            DataGridViewTextBoxColumn cot = TaoCotChu(ten, tieuDe, doRong, chiDoc);
            cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            return cot;
        }

        private void frmKiemKe_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            danhSachVatTu = KhoHelper.DocVatTu();
            tonKho = PhieuRepository.TinhTonKho();
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            dgvKiemKe.Rows.Clear();

            foreach (var vt in danhSachVatTu)
            {
                int tonSoSach = tonKho.ContainsKey(vt.Ma) ? tonKho[vt.Ma] : 0;
                int chiSo = dgvKiemKe.Rows.Add(vt.Ma, vt.Ten, vt.DonViTinh, tonSoSach, null, null, vt.TonToiThieu);
                DataGridViewRow row = dgvKiemKe.Rows[chiSo];
                row.Tag = vt;

                if (tonSoSach < vt.TonToiThieu)
                {
                    row.Cells[CotTonSoSach].Style.ForeColor = Color.Red;
                    row.Cells[CotTonSoSach].Style.Font = new Font(dgvKiemKe.Font, FontStyle.Bold);
                }
            }

            CapNhatTongKet();
        }

        private void dgvKiemKe_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != CotThucTe)
            {
                return;
            }

            DataGridViewRow row = dgvKiemKe.Rows[e.RowIndex];
            object giaTri = row.Cells[CotThucTe].Value;
            string chuoi = giaTri == null ? "" : giaTri.ToString().Trim();

            if (chuoi == "")
            {
                row.Cells[CotThucTe].Value = null;
                row.Cells[CotChenhLech].Value = null;
                row.Cells[CotChenhLech].Style.ForeColor = Color.Black;
                row.Cells[CotThucTe].Style.ForeColor = Color.Black;
                CapNhatTongKet();
                return;
            }

            int soDemThucTe;
            if (!int.TryParse(chuoi, out soDemThucTe) || soDemThucTe < 0)
            {
                MessageBox.Show("Số đếm thực tế phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                row.Cells[CotThucTe].Value = null;
                row.Cells[CotChenhLech].Value = null;
                row.Cells[CotChenhLech].Style.ForeColor = Color.Black;
                row.Cells[CotThucTe].Style.ForeColor = Color.Black;
                CapNhatTongKet();
                return;
            }

            int tonSoSach;
            int.TryParse(Convert.ToString(row.Cells[CotTonSoSach].Value), out tonSoSach);

            int tonToiThieu;
            int.TryParse(Convert.ToString(row.Cells[CotTonToiThieu].Value), out tonToiThieu);

            int chenhLech = soDemThucTe - tonSoSach;

            row.Cells[CotThucTe].Value = soDemThucTe;
            row.Cells[CotThucTe].Style.ForeColor = soDemThucTe < tonToiThieu ? Color.Red : Color.Black;

            row.Cells[CotChenhLech].Value = chenhLech;
            row.Cells[CotChenhLech].Style.ForeColor = chenhLech < 0
                ? Color.Red
                : (chenhLech > 0 ? Color.Blue : Color.Black);

            CapNhatTongKet();
        }

        private void CapNhatTongKet()
        {
            int soDaKiemKe = 0;
            int soChenhLech = 0;
            int tongTang = 0;
            int tongGiam = 0;

            foreach (DataGridViewRow row in dgvKiemKe.Rows)
            {
                object giaTri = row.Cells[CotThucTe].Value;
                if (giaTri == null || string.IsNullOrWhiteSpace(giaTri.ToString()))
                {
                    continue;
                }

                int thucTe;
                if (!int.TryParse(giaTri.ToString(), out thucTe))
                {
                    continue;
                }

                int tonSoSach;
                int.TryParse(Convert.ToString(row.Cells[CotTonSoSach].Value), out tonSoSach);

                int chenhLech = thucTe - tonSoSach;
                soDaKiemKe++;

                if (chenhLech > 0)
                {
                    tongTang += chenhLech;
                    soChenhLech++;
                }
                else if (chenhLech < 0)
                {
                    tongGiam += -chenhLech;
                    soChenhLech++;
                }
            }

            lblTongKet.Text = $"Đã kiểm kê: {soDaKiemKe}/{dgvKiemKe.Rows.Count} vật tư - " +
                $"{soChenhLech} vật tư có chênh lệch (tăng: {tongTang}, giảm: {tongGiam}).";
            lblTongKet.ForeColor = soChenhLech > 0 ? Color.Red : Color.Black;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            bool daNhap = false;

            foreach (DataGridViewRow row in dgvKiemKe.Rows)
            {
                if (row.Cells[CotThucTe].Value != null && !string.IsNullOrWhiteSpace(row.Cells[CotThucTe].Value.ToString()))
                {
                    daNhap = true;
                    break;
                }
            }

            if (daNhap)
            {
                DialogResult result = MessageBox.Show(
                    "Dữ liệu kiểm kê chưa được xuất ra CSV. Bạn có chắc chắn muốn làm mới và xóa các số đếm đã nhập?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            TaiDuLieu();
        }

        private void btnXuatCSV_Click(object sender, EventArgs e)
        {
            if (dgvKiemKe.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu kiểm kê để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Tập tin CSV (*.csv)|*.csv";
            saveFile.Title = "Xuất báo cáo kiểm kê ra CSV";
            saveFile.FileName = $"KiemKe_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (saveFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BÁO CÁO KIỂM KÊ VẬT TƯ");
                sb.AppendLine("Ngày kiểm kê: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                sb.AppendLine("STT;Mã VT;Tên vật tư;Đơn vị tính;Tồn sổ sách;Số đếm thực tế;Chênh lệch;Tồn tối thiểu;Ghi chú");

                int stt = 1;
                foreach (DataGridViewRow row in dgvKiemKe.Rows)
                {
                    object thucTe = row.Cells[CotThucTe].Value;
                    string thucTeText = thucTe == null ? "" : thucTe.ToString();

                    object chenhLech = row.Cells[CotChenhLech].Value;
                    string chenhLechText = chenhLech == null ? "" : chenhLech.ToString();

                    string ghiChu = "";
                    if (chenhLech != null)
                    {
                        int giaTriChenhLech;
                        if (int.TryParse(chenhLech.ToString(), out giaTriChenhLech))
                        {
                            ghiChu = giaTriChenhLech > 0 ? "Thừa" : (giaTriChenhLech < 0 ? "Thiếu" : "Khớp");
                        }
                    }

                    sb.AppendLine(string.Join(";",
                        stt.ToString(),
                        Sach(Convert.ToString(row.Cells[0].Value)),
                        Sach(Convert.ToString(row.Cells[1].Value)),
                        Sach(Convert.ToString(row.Cells[2].Value)),
                        Convert.ToString(row.Cells[CotTonSoSach].Value),
                        thucTeText,
                        chenhLechText,
                        Convert.ToString(row.Cells[CotTonToiThieu].Value),
                        ghiChu));

                    stt++;
                }

                sb.AppendLine();
                sb.AppendLine(lblTongKet.Text);

                File.WriteAllText(saveFile.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất báo cáo kiểm kê ra file:\n" + saveFile.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKiemKe_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private string Sach(string giaTri)
        {
            if (string.IsNullOrEmpty(giaTri))
            {
                return "";
            }

            return giaTri.Replace(";", ",").Replace("\r", " ").Replace("\n", " ").Trim();
        }
    }
}

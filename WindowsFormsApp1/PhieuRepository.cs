using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    internal static class PhieuRepository
    {
        private const string DinhDangNgay = "yyyy-MM-dd HH:mm:ss";
        private const string Cot = ";";

        public static string LayDuongDan(string loaiPhieu)
        {
            string tenFile = loaiPhieu == Phieu.LoaiNhap ? "phieunhap.txt" : "phieuxuat.txt";
            return Path.Combine(AppGlobal.DataFolder, tenFile);
        }

        private static string Sach(string giaTri)
        {
            if (string.IsNullOrEmpty(giaTri))
            {
                return "";
            }

            return giaTri.Replace(";", ",").Replace("\r", " ").Replace("\n", " ").Trim();
        }

        public static List<Phieu> DocPhieu(string loaiPhieu)
        {
            List<Phieu> danhSach = new List<Phieu>();
            string duongDan = LayDuongDan(loaiPhieu);

            try
            {
                if (!File.Exists(duongDan))
                {
                    return danhSach;
                }

                using (StreamReader sr = new StreamReader(duongDan, Encoding.UTF8, true))
                {
                    string line;
                    Phieu phieuHienTai = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        string[] parts = line.Split(';');

                        if (parts[0] == "CT" && phieuHienTai != null && parts.Length >= 6)
                        {
                            int soLuong;
                            int.TryParse(parts[4], out soLuong);

                            decimal donGia;
                            decimal.TryParse(parts[5], NumberStyles.Number, CultureInfo.InvariantCulture, out donGia);

                            phieuHienTai.ChiTiet.Add(new ChiTietPhieu
                            {
                                MaVT = parts[1],
                                TenVT = parts[2],
                                DonViTinh = parts[3],
                                SoLuong = soLuong,
                                DonGia = donGia
                            });
                        }
                        else if ((parts[0] == Phieu.LoaiNhap || parts[0] == Phieu.LoaiXuat) && parts.Length >= 9)
                        {
                            DateTime ngayLap;
                            DateTime.TryParseExact(parts[2], DinhDangNgay, CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayLap);

                            phieuHienTai = new Phieu
                            {
                                LoaiPhieu = parts[0],
                                SoPhieu = parts[1],
                                NgayLap = ngayLap,
                                MaNCC = parts[3],
                                TenNCC = parts[4],
                                NguoiNhan = parts[5],
                                NguoiLap = parts[6],
                                GhiChu = parts[7],
                                TrangThai = parts[8]
                            };

                            danhSach.Add(phieuHienTai);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc phiếu {loaiPhieu} - {ex.Message}\n");
            }

            return danhSach;
        }

        private static void GhiDanhSach(string loaiPhieu, List<Phieu> danhSach)
        {
            string duongDan = LayDuongDan(loaiPhieu);

            KhoHelper.DamBaoThuMuc(duongDan);

            using (StreamWriter sw = new StreamWriter(duongDan, false, new UTF8Encoding(true)))
            {
                foreach (var p in danhSach)
                {
                    sw.WriteLine(string.Join(Cot,
                        p.LoaiPhieu,
                        Sach(p.SoPhieu),
                        p.NgayLap.ToString(DinhDangNgay, CultureInfo.InvariantCulture),
                        Sach(p.MaNCC),
                        Sach(p.TenNCC),
                        Sach(p.NguoiNhan),
                        Sach(p.NguoiLap),
                        Sach(p.GhiChu),
                        p.TrangThai));

                    foreach (var ct in p.ChiTiet)
                    {
                        sw.WriteLine(string.Join(Cot,
                            "CT",
                            Sach(ct.MaVT),
                            Sach(ct.TenVT),
                            Sach(ct.DonViTinh),
                            ct.SoLuong.ToString(CultureInfo.InvariantCulture),
                            ct.DonGia.ToString(CultureInfo.InvariantCulture)));
                    }
                }
            }
        }

        public static void LuuPhieu(Phieu phieu)
        {
            List<Phieu> danhSach = DocPhieu(phieu.LoaiPhieu);
            int viTri = danhSach.FindIndex(p => p.SoPhieu == phieu.SoPhieu);

            if (viTri >= 0)
            {
                danhSach[viTri] = phieu;
            }
            else
            {
                danhSach.Add(phieu);
            }

            GhiDanhSach(phieu.LoaiPhieu, danhSach);
        }

        public static string TaoSoPhieuMoi(string loaiPhieu)
        {
            int lonNhat = 0;

            foreach (var p in DocPhieu(loaiPhieu))
            {
                if (p.SoPhieu != null && p.SoPhieu.Length > loaiPhieu.Length)
                {
                    int so;
                    if (int.TryParse(p.SoPhieu.Substring(loaiPhieu.Length), out so) && so > lonNhat)
                    {
                        lonNhat = so;
                    }
                }
            }

            return loaiPhieu + (lonNhat + 1).ToString("D4");
        }

        public static Dictionary<string, int> TinhTonKho()
        {
            Dictionary<string, int> tonKho = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var p in DocPhieu(Phieu.LoaiNhap))
            {
                if (p.DaHuy)
                {
                    continue;
                }

                foreach (var ct in p.ChiTiet)
                {
                    CongTon(tonKho, ct.MaVT, ct.SoLuong);
                }
            }

            foreach (var p in DocPhieu(Phieu.LoaiXuat))
            {
                if (p.DaHuy)
                {
                    continue;
                }

                foreach (var ct in p.ChiTiet)
                {
                    CongTon(tonKho, ct.MaVT, -ct.SoLuong);
                }
            }

            return tonKho;
        }

        private static void CongTon(Dictionary<string, int> tonKho, string maVT, int soLuong)
        {
            if (tonKho.ContainsKey(maVT))
            {
                tonKho[maVT] += soLuong;
            }
            else
            {
                tonKho[maVT] = soLuong;
            }
        }

        public static void XuatRaTxt(Phieu phieu, string duongDan)
        {
            CultureInfo vi = CultureInfo.GetCultureInfo("vi-VN");
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(phieu.LaPhieuNhap ? "PHIẾU NHẬP VẬT TƯ" : "PHIẾU XUẤT VẬT TƯ");
            sb.AppendLine("Số phiếu: " + phieu.SoPhieu);
            sb.AppendLine("Ngày lập: " + phieu.NgayLap.ToString("dd/MM/yyyy HH:mm", vi));

            if (phieu.LaPhieuNhap)
            {
                sb.AppendLine("Nhà cung cấp: " + phieu.MaNCC + " - " + phieu.TenNCC);
            }
            else
            {
                sb.AppendLine("Người nhận: " + phieu.NguoiNhan);
            }

            sb.AppendLine("Người lập: " + phieu.NguoiLap);
            sb.AppendLine("Ghi chú: " + phieu.GhiChu);
            sb.AppendLine("Trạng thái: " + phieu.TrangThai);
            sb.AppendLine(new string('-', 100));
            sb.AppendLine(
                "STT".PadRight(6) +
                "Mã VT".PadRight(10) +
                "Tên vật tư".PadRight(30) +
                "ĐVT".PadRight(12) +
                "Số lượng".PadRight(10) +
                "Đơn giá".PadRight(15) +
                "Thành tiền");

            int stt = 1;
            foreach (var ct in phieu.ChiTiet)
            {
                sb.AppendLine(
                    stt.ToString().PadRight(6) +
                    (ct.MaVT ?? "").PadRight(10) +
                    (ct.TenVT ?? "").PadRight(30) +
                    (ct.DonViTinh ?? "").PadRight(12) +
                    ct.SoLuong.ToString().PadRight(10) +
                    ct.DonGia.ToString("N0", vi).PadRight(15) +
                    ct.ThanhTien.ToString("N0", vi));
                stt++;
            }

            sb.AppendLine(new string('-', 100));
            sb.AppendLine("Tổng tiền: " + phieu.TongTien.ToString("N0", vi) + " đ");

            File.WriteAllText(duongDan, sb.ToString(), new UTF8Encoding(true));
        }
    }
}

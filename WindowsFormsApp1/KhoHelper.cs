using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WindowsFormsApp1
{
    internal static class KhoHelper
    {
        public static void GhiLog(string thongDiep)
        {
            try
            {
                File.AppendAllText("log.txt", $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {thongDiep}\n");
            }
            catch
            {
                // Ghi log thất bại không được làm dừng chương trình
            }
        }

        public static void GhiLog(string thongDiep, Exception ex)
        {
            GhiLog($"{thongDiep} - {ex.Message}");
        }

        public static void DamBaoThuMuc(string duongDanFile)
        {
            string thuMuc = Path.GetDirectoryName(duongDanFile);
            if (!string.IsNullOrEmpty(thuMuc))
            {
                Directory.CreateDirectory(thuMuc);
            }
        }

        public static bool ThuDocSo(string chuoi, out decimal giaTri)
        {
            giaTri = 0;
            if (string.IsNullOrWhiteSpace(chuoi))
            {
                return false;
            }

            chuoi = chuoi.Trim();

            if (decimal.TryParse(chuoi, NumberStyles.Number, CultureInfo.CurrentCulture, out giaTri))
            {
                return true;
            }

            return decimal.TryParse(chuoi, NumberStyles.Number, CultureInfo.InvariantCulture, out giaTri);
        }

        public static List<VatTu> DocVatTu()
        {
            List<VatTu> danhSach = new List<VatTu>();
            string duongDan = Path.Combine(AppGlobal.DataFolder, "vattu.txt");

            try
            {
                if (!File.Exists(duongDan))
                {
                    return danhSach;
                }

                using (StreamReader sr = new StreamReader(duongDan))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length >= 5)
                        {
                            int ton;
                            int.TryParse(parts[4], out ton);
                            danhSach.Add(new VatTu
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
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc vattu.txt - {ex.Message}\n");
            }

            return danhSach;
        }

        public static List<NhaCungCap> DocNhaCungCap()
        {
            List<NhaCungCap> danhSach = new List<NhaCungCap>();
            string duongDan = Path.Combine(AppGlobal.DataFolder, "nhacungcap.txt");

            try
            {
                if (!File.Exists(duongDan))
                {
                    return danhSach;
                }

                using (StreamReader sr = new StreamReader(duongDan))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length >= 4)
                        {
                            danhSach.Add(new NhaCungCap
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
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now}: Lỗi đọc nhacungcap.txt - {ex.Message}\n");
            }

            return danhSach;
        }
    }
}

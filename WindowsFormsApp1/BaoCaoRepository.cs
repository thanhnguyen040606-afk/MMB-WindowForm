using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class DongNhapXuatTon
    {
        public string MaVT { get; set; }
        public string TenVT { get; set; }
        public string DonViTinh { get; set; }
        public int TonDau { get; set; }
        public int Nhap { get; set; }
        public int Xuat { get; set; }
        public int TonCuoi { get; set; }
        public int TonToiThieu { get; set; }

        public bool DuoiTonToiThieu
        {
            get { return TonCuoi < TonToiThieu; }
        }
    }

    internal static class BaoCaoRepository
    {
        /// <summary>
        /// Tính tồn đầu, nhập, xuất, tồn cuối của từng vật tư trong khoảng [tuNgay, denNgay].
        /// Tồn đầu = tổng nhập - tổng xuất của các phiếu trước tuNgay.
        /// Nhập/Xuất = tổng số lượng trên các phiếu nằm trong khoảng ngày.
        /// Tồn cuối = tồn đầu + nhập - xuất.
        /// Các phiếu đã hủy không được tính.
        /// </summary>
        public static List<DongNhapXuatTon> TinhNhapXuatTon(DateTime tuNgay, DateTime denNgay)
        {
            DateTime batDau = tuNgay.Date;
            DateTime ketThuc = denNgay.Date.AddDays(1);
            Dictionary<string, DongNhapXuatTon> bang = new Dictionary<string, DongNhapXuatTon>(StringComparer.OrdinalIgnoreCase);

            foreach (var vt in KhoHelper.DocVatTu())
            {
                if (string.IsNullOrWhiteSpace(vt.Ma) || bang.ContainsKey(vt.Ma))
                {
                    continue;
                }

                bang[vt.Ma] = new DongNhapXuatTon
                {
                    MaVT = vt.Ma,
                    TenVT = vt.Ten,
                    DonViTinh = vt.DonViTinh,
                    TonToiThieu = vt.TonToiThieu
                };
            }

            foreach (var p in PhieuRepository.DocPhieu(Phieu.LoaiNhap))
            {
                if (!p.DaHuy)
                {
                    CongPhieu(bang, p, batDau, ketThuc, 1);
                }
            }

            foreach (var p in PhieuRepository.DocPhieu(Phieu.LoaiXuat))
            {
                if (!p.DaHuy)
                {
                    CongPhieu(bang, p, batDau, ketThuc, -1);
                }
            }

            List<DongNhapXuatTon> ketQua = new List<DongNhapXuatTon>(bang.Values);
            foreach (var dong in ketQua)
            {
                dong.TonCuoi = dong.TonDau + dong.Nhap - dong.Xuat;
            }

            ketQua.Sort((a, b) => string.Compare(a.MaVT, b.MaVT, StringComparison.OrdinalIgnoreCase));
            return ketQua;
        }

        private static void CongPhieu(Dictionary<string, DongNhapXuatTon> bang, Phieu phieu, DateTime batDau, DateTime ketThuc, int dau)
        {
            foreach (var ct in phieu.ChiTiet)
            {
                if (string.IsNullOrWhiteSpace(ct.MaVT))
                {
                    continue;
                }

                DongNhapXuatTon dong;
                if (!bang.TryGetValue(ct.MaVT, out dong))
                {
                    dong = new DongNhapXuatTon
                    {
                        MaVT = ct.MaVT,
                        TenVT = ct.TenVT,
                        DonViTinh = ct.DonViTinh,
                        TonToiThieu = 0
                    };
                    bang[ct.MaVT] = dong;
                }

                if (string.IsNullOrWhiteSpace(dong.TenVT) && !string.IsNullOrWhiteSpace(ct.TenVT))
                {
                    dong.TenVT = ct.TenVT;
                }

                if (string.IsNullOrWhiteSpace(dong.DonViTinh) && !string.IsNullOrWhiteSpace(ct.DonViTinh))
                {
                    dong.DonViTinh = ct.DonViTinh;
                }

                if (phieu.NgayLap < batDau)
                {
                    dong.TonDau += dau * ct.SoLuong;
                }
                else if (phieu.NgayLap < ketThuc)
                {
                    if (dau > 0)
                    {
                        dong.Nhap += ct.SoLuong;
                    }
                    else
                    {
                        dong.Xuat += ct.SoLuong;
                    }
                }
            }
        }
    }
}

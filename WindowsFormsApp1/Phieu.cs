using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class ChiTietPhieu
    {
        public string MaVT { get; set; }
        public string TenVT { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien
        {
            get { return SoLuong * DonGia; }
        }

        public ChiTietPhieu SaoChep()
        {
            return new ChiTietPhieu
            {
                MaVT = MaVT,
                TenVT = TenVT,
                DonViTinh = DonViTinh,
                SoLuong = SoLuong,
                DonGia = DonGia
            };
        }
    }

    internal class Phieu
    {
        public const string LoaiNhap = "PN";
        public const string LoaiXuat = "PX";
        public const string TrangThaiDaLap = "Đã lập";
        public const string TrangThaiDaHuy = "Đã hủy";

        public string SoPhieu { get; set; }
        public string LoaiPhieu { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string NguoiNhan { get; set; }
        public string NguoiLap { get; set; }
        public string GhiChu { get; set; }
        public string TrangThai { get; set; }
        public List<ChiTietPhieu> ChiTiet { get; set; } = new List<ChiTietPhieu>();

        public decimal TongTien
        {
            get
            {
                decimal tong = 0;
                foreach (var ct in ChiTiet)
                {
                    tong += ct.ThanhTien;
                }
                return tong;
            }
        }

        public bool DaHuy
        {
            get { return TrangThai == TrangThaiDaHuy; }
        }

        public bool LaPhieuNhap
        {
            get { return LoaiPhieu == LoaiNhap; }
        }
    }
}

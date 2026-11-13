using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } 

        public override string ToString()
        {
            return $"{TenDangNhap} - {VaiTro}";
        }
    }

    public static class AppGlobal
    {
        public static NguoiDung UserDangNhap { get; set; } = null;

        public static string DataFolder = LayCauHinh("DataFolder", @"..\..\Data");

        public static string LayCauHinh(string khoa, string giaTriMacDinh)
        {
            try
            {
                string giaTri = ConfigurationManager.AppSettings[khoa];
                return string.IsNullOrWhiteSpace(giaTri) ? giaTriMacDinh : giaTri.Trim();
            }
            catch
            {
                return giaTriMacDinh;
            }
        }
    }
}

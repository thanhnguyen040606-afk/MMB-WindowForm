using System;
using System.Collections.Generic;
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

        public static string DataFolder = @"..\..\Data";
    }
}

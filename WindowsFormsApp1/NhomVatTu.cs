using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class NhomVatTu
    {

        public string MaNhom { get; set; }
        public string TenNhom { get; set; }

        public override string ToString()
        {
            return TenNhom; 
        }
    }
}


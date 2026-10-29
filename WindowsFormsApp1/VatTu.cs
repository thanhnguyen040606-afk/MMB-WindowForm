using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class VatTu
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DonViTinh { get; set; }
        public string MaNhom { get; set; }
        public int TonToiThieu { get; set; }

        public override string ToString()
        {
            return $"{Ma} - {Ten}";
        }
    }
}

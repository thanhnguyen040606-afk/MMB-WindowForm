using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            try
            {
                Directory.CreateDirectory(AppGlobal.DataFolder);
            }
            catch (Exception ex)
            {
                KhoHelper.GhiLog("Không tạo được thư mục dữ liệu", ex);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}

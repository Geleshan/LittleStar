using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestThread
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //如有需要可以在这里编写程序的准备代码
            Splasher.Show();
            Application.Run(new Form1());
            


        }
    }
}

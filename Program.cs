using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CVR100A_U_DSDK_Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new Form3("",0,0));
            //Application.Run(new importInfo());
        }
    }
}
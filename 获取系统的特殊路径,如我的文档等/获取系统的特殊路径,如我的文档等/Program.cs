using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 获取系统的特殊路径_如我的文档等
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
            Application.Run(new Form1());
        }
    }
}

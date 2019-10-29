using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 获取系统的特殊路径_如我的文档等
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sr = new StringBuilder();

            sr.Append($"ApplicationData(目录，它用作当前漫游用户的应用程序特定数据的公共储存库)：{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)};\n\n");

            sr.Append($"CommonApplicationData(目录，它用作所有用户使用的应用程序特定数据的公共储存库)：{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)};\n\n");

            sr.Append($"LocalApplicationData(目录，它用作当前非漫游用户使用的应用程序特定数据的公共储存库)：{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)};\n\n");

            sr.Append($"Cookies(用作 Internet Cookie 的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Cookies)};\n\n");

            sr.Append($"Desktop(逻辑桌面，而不是物理文件系统位置)：{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)};\n\n");

            sr.Append($"Favorites(用作用户收藏夹项的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Favorites)};\n\n");

            sr.Append($"History(用作 Internet 历史记录项的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.History)};\n\n");

            sr.Append($"InternetCache(用作 Internet 临时文件的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)};\n\n");

            sr.Append($"Programs(包含用户程序组的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Programs)};\n\n");

            sr.Append($"MyComputer(“我的电脑”文件夹)：{Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)};\n\n");

            sr.Append($"MyMusic(“My Music”文件夹)：{Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)};\n\n");

            sr.Append($"MyPictures(“My Pictures”文件夹)：{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)};\n\n");

            sr.Append($"Recent(包含用户最近使用过的文档的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Recent)};\n\n");

            sr.Append($"SendTo(包含“发送”菜单项的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.SendTo)};\n\n");

            sr.Append($"StartMenu(包含“开始”菜单项的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)};\n\n");

            sr.Append($"Startup(对应于用户的“启动”程序组的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Startup)};\n\n");

            sr.Append($"System(“System”目录)：{Environment.GetFolderPath(Environment.SpecialFolder.System)};\n\n");

            sr.Append($"Templates(用作文档模板的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Templates)};\n\n");

            sr.Append($"DesktopDirectory(用于物理上存储桌面上的文件对象的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)};\n\n");

            sr.Append($"Personal(用作文档的公共储存库的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.Personal)};\n\n");

            sr.Append($"MyDocuments(“我的电脑”文件夹)：{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)};\n\n");

            sr.Append($"ProgramFiles(“Program files”目录)：{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)};\n\n");

            sr.Append($"CommonProgramFiles(用于应用程序间共享的组件的目录)：{Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles)};\n\n");

            var str = sr.ToString();

            label1.Text = str;
        }
    }
}

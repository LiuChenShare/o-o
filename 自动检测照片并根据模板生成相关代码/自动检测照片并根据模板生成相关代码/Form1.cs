using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自动检测照片并根据模板生成相关代码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> Images = new List<string>();
        public string Template { get; set; }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = @"C:\Users\LWP1398\Desktop"; //设置初始路径
            ofd.Filter = "Excel文件(*.xls)|*.xls|Csv文件(*.csv)|*.csv|所有文件(*.*)|*.*"; //设置“另存为文件类型”或“文件类型”框中出现的选择内容
            ofd.Filter = "图片文件|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff";
            //ofd.FilterIndex = 2; //设置默认显示文件类型为Csv文件(*.csv)|*.csv
            ofd.Title = "选择图片"; //获取或设置文件对话框标题
            ofd.RestoreDirectory = true;////设置对话框是否记忆上次打开的目录

            ofd.Multiselect = true;//设置多选
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //for (int i = 0; i < ofd.FileNames.Length; i++)
                //{
                //    txtPath.Text += ofd.FileNames[i] + "\r\n";//输出一个路径回车换行
                //}
                //for (int i = 0; i < ofd.FileNames.Length; i++)
                //{
                //    txtPath.Text += ofd.SafeFileNames[i] + "\r\n";
                //}
                int count = ofd.FileNames.Length;
                int sucess = 0;
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(ofd.FileNames[i], FileMode.Open, FileAccess.Read))
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                            double width = image.Width;
                            double height = image.Height;
                            double aspectRatio = width / height;
                            var url = ofd.FileNames[i];

                            //string fullPath = @"\WebSite1\Default.aspx";
                            //string filename = System.IO.Path.GetFileName(fullPath);//文件名  “Default.aspx”
                            //string extension = System.IO.Path.GetExtension(fullPath);//扩展名 “.aspx”
                            //string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fullPath);// 没有扩展名的文件名 “Default”

                            var imageName = System.IO.Path.GetFileName(url);
                            Images.Add(imageName);
                            sucess++;
                            Refresh(count, sucess);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                MessageBox.Show(string.Format("加载结束,总数{0}，加载{1}", count, sucess));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var templatePath = System.Environment.CurrentDirectory + @"\Template.txt";
            Template = File.ReadAllText(templatePath);
            var file = new SaveFileDialog();
            file.Title = "选择生成路径";
            file.Filter = "文本格式(*.txt)|*.txt";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.FileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            //先弹框，让用户选择
            if (file.ShowDialog() == DialogResult.OK)
            {
                string savePath = file.FileName;
                foreach(var item in Images)
                {
                    var str = Template.Replace("{ImageName}", item);
                    File.AppendAllText(savePath, str);
                }
            }
            MessageBox.Show("生成结束");
        }

        public void Refresh(int count = 0, int sucess = 0)
        {
            this.countLabel.Text = Images.Count().ToString();
        }

    }
}

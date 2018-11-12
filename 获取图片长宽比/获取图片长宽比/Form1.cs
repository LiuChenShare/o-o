using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 获取图片长宽比
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Refresh();
        }


        public List<ImageModel> Images = new List<ImageModel>();
        public ImageModel MaxAspectRatio = new ImageModel();
        public ImageModel MixAspectRatio = new ImageModel();

        private const string LoadString = "正在加载（{0}/{1}）";

        private const string EndString = "成功加载{0}个文件";

        private void button2_Click(object sender, EventArgs e)
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
                NewMethod(ofd);

            }
        }

        private Task NewMethod(OpenFileDialog ofd)
        {
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
                        var info = new ImageModel();
                        info.Url = ofd.FileNames[i];
                        info.Width = width;
                        info.Height = height;
                        info.AspectRatio = aspectRatio;
                        Images.Add(info);
                        sucess++;
                        if (aspectRatio > MaxAspectRatio.AspectRatio)
                        {
                            MaxAspectRatio = info;
                        }
                        if (aspectRatio < MixAspectRatio.AspectRatio)
                        {
                            MixAspectRatio = info;
                        }
                        if (i == 0)
                        {
                            MixAspectRatio = info;
                        }
                        Refresh(count, sucess);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return Task.CompletedTask;
        }

        public void Refresh(int count = 0, int sucess = 0)
        {
            this.countLabel.Text = Images.Count().ToString();
            this.maxLabel.Text = MaxAspectRatio.AspectRatio.ToString();
            this.mixLabel.Text = MixAspectRatio.AspectRatio.ToString();
            this.label4.Text = string.Format(LoadString, sucess, count);
            if(count == sucess)
            {
                this.label4.Text = string.Format(EndString, sucess);
            }
        }
    }
}

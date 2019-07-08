using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图片加水印
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文件地址
        /// </summary>
        private string Path;
        private Bitmap Bitmap1;
        private Bitmap Bitmap2;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog InvokeDialog = new OpenFileDialog();
                InvokeDialog.Title = "选择文件";
                //Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif|所有文件|*.*"
                InvokeDialog.Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif";
                InvokeDialog.RestoreDirectory = true;
                if (InvokeDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Path = InvokeDialog.FileName;
                    if (File.Exists(Path))
                    {
                        Bitmap1 = new Bitmap(Path);
                        pictureBox1.Image = Bitmap1;
                    }
                    else
                    {
                        MessageBox.Show(this, "请确认文件是否存在");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "选择失败:" + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var a = PngAddText(Path, textBox1.Text);
            if (a != null)
            {
                pictureBox2.Image = a;
            }
        }


        /// <summary>
        /// 图片上嵌入文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static Bitmap PngAddText(string imgPath, string text)
        {
            try
            {
                System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(imgPath);
                
                float x = 0;
                float y = 30;

                float xOffset = 20;
                using (Graphics g = Graphics.FromImage(imgSrc))
                {
                    g.DrawImage(imgSrc, 0, 0, imgSrc.Width, imgSrc.Height);
                    using (Font f = new Font("楷体", 64, FontStyle.Bold))
                    {
                        using (Brush b = new SolidBrush(Color.FromArgb(160,205,205,180)))
                        {
                            //for (int i = 0; i < text.Length; i++)
                            //{
                            //    switch (i)
                            //    {
                            //        case 0:
                            //            x = imgSrc.Width / 2 - xOffset;
                            //            y = xOffset;
                            //            break;
                            //        case 1:
                            //            x = imgSrc.Width / 2 - xOffset;
                            //            y = imgSrc.Height / 2;
                            //            break;
                            //        case 2:
                            //            if (text.Length == 4)
                            //            {
                            //                x = 0;
                            //                y = xOffset;
                            //            }
                            //            else if (text.Length == 3)
                            //            {
                            //                x = 0;
                            //                y = imgSrc.Height / 2 - 65 / 2.0f;
                            //            }
                            //            break;
                            //        case 3:
                            //            x = 0;
                            //            y = imgSrc.Height / 2;
                            //            break;
                            //        default:
                            //            break;
                            //    }

                            //    g.DrawString(text[i].ToString(), f, b, x, y);
                            //}
                            g.DrawString(text, f, b, x, y);
                        }
                    }
                }
                return new Bitmap(imgSrc);
                //string fontpath = AppDomain.CurrentDomain.BaseDirectory + @"save.png";
                //imgSrc.Save(fontpath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                MessageBox.Show("添加失败" + e.Message);
                return null;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 文本相似判断工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aPath = label1.Text == "-" ? string.Empty : label1.Text;
            string bPath = label2.Text == "-" ? string.Empty : label2.Text;
            if (string.IsNullOrWhiteSpace(aPath) || string.IsNullOrWhiteSpace(bPath))
            {
                MessageBox.Show(this, "请选择文件");
                return;
            }
            var aaaa = File.ReadAllText(aPath);
            var bbbb = File.ReadAllText(bPath);
            var result = Similarity.GetSimilarity(aaaa, bbbb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filename = OpenFile();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                label1.Text = filename;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var filename = OpenFile();
            if (!string.IsNullOrWhiteSpace(filename))
            {
                label2.Text = filename;
            }
        }

        private string OpenFile()
        {
            string filename = string.Empty;
            OpenFileDialog InvokeDialog = new OpenFileDialog();
            InvokeDialog.Title = "选择文本文件";
            InvokeDialog.Filter = "文本文件|*.txt";
            InvokeDialog.RestoreDirectory = true;
            if (InvokeDialog.ShowDialog(this) == DialogResult.OK)
            {
                filename = InvokeDialog.FileName;
            }
            return filename;
        }
    }
}

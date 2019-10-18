using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 获取电脑硬件信息
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var a1 = HardwareHepler.Get_OSVersion();//获取操作系统信息
            label1.Text = a1;
            var a2 = HardwareHepler.GetMacAddress();//获取MAC地址
            label2.Text = a2;
            var a3 = HardwareHepler.CXX2();//获取CPU信息
            label3.Text = a3;
            var a4 = HardwareHepler.GetMemoryInfo();//获取CPU信息
            label4.Text = a4;
            var a5 = HardwareHepler.HardDiskInfo();//获取硬盘信息
            label5.Text = a5;
        }
    }
}

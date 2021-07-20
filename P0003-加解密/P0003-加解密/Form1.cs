using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P0003_加解密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aaa = AESHelper.AESEncrypt(textBox1.Text, "1@admin");
            textBox2.Text = aaa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var aaa = AESHelper.AESDecrypt(textBox2.Text,"1admin");
            textBox1.Text = aaa;
        }
    }
}

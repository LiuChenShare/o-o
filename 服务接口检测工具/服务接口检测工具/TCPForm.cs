using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 服务接口检测工具
{
    public partial class TCPForm : Form
    {
        string Host = string.Empty;
        int Port = 0;
        int Timeout = 10000;
        int TotalNumber = 1000;
        int IdealTimeout = 2000;
        Thread thread = null;
        bool Start = false;

        public TCPForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                panel1.Enabled = false;
                Start = true;
                Host = textBox1.Text;
                Port = int.Parse(textBox2.Text);
                Timeout = int.Parse(textBox3.Text);
                TotalNumber = int.Parse(textBox4.Text);
                IdealTimeout = int.Parse(textBox5.Text);
                thread = new Thread(xxxxx);
                thread.Start();
            }
            catch (Exception ex)
            {
                button1.Enabled = true;
                panel1.Enabled = true;
                Start = false;
                MessageBox.Show(this, ex.Message);
            }
        }

        private void xxxxx()
        {
            string host = Host;
            int port = Port;
            int timeout = Timeout;
            int totalNumber = TotalNumber;
            int idealTimeout = IdealTimeout;
            int complete = 0;//已进行
            int fail = 0;//失败
            int error = 0;//异常
            int noHappy = 0;//不理想

            for (int i = 1; i <= totalNumber; i++)
            {
                try
                {
                    if (!Start) break;
                    complete++;//次数递增

                    label6.Text = complete.ToString();
                    label8.Text = fail.ToString();
                    label10.Text = error.ToString();
                    label12.Text = noHappy.ToString();

                    System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                    client.ReceiveTimeout = timeout;
                    client.SendTimeout = timeout;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    client.Connect(host, port);
                    if (!client.Connected)
                    {
                        fail++;//认为失败
                    }
                    sw.Stop();
                    client.Close();
                    var time = sw.ElapsedMilliseconds;
                    if (time >= idealTimeout)
                    {
                        noHappy++;//认为不理想
                    }
                }
                catch (Exception ex)
                {
                    error++;//认为异常了
                }
                Thread.Sleep(100);
            }
            button1.Enabled = true;
            panel1.Enabled = true;
            label6.Text = complete.ToString();
            label8.Text = fail.ToString();
            label10.Text = error.ToString();
            label12.Text = noHappy.ToString();
            LogHelper.TCPLog(string.Format("总进行：{0}\n失败：{1}\n异常：{2}\n不理想：{3}", complete, fail, error, noHappy));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start = false;
        }
    }
}

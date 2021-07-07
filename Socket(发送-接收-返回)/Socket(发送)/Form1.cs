using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Socket_发送_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }
            IPAddress ip = IPAddress.Parse(textBox2.Text);//接收端所在IP
            IPEndPoint ipEnd = new IPEndPoint(ip, int.Parse(textBox3.Text));//接收端所监听的接口
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//初始化一个Socket对象
            try
            {
                socket.Connect(ipEnd);//连接指定IP&端口
            }
            catch (SocketException ex)
            {
                Console.WriteLine("连接失败");
                Console.WriteLine(ex.ToString());
                return;
            }
            var body = Encoding.UTF8.GetBytes(text);
            //body = System.Text.Encoding.Default.GetBytes(ResultFilePath);
            socket.Send(body);//发送数据

            string str = System.Text.Encoding.Default.GetString(body);

            //string filePath = @"C:\Users\admin\Desktop\log.txt";
            //File.AppendAllText(filePath, Process.GetCurrentProcess().Id + "发送消息" + str + "\r\n");

            //while (true)//定义一个循环接收返回数据
            //{
            //    byte[] data = new byte[1024];
            //    var length = socket.Receive(data);//接收返回数据
            //    string stringData = Encoding.UTF8.GetString(data, 0, length);
            //    if (!string.IsNullOrWhiteSpace(stringData))
            //    {
            //        Console.Write(stringData);
            //        MessageBox.Show("发送成功！");
            //        break;
            //    }
            //}
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();//关闭Socket
        }
    }
}

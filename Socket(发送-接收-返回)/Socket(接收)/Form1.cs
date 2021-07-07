using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket_接收_
{
    public partial class Form1 : Form
    {
        Thread t;
        TcpListener tcpl = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), 1111);//定义一个TcpListener对象监听本地的1111端口
        /// <summary>
        /// 是否启动接收
        /// </summary>
        public bool startState { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 开始接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!startState)
            {
                tcpl = new TcpListener(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));//定义一个TcpListener对象监听本地的1111端口

                startState = true;
                t = new Thread(ReciveMsg);
                t.Start();
            }
        }

        /// <summary>
        /// 停止接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (startState)
            {
                tcpl.Stop();
                t.Abort();
                startState = false;
            }
        }


        /// <summary>        
        /// /// 接收发送给本机ip对应端口号的数据报        
        /// /// </summary>        
        private void  ReciveMsg()
        {
            try
            {
                tcpl.Start();//监听开始
                while (startState)
                {
                    try
                    {
                        Socket s = tcpl.AcceptSocket();//挂起一个Socket对象
                        string remote = s.RemoteEndPoint.ToString();//获取发送端的IP及端口转为String备用
                        Byte[] stream = new Byte[1024 * 1024 * 2];
                        var length = s.Receive(stream);//接收发送端发过来的数据,写入字节数组
                                                       //BGW_Handle.ReportProgress(1, "接收来自[" + remote + "]信息");

                        //string str = System.Text.Encoding.Default.GetString(stream, 0, length);

                        string _data = Encoding.UTF8.GetString(stream, 0, length);//将字节数据数组转为String
                        s.Send(stream);//将接收到的内容，直接返回接收端
                        s.Shutdown(SocketShutdown.Both);
                        if (!string.IsNullOrEmpty(_data))
                        {
                            //string filePath3 = @"C:\Users\admin\Desktop\log3.txt";
                            //File.AppendAllText(filePath3, Process.GetCurrentProcess().Id + "接收到:" + _data + "\r\n");
                            NewMethod(_data);
                            //break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                tcpl.Stop();//停止监听
                t.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewMethod(string _data)
        {
            listBox1.Items.Add(_data);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (startState)
                {
                    tcpl.Stop();
                    t.Abort();
                    startState = false;
                }
            }
            catch 
            {

            }
        }
    }
}

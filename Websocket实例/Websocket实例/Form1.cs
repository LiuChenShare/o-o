using Fleck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Websocket实例
{
    public partial class Form1 : Form
    {
        private List<IWebSocketConnection> allSockets;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //FleckLog.Level = LogLevel.Debug;
            allSockets = new List<IWebSocketConnection>();
            //var server = new WebSocketServer("ws://localhost:12345");
            var server = new WebSocketServer("ws://0.0.0.0:7181");
            var a = server.Location;
            var b = server.Port;

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    //Console.WriteLine("Open!");
                    //MessageBox.Show("Open!");
                    listBox1.Items.Add("Open!");
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    //Console.WriteLine("Close!");
                    //MessageBox.Show("Close!");
                    listBox1.Items.Add("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    //Console.WriteLine(message);
                    //MessageBox.Show(message);
                    listBox1.Items.Add(message);
                    allSockets.ToList().ForEach(s => s.Send("Echo: " + message));
                };
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = textBox1.Text;
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            foreach (var socket in allSockets.ToList())
            {
                socket.Send(input);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace P0001_文件对比并自动提取
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProcessStartEventHander += ProcessStart;
            ProcessChangedEventHander += ProcessChanged;
            ProcessStopEventHander += ProcessStop;
        }

        /// <summary> 开始提取 </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var t1 = textBox1.Text;//原始文件夹路径
                var t2 = textBox2.Text;//最新文件夹路径
                var t3 = textBox3.Text;//目标文件夹路径
                if (string.IsNullOrWhiteSpace(t1) || !Directory.Exists(t1))
                {
                    throw new Exception("请检查原始文件夹路径是否正确");
                }
                if (string.IsNullOrWhiteSpace(t2) || !Directory.Exists(t2))
                {
                    throw new Exception("请检查最新文件夹路径是否正确");
                }
                if (string.IsNullOrWhiteSpace(t3) || !Directory.Exists(t3))
                {
                    throw new Exception("请检查目标文件夹路径是否正确");
                }
                Task.Factory.StartNew(() =>
                {
                    var hash = System.Security.Cryptography.HashAlgorithm.Create();

                    var files = GetFiles(t2);

                    int count = files.Count();
                    ProcessStartEventHander?.Invoke(count, new EventArgs());//开始
                    int num = 1;
                    foreach (var file in files)
                    {
                        try
                        {
                            string p_1 = file;
                            string p_2 = file.Replace(t2, t1);
                            if (File.Exists(p_2))
                            {
                                //计算第一个文件的哈希值
                                var stream_1 = new System.IO.FileStream(p_1, System.IO.FileMode.Open);
                                byte[] hashByte_1 = hash.ComputeHash(stream_1);
                                stream_1.Close();
                                //计算第二个文件的哈希值
                                var stream_2 = new System.IO.FileStream(p_2, System.IO.FileMode.Open);
                                byte[] hashByte_2 = hash.ComputeHash(stream_2);
                                stream_2.Close();

                                //比较两个哈希值
                                if (BitConverter.ToString(hashByte_1) == BitConverter.ToString(hashByte_2))
                                {
                                    Console.WriteLine("两个文件相等");
                                }
                                else
                                {
                                    Console.WriteLine("两个文件不等");
                                    string p_3 = file.Replace(t2, t3);
                                    //if (!File.Exists(p_3))        // 返回bool类型，存在返回true，不存在返回false                                     
                                    //{
                                    //    File.Create(p_3);         //不存在则创建文件
                                    //}
                                    string s = p_3.Substring(0, p_3.LastIndexOf('\\'));
                                    Directory.CreateDirectory(s);
                                    File.Copy(p_1, p_3, true);
                                }
                            }
                            else
                            {
                                string p_3 = file.Replace(t2, t3);
                                string s = p_3.Substring(0, p_3.LastIndexOf('\\'));
                                Directory.CreateDirectory(s);
                                File.Copy(p_1, p_3, true);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        ProcessChangedEventHander?.Invoke(num, new EventArgs());//进度回调
                        num++;
                    }

                    ProcessStopEventHander?.Invoke(num, new EventArgs());//结束回调
                });
            }
            catch(Exception ex)
            {
                UpdateState(true);
                System.Windows.MessageBox.Show(this, ex.Message);
            }
        }

        private void UpdateState( bool style)
        {
            this.textBox1.Dispatcher.BeginInvoke((ThreadStart)delegate {

                button1.IsEnabled = style;
                button2.IsEnabled = style;
                button3.IsEnabled = style;
                textBox1.IsEnabled = style;
                textBox2.IsEnabled = style;
                textBox3.IsEnabled = style;

                startButton.IsEnabled = style;
            });
        }

        private List<string> GetFiles(string path)
        {
            List<string> fileModel = new List<string>();

            //获取文件夹下所有的文件
            FileInfo[] files = new DirectoryInfo(path).GetFiles();
            //获取文件夹下所有的目录
            DirectoryInfo[] dyInfos = new DirectoryInfo(path).GetDirectories();

            foreach (var file in files)
            {
                fileModel.Add(file.FullName);
            }
            foreach (var dy in dyInfos)
            {
                fileModel.AddRange(GetFiles(dy.FullName));
            }
            return fileModel;
        }

        private FileModel GetFiles2(string path)
        {
            FileModel fileModel = new FileModel();

            //获取文件夹下所有的文件
            FileInfo[] files = new DirectoryInfo(path).GetFiles();
            //获取文件夹下所有的目录
            DirectoryInfo[] dyInfos = new DirectoryInfo(path).GetDirectories();

            fileModel.Path = path;
            foreach(var file in files)
            {
                fileModel.Files.Add(file.FullName);
            }
            foreach (var dy in dyInfos)
            {
                fileModel.Childs.Add(GetFiles2(dy.FullName));
            }
            return fileModel;
        }


        #region 事件

        /// <summary>
        /// 进度开始回调事件
        /// </summary>
        public ProgressEventHandler ProcessStartEventHander;
        /// <summary>
        /// 进度回调事件
        /// </summary>
        public ProgressEventHandler ProcessChangedEventHander;
        /// <summary>
        /// 进度结束回调事件
        /// </summary>
        public ProgressEventHandler ProcessStopEventHander;

        /// <summary>
        /// 进度事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ProgressEventHandler(object sender, EventArgs e);
        
        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessStart(object sender, EventArgs e)
        {
            var num = (int)sender;
            UpdateState(false);
            this.progressBar.Dispatcher.BeginInvoke((ThreadStart)delegate {
                this.progressBar.Maximum = num; });
        }

        /// <summary>
        /// 进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessChanged(object sender, EventArgs e)
        {
            //Dispatcher.BeginInvoke(new Action(delegate
            //{
            //    progressBar.Value = (int)sender;
            //}));
            var num = (int)sender;
            this.progressBar.Dispatcher.BeginInvoke((ThreadStart)delegate { this.progressBar.Value = num; });
        }

        /// <summary>
        /// 结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessStop(object sender, EventArgs e)
        {
            UpdateState(true);
            this.progressBar.Dispatcher.BeginInvoke((ThreadStart)delegate {
                this.progressBar.Value = this.progressBar.Maximum; });
        }
        #endregion

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var aaaa = sender as System.Windows.Controls.Button;
            var name = aaaa.Name;
            string folderPath = "";
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            //dialog.Description = string.Format("导出另存为《{0}》", model.FolderName);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;
                switch (name)
                {
                    case "button1":
                        textBox1.Text = folderPath;
                        break;
                    case "button2":
                        textBox2.Text = folderPath;
                        break;
                    case "button3":
                        textBox3.Text = folderPath;
                        break;
                }
            }
            else
            {
            }
        }
    }
}

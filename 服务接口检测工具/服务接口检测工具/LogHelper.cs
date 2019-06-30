using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 服务接口检测工具
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        private static volatile LogHelper instance;
        private static readonly object obj = new object();
        public static LogHelper Instance
        {
            get
            {
                if (null == instance)
                {
                    lock (obj)
                    {
                        if (null == instance)
                        {
                            instance = new LogHelper();
                        }
                    }

                }
                return instance;
            }
        }


        private static string TCPPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "TCPLogs.txt";
        private static string HTTPPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "HTTPLogs.txt";
        
        
        public static void TCPLog(string Message)
        {
            File.AppendAllText(TCPPath, Message + "\n\n\n");
        }


        public static void HTTPLog(string Message)
        {
            File.AppendAllText(HTTPPath, Message + "\n\n\n");
        }


    }
}

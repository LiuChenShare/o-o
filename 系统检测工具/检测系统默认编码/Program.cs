using System;
using System.Text;

namespace 检测系统默认编码
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("当前系统默认编码格式为：\n");
            Console.WriteLine(Encoding.Default + "\n");
            Console.WriteLine("CodePage：" + Encoding.Default.CodePage + "\n");
            Console.WriteLine("BodyName：" + Encoding.Default.BodyName + "\n");
            Console.WriteLine("EncodingName：" + Encoding.Default.EncodingName + "\n");
            Console.WriteLine("WebName：" + Encoding.Default.WebName + "\n");
            Console.WriteLine("HeaderName：" + Encoding.Default.HeaderName + "\n");
            Console.WriteLine("WindowsCodePage：" + Encoding.Default.WindowsCodePage + "\n");
            Console.WriteLine("请按Enter键结束：\n");
            Console.Read();
        }
    }
}

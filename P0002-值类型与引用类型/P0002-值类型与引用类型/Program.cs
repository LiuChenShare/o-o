using System;

namespace P0002_值类型与引用类型
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试引用类型
            TestClass c1 = new TestClass { Id = 0, Name = "未定义" };
            TestClass c2 = c1;//c1给了c2
            c2.Id = 1;c2.Name = "a";
            WriteColorLine($"c1[{c1.Id},{c1.Name}]", ConsoleColor.Green);
            //测试值类型
            TestStruct s1 = new TestStruct { Id = 0, Name = "未定义" };
            TestStruct s2 = s1;//s1给了s2
            s2.Id = 2; s2.Name = "b";
            WriteColorLine($"s1[{s1.Id},{s1.Name}]", ConsoleColor.Green);
            Console.ReadKey();
        }

        /// <summary>
        /// 打个日志
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        static void WriteColorLine(string str, System.ConsoleColor color)
        {
            ConsoleColor currentForeColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = currentForeColor;
        }
    }


    /// <summary>
    /// 类
    /// </summary>
    class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// 结构体
    /// </summary>
    struct TestStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}

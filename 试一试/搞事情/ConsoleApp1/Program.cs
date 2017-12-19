using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();   // 在静态函数Main中调用非静态方法时,  
            // 必须先实例化该类对象,方可调用Add方法   
            DllClass dll = new DllClass();

            dll.SetAddCallBack(prog.Add);   // 设置回调  
            dll.CallAdd();                  // 触发回调  
            Console.Read();                 // 暂停程序  
        }

        // 回调函数  
        private int Add(int a, int b)
        {
            int c = a + b;
            Console.WriteLine("Add被调用了，a+b={0}", c);
            return c;
        }
    }
}

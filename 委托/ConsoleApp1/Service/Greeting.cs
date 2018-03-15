using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Service
{
    class Greeting
    {

        public delegate void GreetingDelegate(string name);

        //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning," + name);
        }

        public void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }
    }
}

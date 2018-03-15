using ConsoleApp1.Service;
using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp1.Service.Greeting;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting dele = new Greeting();

            //(一)委托的使用
            dele.GreetPeople("村长", dele.EnglishGreeting);
            dele.GreetPeople("村长", dele.ChineseGreeting);


            //(二)像使用string一样的使用委托
            GreetingDelegate Adelegate1, Adelegate2;
            Adelegate1 = dele.EnglishGreeting;
            Adelegate2 = dele.ChineseGreeting;
            dele.GreetPeople("Jimmy Zhang", Adelegate1);
            dele.GreetPeople("张子阳", Adelegate2);


            //(三)也可以将多个方法赋给同一个委托
            GreetingDelegate Bdelegate1;
            Bdelegate1 = dele.EnglishGreeting; // 先给委托类型的变量赋值
            Bdelegate1 += dele.ChineseGreeting;   // 给此委托变量再绑定一个方法
            // 将先后调用 EnglishGreeting 与 ChineseGreeting 方法
            dele.GreetPeople("Jimmy Zhang", Bdelegate1);


            //(四)实际上，我们可以也可以绕过GreetPeople方法，通过委托来直接调用EnglishGreeting和ChineseGreeting
            GreetingDelegate Cdelegate1;
            Cdelegate1 = dele.EnglishGreeting; // 先给委托类型的变量赋值
            Cdelegate1 += dele.ChineseGreeting;   // 给此委托变量再绑定一个方法
            Cdelegate1("Jimmy Zhang");


            Console.ReadKey();
        }
        
    }
}

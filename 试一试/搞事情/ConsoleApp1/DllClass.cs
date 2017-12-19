using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DllClass  // 假设此类封装在dll中  
    {
        // 声明回调函数原型，即函数委托了  
        public delegate int Add(int num1, int num2);

        public Add OnAdd = null;   // 此处相当于定义函数指针了  

        // 设置回调函数地址  
        public void SetAddCallBack(Add add)
        {
            this.OnAdd = add;
        }

        // 调用回调函数  
        public void CallAdd()
        {
            if (OnAdd != null)
            {
                OnAdd(1, 99);
            }
        }
    }
}

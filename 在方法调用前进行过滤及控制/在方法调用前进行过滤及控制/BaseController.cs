using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 在方法调用前进行过滤及控制
{
    public class BaseController
    {
        public void Main()
        {
            Order order = new Order() { Id = 1, Name = "lee", Count = 10, Price = 100.00, Desc = "订单测试" };
            IOrderProcessor orderprocessor = new OrderProcessorDecorator(new OrderProcessor());
            orderprocessor.Submit(order);
            Console.ReadLine();
        }
    }
}

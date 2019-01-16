using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 在方法调用前进行过滤及控制
{
    /// <summary>
    /// 订单模型
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { set; get; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { set; get; }
    }
}

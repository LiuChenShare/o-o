using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date.人物
{
    /// <summary>
    /// 人物模型
    /// </summary>
    public class PlayerInfo
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 生命值
        /// </summary>
        public double ShengMing { get; set; }

        /// <summary>
        /// 体力值
        /// </summary>
        public double TiLi { get; set; }

        /// <summary>
        /// 饱食度
        /// </summary>
        public double BaoShi { get; set; }

        /// <summary>
        /// 水份
        /// </summary>
        public double ShuiFen { get; set; }
    }
}

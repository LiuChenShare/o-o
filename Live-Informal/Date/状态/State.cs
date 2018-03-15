using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date.状态
{
    /// <summary>
    /// 状态
    /// </summary>
    public class State
    {
        /// <summary>
        /// 唯一Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        #region 战斗相关
        /// <summary>
        /// 增加伤害的 数值
        /// </summary>
        public double ShangHaiNumber { get; set; }

        /// <summary>
        /// 增加伤害的 百分比
        /// </summary>
        public double ShangHaiPercentage { get; set; }

        /// <summary>
        /// 增加防御的 数值
        /// </summary>
        public double FangYuNumber { get; set; }

        /// <summary>
        /// 增加防御的 百分比
        /// </summary>
        public double FangYuPercentage { get; set; }

        /// <summary>
        /// 增加命中的 数值
        /// </summary>
        public double MingzhongNumber { get; set; }

        /// <summary>
        /// 增加闪避的 数值
        /// </summary>
        public double ShanBiNumber { get; set; }
        #endregion

        #region 生存相关
        /// <summary>
        /// 生命值上限提高的 数值
        /// </summary>
        public double ShengMingNumber { get; set; }

        /// <summary>
        /// 生命值上限提高的数值 百分比
        /// </summary>
        public double ShengMingPercentage { get; set; }

        /// <summary>
        /// 体力值上限提高的 数值
        /// </summary>
        public double TiLiNumber { get; set; }

        /// <summary>
        /// 体力值上限提高的数值 百分比
        /// </summary>
        public double TiLiPercentage { get; set; }

        /// <summary>
        /// 饱食度上限提高的 数值
        /// </summary>
        public double BaoShiNumber { get; set; }

        /// <summary>
        /// 饱食度上限提高的数值 百分比
        /// </summary>
        public double BaoShiPercentage { get; set; }

        /// <summary>
        /// 身体水份上限提高的 数值
        /// </summary>
        public double ShuiFenNumber { get; set; }

        /// <summary>
        /// 身体水份上限提高的数值 百分比
        /// </summary>
        public double ShuiFenPercentage { get; set; }
        #endregion
    }
}

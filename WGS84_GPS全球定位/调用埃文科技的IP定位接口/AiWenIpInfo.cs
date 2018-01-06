using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 调用埃文科技的IP定位接口
{
    [Serializable]
    public class AiWenIpInfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// 简要地址
        /// </summary>
        public string Address { get; set; }

        #region address_detail  （From 埃文科技）
        /// <summary>
        /// 大陆
        /// </summary>
        public string Continent { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Zipcode { get; set; }
        /// <summary>
        /// 时区
        /// </summary>
        public string Timezone { get; set; }
        /// <summary>
        /// 精确等级
        /// </summary>
        public string Accuracy { get; set; }
        /// <summary>
        /// 运营商
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 准确性
        /// </summary>
        public string Correctness { get; set; }
        /// <summary>
        /// 一致性
        /// </summary>
        public string Consistency { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public List<MultiAreas> MultiAreas { get; set; }

        #endregion


    }


    [Serializable]
    public class MultiAreas
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng { get; set; }
        /// <summary>
        /// 半径（KM）
        /// </summary>
        public string Radius { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Prov { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }
    }
}

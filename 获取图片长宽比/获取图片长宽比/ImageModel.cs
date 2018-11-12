using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取图片长宽比
{
    /// <summary>
    /// 图像数据
    /// </summary>
    public class ImageModel
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Url { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        /// <summary>
        /// 宽高比
        /// </summary>
        public double AspectRatio { get; set; }
    }
}

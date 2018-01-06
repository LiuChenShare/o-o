using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 调用埃文科技的IP定位接口
{
    public class Result<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="model"></param>
        public Result(bool success, string msg = "", T model = default(T))
        {
            this.success = success;
            this.message = msg;
            this.Data = model;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }
}

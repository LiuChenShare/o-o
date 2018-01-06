using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace 调用埃文科技的IP定位接口
{
    public class Program
    {

        public const string Default_Key = "SfFBxTkzGHjDKhsLAMdQZG2tkcvgiFykjIFGuTQR32GZlJQBiHY4CPfbE2e5DsG2";
        public const string Default_Coordsys = "WGS84";

        static void Main(string[] args)
        {
            Console.Write("我开始调用APi了");

            string ip = "60.168.155.76";
            var program = new Program();
            var model = program.request(ip);

            Console.Write("回车键结束");
            Console.WriteLine();
        }

        protected AiWenIpInfo request(string IP, string key = Default_Key, string Coordsys = Default_Coordsys)
        {
            var url = string.Empty;
            //https: //mall.ipplus360.com/ip/locate/api?key=您申请的KEY&ip=您需要查询的ip&coordsys=WGS84
            //key=SfFBxTkzGHjDKhsLAMdQZG2tkcvgiFykjIFGuTQR32GZlJQBiHY4CPfbE2e5DsG2&ip=60.168.155.76&coordsys=WGS84
            url = "https://mall.ipplus360.com/ip/locate/api" + "?key={0}&ip={1}&coordsys={2}";
            url = string.Format(url, key, IP, Coordsys);
            //url = string.Format(url, "SfFBxTkzGHjDKhsLAMdQZG2tkcvgiFykjIFGuTQR32GZlJQBiHY4CPfbE2e5DsG2", "60.168.155.76", "WGS84");

            var model = this.InvokeRequest<Result<AiWenIpInfo>>(url, HttpMethod.Get, null)?.Data;
            return model;
        }

        /// <summary>
        /// 发送请求，读取响应
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        protected virtual T InvokeRequest<T>(string url, HttpMethod method, string postData = "") where T : class
        {
            string text = string.Empty;
            try
            {
                text = this.InternalInvokeRequest(url, null, method);
            }
            catch
            {
                text = null;
            }
            return JsonConvert.DeserializeObject<T>(text);
        }

        /// <summary>
        /// 构建请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        protected virtual string InternalInvokeRequest(string url, string data, HttpMethod method)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = Encoding.UTF8;
                    if (method == HttpMethod.Get)
                    {
                        return client.DownloadString(url);
                    }
                    else if (method == HttpMethod.Post)
                    {
                        return client.UploadString(url, data);
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(new { success = false, message = $"不支持的{method.ToString()}" });
                    }
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(new { success = false, message = e.Message });
                }
            }
        }
    }
}

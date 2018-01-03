using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGS84_GPS全球定位
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = SqlGeography.Point(22.54587746, 114.12873077, 4326); //上海的某个点
            var b = SqlGeography.Point(23, 115, 4326); //上海的某个点,4236代表WGS84这种坐标参照系统。
            Console.WriteLine(a.STDistance(b)); //距离

            var c = SqlGeography.Point(31.837964, 117.203123, 4326); //公司的位置
            var d = SqlGeography.Point(31.822426, 117.221662, 4326); // 合肥市政务中心,4236代表WGS84这种坐标参照系统。
            Console.WriteLine("公司和合肥市政务中心的距离是：" + c.STDistance(d) + "米"); //距离

            Console.ReadKey();
        }
    }
}

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
            // 1.使用Microsoft.SqlServer.Types计算WGS84坐标的两点距离
            var c = SqlGeography.Point(31.837964, 117.203123, 4326); //公司的位置
            var d = SqlGeography.Point(31.822426, 117.221662, 4326); // 合肥市政务中心,4236代表WGS84这种坐标参照系统。
            Console.WriteLine("公司和合肥市政务中心的距离是：" + c.STDistance(d) + "米"); //距离


            // 2.使用把坐标当做平面坐标计算两点距离
            double width = 31.837964 - 31.822426;
            double height = 117.203123 - 117.221662;
            double result = (width * width) + (height * height);
            result = Math.Sqrt(result);//根号
            Console.WriteLine("想象成平面时公司和合肥市政务中心的距离是：" + result + "米"); //距离


            // 3.用haversine公式计算WGS84坐标的两点距离
            WGS84 wgs84 = new WGS84();
            var coordinateA = new Coordinate() { Latitude = 31.837964, Longitude = 117.203123 };
            var coordinateB = new Coordinate() { Latitude = 31.822426, Longitude = 117.221662 };
            var xxx = wgs84.Distance(coordinateA, coordinateB);
            Console.WriteLine("用haversine公式时公司和合肥市政务中心的距离是：" + xxx*1000 + "米"); //距离

            Console.ReadKey();
        }
    }
}

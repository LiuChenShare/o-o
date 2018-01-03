using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGS84_GPS全球定位
{
    /// <summary>
    /// 获取距离
    /// </summary>
    public class GetDis
    {
        /// <summary>
        /// 计算球面两点距离
        /// </summary>
        /// <param name="coordinateA"></param>
        /// <param name="coordinateB"></param>
        /// <returns></returns>
        public static double getDistance(Coordinate coordinateA, Coordinate coordinateB)
        {
            double lat1 = (Math.PI / 180) * coordinateA.Latitude;
            double lat2 = (Math.PI / 180) * coordinateB.Latitude;

            double lon1 = (Math.PI / 180) * coordinateA.Longitude;
            double lon2 = (Math.PI / 180) * coordinateB.Longitude;

            //地球半径    
            double R = 6371;

            //两点间距离 km，如果想要米的话，结果*1000就可以了    
            double d = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * R;

            return d * 1000;
        }

        public static double getXXX()
        {
            var a = SqlGeography.Point(22.54587746, 114.12873077, 4326); //上海的某个点
            var b = SqlGeography.Point(23, 115, 4326); //上海的某个点,4236代表WGS84这种坐标参照系统。
            return a.STDistance(b).Value; //距离
        }

        /// <summary>
        /// Haversine公式代码
        /// </summary>
        /// <param name="coordinateA"></param>
        /// <param name="coordinateB"></param>
        /// <returns></returns>
        public static double distHaversineRAD(Coordinate coordinateA, Coordinate coordinateB)
        {
            double hsinX = Math.Sin((coordinateA.Longitude - coordinateB.Longitude) * 0.5);
            double hsinY = Math.Sin((coordinateA.Latitude - coordinateB.Latitude) * 0.5);
            double h = hsinY * hsinY +
                    (Math.Cos(coordinateA.Latitude) * Math.Cos(coordinateB.Latitude) * hsinX * hsinX);
            return 2 * Math.Atan2(Math.Sqrt(h), Math.Sqrt(1 - h)) * 6367000;
        }


        #region 使用Haversine公式进行计算
        static double EARTH_RADIUS = 6371.0;//km 地球半径 平均值，千米
        public static double HaverSin(double theta)
        {
            var v = Math.Sin(theta / 2);
            return v * v;
        }
        /// <summary>
        /// 给定的经度1，纬度1；经度2，纬度2. 计算2个经纬度之间的距离。
        /// </summary>
        /// <param name="lat1">经度1</param>
        /// <param name="lon1">纬度1</param>
        /// <param name="lat2">经度2</param>
        /// <param name="lon2">纬度2</param>
        /// <returns>距离（公里、千米）</returns>
        public double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            //用haversine公式计算球面两点间的距离。
            //经纬度转换成弧度
            lat1 = ConvertDegreesToRadians(lat1);
            lon1 = ConvertDegreesToRadians(lon1);
            lat2 = ConvertDegreesToRadians(lat2);
            lon2 = ConvertDegreesToRadians(lon2);

            //差值
            var vLon = Math.Abs(lon1 - lon2);
            var vLat = Math.Abs(lat1 - lat2);

            //h is the great circle distance in radians, great circle就是一个球体上的切面，它的圆心即是球心的一个周长最大的圆。
            var h = HaverSin(vLat) + Math.Cos(lat1) * Math.Cos(lat2) * HaverSin(vLon);

            var distance = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(h));

            return distance;
        }

        /// <summary>
        /// 将角度换算为弧度。
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double ConvertRadiansToDegrees(double radian)
        {
            return radian * 180.0 / Math.PI;
        }
        #endregion 

    }
}

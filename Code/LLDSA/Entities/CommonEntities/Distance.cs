/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    /// <summary>
    /// 已知地球两点经纬度，求距离||get distance with longitude & latitude of two points
    /// </summary>
    public static class Distance
    {
        private static double earthR = 6378.137;
        
        public static double EarthR
        {
            get { return earthR; }
            set { earthR = value; }
        }
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        ///求两地球上两点间距离（经纬度）
        /// </summary>
        public static double DistanceOfTwoPoints(double lng1, double lat1, double lng2, double lat2)//重载，输入两点经纬度，求之间距离
        {
            double a = Rad(lat1) - Rad(lat2);
            double b = Rad(lng1) - Rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
            Math.Cos(Rad(lat1)) * Math.Cos(Rad(0.1)) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * earthR;
            return s;
        }

        /// <summary>
        /// 某点附近，每1经度的距离
        /// </summary>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static double DistanceOfPerLongitudeDegree(double latitude)
        {
            double distance = 0;
            distance = DistanceOfTwoPoints(0, latitude, 1, latitude);
            return distance;
        }

        /// <summary>
        /// 某点附近，每1纬度的距离
        /// </summary>
        /// <returns></returns>
        public static double DistanceOfPerLatitudeDegree()
        {
            double distance = 0;
            distance = DistanceOfTwoPoints(110, 30, 110, 31);
            return distance;
        }

        /// <summary>
        /// 某点附近，一个经度所相差的距离
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static double LongitudeDegreeOfPerKm(double latitude)
        {
            double lngInterval;
            lngInterval = 1 / DistanceOfPerLongitudeDegree(latitude);
            return lngInterval;
        }
        public static double LatitudeDegreeOfPerKm()
        {
            double latInterval;
            latInterval = 1 / DistanceOfPerLatitudeDegree();
            return latInterval;
        }


        /// <summary>
        /// 输入最大最小经纬度，返回较大边的长度（km）
        /// </summary>
        /// <param name="_minLongitude"></param>
        /// <param name="_maxLongitude"></param>
        /// <param name="_minLatitude"></param>
        /// <param name="_maxLatitude"></param>
        /// <returns></returns>
        public static double GetBiggerSideLength(double _minLongitude, double _maxLongitude, double _minLatitude, double _maxLatitude)
        {
            try
            {
                double _BiggerSideLength = 0;
                double avgLatitude = (_maxLatitude - _minLatitude) / 2 + _minLatitude;
                double avgLongitude = (_maxLongitude - _minLongitude) / 2 + _minLongitude;
                double x = DistanceOfTwoPoints(_minLongitude, avgLatitude, _maxLongitude, avgLatitude);
                double y = DistanceOfTwoPoints(avgLongitude, _minLatitude, avgLongitude, _maxLatitude);
                _BiggerSideLength = Math.Max(x, y);
                return _BiggerSideLength;
            }
            catch
            { throw; }
        }

    }
}

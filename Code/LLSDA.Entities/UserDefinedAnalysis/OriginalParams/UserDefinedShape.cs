using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    
    public class UserDefinedShape
    {

        #region LocalVariable
        /** 形状类型 */
        private ShapeType shapeType;

        /** 面积 */
        private double size;

        /** 矩形范围顶点 */
        private List<Point> vertexArray;

        /** 圆形圆心 */
        private Point centerPoint;

        /** 圆形半径 */
        private double radius;

        /** 多边形、多边线顶点 */
        private List<Point> pathArray;

        /** 多边线偏移顶点 */
        private List<Point> excursionVertexArray;

        /** 最小经度 */
        private double minLongitude;

        /** 最大经度 */
        private double maxLongitude;

        /** 最小纬度  */
        private double minLatitude;

        /** 最大纬度  */
        private double maxLatitude;
        #endregion 


        #region methods
        /// <summary>
        /// 得到本形状的边界属性
        /// </summary>
        public double CalcuShapeSize()
        {
            if (shapeType == ShapeType.Square || shapeType == ShapeType.Rectangle)
            {
                if (vertexArray.Any())
                {
                    size = CalcuRectangleSize(vertexArray);
                }
                else
                    throw new InvalidOperationException("vertexArray中不包括任何元素");
            }
            else if (shapeType == ShapeType.Circle)
            {

                if (radius != 0)
                {
                    size = CalcuCircleSize(radius);
                }
                else
                    throw new InvalidOperationException("圆的半径不能为0。");

            }
            else if (shapeType == ShapeType.Polygon || shapeType == ShapeType.Polyline || shapeType == ShapeType.Triangle)
            {
                if (pathArray.Any())
                {
                    size = CalcuPolygonSize(pathArray);
                }
                else
                    throw new InvalidOperationException("pathArray中不包括任何元素");
            }
            else
            {
                // donothing  边界为0
                size = 0;
            }
            return size;
        }

        public double GetShapeBorder()
        {
            double result = 0;
            if (shapeType == ShapeType.Square || shapeType == ShapeType.Rectangle)
            {
                if (vertexArray.Any())
                {
                    minLongitude = vertexArray.Select(r => r.Lng).Min();
                    minLatitude = vertexArray.Select(r => r.Lat).Min();
                    maxLongitude = vertexArray.Select(r => r.Lng).Max();
                    maxLatitude = vertexArray.Select(r => r.Lat).Max();
                }
                else
                    throw new InvalidOperationException("vertexArray中不包括任何元素");
            }
            else if (shapeType == ShapeType.Circle)
            {
                if (centerPoint != null)
                {
                    if (radius != 0)
                    {
                        minLongitude = centerPoint.Lng - radius / Distance.DistanceOfPerLongitudeDegree(centerPoint.Lat) * 1.0;
                        maxLongitude = centerPoint.Lng + radius / Distance.DistanceOfPerLongitudeDegree(centerPoint.Lat) * 1.0;
                        minLatitude = centerPoint.Lat - radius / Distance.DistanceOfPerLatitudeDegree();
                        maxLatitude = centerPoint.Lat + radius / Distance.DistanceOfPerLatitudeDegree();
                    }
                    else
                        throw new InvalidOperationException("圆的半径不能为0。");
                }
                else
                    throw new InvalidOperationException("圆心不存在。");
            }
            else if (shapeType == ShapeType.Polygon || shapeType == ShapeType.Polyline || shapeType == ShapeType.Triangle)
            {
                if (pathArray.Any())
                {
                    minLongitude = pathArray.Select(r => r.Lng).Min();
                    minLatitude = pathArray.Select(r => r.Lat).Min();
                    maxLongitude = pathArray.Select(r => r.Lng).Max();
                    maxLatitude = pathArray.Select(r => r.Lat).Max();
                }
                else
                    throw new InvalidOperationException("pathArray中不包括任何元素");
            }
            else
            {
                //donothing  边界为0
            }
            return result;
        }

        /// <summary>
        /// 计算不规则多边形的面积，输入顶点序列
        /// </summary>
        /// <param name="listPoint"></param>
        /// <returns></returns>
        private double CalcuPolygonSize(List<Point> listPoint)
        {
            List<double> xs = listPoint.Select(r => r.Lng).ToList();
            List<double> ys = listPoint.Select(r => r.Lat).ToList();
            double size = 0;
            size += Math.Abs(xs[listPoint.Count - 1] * ys[0] - xs[0] * ys[listPoint.Count - 1]);
            for (int k = 0; k < listPoint.Count - 1; k++)
            {
                double tmp1 = xs[k] * ys[k + 1];
                double tmp2 = xs[k + 1] * ys[k];

                size = size + Math.Abs(tmp1 - tmp2);
            }
            size = size / 2.0;
            return size;
        }

        /// <summary>
        /// 计算圆形面积
        /// </summary>
        /// <param name="radius">单位: 千米</param>
        /// <returns></returns>
        private double CalcuCircleSize(double radius)
        {
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// 计算矩形面积。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private double CalcuRectangleSize(List<Point> listPoint)
        {
            double size, length, width;
            if (listPoint.Count == 4)
            {
                minLongitude = vertexArray.Select(r => r.Lng).Min();
                minLatitude = vertexArray.Select(r => r.Lat).Min();
                maxLongitude = vertexArray.Select(r => r.Lng).Max();
                maxLatitude = vertexArray.Select(r => r.Lat).Max();

                width = Distance.DistanceOfTwoPoints(minLongitude, minLatitude, minLongitude, maxLatitude);
                length = Distance.DistanceOfTwoPoints(minLongitude, minLatitude, maxLongitude, minLatitude);
                size = width * length;
                return size;
            }
            else
                throw new Exception("矩形有且只有4个顶点");
        }

        #endregion


        #region Property
        
        public ShapeType ShapeType
        {
            get { return shapeType; }
            set { shapeType = value; }
        }


        public double Size
        {
            get
            {
                if (size == 0)
                    size = CalcuShapeSize();
                return size;
            }
            set { size = value; }
        }


        
        public List<Point> VertexArray
        {
            get { return vertexArray; }
            set { vertexArray = value; }
        }

        
        public Point CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }


        
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }


        
        public List<Point> PathArray
        {
            get { return pathArray; }
            set { pathArray = value; }
        }


        
        public List<Point> ExcursionVertexArray
        {
            get { return excursionVertexArray; }
            set { excursionVertexArray = value; }
        }


        public double MinLongitude
        {
            get { return minLongitude; }
            set { minLongitude = value; }
        }


        public double MaxLongitude
        {
            get { return maxLongitude; }
            set { maxLongitude = value; }
        }


        public double MinLatitude
        {
            get { return minLatitude; }
            set { minLatitude = value; }
        }


        public double MaxLatitude
        {
            get { return maxLatitude; }
            set { maxLatitude = value; }
        }
        #endregion

    }


    public class DateTimePeriod
    {
        DateTime startDateTime, endDateTime;
        
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }

    }
}

/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using LLSDA.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public abstract class Shapes : IDisposable
    {
        #region FieldAttribute
        internal Shape centerShape, wholeShape;
        internal ConcurrentBag<Shape> shapesCore;
        //internal ConcurrentBag<Shape> shapesList;
        internal double years;

        /// <summary>
        /// 有所有形状构成的整体
        /// </summary>
        public Shape WholeShape
        {
            get { return wholeShape; }
            set { wholeShape = value; }
        }
        public ConcurrentBag<Shape> ShapesList
        {
            get
            {
                return shapesCore;
            }
            set { shapesCore = value; }
        }
        public Shape CenterShape
        {
            get { return centerShape; }
            set { centerShape = value; }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        public Shape this[int index]
        {
            get
            {
                return shapesCore.ElementAt(index);
            }
        }
        #endregion

        #region Method
        internal abstract void CreateShapes(string _areaName);


        /// <summary>
        /// 判断闪电是否在形状集内部
        /// </summary>
        /// <param name="_srcStrike"></param>
        /// <returns></returns>
        public bool AddStrikeToShapesWithJudgment(AbstractStrike_Standard _srcStrike)
        {
            foreach (var tmpShape in shapesCore)
            {
                bool srcStrikeInTmpShape = tmpShape.AddStrikeToShapeWithJudgment(_srcStrike);
                if (srcStrikeInTmpShape)
                    return true; // 当前闪电落在任何一个矩形集合中，返回true; 并且不要继续执行;
            }
            return false;
        }


        /// <summary>
        ///计算Ng，需对闪电数据循环判断完毕后有效
        /// </summary>
        public void CalcuNg(double _years)
        {
            years = _years;
            foreach (var squareTmp in shapesCore)
            {
                squareTmp.CalcuNg(_years);
            }
        }


        /// <summary>
        /// 计算范围内各种属性，包括：时分布、月分布、年分布等
        /// </summary>
        public void CalcuTimeDistribution()
        {
            foreach (var squareTmp in shapesCore)
            {
                if (squareTmp.Strikes.Strikes.Any())
                    squareTmp.Strikes.CalcuDistribution();
            }
        }


        /// <summary>
        /// 根据输入的闪电计算总年数
        /// </summary>
        /// <param name="strikes"></param>
        /// <returns></returns>
        public double CalcuYears(List<LightningStrike_Basic> strikes)
        {
            double years;
            DateTime dtStart = strikes.OrderBy(record => record.DateAndTime).Select(record => record.DateAndTime).FirstOrDefault();
            DateTime dtEnd = strikes.OrderByDescending(record => record.DateAndTime).Select(record => record.DateAndTime).FirstOrDefault();
            years = (dtEnd - dtStart).TotalDays / 365;
            return years;
        }


        public void CalcuProbability()
        {
            foreach (var squareTmp in shapesCore)
            {
                squareTmp.Strikes.CalcuProbabilityDistribution();
            }
        }
        #endregion

        #region 析构函数
        //显示实现Dispose接口，避免同时出现Dispose方法和自定义命名方法(Close)
        public void Dispose()
        {
            //释放所有资源
            Dispose(true);
            //避免重复调用Finalize函数
            GC.SuppressFinalize(this);
        }

        //内部Dispose方法，真正试试资源释放工作
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                    shapesCore = new ConcurrentBag<Shape>();
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }

        //在Finalize函数中调用内部的Dispose方法
        ~Shapes()
        {
            //被自动回收是仅释放托管资源，不释放非托管资源
            Dispose(false);
        }

        private bool m_disposed;
        #endregion
    }



    /// <summary>
    /// 正方形合集，功能：输入中心正方形位置、闪电
    /// </summary>
    public class Squares : Shapes, IDisposable
    {
        #region InitiatialMethod
        public Squares(double _longitude, double _latitude, double _boxLengthEachSide, int _boxNumEachSide, string _areaName)
        {
            Square square = new Square(_longitude, _latitude);
            square.Length = _boxLengthEachSide;
            base.centerShape = square;
            boxNumEachSide = _boxNumEachSide;
            boxLengthEachSide = _boxLengthEachSide;
            CreateShapes(_areaName);
        }
        public Squares(double _longitude, double _latitude, double _boxLengthEachSide, int _boxNumEachSide)
        {
            Square square = new Square(_longitude, _latitude);
            square.Length = _boxLengthEachSide;
            base.centerShape = square;
            boxNumEachSide = _boxNumEachSide;
            boxLengthEachSide = _boxLengthEachSide;
            CreateShapes();
        }
        public Squares(Square _centerSquare, int _boxNumEachSide, double _boxLengthEachSide)
        {
            _centerSquare.Length = _boxLengthEachSide;
            base.centerShape = _centerSquare;
            boxLengthEachSide = _boxLengthEachSide;
            CreateShapes();
        }
        public Squares(Square _centerSquare)
        {
            base.centerShape = _centerSquare;
            boxNumEachSide = 9;
            boxLengthEachSide = 3;
            CreateShapes();
        }
        public Squares(double lng, double lat)
        {
            Square _square = new Square(lng, lat);
            base.centerShape = _square;
            boxNumEachSide = 9;
            boxLengthEachSide = 3;
            CreateShapes();
        }
        #endregion

        #region FieldAttribute
        double boxLengthEachSide;
        int boxNumEachSide;

        #endregion

        /// <summary>
        /// 根据已知需求创建squares
        /// </summary>
        internal void CreateShapes()
        {
            CreateShapes(string.Empty);
        }

        /// <summary>
        /// 根据已知需求创建squares
        /// </summary>
        internal override void CreateShapes(string _areaName)
        {
            shapesCore = new ConcurrentBag<Shape>();
            // 左下角格子的中心点经纬度;
            double lngBasic, latBasic;
            //中心点经纬度
            double lngCenter, latCenter;

            latBasic = centerShape.centerPoint.Latitude - boxLengthEachSide * (boxNumEachSide / 2) * Distance.LatitudeDegreeOfPerKm();
            lngBasic = centerShape.centerPoint.Longitude - boxLengthEachSide * (boxNumEachSide / 2) * Distance.LongitudeDegreeOfPerKm(latBasic);

            lngCenter = centerShape.centerPoint.Longitude;
            latCenter = centerShape.centerPoint.Latitude;

            for (int i = 0; i < boxNumEachSide; i++)     // 经度
                for (int j = 0; j < boxNumEachSide; j++) // 纬度
                {
                    double lngTmp, latTmp;

                    latTmp = latBasic + j * boxLengthEachSide * Distance.LatitudeDegreeOfPerKm();
                    lngTmp = lngBasic + i * boxLengthEachSide * Distance.LongitudeDegreeOfPerKm(latTmp);
                    var square = new Square(lngTmp, latTmp);
                    square.Name = _areaName;
                    square.Length = boxLengthEachSide;

                    // 由于地球不是完美球体;  所以需要把内容精确到小数点后3位; 以确保能够实现找到centerShape; 
                    // 尽量避免使用centerShape
                    if (Math.Round(lngTmp, 3) == Math.Round(lngCenter, 3) && Math.Round(latTmp, 3) == Math.Round(latCenter, 3))
                    {
                        this.centerShape = square;
                    }
                    shapesCore.Add(square);
                }
            // int centerShapeIndex = boxNumEachSide * boxNumEachSide / 2;
            // this.centerShape = this[centerShapeIndex];

            wholeShape = new Square(centerShape.centerPoint.Longitude, centerShape.centerPoint.Latitude);
            ((Square)wholeShape).Length = boxLengthEachSide * boxNumEachSide;
        }
    }


    /// <summary>
    /// 圆形合集，功能：存储中心圆形位置、闪电
    /// </summary>
    public class Circles : Shapes, IDisposable
    {
        #region Initiate
        public Circles(Circle _centerCircle)
        {
            centerShape = _centerCircle;
            circlesNumEachSide = 9;
            CreateShapes();
        }
        public Circles(Circle _centerCircle, int _circlesNumEachSide)
        {
            centerShape = _centerCircle;
            circlesNumEachSide = _circlesNumEachSide;
            CreateShapes();
        }
        public Circles(double _centerLongitude, double _centerLatitude, double _r, int _circlesNumEachSide)
        {
            centerShape = new Circle(_centerLongitude, _centerLatitude, _r);
            circlesNumEachSide = _circlesNumEachSide;
            centerR = _r;
            CreateShapes();
        }
        public Circles(double _centerLongitude, double _centerLatitude, double _r, int _circlesNumEachSide, string _areaName)
        {
            centerShape = new Circle(_centerLongitude, _centerLatitude, _r);
            circlesNumEachSide = _circlesNumEachSide;
            centerR = _r;
            CreateShapes();
        }
        #endregion

        #region FieldAttribute
        double centerR = 3;

        public double CenterR
        {
            get { return centerR; }
            set { centerR = value; }
        }
        int circlesNumEachSide = 9;

        public int CirclesNumEachSide
        {
            get { return circlesNumEachSide; }
            set { circlesNumEachSide = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// 根据已知需求创建squares
        /// </summary>
        internal override void CreateShapes(string _areaName)
        {
            shapesCore = new ConcurrentBag<Shape>();
            //左下角格点
            double lngBasic, latBasic;
            latBasic = centerShape.centerPoint.Latitude - centerR * (circlesNumEachSide / 2) * Distance.LatitudeDegreeOfPerKm();
            lngBasic = centerShape.centerPoint.Longitude - centerR * (circlesNumEachSide / 2) * Distance.LongitudeDegreeOfPerKm(latBasic);


            for (int i = 0; i < circlesNumEachSide; i++)//经度
                for (int j = 0; j < circlesNumEachSide; j++)//维度
                {
                    double lngTmp, latTmp;
                    latTmp = latBasic + j * CenterR * Distance.LatitudeDegreeOfPerKm();
                    lngTmp = lngBasic + i * CenterR * Distance.LongitudeDegreeOfPerKm(latTmp);
                    Circle tmpCircle = new Circle(lngTmp, latTmp, centerR);
                    tmpCircle.name = _areaName;
                    shapesCore.Add(tmpCircle);
                }
            int centerShapeIndex = circlesNumEachSide * circlesNumEachSide / 2;
            this.centerShape = this[centerShapeIndex];

            Circle circle = new Circle(centerShape.centerPoint.Longitude, centerShape.centerPoint.Latitude, centerR * circlesNumEachSide);
            wholeShape = circle;
        }
        public void CreateShapes()
        {
            CreateShapes(string.Empty);
        }
        #endregion
    }
}

/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License Desc: https://creativecommons.org/licenses/by-nc-nd/3.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public abstract class Shape : IDisposable
    {
        public Shape()
        {
        }

        public Shape(double lng, double lat)
        {
            centerPoint = new PointLocation();
            centerPoint.Longitude = lng;
            centerPoint.Latitude = lat;
        }

        public Shape(double lng, double lat, double _years)
        {
            centerPoint = new PointLocation();
            centerPoint.Longitude = lng;
            centerPoint.Latitude = lat;
            years = _years;
        }


        #region 变量、属性|Variables
        internal LightningStrikes_Standard strikes_Standard = new LightningStrikes_Standard();
        internal double minLatitude, maxLatitude, minLongitude, maxLongitude;
        internal double size = 0, curAvg = 0, years = 1, ng = 0;
        internal PointLocation centerPoint;
        internal string name;


        public double MaxLongitude
        {
            get { CalcuShapeBorder(); return maxLongitude; }
            set { maxLongitude = value; }
        }

        public double MinLongitude
        {
            get { CalcuShapeBorder(); return minLongitude; }
            set { minLongitude = value; }
        }

        public double MaxLatitude
        {
            get { CalcuShapeBorder(); return maxLatitude; }
            set { maxLatitude = value; }
        }

        public double MinLatitude
        {
            get { CalcuShapeBorder(); return minLatitude; }
            set { minLatitude = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Ng
        {
            get { return ng; }
            set { ng = value; }
        }


        public double Years
        {
            get { return years; }
            set { years = value; }
        }

        /// <summary>
        /// 形状面积；单位：平方公里 | size unit: sq.km
        /// </summary>
        public double Size
        {
            get { return size; }
            set { size = value; }
        }

        public LightningStrikes_Standard Strikes
        {
            get { return strikes_Standard; }
            set { strikes_Standard = value; }
        }

        public PointLocation CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }
        #endregion

        #region 公开函数|public methods
        /// <summary>
        /// 调用此程序后得到size。
        /// </summary>
        public abstract void CalcuSize();

        /// <summary>
        /// 调用此函数来计算经纬度上下限。
        /// </summary>
        public abstract void CalcuShapeBorder();
        public abstract bool AddStrikeToShapeWithJudgment(LightningStrike_Basic _strike);
        public abstract bool AddStrikeToShapeWithJudgment(LightningStrike_Standard _strike);


        //public abstract void AddStrikeToShapeWithJudgment(IEnumerable<IStrike_Standard> _strikes);
        public double CalcuNg(double _years)
        {
            if (_years > 0)
            {
                years = _years;
                Int64 countStrikes = strikes_Standard.Strikes.Count;
                CalcuSize();
                if (size > 0)
                    return ng = countStrikes / size / years;
                else
                    throw new ArgumentOutOfRangeException("size should bigger than 0");
            }
            else
                throw new ArgumentOutOfRangeException("Years should be bigger than 0");
        }

        /// <summary>
        /// 统计雷电主次导方向概率|calcu direction properbility
        /// </summary>
        /// <returns></returns>
        public Dictionary<LightningStrikeDirectionEnum, double> CalcuLightningStrikeDirectionProbabilityDistribution(IEnumerable<LightningStrike_Standard> _strikes)
        {
            if (_strikes.Any())
            {
                Dictionary<LightningStrikeDirectionEnum, double> resultDictionaryList = new Dictionary<LightningStrikeDirectionEnum, double>();
                //北", "东北", "东", "东南", "南", "西南", "西", "西北"
                double resultProbability;
                //遍历整个枚举类型
                foreach (LightningStrikeDirectionEnum item in Enum.GetValues(typeof(LightningStrikeDirectionEnum)))
                {
                    resultProbability = CalcuLightningStrikeDirectionProbability(_strikes, item);
                    resultDictionaryList.Add(item, resultProbability);
                }
                return resultDictionaryList;
            }
            else
                throw new ArgumentNullException("No lightning contained");
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 输入闪电，计算某种方向闪电的概率。概率格式：33.3%|| Calcu property of a lightning
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        private double CalcuLightningStrikeDirectionProbability(IEnumerable<LightningStrike_Standard> _strikes, LightningStrikeDirectionEnum _directionEnum)
        {
            double result = 0;
            int suitedNum = 0;
            int TotalNumber = _strikes.Count();
            foreach (var tmpStrike in _strikes)
            {
                if (_directionEnum == JudgeLightningStrikeDirection(tmpStrike, centerPoint))
                {
                    suitedNum++;
                }
            }
            result = Math.Round((double)suitedNum / (double)TotalNumber * 100, 1);
            return result;

        }
        /// <summary>
        /// 输入一个闪电，判断其对应中心点经纬度 方向|| Get direction of a strike
        /// </summary>
        /// <param name="_strike"></param>
        /// <returns></returns>
        private LightningStrikeDirectionEnum JudgeLightningStrikeDirection(LightningStrike_Standard _strike, PointLocation _centerPoint)
        {
            try
            {
                LightningStrikeDirectionEnum result = new LightningStrikeDirectionEnum();
                double angle = AngleClass.CalcueAngle(_centerPoint.Longitude, _centerPoint.Latitude, _strike.Longitude, _strike.Latitude);
                result = AngleClass.GetLightningStrikeDirection(angle);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 析构函数|Disposer
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
                    strikes_Standard = new LightningStrikes_Standard();
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }

        //在Finalize函数中调用内部的Dispose方法
        ~Shape()
        {
            //被自动回收是仅释放托管资源，不释放非托管资源
            Dispose(false);
        }

        private bool m_disposed;
        #endregion
    }
}

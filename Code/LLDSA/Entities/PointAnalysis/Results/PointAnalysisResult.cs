using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace LLSDA.Entities
{
    /// <summary>
    /// 传输给客户端供显示的内容格式
    /// </summary> 
    public class PointAnalysisResults : CommonAbstractResults, IPointAnalysisResult, IDisposable
    {
        public PointAnalysisResults()
            : base()
        {
            strikesStandard = new List<LightningStrikeStandard>();
            ngList = new List<ResultElement>();
            intensityAvgList = new List<ResultElement>();
        }
        private string pointName;
        private List<ResultElement> ngList, intensityAvgList;
        private Dictionary<LightningStrikeDirectionEnum, double> roseDistribution;
        private LongitudeOrLatitude longitudeInput, latitudeInput;
        private List<LightningStrikeStandard> strikesStandard;

        
        public List<LightningStrikeStandard> Strikes
        {
            get { return strikesStandard; }
            set { strikesStandard = value; }
        }

        
        public LongitudeOrLatitude LatitudeInput
        {
            get { return latitudeInput; }
            set { latitudeInput = value; }
        }

        
        public LongitudeOrLatitude LongitudeInput
        {
            get { return longitudeInput; }
            set { longitudeInput = value; }
        }

        
        public Dictionary<LightningStrikeDirectionEnum, double> RoseDistribution
        {
            get { return roseDistribution; }
            set { roseDistribution = value; }
        }

        
        public string PointName
        {
            get { return pointName; }
            set { pointName = value; }
        }

        
        public List<ResultElement> IntensityAvgList
        {
            get { return intensityAvgList; }
            set { intensityAvgList = value; }
        }

        
        public List<ResultElement> NgList
        {
            get { return ngList; }
            set { ngList = value; }
        }


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
                    strikesStandard = new List<LightningStrikeStandard>();
                    ngList = new List<ResultElement>();
                    intensityAvgList = new List<ResultElement>();
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }

        //在Finalize函数中调用内部的Dispose方法
        ~PointAnalysisResults()
        {
            //被自动回收是仅释放托管资源，不释放非托管资源
            Dispose(false);
        }

        private bool m_disposed;
        #endregion

    }
}

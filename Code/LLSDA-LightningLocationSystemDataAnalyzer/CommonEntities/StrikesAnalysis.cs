/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License Desc: https://creativecommons.org/licenses/by-nc-nd/3.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
* ******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities.CommonEntities
{
    public abstract class StrikesAnalysis : IDisposable
    {
        int curStrike = 1;
        internal Shapes shapes;
        internal Shape centerShape;
        internal string areaName;

        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }

        internal Shape CenterShape
        {
            get { return centerShape; }
            set { centerShape = value; }
        }


        public Shapes Shapes
        {
            get { return shapes; }
            set { shapes = value; }
        }

        public int CurStrike
        {
            get { return curStrike; }
            set { curStrike = value; }
        }

        public abstract void ProcessStrikes(LightningStrike_Basic strike);
        public abstract void ProcessStrikes(LightningStrike_Standard strike);
        public abstract void ProcessStrikes(LightningStrike_China strike);


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
                    shapes.Dispose();
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }

        //在Finalize函数中调用内部的Dispose方法
        ~StrikesAnalysis()
        {
            //被自动回收是仅释放托管资源，不释放非托管资源
            Dispose(false);
        }

        private bool m_disposed;
        #endregion
    }



    public class StrikesAnalysis_Square : StrikesAnalysis, IDisposable
    {
        /// <summary>
        /// 默认每边9个格子，边长5km
        /// </summary>
        /// <param name="_centerLongitude"></param>
        /// <param name="_centerLatitude"></param>
        public StrikesAnalysis_Square(double _centerLongitude, double _centerLatitude)
        {
            shapes = new Squares(_centerLongitude, _centerLatitude, 9, 5);
            this.centerShape = shapes.CenterShape;
        }
        public StrikesAnalysis_Square(double _centerLongitude, double _centerLatitude, double _eachBoxLength, int _eachSideBoxNum, string _areaName)
        {
            shapes = new Squares(_centerLongitude, _centerLatitude, _eachBoxLength, _eachSideBoxNum, _areaName);
            this.centerShape = shapes.CenterShape;

        }
        public StrikesAnalysis_Square(double _centerLongitude, double _centerLatitude, double _eachBoxLength, int _eachSideBoxNum)
        {
            shapes = new Squares(_centerLongitude, _centerLatitude, _eachBoxLength, _eachSideBoxNum);
            this.centerShape = shapes.CenterShape;
        }
        public override void ProcessStrikes(LightningStrike_Basic strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike.ConvertToIStrike_Standard());
        }
        public override void ProcessStrikes(LightningStrike_Standard strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike);
        }
        public override void ProcessStrikes(LightningStrike_China strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike.ConvertToIStrike_Standard());
        }
    }



    public class StrikesAnalysis_Circle : StrikesAnalysis, IDisposable
    {
        /// <summary>
        /// 默认半径3km，每边9个个格子
        /// </summary>
        /// <param name="_centerLongitude"></param>
        /// <param name="_centerLatitude"></param>
        public StrikesAnalysis_Circle(double _centerLongitude, double _centerLatitude)
        {
            shapes = new Circles(_centerLongitude, _centerLatitude, 3, 9);
            this.centerShape = shapes.CenterShape;
        }
        public StrikesAnalysis_Circle(double _centerLongitude, double _centerLatitude, double _r, int _circlesEachSideNum)
        {
            shapes = new Circles(_centerLongitude, _centerLatitude, _r, _circlesEachSideNum);
            this.centerShape = shapes.CenterShape;
        }
        public StrikesAnalysis_Circle(double _centerLongitude, double _centerLatitude, double _r, int _circlesEachSideNum, string _areaName)
        {
            shapes = new Circles(_centerLongitude, _centerLatitude, _r, _circlesEachSideNum, _areaName);
            this.centerShape = shapes.CenterShape;
        }
        public override void ProcessStrikes(LightningStrike_Basic strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike.ConvertToIStrike_Standard());
        }
        public override void ProcessStrikes(LightningStrike_Standard strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike);
        }
        public override void ProcessStrikes(LightningStrike_China strike)
        {
            shapes.AddStrikeToShapesWithJudgment(strike.ConvertToIStrike_Standard());
        }
    }
    
}

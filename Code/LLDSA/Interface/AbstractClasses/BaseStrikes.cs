/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LLSDA.Interface
{
    public abstract class BaseStrikesBasic
    {
        #region Variables&Properties

        internal Int64 sumStrikesNum;
        internal Dictionary<int, int> hourDistribution, monthDistribution, yearDistribution;
        internal string hourDistributionDesc, monthDistributionDesc, yearDistributionDesc;
        internal BaseLightningStrikeDays lightningStrikeDays;
        internal string areaName;
        internal List<int> _yearList;

        IStrikesDistributionStatisticService iStrikesDistributionStatisticService;

        public ConcurrentBag<BaseStrikeBasic> Strikes { get; set; }


        public List<int> YearList
        {
            get { return _yearList; }
            set { _yearList = value; }
        }

        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }
        /// <summary>
        /// 得到雷电日类型，调用此属性前应调用CalcuLightningStrikeDays()方法
        /// </summary>

        public BaseLightningStrikeDays LightningStrikeDays
        {
            get
            {
                return lightningStrikeDays;
            }
            set { lightningStrikeDays = value; }
        }


        public Dictionary<int, int> YearDistribution
        {
            get
            {
                return yearDistribution;
            }
            set { yearDistribution = value; }
        }


        public Dictionary<int, int> MonthDistribution
        {
            get
            {
                return monthDistribution;
            }
            set { monthDistribution = value; }
        }


        public Dictionary<int, int> HourDistribution
        {
            get
            {
                return hourDistribution;
            }
            set { hourDistribution = value; }
        }


        public Int64 SumStrikesNum
        {
            get
            {
                return sumStrikesNum;
            }
            set { sumStrikesNum = value; }
        }


        public string YearDistributionDesc
        {
            get { return yearDistributionDesc; }
            set { yearDistributionDesc = value; }
        }



        public string MonthDistributionDesc
        {
            get { return monthDistributionDesc; }
            set { monthDistributionDesc = value; }
        }


        public string HourDistributionDesc
        {
            get { return hourDistributionDesc; }
            set { hourDistributionDesc = value; }
        }

        public IStrikesDistributionStatisticService IStrikesDistributionStatisticService { get => iStrikesDistributionStatisticService; set => iStrikesDistributionStatisticService = value; }
        #endregion

        /// <summary>
        /// readonly index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public BaseStrikeBasic this[int index]
        {
            get { return Strikes.ElementAt(index); }
        }

        #region PublicMethods
        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public abstract void CalcuDistribution();

        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public abstract void CalcuDistribution(string _areaName);
        #endregion

    }


    public abstract class BaseStrikesStandard: BaseStrikesBasic
    {
        public Int64 SumNumPositive, SumNumNegative;
        public double IntensityPositiveAvg, IntensityNegativeAvg, IntensityAvg, MinNegativeIntensity, MaxNegativeIntensity, MinPositiveIntensity, MaxPositiveIntensity;
        public Dictionary<int, double> ProbabilityDistribution;
        public Dictionary<int, int> MonthDistributionPositive, MonthDistributionNegative, HourDistributionPositive, HourDistributionNegative;
        public String ProbabilityDistributioDisc;

        public new  ConcurrentBag<BaseStrikeStandard> Strikes { get; set; }
        public Dictionary<int, int> YearDistributionPositive { get; set; }
        public Dictionary<int, int> YearDistributionNegative { get; set; }

        /// <summary>
        /// 统计雷电流强度累计概率分布
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<int, double> CalcuProbabilityDistribution();
    }


    public abstract class BaseStrikesChina: BaseStrikesStandard
    {
        public string LightningBulletinDesc;
        public new ConcurrentBag<BaseStrikeChina> Strikes { get; set; }
    }
}

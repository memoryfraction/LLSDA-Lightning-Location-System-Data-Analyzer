/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License Desc: https://creativecommons.org/licenses/by-nc-nd/3.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public class LightningStrikes_Standard
    {
        public LightningStrikes_Standard(IEnumerable<LightningStrike_Standard> _strikes_Standard)
        {
            strikes = new ConcurrentBag<LightningStrike_Standard>();
            foreach (var tmpStrike in _strikes_Standard)
                strikes.Add(tmpStrike);
            CalcuIntensity();
        }

        public LightningStrikes_Standard(IEnumerable<LightningStrike_China> _strikes_China)
        {
            strikes = new ConcurrentBag<LightningStrike_Standard>();
            foreach (var tmpStrike in _strikes_China)
                strikes.Add(tmpStrike);
            CalcuIntensity();
        }

        public LightningStrikes_Standard()
        {
            strikes = new ConcurrentBag<LightningStrike_Standard>();
        }


        #region 变量、属性
        private string hourDistributionDesc, monthDistributionDesc, yearDistributionDesc;
        private LightningStrikeDays lightningStrikeDays;
        private List<int> _yearList;
        private Int64 sumStrikesNum, sumNumPositive, sumNumNegative;
        private double intensityPositiveAvg, intensityNegativeAvg, intensityAvg, maxPositiveIntensity, minPositiveIntensity, maxNegativeIntensity, minNegativeIntensity;
        private string probabilityDistributioDisc, areaName;
        private Dictionary<int, double> probabilityDistribution;
        private Dictionary<int, int> hourDistribution, monthDistribution, yearDistribution, hourDistributionPositive, hourDistributionNegative, monthDistributionPositive, monthDistributionNegative, yearDistributionPositive, yearDistributionNegative;


        ConcurrentBag<LightningStrike_Standard> strikes;


        /// <summary>
        /// 通过new 隐藏父类属性
        /// </summary>
        
        public ConcurrentBag<LightningStrike_Standard> Strikes
        {
            get { return strikes; }
            set { strikes = value; }
        }

        
        public double MinNegativeIntensity
        {
            get
            {
                return minNegativeIntensity;
            }
            set { minNegativeIntensity = value; }
        }

        
        public double MaxNegativeIntensity
        {
            get { return maxNegativeIntensity; }
            set { maxNegativeIntensity = value; }
        }

        
        public double MinPositiveIntensity
        {
            get { return minPositiveIntensity; }
            set { minPositiveIntensity = value; }
        }

        
        public double MaxPositiveIntensity
        {
            get { return maxPositiveIntensity; }
            set { maxPositiveIntensity = value; }
        }

        
        public Dictionary<int, int> YearDistributionNegative
        {
            get { return yearDistributionNegative; }
            set { yearDistributionNegative = value; }
        }
        
        public Dictionary<int, int> YearDistributionPositive
        {
            get { return yearDistributionPositive; }
            set { yearDistributionPositive = value; }
        }
        
        public Dictionary<int, int> MonthDistributionNegative
        {
            get { return monthDistributionNegative; }
            set { monthDistributionNegative = value; }
        }
        
        public Dictionary<int, int> MonthDistributionPositive
        {
            get { return monthDistributionPositive; }
            set { monthDistributionPositive = value; }
        }
        
        public Dictionary<int, int> HourDistributionNegative
        {
            get { return hourDistributionNegative; }
            set { hourDistributionNegative = value; }
        }
        
        public Dictionary<int, int> HourDistributionPositive
        {
            get { return hourDistributionPositive; }
            set { hourDistributionPositive = value; }
        }
        
        public Dictionary<int, double> ProbabilityDistribution
        {
            get { return probabilityDistribution; }
            set { probabilityDistribution = value; }
        }
        
        public string ProbabilityDistributioDisc
        {
            get { return probabilityDistributioDisc; }
            set { probabilityDistributioDisc = value; }
        }
        
        public Int64 SumNumNegative
        {
            get { return sumNumNegative; }
            set { sumNumNegative = value; }
        }
        
        public Int64 SumNumPositive
        {
            get { return sumNumPositive; }
            set { sumNumPositive = value; }
        }
        
        public double IntensityAvg
        {
            get { return intensityAvg; }
            set { intensityAvg = value; }
        }
        
        public double IntensityNegativeAvg
        {
            get { return intensityNegativeAvg; }
            set { intensityNegativeAvg = value; }
        }
        
        public double IntensityPositiveAvg
        {
            get { return intensityPositiveAvg; }
            set { intensityPositiveAvg = value; }
        }
        
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
        public LightningStrikeDays LightningStrikeDays
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
                sumStrikesNum = strikes.Count;
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
        /// <summary>
        /// 希望隐藏父类的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns> 
        public LightningStrike_Standard this[int index]
        {
            get
            {
                return strikes.ElementAt(index);
            }
        }
        #endregion


        #region 私有方法
        /// <summary>
        /// 计算总闪击、总正闪、总负闪、平均强度正闪、平均强度负闪、强度平均绝对值
        /// </summary>
        private void CalcuIntensity()
        {
            sumNumPositive = StrikesDistributionStatistic.CalcuPositiveSumNum(strikes);
            sumNumNegative = StrikesDistributionStatistic.CalcuPositiveSumNum(strikes);
            intensityPositiveAvg = StrikesDistributionStatistic.CalcuPositiveAvgIntensity(strikes);
            intensityNegativeAvg = StrikesDistributionStatistic.CalcuNegativeAvgIntensity(strikes);
            intensityAvg = StrikesDistributionStatistic.CalcuAbsAvgIntensity(strikes);
        }
        #endregion


        #region PublicMethods
        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public void CalcuDistribution(IEnumerable<LightningStrike_Standard> _strikes, string _areaName)
        {
            if (_strikes.Any())
            {
                //年分布
                yearDistribution = StrikesDistributionStatistic.CalcuYearDistribution(_strikes);
                yearDistributionPositive = StrikesDistributionStatistic.CalcuYearDistributionPositive(_strikes);
                yearDistributionNegative = StrikesDistributionStatistic.CalcuYearDistributionNegative(_strikes);
                yearDistributionDesc = StrikesDistributionStatistic.GenerateYearDistributionText(_strikes);
                //月分布
                monthDistribution = StrikesDistributionStatistic.CalcuMonthDistribution(_strikes);
                monthDistributionPositive = StrikesDistributionStatistic.CalcuMonthDistributionPosive(_strikes);
                monthDistributionNegative = StrikesDistributionStatistic.CalcuMonthDistributionNegative(_strikes);
                monthDistributionDesc = StrikesDistributionStatistic.GenerateMonthDistributionText(_strikes);
                //时分布
                hourDistribution = StrikesDistributionStatistic.CalcuHourDistribution(_strikes);
                hourDistributionPositive = StrikesDistributionStatistic.CalcuHourDistribution_Positive(_strikes);
                hourDistributionNegative = StrikesDistributionStatistic.CalcuHourDistribution_Negative(_strikes);
                hourDistributionDesc = StrikesDistributionStatistic.GenerateHourDistributionText(_strikes);
                //统计各类总数
                sumStrikesNum = StrikesDistributionStatistic.CalcuSumNum(_strikes);
                sumNumPositive = StrikesDistributionStatistic.CalcuPositiveSumNum(_strikes);
                sumNumNegative = StrikesDistributionStatistic.CalcuNegativeSumNum(_strikes);
                minNegativeIntensity = StrikesDistributionStatistic.CalcuMinNegativeIntensity(_strikes);
                maxNegativeIntensity = StrikesDistributionStatistic.CalcuMaxNegativeIntensity(_strikes);
                minPositiveIntensity = StrikesDistributionStatistic.CalcuMinPositiveIntensity(_strikes);
                maxPositiveIntensity = StrikesDistributionStatistic.CalcuMaxPositiveIntensity(_strikes);

                // 雷电流强度
                try
                {
                    intensityAvg = StrikesDistributionStatistic.CalcuAbsAvgIntensity(_strikes);
                }
                catch
                {
                    throw;
                }
                try
                {
                    intensityPositiveAvg = StrikesDistributionStatistic.CalcuPositiveAvgIntensity(_strikes);
                }
                catch
                {
                    throw;
                }
                try
                {
                    intensityNegativeAvg = StrikesDistributionStatistic.CalcuNegativeAvgIntensity(_strikes);
                }
                catch
                {
                    throw;
                }

                //yearList
                _yearList = StrikesDistributionStatistic.CalcuYearList(_strikes);
                //雷电流累计概率分布
                probabilityDistribution = StrikesDistributionStatistic.CalcuProbabilityDistribution(_strikes);
                probabilityDistributioDisc = StrikesDistributionStatistic.GenerateProbabilityDistributionText(_strikes);
                //雷电日
                lightningStrikeDays = StrikesDistributionStatistic.GetLightningStrikesDays(_strikes, _areaName);
            }
            else
                throw new ArgumentNullException("LightningStrikes_Standard中统计各属性的计算，序列中不包含任何闪电。");
        }


        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public void CalcuDistribution(IEnumerable<LightningStrike_Standard> _strikes)
        {
            CalcuDistribution(_strikes, string.Empty);
        }


        /// <summary>
        /// 统计雷电流强度累计概率分布
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, double> CalcuProbabilityDistribution()
        {
            probabilityDistribution = StrikesDistributionStatistic.CalcuProbabilityDistribution(strikes);
            return probabilityDistribution;
        }
        #endregion


        public override string ToString()
        {
            return "areaName: " + this.AreaName.ToString() + "\r\n"
                + "sumStrikesNum: " + this.sumStrikesNum.ToString() + "\r\n"
                + "hourDistributionDesc" + this.HourDistributionDesc.ToString() + "\r\n"
                + "monthDistributionDesc" + this.MonthDistributionDesc.ToString() + "\r\n"
                 + "yearDistributionDesc" + this.YearDistributionDesc.ToString() + "\r\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LightningStrike_Standard))
                return false;
            else
            {
                LightningStrikes_Standard o = new LightningStrikes_Standard();
                o = (LightningStrikes_Standard)obj;
                foreach (var tmp in o.strikes)
                {
                    if (!this.strikes.Contains(tmp))
                        return false;
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            return 17 * this.strikes.GetHashCode()
                + 19 * this.areaName.GetHashCode();
        }
    }
}

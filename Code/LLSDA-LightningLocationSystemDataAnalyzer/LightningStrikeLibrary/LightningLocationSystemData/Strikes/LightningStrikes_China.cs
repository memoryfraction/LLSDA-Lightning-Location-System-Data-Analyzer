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
    public class LightningStrikes_China
    {
        public LightningStrikes_China(IEnumerable<LightningStrike_China> _strikes_China)
        {
            foreach (var tmpStrike in _strikes_China)
                strikes.Add(tmpStrike);
        }
        public LightningStrikes_China()
        { }


        #region 变量、属性 || VARIABLES
        ConcurrentBag<LightningStrike_China> strikes = new ConcurrentBag<LightningStrike_China>();
        AdministrativeLevel administrativeLevel;
        Dictionary<string, int> districtDistribution;
        string districtDistributionDesc;

        private string hourDistributionDesc, monthDistributionDesc, yearDistributionDesc, lightningBulletinDesc;


        private LightningStrikeDays lightningStrikeDays;
        private List<int> _yearList;
        private Int64 sumStrikesNum, sumNumPositive, sumNumNegative;
        private double intensityPositiveAvg, intensityNegativeAvg, intensityAvg, maxPositiveIntensity, minPositiveIntensity, maxNegativeIntensity, minNegativeIntensity;
        private string probabilityDistributioDisc, areaName;
        private Dictionary<int, double> probabilityDistribution;
        private Dictionary<int, int> hourDistribution, monthDistribution, yearDistribution, hourDistributionPositive, hourDistributionNegative, monthDistributionPositive, monthDistributionNegative, yearDistributionPositive, yearDistributionNegative;

        /// <summary>
        /// 雷电公报文字描述||lightning Bulletin Description
        /// </summary>
        
        public string LightningBulletinDesc
        {
            get { return lightningBulletinDesc; }
            set { lightningBulletinDesc = value; }
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

        
        public Dictionary<string, int> DistrictDistribution
        {
            get
            {

                return districtDistribution;
            }
            set { districtDistribution = value; }
        }

        
        public string DistrictDistributionDesc
        {
            get { return districtDistributionDesc; }
            set { districtDistributionDesc = value; }
        }


        
        public AdministrativeLevel AdministrativeLevel
        {
            get { return administrativeLevel; }
            set { administrativeLevel = value; }
        }

        
        public ConcurrentBag<LightningStrike_China> Strikes
        {
            get { return strikes; }
            set { strikes = value; }
        }
        #endregion


        /// <summary>
        /// 隐藏父类索引器|| hide parent class index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LightningStrike_China this[int index]
        {
            get
            {
                if (strikes.Any())
                    return strikes.ElementAt(index);
                else
                    return null;
            }
        }

        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作|| statistic methods, time consuming methods
        /// </summary>
        public void CalcuDistribution(IEnumerable<LightningStrike_China> _strikes, string _areaName)
        {
            if (_strikes.Any())
            {
                //年分布
                yearDistribution = StrikesDistributionStatistic.CalcuYearDistribution(strikes);
                yearDistributionPositive = StrikesDistributionStatistic.CalcuYearDistributionPositive(strikes);
                yearDistributionNegative = StrikesDistributionStatistic.CalcuYearDistributionNegative(strikes);
                yearDistributionDesc = StrikesDistributionStatistic.GenerateYearDistributionText(strikes);
                //月分布
                monthDistribution = StrikesDistributionStatistic.CalcuMonthDistribution(strikes);
                monthDistributionPositive = StrikesDistributionStatistic.CalcuMonthDistributionPosive(strikes);
                monthDistributionNegative = StrikesDistributionStatistic.CalcuMonthDistributionNegative(strikes);
                monthDistributionDesc = StrikesDistributionStatistic.GenerateMonthDistributionText(strikes);
                //时分布
                hourDistribution = StrikesDistributionStatistic.CalcuHourDistribution(strikes);
                hourDistributionPositive = StrikesDistributionStatistic.CalcuHourDistribution_Positive(strikes);
                hourDistributionNegative = StrikesDistributionStatistic.CalcuHourDistribution_Negative(strikes);
                hourDistributionDesc = StrikesDistributionStatistic.GenerateHourDistributionText(strikes);
                //统计各类总数
                sumStrikesNum = StrikesDistributionStatistic.CalcuSumNum(strikes);
                sumNumPositive = StrikesDistributionStatistic.CalcuPositiveSumNum(strikes);
                sumNumNegative = StrikesDistributionStatistic.CalcuNegativeSumNum(strikes);
                minNegativeIntensity = StrikesDistributionStatistic.CalcuMinNegativeIntensity(strikes);
                maxNegativeIntensity = StrikesDistributionStatistic.CalcuMaxNegativeIntensity(strikes);
                minPositiveIntensity = StrikesDistributionStatistic.CalcuMinPositiveIntensity(strikes);
                maxPositiveIntensity = StrikesDistributionStatistic.CalcuMaxPositiveIntensity(strikes);

                //统计雷电流强度
                try
                {
                    intensityAvg = StrikesDistributionStatistic.CalcuAbsAvgIntensity(_strikes);
                }
                catch
                {
                    intensityAvg = 0;
                }
                try
                {
                    intensityPositiveAvg = StrikesDistributionStatistic.CalcuPositiveAvgIntensity(_strikes);
                }
                catch
                {
                    intensityPositiveAvg = 0;
                }
                try
                {
                    intensityNegativeAvg = StrikesDistributionStatistic.CalcuNegativeAvgIntensity(_strikes);
                }
                catch
                {
                    intensityNegativeAvg = 0;
                }

                //yearList
                _yearList = StrikesDistributionStatistic.CalcuYearList(strikes);
                //雷电流累计概率分布
                probabilityDistribution = StrikesDistributionStatistic.CalcuProbabilityDistribution(strikes);
                probabilityDistributioDisc = StrikesDistributionStatistic.GenerateProbabilityDistributionText(strikes);
                //地区分布
                districtDistribution = StrikesDistributionStatistic.ProcessAreaDistribution(strikes, administrativeLevel);
                districtDistributionDesc = StrikesDistributionStatistic.ProcessLightningBulletinDesc(strikes);
                //雷电日
                lightningStrikeDays = StrikesDistributionStatistic.GetLightningStrikesDays(strikes, _areaName);

                //雷电公报文字描述
                lightningBulletinDesc = StrikesDistributionStatistic.ProcessLightningBulletinDesc(strikes);
            }
            else
                throw new ArgumentNullException("LightningStrikes_China中统计各属性的计算，序列中不包含任何闪电。");
        }



        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public void CalcuDistribution(IEnumerable<LightningStrike_China> _strikes)
        {
            CalcuDistribution(_strikes, string.Empty);
        }

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
            if (obj == null || !(obj is LightningStrikes_China))
                return false;
            else
            {
                LightningStrikes_China o = new LightningStrikes_China();
                o = (LightningStrikes_China)obj;
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

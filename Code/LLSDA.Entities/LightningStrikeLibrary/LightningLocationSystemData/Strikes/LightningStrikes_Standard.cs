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
    public class LightningStrikes_Standard: AbstractStrikes_Standard
    {

        public LightningStrikes_Standard(IEnumerable<AbstractStrike_Standard> _strikes_Standard, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            Strikes = new ConcurrentBag<AbstractStrike_Standard>();
            foreach (var tmpStrike in _strikes_Standard)
                Strikes.Add(tmpStrike);
            CalcuIntensity();
        }

        public LightningStrikes_Standard(IEnumerable<LightningStrike_China> _strikes_China, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            Strikes = new ConcurrentBag<AbstractStrike_Standard>();
            foreach (var tmpStrike in _strikes_China)
                Strikes.Add(tmpStrike);
            CalcuIntensity();
        }

        public LightningStrikes_Standard(IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            Strikes = new ConcurrentBag<AbstractStrike_Standard>();
        }

        public LightningStrikes_Standard()
        {
            Strikes = new ConcurrentBag<AbstractStrike_Standard>();
        }



        #region 私有方法
        /// <summary>
        /// 计算总闪击、总正闪、总负闪、平均强度正闪、平均强度负闪、强度平均绝对值
        /// </summary>
        private void CalcuIntensity()
        {
            if(IStrikesDistributionStatisticService != null)
            { 
                SumNumPositive = IStrikesDistributionStatisticService.CalcuPositiveSumNum(Strikes);
                SumNumNegative = IStrikesDistributionStatisticService.CalcuPositiveSumNum(Strikes);
                IntensityPositiveAvg = IStrikesDistributionStatisticService.CalcuPositiveAvgIntensity(Strikes);
                IntensityNegativeAvg = IStrikesDistributionStatisticService.CalcuNegativeAvgIntensity(Strikes);
                IntensityAvg = IStrikesDistributionStatisticService.CalcuAbsAvgIntensity(Strikes);
            }
        }
        #endregion


        #region PublicMethods
        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public override void CalcuDistribution(string _areaName)
        {
            if (Strikes.Any() & IStrikesDistributionStatisticService!=null)
            {
                //年分布
                YearDistribution = IStrikesDistributionStatisticService.CalcuYearDistribution(Strikes);
                YearDistributionPositive = IStrikesDistributionStatisticService.CalcuYearDistributionPositive(Strikes);
                YearDistributionNegative = IStrikesDistributionStatisticService.CalcuYearDistributionNegative(Strikes);
                YearDistributionDesc = IStrikesDistributionStatisticService.GenerateYearDistributionText(Strikes);
                //月分布
                MonthDistribution = IStrikesDistributionStatisticService.CalcuMonthDistribution(Strikes);
                MonthDistributionPositive = IStrikesDistributionStatisticService.CalcuMonthDistributionPosive(Strikes);
                MonthDistributionNegative = IStrikesDistributionStatisticService.CalcuMonthDistributionNegative(Strikes);
                MonthDistributionDesc = IStrikesDistributionStatisticService.GenerateMonthDistributionText(Strikes);
                //时分布
                HourDistribution = IStrikesDistributionStatisticService.CalcuHourDistribution(Strikes);
                HourDistributionPositive = IStrikesDistributionStatisticService.CalcuHourDistribution_Positive(Strikes);
                HourDistributionNegative = IStrikesDistributionStatisticService.CalcuHourDistribution_Negative(Strikes);
                HourDistributionDesc = IStrikesDistributionStatisticService.GenerateHourDistributionText(Strikes);
                //统计各类总数
                SumStrikesNum = IStrikesDistributionStatisticService.CalcuSumNum(Strikes);
                SumNumPositive = IStrikesDistributionStatisticService.CalcuPositiveSumNum(Strikes);
                SumNumNegative = IStrikesDistributionStatisticService.CalcuNegativeSumNum(Strikes);
                MinNegativeIntensity = IStrikesDistributionStatisticService.CalcuMinNegativeIntensity(Strikes);
                MaxNegativeIntensity = IStrikesDistributionStatisticService.CalcuMaxNegativeIntensity(Strikes);
                MinPositiveIntensity = IStrikesDistributionStatisticService.CalcuMinPositiveIntensity(Strikes);
                MaxPositiveIntensity = IStrikesDistributionStatisticService.CalcuMaxPositiveIntensity(Strikes);

                // 雷电流强度
                IntensityAvg = IStrikesDistributionStatisticService.CalcuAbsAvgIntensity(Strikes);
                IntensityPositiveAvg = IStrikesDistributionStatisticService.CalcuPositiveAvgIntensity(Strikes);
                IntensityNegativeAvg = IStrikesDistributionStatisticService.CalcuNegativeAvgIntensity(Strikes);

                //yearList
                YearList = IStrikesDistributionStatisticService.CalcuYearList(Strikes);
                //雷电流累计概率分布
                ProbabilityDistribution = IStrikesDistributionStatisticService.CalcuProbabilityDistribution(Strikes);
                ProbabilityDistributioDisc = IStrikesDistributionStatisticService.GenerateProbabilityDistributionText(Strikes);
                //雷电日
                LightningStrikeDays = IStrikesDistributionStatisticService.GetLightningStrikesDays(Strikes, _areaName);
            }
        }


        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public override void CalcuDistribution()
        {
            CalcuDistribution(string.Empty);
        }


        /// <summary>
        /// 统计雷电流强度累计概率分布
        /// </summary>
        /// <returns></returns>
        public override Dictionary<int, double> CalcuProbabilityDistribution()
        {
            ProbabilityDistribution = IStrikesDistributionStatisticService.CalcuProbabilityDistribution(Strikes);
            return ProbabilityDistribution;
        }
        #endregion


        public override string ToString()
        {
            return "areaName: " + this.AreaName.ToString() + "\r\n"
                + "sumStrikesNum: " + this.SumStrikesNum.ToString() + "\r\n"
                + "hourDistributionDesc" + this.HourDistributionDesc.ToString() + "\r\n"
                + "monthDistributionDesc" + this.MonthDistributionDesc.ToString() + "\r\n"
                 + "yearDistributionDesc" + this.YearDistributionDesc.ToString() + "\r\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AbstractStrike_Standard))
                return false;
            else
            {
                LightningStrikes_Standard o = new LightningStrikes_Standard();
                o = (LightningStrikes_Standard)obj;
                foreach (var tmp in o.Strikes)
                {
                    if (!this.Strikes.Contains(tmp))
                        return false;
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            return 17 * this.Strikes.GetHashCode()
                + 19 * this.AreaName.GetHashCode();
        }
    }
}

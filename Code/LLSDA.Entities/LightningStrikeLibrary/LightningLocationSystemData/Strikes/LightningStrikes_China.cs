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
    public class LightningStrikes_China: AbstractStrikes_China
    {
        public LightningStrikes_China(IEnumerable<LightningStrike_China> _strikes_China, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            foreach (var tmpStrike in _strikes_China)
                Strikes.Add(tmpStrike);
        }
        public LightningStrikes_China(IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
        }
        public LightningStrikes_China()
        { }


        #region PublicMethods
        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public override void CalcuDistribution(string _areaName)
        {
            if (Strikes.Any() & IStrikesDistributionStatisticService != null)
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



        ///// <summary>
        ///// 统计本类目下所有相关属性，耗时操作|| statistic methods, time consuming methods
        ///// </summary>
        //public void CalcuDistribution(IEnumerable<LightningStrike_China> _strikes, string _areaName)
        //{
        //    if (_strikes.Any())
        //    {
        //        //年分布
        //        yearDistribution = StrikesDistributionStatistic.CalcuYearDistribution(strikes);
        //        yearDistributionPositive = StrikesDistributionStatistic.CalcuYearDistributionPositive(strikes);
        //        yearDistributionNegative = StrikesDistributionStatistic.CalcuYearDistributionNegative(strikes);
        //        yearDistributionDesc = StrikesDistributionStatistic.GenerateYearDistributionText(strikes);
        //        //月分布
        //        monthDistribution = StrikesDistributionStatistic.CalcuMonthDistribution(strikes);
        //        monthDistributionPositive = StrikesDistributionStatistic.CalcuMonthDistributionPosive(strikes);
        //        monthDistributionNegative = StrikesDistributionStatistic.CalcuMonthDistributionNegative(strikes);
        //        monthDistributionDesc = StrikesDistributionStatistic.GenerateMonthDistributionText(strikes);
        //        //时分布
        //        hourDistribution = StrikesDistributionStatistic.CalcuHourDistribution(strikes);
        //        hourDistributionPositive = StrikesDistributionStatistic.CalcuHourDistribution_Positive(strikes);
        //        hourDistributionNegative = StrikesDistributionStatistic.CalcuHourDistribution_Negative(strikes);
        //        hourDistributionDesc = StrikesDistributionStatistic.GenerateHourDistributionText(strikes);
        //        //统计各类总数
        //        sumStrikesNum = StrikesDistributionStatistic.CalcuSumNum(strikes);
        //        sumNumPositive = StrikesDistributionStatistic.CalcuPositiveSumNum(strikes);
        //        sumNumNegative = StrikesDistributionStatistic.CalcuNegativeSumNum(strikes);
        //        minNegativeIntensity = StrikesDistributionStatistic.CalcuMinNegativeIntensity(strikes);
        //        maxNegativeIntensity = StrikesDistributionStatistic.CalcuMaxNegativeIntensity(strikes);
        //        minPositiveIntensity = StrikesDistributionStatistic.CalcuMinPositiveIntensity(strikes);
        //        maxPositiveIntensity = StrikesDistributionStatistic.CalcuMaxPositiveIntensity(strikes);

        //        //统计雷电流强度
        //        try
        //        {
        //            intensityAvg = StrikesDistributionStatistic.CalcuAbsAvgIntensity(_strikes);
        //        }
        //        catch
        //        {
        //            intensityAvg = 0;
        //        }
        //        try
        //        {
        //            intensityPositiveAvg = StrikesDistributionStatistic.CalcuPositiveAvgIntensity(_strikes);
        //        }
        //        catch
        //        {
        //            intensityPositiveAvg = 0;
        //        }
        //        try
        //        {
        //            intensityNegativeAvg = StrikesDistributionStatistic.CalcuNegativeAvgIntensity(_strikes);
        //        }
        //        catch
        //        {
        //            intensityNegativeAvg = 0;
        //        }

        //        //yearList
        //        _yearList = StrikesDistributionStatistic.CalcuYearList(strikes);
        //        //雷电流累计概率分布
        //        probabilityDistribution = StrikesDistributionStatistic.CalcuProbabilityDistribution(strikes);
        //        probabilityDistributioDisc = StrikesDistributionStatistic.GenerateProbabilityDistributionText(strikes);
        //        //地区分布
        //        districtDistribution = StrikesDistributionStatistic.ProcessAreaDistribution(strikes, administrativeLevel);
        //        districtDistributionDesc = StrikesDistributionStatistic.ProcessLightningBulletinDesc(strikes);
        //        //雷电日
        //        lightningStrikeDays = StrikesDistributionStatistic.GetLightningStrikesDays(strikes, _areaName);

        //        //雷电公报文字描述
        //        lightningBulletinDesc = StrikesDistributionStatistic.ProcessLightningBulletinDesc(strikes);
        //    }
        //    else
        //        throw new ArgumentNullException("LightningStrikes_China中统计各属性的计算，序列中不包含任何闪电。");
        //}



        ///// <summary>
        ///// 统计本类目下所有相关属性，耗时操作
        ///// </summary>
        //public void CalcuDistribution(IEnumerable<LightningStrike_China> _strikes)
        //{
        //    CalcuDistribution(_strikes, string.Empty);
        //}
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
            if (obj == null || !(obj is LightningStrikes_China))
                return false;
            else
            {
                LightningStrikes_China o = new LightningStrikes_China();
                o = (LightningStrikes_China)obj;
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

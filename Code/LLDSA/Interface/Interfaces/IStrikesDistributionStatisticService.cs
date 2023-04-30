/*****************************************************************
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using LLSDA.Entities;
using System;
using System.Collections.Generic;

namespace LLSDA.Interface
{
    /// <summary>
    /// Statistic methods for lightning strikes
    /// </summary>
    public interface IStrikesDistributionStatisticService
    {
        #region 年分布
        Dictionary<int, int> CalcuYearDistribution(IEnumerable<BaseStrikeBasic> _strikes);

        /// <summary>
        /// 统计雷电的年份
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        List<int> CalcuYearList(IEnumerable<BaseStrikeBasic> _strikes);

        /// <summary>
        /// 计算正闪年分布情况，耗时操作。
        /// </summary>
        Dictionary<int, int> CalcuYearDistributionPositive(IEnumerable<BaseStrikeCompactEdition> _strikes);

        /// <summary>
        /// 计算负闪年分布情况，耗时操作。
        /// </summary>
        Dictionary<int, int> CalcuYearDistributionNegative(IEnumerable<BaseStrikeCompactEdition> _strikes);
        #endregion


        #region 月分布
        /// 月分布
        /// <summary>
        /// 统计月份分布情况，耗时操作。
        /// </summary>
        Dictionary<int, int> CalcuMonthDistribution(IEnumerable<BaseStrikeBasic> _strikes);


        /// <summary>
        /// 统计正闪月份分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<int, int> CalcuMonthDistributionPosive(IEnumerable<BaseStrikeStandard> _strikes);


        /// <summary>
        /// 统计正闪月份分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<int, int> CalcuMonthDistributionNegative(IEnumerable<BaseStrikeStandard> _strikes);
        #endregion


        #region 时分布
        //时分布
        /// <summary>
        /// 统计时间分布情况，耗时操作。
        /// </summary>
        Dictionary<int, int> CalcuHourDistribution(IEnumerable<BaseStrikeBasic> _strikes);

        /// <summary>
        /// 统计正闪时间分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<int, int> CalcuHourDistribution_Positive(IEnumerable<BaseStrikeStandard> _strikes);


        /// <summary>
        /// 统计负闪时间分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<int, int> CalcuHourDistribution_Negative(IEnumerable<BaseStrikeStandard> _strikes);
        #endregion


        #region 雷电流累计概率分布

        /// <summary>
        /// 为probabilityDistribution赋值
        /// </summary>
        Dictionary<int, double> CalcuProbabilityDistribution(IEnumerable<BaseStrikeStandard> _strikes);

        #endregion


        #region 文字描述
        //文字描述
        //生成年分布文字描述
        string GenerateYearDistributionText(IEnumerable<BaseStrikeBasic> _strikes);

        /// <summary>
        /// 生成HourDistributionText
        /// </summary>
        string GenerateHourDistributionText(IEnumerable<BaseStrikeBasic> _strikes);

        /// <summary>
        /// 生成MonthDistributionText
        /// </summary>
        string GenerateMonthDistributionText(IEnumerable<BaseStrikeBasic> _strikes);


        /// <summary>
        /// 生成ProbabilityDistributionText
        /// </summary>
        string GenerateProbabilityDistributionText(IEnumerable<BaseStrikeStandard> _strikes);

        #endregion


        #region 雷电流强度区间概率
        //雷电流强度区间概率
        /// <summary>
        /// 统计雷电流强度区间概率
        /// </summary>
        Dictionary<string, double> CalcuIntensityProbabilityDistribution(IEnumerable<BaseStrikeStandard> _strikes);

        /// <summary>
        /// 统计正闪雷电流强度区间概率
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<string, double> CalcuIntensityProbabilityDistributionPositive(IEnumerable<BaseStrikeStandard> _strikes);

        /// <summary>
        /// 统计负闪雷电流强度区间概率
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<string, double> CalcuIntensityProbabilityDistributionNegative(IEnumerable<BaseStrikeStandard> _strikes);
        #endregion


        #region 雷电日
        //雷电日
        /// <summary>
        /// 计算平均年雷电日并返回
        /// </summary>
        double GetLightningDaysPerYear(IEnumerable<BaseStrikeBasic> _strikes, double _years);

        /// <summary>
        /// 输入指定信息，根据LLS数据统计雷电日信息。
        /// </summary>
        /// <returns></returns>
        BaseLightningStrikeDays GetLightningStrikesDays(IEnumerable<BaseStrikeBasic> _strikes, string _administrativeRegionName);
        #endregion


        #region 最大、最小雷电流强度、数量
        double CalcuMaxPositiveIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuMinPositiveIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuMaxNegativeIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuMinNegativeIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuPositiveAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuNegativeAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuAbsAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuAbsMinIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        double CalcuAbsMaxIntensity(IEnumerable<BaseStrikeStandard> _strikes);
        Int64 CalcuPositiveSumNum(IEnumerable<BaseStrikeStandard> _strikes);
        Int64 CalcuNegativeSumNum(IEnumerable<BaseStrikeStandard> _strikes);
        Int64 CalcuSumNum(IEnumerable<BaseStrikeBasic> _strikes);
        #endregion


        #region 地区分布
        /// <summary>
        /// 处理雷电公报的描述,需要在计算完雷电日以后再提出
        /// </summary>
        /// <returns></returns>
        string ProcessLightningBulletinDesc(IEnumerable<BaseStrikeChina> _strikes, string _administrativeRegionName);

        /// <summary>
        /// 处理雷电公报的描述,需要在计算完雷电日以后再提出
        /// </summary>
        /// <returns></returns>
        string ProcessLightningBulletinDesc(IEnumerable<BaseStrikeChina> _strikes);

        /// <summary>
        /// 计算下级地区闪电分布情况。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        Dictionary<string, int> ProcessAreaDistribution(IEnumerable<BaseStrikeChina> _strikes, AdministrativeLevel _administrativeLevelEnum);


        #endregion


        #region 雷电玫瑰图，暂被注释，因为包含经纬度信息，不应该出现在这里。
        Dictionary<LightningStrikeDirectionEnum, double> CalcuLightningStrikeDirectionProbabilityDistribution(IEnumerable<BaseStrikeStandard> _strikes);
        #endregion


        #region Ng
        /// <summary>
        /// 计算Ng值
        /// </summary>
        /// <param name="strikesNumber"></param>
        /// <param name="size"></param>
        /// <param name="yearNum"></param>
        /// <returns></returns>
        double CalcuNg(long strikesNumber, double size, double yearNum);
        #endregion
    }
}

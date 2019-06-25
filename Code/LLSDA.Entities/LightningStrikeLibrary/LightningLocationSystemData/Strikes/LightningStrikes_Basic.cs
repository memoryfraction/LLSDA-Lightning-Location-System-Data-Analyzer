/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using LLSDA.Entities;
using LLSDA.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public class LightningStrikes_Basic: BaseStrikesBasic
    {
        #region 构造函数
        public LightningStrikes_Basic(IEnumerable<BaseStrikeBasic> _lightningStrikes_Basic, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            foreach (var tmpStrike in _lightningStrikes_Basic)
                Strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic(IEnumerable<BaseStrikeStandard> _lightningStrikes_Standard, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            foreach (var tmpStrike in _lightningStrikes_Standard)
                Strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic(IEnumerable<BaseStrikeChina> _lightningStrikes_China, IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
            foreach (var tmpStrike in _lightningStrikes_China)
                Strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic(IStrikesDistributionStatisticService _iStrikesDistributionStatisticService)
        {
            IStrikesDistributionStatisticService = _iStrikesDistributionStatisticService;
        }
        public LightningStrikes_Basic()
        { }
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


        #region 公开方法
        /// <summary>
        /// 统计本类目下所有相关属性，耗时操作
        /// </summary>
        public override void CalcuDistribution(string _areaName)
        {
            if (Strikes.Any() & IStrikesDistributionStatisticService != null)
            {
                //年分布
                YearDistribution = IStrikesDistributionStatisticService.CalcuYearDistribution(Strikes);
                YearDistributionDesc = IStrikesDistributionStatisticService.GenerateYearDistributionText(Strikes);

                //月分布
                MonthDistribution = IStrikesDistributionStatisticService.CalcuMonthDistribution(Strikes);
                MonthDistributionDesc = IStrikesDistributionStatisticService.GenerateMonthDistributionText(Strikes);
                //时分布
                HourDistribution = IStrikesDistributionStatisticService.CalcuHourDistribution(Strikes);
                HourDistributionDesc = IStrikesDistributionStatisticService.GenerateHourDistributionText(Strikes);
                //统计各类总数
                SumStrikesNum = IStrikesDistributionStatisticService.CalcuSumNum(Strikes);
                //yearList
                YearList = IStrikesDistributionStatisticService.CalcuYearList(Strikes);
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
            if (obj == null || !(obj is LightningStrikes_Basic))
                return false;
            else
            {
                LightningStrikes_Basic o = new LightningStrikes_Basic();
                o = (LightningStrikes_Basic)obj;
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

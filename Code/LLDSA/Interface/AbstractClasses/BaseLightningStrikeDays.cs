/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Interface
{
    public abstract class BaseLightningStrikeDays
    {
        #region Variables
        public string AdministrativeRegionName { get; set; }

        public ConcurrentBag<BaseLightningStrikeDay> LightningStrikesDayList { get; set; }

        #endregion

        #region Index

        public BaseLightningStrikeDay this[int index]
        {
            get
            {
                return LightningStrikesDayList.ElementAt(index);
            }
        }
        #endregion

        #region Method

        /// <summary>
        /// 输入年份,返回一个Dictionary<1-12月份，雷电日数字>。
        /// </summary>
        /// <param name="_monthIndex">1~12月份</param>
        /// <returns>雷电日数字</returns>
        public abstract Dictionary<int, double> StaticLightningStrikesDayMonthly(int _year);

        /// <summary>
        /// 统计Dictionary<1-12月份，雷电日数字>。
        /// </summary>
        /// <returns>雷电日字典，按月份。</returns>
        public abstract Dictionary<int, double> StaticLightningStrikesDayMonthly();

        /// <summary>
        /// 输入雷电日列表，返回其对应的年份列表。
        /// </summary>
        /// <param name="_lightningStrikesDayList"></param>
        /// <returns></returns>
        public abstract List<int> StatisticYearList(IEnumerable<BaseLightningStrikeDay> _lightningStrikesDayList);

        /// <summary>
        /// 输入已经统计完毕的LightningStrikeDay，按年分类,返回List<Dictionary<int, LightningStrikeDay>>
        /// </summary>
        /// <returns></returns>
        public abstract List<Dictionary<int, BaseLightningStrikeDay>> StatisticLightningStrikesDayYearly(IEnumerable<BaseLightningStrikeDay> _lightningStrikeDays);
        #endregion
    }
}

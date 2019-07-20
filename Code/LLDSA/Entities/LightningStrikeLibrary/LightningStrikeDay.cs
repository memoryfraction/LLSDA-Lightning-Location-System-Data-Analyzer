/*****************************************************************

** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
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
    public class LightningStrikeDay : BaseLightningStrikeDay
    {
        DateTime dateTime;
        string administrativeRegionName;

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        
        public string AdministrativeRegionName
        {
            get { return administrativeRegionName; }
            set { administrativeRegionName = value; }
        }


        public LightningStrikeDay(BaseStrikeBasic _strike, string _administrativeRegionName)
        {
            if (_administrativeRegionName != null)
                administrativeRegionName = _administrativeRegionName;
            dateTime = _strike.DateAndTime;
        }

        public LightningStrikeDay(LightningStrikeBasic _strike)
        {
            dateTime = _strike.DateAndTime;
        }
    }


    public class LightningStrikeDays: BaseLightningStrikeDays
    {
        #region 构造函数

        public LightningStrikeDays(IEnumerable<BaseStrikeBasic> _strikes, string _administrativeRegionName)
        {
            if (_administrativeRegionName != null)
                administrativeRegionName = _administrativeRegionName;
            lightningStrikesDayList = new ConcurrentBag<BaseLightningStrikeDay>();
            lightningStrikesDayList = Initiate(_strikes, _administrativeRegionName, parallel);
        }

        public LightningStrikeDays(IEnumerable<BaseStrikeBasic> _strikes)
        {
            lightningStrikesDayList = new ConcurrentBag<BaseLightningStrikeDay>();
            lightningStrikesDayList = Initiate(_strikes, administrativeRegionName, parallel);
        }
        #endregion

        #region Variables
        string administrativeRegionName;


        
        ConcurrentBag<BaseLightningStrikeDay> lightningStrikesDayList;


        
        public ConcurrentBag<BaseLightningStrikeDay> LightningStrikesDayList
        {
            get { return lightningStrikesDayList; }
            set { lightningStrikesDayList = value; }
        }
        bool parallel = true;

        
        public bool Parallel
        {
            get { return parallel; }
            set { parallel = value; }
        }

        /// <summary>
        /// Administrative name
        /// </summary>
        
        public string AdministrativeRegionName
        {
            get { return administrativeRegionName; }
            set { administrativeRegionName = value; }
        }
        #endregion

        #region Index

        public BaseLightningStrikeDay this[int index]
        {
            get
            {
                return lightningStrikesDayList.ElementAt(index);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 初始化lightningStrikesDayList,插入时加入判断：“如果核心List已经存在该日期，则不重复插入”
        /// </summary>
        /// <param name="parallel"></param>
        private ConcurrentBag<BaseLightningStrikeDay> Initiate(IEnumerable<BaseStrikeBasic> _strikes, string _administrativeRegionName, bool parallel)
        {
            if (_strikes.Any())
            {
                var lightningStrikesDayResultList = new ConcurrentBag<BaseLightningStrikeDay>();
                if (parallel)//并行
                {
                    System.Threading.Tasks.Parallel.ForEach(_strikes, tmpStrike =>
                    {
                        LightningStrikeDay tmpLightningStrikeDay = new LightningStrikeDay(tmpStrike, _administrativeRegionName);
                        if (!lightningStrikesDayResultList.Any(r => r.DateTime.Date == tmpStrike.DateAndTime.Date))//不存在已有日期的雷电日值
                            lightningStrikesDayResultList.Add(tmpLightningStrikeDay);
                    });
                }
                else
                {
                    foreach (var tmpStrike in _strikes)
                    {
                        LightningStrikeDay tmpLightningStrikeDay = new LightningStrikeDay(tmpStrike, _administrativeRegionName);
                        if (!lightningStrikesDayResultList.Any(r => r.DateTime.Date == tmpStrike.DateAndTime.Date))//不存在已有日期的雷电日值
                            lightningStrikesDayResultList.Add(tmpLightningStrikeDay);
                    }
                }
                return lightningStrikesDayResultList;
            }
            else
                throw new ArgumentNullException("初始化LightningStrikeDays，序列中不包含闪电。");
        }

        /// <summary>
        /// 输入年份,返回一个Dictionary<1-12月份，雷电日数字>。
        /// </summary>
        /// <param name="_monthIndex">1~12月份</param>
        /// <returns>雷电日数字</returns>
        public override Dictionary<int, double> StaticLightningStrikesDayMonthly(int _year)
        {
            try
            {
                Dictionary<int, double> LightningStrikesDayResultDictionary = new Dictionary<int, double>();
                for (int i = 1; i <= 12; i++)//初始化类库
                {
                    int LightningStrikesDayYearly = 0;
                    if (parallel)
                        LightningStrikesDayYearly = LightningStrikesDayList.Where(r => r.DateTime.Year == _year && r.DateTime.Month == i).AsParallel().Count();
                    else
                        LightningStrikesDayYearly = LightningStrikesDayList.Where(r => r.DateTime.Year == _year && r.DateTime.Month == i).Count();
                    LightningStrikesDayResultDictionary.Add(i, LightningStrikesDayYearly);
                }
                return LightningStrikesDayResultDictionary;
            }
            catch
            { return null; }
        }

        /// <summary>
        /// 统计Dictionary<1-12月份，雷电日数字>。
        /// </summary>
        /// <returns>雷电日字典，按月份。</returns>
        public override Dictionary<int, double> StaticLightningStrikesDayMonthly()
        {
            try
            {
                Dictionary<int, double> LightningStrikesDayMonthlyDictionary = new Dictionary<int, double>();
                for (int i = 1; i <= 12; i++)//初始化类库
                {
                    double LightningStrikesDayMonthly = 0;
                    double numSum;
                    List<int> yearList = new List<int>();
                    yearList = StatisticYearList(LightningStrikesDayList);
                    double yearNum = yearList.Count;
                    if (parallel)
                    {
                        numSum = (double)LightningStrikesDayList.AsParallel().Where(r => r.DateTime.Month == i).Count();
                        LightningStrikesDayMonthly = numSum / yearNum;
                    }
                    else
                    {
                        numSum = (double)LightningStrikesDayList.Where(r => r.DateTime.Month == i).Count();
                        LightningStrikesDayMonthly = numSum / yearNum;
                    }
                    LightningStrikesDayMonthlyDictionary.Add(i, LightningStrikesDayMonthly);
                }
                return LightningStrikesDayMonthlyDictionary;
            }
            catch
            { return null; }
        }

        /// <summary>
        /// 输入雷电日列表，返回其对应的年份列表。
        /// </summary>
        /// <param name="_lightningStrikesDayList"></param>
        /// <returns></returns>
        public override List<int> StatisticYearList(IEnumerable<BaseLightningStrikeDay> _lightningStrikesDayList)
        {
            try
            {
                List<int> resultList = new List<int>();
                resultList = _lightningStrikesDayList.Select(r => r.DateTime.Year).Distinct().ToList();
                return resultList;
            }
            catch
            { return null; }
        }

        /// <summary>
        /// 输入已经统计完毕的LightningStrikeDay，按年分类,返回List<Dictionary<int, LightningStrikeDay>>
        /// </summary>
        /// <returns></returns>
        public override List<Dictionary<int, BaseLightningStrikeDay>> StatisticLightningStrikesDayYearly(IEnumerable<BaseLightningStrikeDay> _lightningStrikeDays)
        {
            try
            {
                List<Dictionary<int, BaseLightningStrikeDay>> result = new List<Dictionary<int, BaseLightningStrikeDay>>();
                List<int> yearList = StatisticYearList(_lightningStrikeDays);
                foreach (var tmpYear in yearList)
                {
                    Dictionary<int, BaseLightningStrikeDay> tmpDic = new Dictionary<int, BaseLightningStrikeDay>();
                    foreach (var tmp in _lightningStrikeDays)
                    {
                        if (tmp.DateTime.Date.Year == tmpYear)
                        {
                            tmpDic.Add(tmpYear, tmp);
                        }
                    }
                    result.Add(tmpDic);
                }
                return result;
            }
            catch { return null; }
        }

       
        #endregion
    }
}

/*****************************************************************

** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/


using LLSDA.Entities;
using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Service
{
    /// <summary>
    /// 统计strikes中各类属性、字符串等的静态方法| Statistic methods for lightning strikes
    /// </summary>
    public class StrikesDistributionStatisticService : IStrikesDistributionStatisticService
    {
        #region 年分布
        //年分布
        /// <summary>
        /// 计算年分布情况，耗时操作。
        /// </summary>
        public  Dictionary<int, int> CalcuYearDistribution(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                var yearQuery = _strikes.Select(record => record.DateAndTime.Year).Distinct();
                foreach (var tmpYear in yearQuery)
                {
                    resultDistribution.Add(tmpYear, 0);
                }
                foreach (var tmpLightning in _strikes)
                {
                    int year = tmpLightning.DateAndTime.Year;
                    resultDistribution[year] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("年分布统计，序列中不包含闪电。");
        }
        /// <summary>
        /// 统计雷电的年份
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  List<int> CalcuYearList(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                List<int> _yearList = new List<int>();
                _yearList = _strikes.OrderBy(r => r.DateAndTime.Year).Select(r => r.DateAndTime.Year).Distinct().ToList<int>();
                return _yearList;
            }
            else
                throw new ArgumentNullException("年分布列表计算，序列中不包含闪电。");
        }

        /// <summary>
        /// 计算正闪年分布情况，耗时操作。
        /// </summary>
        public  Dictionary<int, int> CalcuYearDistributionPositive(IEnumerable<BaseStrikeCompactEdition> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                var yearQuery = _strikes.Select(record => record.DateAndTime.Year).Distinct();
                foreach (var tmpYear in yearQuery)
                {
                    resultDistribution.Add(tmpYear, 0);
                }
                var query = _strikes.Where(record => record.LightningType == LightningType.Positive).Select(record => record);
                foreach (var tmpLightning in query)
                {
                    int year = tmpLightning.DateAndTime.Year;
                    resultDistribution[year] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("年正闪分布统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 计算负闪年分布情况，耗时操作。
        /// </summary>
        public  Dictionary<int, int> CalcuYearDistributionNegative(IEnumerable<BaseStrikeCompactEdition> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                var yearQuery = _strikes.Select(record => record.DateAndTime.Year).Distinct();
                foreach (var tmpYear in yearQuery)
                {
                    resultDistribution.Add(tmpYear, 0);
                }
                var query = _strikes.Where(record => record.LightningType == LightningType.Negative).Select(record => record);
                foreach (var tmpLightning in query)
                {
                    int year = tmpLightning.DateAndTime.Year;
                    resultDistribution[year] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("年负闪分布统计，序列中不包含闪电。");
        }
        #endregion


        #region 月分布
        //月分布
        /// <summary>
        /// 统计月份分布情况，耗时操作。
        /// </summary>
        public  Dictionary<int, int> CalcuMonthDistribution(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                for (int i = 1; i <= 12; i++)
                {
                    resultDistribution.Add(i, 0);
                }
                foreach (var tmpLightning in _strikes)
                {
                    int month = tmpLightning.DateAndTime.Month;
                    resultDistribution[month] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("月分布统计，序列中不包含闪电。");

        }
        /// <summary>
        /// 统计正闪月份分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<int, int> CalcuMonthDistributionPosive(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                for (int i = 1; i <= 12; i++)
                {
                    resultDistribution.Add(i, 0);
                }
                var queryPositive = _strikes.Where(record => record.Intensity >= 0).Select(record => record);
                foreach (var tmpLightning in queryPositive)
                {
                    int month = tmpLightning.DateAndTime.Month;
                    resultDistribution[month] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("月正闪分布统计，序列中不包含闪电。");
        }
        /// <summary>
        /// 统计正闪月份分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<int, int> CalcuMonthDistributionNegative(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                for (int i = 1; i <= 12; i++)
                {
                    resultDistribution.Add(i, 0);
                }
                var queryPositive = _strikes.Where(record => record.Intensity <= 0).Select(record => record);
                foreach (var tmpLightning in queryPositive)
                {
                    int month = tmpLightning.DateAndTime.Month;
                    resultDistribution[month] += 1;
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("月负闪分布统计，序列中不包含闪电。");
        }
        #endregion


        #region 时分布
        //时分布
        /// <summary>
        /// 统计时间分布情况，耗时操作。
        /// </summary>
        public  Dictionary<int, int> CalcuHourDistribution(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> hourDistribution = new Dictionary<int, int>();
                //hourDistributionPositive = new Dictionary<int, int>();
                //hourDistributionNegative = new Dictionary<int, int>();
                //初始化
                for (int i = 0; i < 24; i++)
                {
                    hourDistribution.Add(i, 0);
                    //hourDistributionPositive.Add(i, 0);
                    //hourDistributionNegative.Add(i, 0);
                }
                ///给时段雷电次数赋值
                foreach (var lightningTmp in _strikes)
                {
                    int hour = lightningTmp.DateAndTime.Hour;
                    hourDistribution[hour] += 1;
                }
                return hourDistribution;
            }
            else
            {
                throw new ArgumentNullException("时分布统计，序列中不包含闪电。");
            }
        }
        /// <summary>
        /// 统计正闪时间分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<int, int> CalcuHourDistribution_Positive(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                //初始化
                for (int i = 0; i < 24; i++)
                {
                    resultDistribution.Add(i, 0);
                }
                ///给时段雷电次数赋值
                var queryPositive = _strikes.Where(record => record.Intensity >= 0).Select(record => record);
                foreach (var lightningTmp in queryPositive)
                {
                    int hour = lightningTmp.DateAndTime.Hour;
                    resultDistribution[hour] += 1;
                }
                return resultDistribution;
            }
            else
            {
                throw new ArgumentNullException("正闪时分布统计，序列中不包含闪电。");
            }
        }
        /// <summary>
        /// 统计负闪时间分布情况，耗时操作。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<int, int> CalcuHourDistribution_Negative(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> resultDistribution = new Dictionary<int, int>();
                //初始化
                for (int i = 0; i < 24; i++)
                {
                    resultDistribution.Add(i, 0);
                }
                ///给时段雷电次数赋值
                var queryPositive = _strikes.Where(record => record.Intensity <= 0).Select(record => record);
                foreach (var lightningTmp in queryPositive)
                {
                    int hour = lightningTmp.DateAndTime.Hour;
                    resultDistribution[hour] += 1;
                }
                return resultDistribution;
            }
            else
            {
                throw new ArgumentNullException("负闪时分布统计，序列中不包含闪电。");
            }
        }
        #endregion


        #region 雷电流累计概率分布
        /// <summary>
        /// 计算累计概率数组,输入
        /// </summary>
        /// <param name="limitedCurValue"></param>
        /// <returns></returns>
        private  double CacuLJProbability(IEnumerable<BaseStrikeStandard> _strikes, int limitedCurValue)
        {
            double resultProbability;
            Int64 conditionedStrikeNumber = _strikes.Where(strike => Math.Abs(strike.Intensity) >= limitedCurValue).LongCount();
            Int64 totalStrikeNumber = _strikes.LongCount();
            resultProbability = (double)conditionedStrikeNumber / (double)totalStrikeNumber;
            return resultProbability;
        }
        /// <summary>
        /// 为probabilityDistribution赋值
        /// </summary>
        public  Dictionary<int, double> CalcuProbabilityDistribution(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                List<int> LJArrayX = new List<int>() { 10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 210, 230 };
                Dictionary<int, double> probabilityDistribution = new Dictionary<int, double>();
                foreach (var tmp in LJArrayX)
                {
                    double probability = CacuLJProbability(_strikes, tmp);
                    probabilityDistribution.Add(tmp, probability);
                }
                return probabilityDistribution;
            }
            else
                throw new ArgumentNullException("雷电流累计概率分布统计，序列中不包含闪电。");
        }
        #endregion


        #region 文字描述
        //文字描述
        //生成年分布文字描述
        public string GenerateYearDistributionText(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                string resultString = string.Empty;
                //统计生成年分布情况文字描述
                Dictionary<int, int> yearDistribution = CalcuYearDistribution(_strikes);
                var OrderedQuery = yearDistribution.OrderByDescending(record => record.Value).Select(record => record).ToList();
                double SumNum = (double)yearDistribution.Values.Sum();
                int elementNum = yearDistribution.Count;

                if (elementNum > 1)
                {
                    int firstNum = 2;
                    double topFirstNumSumNum = (double)yearDistribution.Values.OrderByDescending(r => r).Take(firstNum).Sum();


                    double Percentage = topFirstNumSumNum / SumNum * 100;
                    string tmp1 = "";
                    for (int i = 0; i < firstNum; i++)
                    {
                        if (i == firstNum - 1)
                            tmp1 += (OrderedQuery[i].Key.ToString()).ToString();
                        else
                            tmp1 += (OrderedQuery[i].Key.ToString()).ToString() + "、";
                    }
                    string tmp2 = OrderedQuery[0].Key.ToString();

                    resultString = "该地域闪电主要活跃在" + tmp1 + "年份，" + Math.Round(Percentage, 1) + "%以上的闪电都发生在这些年份。";
                }
                return resultString;
            }
            else
                throw new ArgumentNullException("年分布文字说明统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 生成HourDistributionText
        /// </summary>
        public  string GenerateHourDistributionText(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> hourDistribution = CalcuHourDistribution(_strikes);
                string result;
                int firstNum = 3;
                var OrderedQuery = hourDistribution.OrderByDescending(record => record.Value).Select(record => record).ToList();

                double topFirstNumSumNum = (double)hourDistribution.Values.OrderByDescending(r => r).Take(3).Sum();
                double SumNum = (double)hourDistribution.Values.Sum();

                double Percentage = topFirstNumSumNum / SumNum * 100;
                string tmp1 = "";
                for (int i = 0; i < firstNum; i++)
                {
                    if (i == firstNum - 1)
                        tmp1 += (OrderedQuery[i].Key.ToString()).ToString();
                    else
                        tmp1 += (OrderedQuery[i].Key.ToString()).ToString() + "、";
                }
                string tmp2 = OrderedQuery[0].Key.ToString();

                result = "该地域闪电主要活跃在" + tmp1 + "时，" + Math.Round(Percentage, 1) + "%以上的闪电都发生在这些时段，\r\n" +
                    OrderedQuery[0].Key.ToString() + "时～" + OrderedQuery[2].Key.ToString() +
                    "时为闪电高发时段，其中" + tmp2 + "时段雷电活动最为强烈。";
                return result;
            }
            else
                throw new ArgumentNullException("时分布文字说明统计，序列中不包含闪电。");
        }
        /// <summary>
        /// 生成MonthDistributionText
        /// </summary>
        public  string GenerateMonthDistributionText(IEnumerable<BaseStrikeBasic > _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                Dictionary<int, int> monthDistribution = CalcuMonthDistribution(_strikes);
                string result;
                int firstNum = 3;
                var OrderedQuery = monthDistribution.OrderByDescending(r => r.Value).Select(r => r).ToList();
                double topFirstNumSumNum = (double)monthDistribution.Values.OrderByDescending(r => r).Take(firstNum).Sum();
                double SumNum = (double)monthDistribution.Values.Sum();
                double percentage = topFirstNumSumNum / SumNum * 100;
                string tmp1 = "";
                for (int i = 0; i < firstNum; i++)
                {
                    if (i == firstNum - 1)
                        tmp1 += (OrderedQuery[i].Key.ToString()).ToString();
                    else
                        tmp1 += (OrderedQuery[i].Key.ToString()).ToString() + "、";
                }
                result = "该地区" + tmp1 + "月份为闪电高发期，" + Math.Round(percentage, 1) + "%以上的闪电都发生在这些月份。";
                return result;
            }
            else
                throw new ArgumentNullException("月分布统计文字，序列中不包含闪电。");
        }
        /// <summary>
        /// 生成ProbabilityDistributionText
        /// </summary>
        public  string GenerateProbabilityDistributionText(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                double intensityMax = 0, intensityMin = 0, intensityAvg = 0;
                List<double> limitedProbabilityArray = new List<double>() { 0.01, 0.02, 0.05, 0.10, 0.20, 0.50 };
                List<string> resultStringArray = new List<string>();
                string resultString = "";
                for (int i = 0; i < limitedProbabilityArray.Count; i++)
                {
                    var query = _strikes.Select(r => Math.Abs(r.Intensity)).ToList();
                    query.Sort();
                    query.Reverse();//把query按照绝对值进行从大到小排序
                    //求雷电流最大值、最小值、平均值
                    intensityMax = query.FirstOrDefault();
                    intensityMin = query.LastOrDefault();
                    intensityAvg = query.Average();
                    int index = (int)Math.Floor(limitedProbabilityArray[i] * query.Count);
                    if (index > query.Count - 1)
                        index = query.Count - 1;
                    resultStringArray.Add(Math.Round(query[index], 1).ToString());
                }
                for (int i = 0; i < limitedProbabilityArray.Count; i++)
                {
                    resultStringArray[i] = limitedProbabilityArray[i] * 100 + "%的雷电流强度大于" + resultStringArray[i] + "kA;\r\n";
                    resultString = resultString + resultStringArray[i];
                }
                resultString = resultString + "\r\n最大雷电流" + Math.Round(intensityMax, 2).ToString() + "kA;\r\n最小雷电流" + Math.Round(intensityMin, 2)
                    + "kA;\r\n平均雷电流" + Math.Round(intensityAvg, 2) + "kA\r\n更多详细信息，请查看闪电明细";
                return resultString;
            }
            else
                throw new ArgumentNullException("雷电流累计概率分布文字说明统计，序列中不包含闪电。");
        }
        #endregion


        #region 雷电流强度区间概率
        //雷电流强度区间概率
        /// <summary>
        /// 统计雷电流强度区间概率
        /// </summary>
        public  Dictionary<string, double> CalcuIntensityProbabilityDistribution(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                // 统计雷电流强度区间概率，赋值intensityProbabilityDistribution, intensityProbabilityDistributionPositive, intensityProbabilityDistributionNegative
                Dictionary<string, double> resultDistribution = new Dictionary<string, double>();

                List<Section> sectionList = InitiateSectionList();
                foreach (Section tmpSection in sectionList)
                {
                    double probability;
                    probability = CalcuProbability(tmpSection, _strikes);
                    resultDistribution.Add(tmpSection.Description, probability);
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("强度区间概率统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 统计正闪雷电流强度区间概率
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<string, double> CalcuIntensityProbabilityDistributionPositive(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                // 统计雷电流强度区间概率，赋值intensityProbabilityDistribution, intensityProbabilityDistributionPositive, intensityProbabilityDistributionNegative
                Dictionary<string, double> resultDistribution = new Dictionary<string, double>();

                List<Section> sectionList = InitiateSectionList();
                foreach (Section tmpSection in sectionList)
                {
                    double probability;
                    probability = CalcuProbability(tmpSection, _strikes.Where(r => r.Intensity >= 0).Select(r => r));
                    resultDistribution.Add(tmpSection.Description, probability);
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("正闪强度概率统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 统计负闪雷电流强度区间概率
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<string, double> CalcuIntensityProbabilityDistributionNegative(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                // 统计雷电流强度区间概率，赋值intensityProbabilityDistribution, intensityProbabilityDistributionPositive, intensityProbabilityDistributionNegative
                Dictionary<string, double> resultDistribution = new Dictionary<string, double>();

                List<Section> sectionList = InitiateSectionList();
                foreach (Section tmpSection in sectionList)
                {
                    double probability;
                    probability = CalcuProbability(tmpSection, _strikes.Where(r => r.Intensity <= 0).Select(r => r));
                    resultDistribution.Add(tmpSection.Description, probability);
                }
                return resultDistribution;
            }
            else
                throw new ArgumentNullException("负闪强度区间统计，序列中不包含闪电。");
        }

        /// <summary>
        ///输入闪电序列和section，计算对应的概率（0-100）
        /// </summary>
        /// <returns></returns>
        private  double CalcuProbability(Section _section, IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
            {
                double probability = 0;
                Int64 totalNumber = _strikes.LongCount();
                Int64 numberInSection = 0;
                foreach (var tmp in _strikes)
                {
                    if (WhetherStrikeInSection(tmp, _section))
                        numberInSection++;
                }
                probability = Math.Round((double)numberInSection / (double)totalNumber * 100.0, 2);
                return probability;
            }
            else
                throw new ArgumentException("输入闪电序列和section，计算对应的概率（0-100），序列中不包含闪电。");
        }

        /// <summary>
        /// 判断闪电的强度是否在section范围内，强度取绝对值。
        /// </summary>
        /// <param name="_strike"></param>
        /// <param name="_section"></param>
        /// <returns></returns>
        private  bool WhetherStrikeInSection(BaseStrikeStandard _strike, Section _section)
        {

            bool result = false;
            double intensity = Math.Abs(_strike.Intensity);
            if (intensity >= _section.minValue && intensity < _section.maxValue)
                result = true;
            return result;

        }

        /// <summary>
        /// 初始化List<Section
        /// </summary>
        /// <returns></returns>
        private  List<Section> InitiateSectionList()
        {
            List<Section> sectionList = new List<Section>();
            Section section;
            section = new Section();
            section.MinValue = 0;
            section.MaxValue = 20;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 20;
            section.MaxValue = 40;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 40;
            section.MaxValue = 60;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 60;
            section.MaxValue = 80;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 80;
            section.MaxValue = 100;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 100;
            section.MaxValue = 120;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 120;
            section.MaxValue = 140;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 140;
            section.MaxValue = 160;
            sectionList.Add(section);

            section = new Section();
            section.MinValue = 160;
            section.MaxValue = double.PositiveInfinity;//正无穷大
            sectionList.Add(section);
            return sectionList;
        }
        #endregion


        #region 雷电日
        //雷电日
        /// <summary>
        /// 计算平均年雷电日并返回
        /// </summary>
        public  double GetLightningDaysPerYear(IEnumerable<BaseStrikeBasic> _strikes, double _years) 
        {
            if (_strikes!=null && _strikes.Any())
            {
                double thunderStormDayPerYear;
                List<DateTime> existedDateList = new List<DateTime>();
                foreach (var tmp in _strikes)
                {
                    bool tmpDateExisted = existedDateList.Exists(r => r.Date == tmp.DateAndTime.Date);
                    if (!tmpDateExisted)
                    {
                        existedDateList.Add(tmp.DateAndTime);
                    }
                }
                thunderStormDayPerYear = existedDateList.Count;
                if (_years != 0)
                {
                    thunderStormDayPerYear = thunderStormDayPerYear / _years;
                    return thunderStormDayPerYear;
                }
                else
                    throw new ArgumentOutOfRangeException("年份为0，被除数不能为0。");
            }
            else
                throw new ArgumentNullException("年平均雷电日计算，序列中不包含闪电。");
        }

        /// <summary>
        /// 输入指定信息，根据LLS数据统计雷电日信息。
        /// </summary>
        /// <returns></returns>
        public BaseLightningStrikeDays GetLightningStrikesDays(IEnumerable<BaseStrikeBasic> _strikes, string _administrativeRegionName)
        {
            if (_strikes!=null && _strikes!=null && _strikes.Any())
            {
                BaseLightningStrikeDays resultDays = new LightningStrikeDays(_strikes, _administrativeRegionName);
                return resultDays;
            }
            else
                throw new ArgumentNullException("总雷电日计算，序列中不包含闪电。");
        }
        #endregion


        #region 最大、最小雷电流强度、数量
        public  double CalcuMaxPositiveIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity >= 0).Any())
                    return _strikes.Select(r => r.Intensity).Max();
                else
                    return 0;
            else
                throw new ArgumentNullException("正闪最大雷电流计算，序列中不包含闪电。");
        }
        public  double CalcuMinPositiveIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity >= 0).Any())
                    return _strikes.Select(r => r.Intensity).Min();
                else
                    return 0;
            else
                throw new ArgumentNullException("正闪最小雷电流计算，序列中不包含闪电。");
        }
        public  double CalcuMaxNegativeIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity <= 0).Any())
                    return _strikes.Select(r => r.Intensity).Max();
                else
                    return 0;
            else
                throw new ArgumentNullException("负闪最大雷电流计算，序列中不包含闪电。");
        }
        public  double CalcuMinNegativeIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity <= 0).Any())
                    return _strikes.Select(r => r.Intensity).Min();
                else
                    return 0;
            else
                throw new ArgumentNullException("负闪最小雷电流强度计算，序列中不包含闪电。");
        }

        public  double CalcuPositiveAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity >= 0).Any())
                    return _strikes.Select(r => r.Intensity).Average();
                else
                    return 0;
            else
                throw new ArgumentNullException("正闪平均雷电流强度计算，序列中不包含闪电。");
        }
        public  double CalcuNegativeAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity <= 0).Any())
                    return _strikes.Select(r => r.Intensity).Average();
                else
                    return 0;
            else
                throw new ArgumentNullException("负闪平均雷电流强度计算，序列中不包含闪电。");
        }
        public  double CalcuAbsAvgIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes.Where(x => x.Intensity <= 300 && x.Intensity >= -300).Any())
                return _strikes.Where(x => x.Intensity <= 300 && x.Intensity >= -300).Select(r => Math.Abs(r.Intensity)).Average();
            else
                throw new ArgumentNullException("绝对值雷电流强度计算，序列中不包含闪电。");
        }
        public  double CalcuAbsMinIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            //超过300KA的数据是没有意义的
            if (_strikes!=null && _strikes.Any())
                return _strikes.Where(x => x.Intensity <= 300 && x.Intensity >= -300).Select(r => Math.Abs(r.Intensity)).Min();
            else
                throw new ArgumentNullException("绝对值雷电流强度计算，序列中不包含闪电。");
        }

        public  double CalcuAbsMaxIntensity(IEnumerable<BaseStrikeStandard> _strikes)
        {
            //超过300KA的数据是没有意义的
            if (_strikes!=null && _strikes.Any())
                return _strikes.Where(x => x.Intensity <= 300 && x.Intensity >= -300).Select(r => Math.Abs(r.Intensity)).Max();
            else
                throw new ArgumentNullException("绝对值雷电流强度计算，序列中不包含闪电。");
        }

        public  Int64 CalcuPositiveSumNum(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity >= 0).Any())
                    return _strikes.Where(r => r.Intensity >= 0).LongCount();
                else
                    return 0;
            else
                throw new ArgumentNullException("正闪总数计算，序列中不包含闪电。");
        }
        public  Int64 CalcuNegativeSumNum(IEnumerable<BaseStrikeStandard> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                if (_strikes.Where(r => r.Intensity <= 0).Any())
                    return _strikes.Where(r => r.Intensity <= 0).LongCount();
                else
                    return 0;
            else
                throw new ArgumentNullException("负闪总数计算，序列中不包含闪电。");
        }
        public  Int64 CalcuSumNum(IEnumerable<BaseStrikeBasic> _strikes)
        {
            if (_strikes!=null && _strikes.Any())
                return _strikes.LongCount();
            else
                throw new ArgumentNullException("地闪总数计算，序列中不包含闪电。");
        }
        #endregion


        #region 地区分布
        /// <summary>
        /// 处理雷电公报的描述,需要在计算完雷电日以后再提出
        /// </summary>
        /// <returns></returns>
        public  string ProcessLightningBulletinDesc(IEnumerable<BaseStrikeChina> _strikes, string _administrativeRegionName)
        {
            string resultString = string.Empty;
            //xx地区初雷日为x月x日，终雷日为y月y日。
            //地区内正闪最大雷电强度：xxkA,正闪最小强度：xxkA；
            //负闪最大强度：xxkA，负闪最小强度，负闪平均强度；
            //绝对值平均强度：xxkA；
            //平均雷电日数：xx.xx天。
            if (_strikes!=null && _strikes.Any())
            {
                BaseStrikeStandard strikeStandardFirst, strikeStandardLast;
                strikeStandardFirst = (BaseStrikeStandard)_strikes.OrderBy(r => r.DateAndTime).Select(r => r).FirstOrDefault();
                strikeStandardLast = (BaseStrikeStandard)_strikes.OrderBy(r => r.DateAndTime).Select(r => r).LastOrDefault();
                resultString = _administrativeRegionName + "地区初雷日为" + strikeStandardFirst.DateAndTime.Month + "月" + strikeStandardFirst.DateAndTime.Day + "日。终雷日为"
                    + strikeStandardLast.DateAndTime.Month + "月"
                    + strikeStandardLast.DateAndTime
                    + "日。地区内最大正地闪为"
                    + CalcuMaxPositiveIntensity(_strikes).ToString() + "kA。最小正地闪为"
                    + CalcuMinPositiveIntensity(_strikes).ToString() + "kA。最大负地闪为"
                    + CalcuMaxNegativeIntensity(_strikes).ToString() + "kA。最小负地闪为"
                    + CalcuMinNegativeIntensity(_strikes).ToString() + "kA。地闪强度绝对值平均数为"
                    + CalcuAbsAvgIntensity(_strikes).ToString() + "kA。";
                return resultString;
            }
            else
                throw new ArgumentNullException("雷电公报文字描述统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 处理雷电公报的描述,需要在计算完雷电日以后再提出
        /// </summary>
        /// <returns></returns>
        public  string ProcessLightningBulletinDesc(IEnumerable<BaseStrikeChina> _strikes)
        {
            string resultString = string.Empty;
            //xx地区初雷日为x月x日，终雷日为y月y日。
            //地区内正闪最大雷电强度：xxkA,正闪最小强度：xxkA；
            //负闪最大强度：xxkA，负闪最小强度，负闪平均强度；
            //绝对值平均强度：xxkA；
            //平均雷电日数：xx.xx天。
            if (_strikes!=null && _strikes.Any())
            {
                var strikeFirst = _strikes.OrderBy(r => r.DateAndTime).Select(r => r).FirstOrDefault();
                var strikeLast = _strikes.OrderBy(r => r.DateAndTime).Select(r => r).LastOrDefault();
                resultString = "该地区初雷日为" + strikeFirst.DateAndTime.Month + "月" + strikeFirst.DateAndTime.Day + "日。终雷日为"
                    + strikeLast.DateAndTime.Month + "月"
                    + strikeLast.DateAndTime.Day
                    + "日。地区内最大正地闪为"
                    + Math.Round(CalcuMaxPositiveIntensity(_strikes), 2).ToString() + "kA。最小正地闪为"
                    + Math.Round(CalcuMinPositiveIntensity(_strikes), 2).ToString() + "kA。最大负地闪为"
                    + Math.Round(CalcuMaxNegativeIntensity(_strikes), 2).ToString() + "kA。最小负地闪为"
                    + Math.Round(CalcuMinNegativeIntensity(_strikes), 2).ToString() + "kA。地闪强度绝对值平均数为"
                    + Math.Round(CalcuAbsAvgIntensity(_strikes), 2).ToString() + "kA。";
                return resultString;
            }
            else
                throw new ArgumentNullException("雷电公报文字描述统计，序列中不包含闪电。");
        }

        /// <summary>
        /// 计算下级地区闪电分布情况。
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        public  Dictionary<string, int> ProcessAreaDistribution(IEnumerable<BaseStrikeChina> _strikes, AdministrativeLevel _administrativeLevelEnum)
        {
            //if (_administrativeLevelEnum)
            //{
            Dictionary<string, int> resultDic = new Dictionary<string, int>();
            List<string> areaList = new List<string>();
            if (_strikes!=null && _strikes.Any())
            {
                areaList = ProcessAreaList(_strikes, _administrativeLevelEnum);
                if (areaList != null)
                {
                    foreach (var tmp in areaList)
                    {
                        int resultNum = CalculateNumber(_strikes, _administrativeLevelEnum, tmp);
                        resultDic.Add(tmp, resultNum);
                    }
                    return resultDic;
                }
                else
                    return null;
            }
            else
                throw new ArgumentException("下级地区分布描述处理，序列中不包含闪电。");
        }

        /// <summary>
        /// 根据行政区划和
        /// </summary>
        /// <param name="_strikes"></param>
        /// <param name="_administrativeLevelEnum"></param>
        /// <returns></returns>
        private  List<string> ProcessAreaList(IEnumerable<BaseStrikeChina> _strikes, AdministrativeLevel _administrativeLevelEnum)
        {
            List<string> areaList = new List<string>();
            if (_administrativeLevelEnum == AdministrativeLevel.Country)
            {
                areaList = _strikes.Select(r => r.Province).Distinct().ToList();
            }
            else if (_administrativeLevelEnum == AdministrativeLevel.Province)
            {
                areaList = _strikes.Select(r => r.City).Distinct().ToList();
            }
            else if (_administrativeLevelEnum == AdministrativeLevel.City)
            {
                areaList = _strikes.Select(r => r.City).Distinct().ToList();
            }
            else if (_administrativeLevelEnum == AdministrativeLevel.County)
            {
                return null;
                //无下级单位
                throw new ArgumentOutOfRangeException("县无下级行政区划单位");
            }
            else//默认为市级
            {
                areaList = _strikes.Select(r => r.City).Distinct().ToList();
            }
            return areaList;
        }

        /// <summary>
        /// 从闪电序列中找出制定地名的闪电数据
        /// </summary>
        /// <param name="_strikes"></param>
        /// <returns></returns>
        private  int CalculateNumber(IEnumerable<BaseStrikeChina> _strikes, AdministrativeLevel _administrativeLevelEnum, string _areaName)
        {
            int resultNum = 0;
            switch (_administrativeLevelEnum)
            {
                case AdministrativeLevel.Country:
                    resultNum = _strikes.Where(r => r.Province == _areaName).Count();
                    break;
                case AdministrativeLevel.Province:
                    resultNum = _strikes.Where(r => r.City == _areaName).Count();
                    break;
                case AdministrativeLevel.City:
                    resultNum = _strikes.Where(r => r.City == _areaName).Count();
                    break;
                case AdministrativeLevel.Village:
                    throw new ArgumentOutOfRangeException("不存在比县更小的行政级别");
                default:
                    throw new ArgumentOutOfRangeException("未知的行政区划级别");
            }
            return resultNum;
        }
        #endregion


        #region 雷电玫瑰图，暂被注释，因为包含经纬度信息，不应该出现在这里。
        ///// <summary>
        ///// 统计雷电主次导方向概率
        ///// </summary>
        ///// <returns></returns>
        //public  Dictionary<LightningStrikeDirectionEnum, double> CalcuLightningStrikeDirectionProbabilityDistribution(IEnumerable<AbstractStrike_Standard> _strikes,PointLocation _point)
        //{ 
        //    if (_strikes!=null && _strikes.Any())
        //    {
        //        Dictionary<LightningStrikeDirectionEnum, double> resultDictionaryList = new Dictionary<LightningStrikeDirectionEnum, double>();
        //        //北", "东北", "东", "东南", "南", "西南", "西", "西北"
        //        double resultProbability;
        //        //遍历整个枚举类型
        //        foreach (LightningStrikeDirectionEnum item in Enum.GetValues(typeof(LightningStrikeDirectionEnum)))
        //        {
        //            resultProbability = CalcuLightningStrikeDirectionProbability(_strikes, item, _point);
        //            resultDictionaryList.Add(item, resultProbability);
        //        }
        //        return resultDictionaryList;
        //    }
        //    else
        //        throw new ArgumentNullException("序列中不包含闪电。"); 
        //}
        ///// <summary>
        ///// 输入闪电，计算某种方向闪电的概率。概率格式：33.3%
        ///// </summary>
        ///// <param name="_strikes"></param>
        ///// <returns></returns>
        //private  double CalcuLightningStrikeDirectionProbability(IEnumerable<AbstractStrike_Standard> _strikes, LightningStrikeDirectionEnum _directionEnum,PointLocation _centerPoint)
        //{
        //    double result = 0;
        //    int suitedNum = 0;
        //    int TotalNumber = _strikes.Count();
        //    foreach (var tmpStrike in _strikes)
        //    {
        //        if (_directionEnum == JudgeLightningStrikeDirection(tmpStrike, _centerPoint))
        //        {
        //            suitedNum++;
        //        }
        //    }
        //    result = Math.Round((double)suitedNum / (double)TotalNumber * 100, 1);
        //    return result;

        //}
        ///// <summary>
        ///// 输入一个闪电，判断其对应中心点经纬度 方向
        ///// </summary>
        ///// <param name="_strike"></param>
        ///// <returns></returns>
        //private  LightningStrikeDirectionEnum JudgeLightningStrikeDirection(AbstractStrike_Standard _strike, PointLocation _centerPoint)
        //{
        //    LightningStrikeDirectionEnum result = new LightningStrikeDirectionEnum();
        //    double angle = AngleClass.CalcueAngle(_centerPoint.Longitude, _centerPoint.Latitude, _strike.Longitude, _strike.Latitude);
        //    result = AngleClass.GetLightningStrikeDirection(angle);
        //    return result;
        //}
        #endregion

        #region Ng
        /// <summary>
        /// 计算Ng值
        /// </summary>
        /// <param name="strikesNumber"></param>
        /// <param name="size"></param>
        /// <param name="yearNum"></param>
        /// <returns></returns>
        public  double CalcuNg(long strikesNumber, double size, double yearNum)
        {
            if (size != 0 && yearNum != 0)
                return (double)strikesNumber / size / yearNum;
            else
                throw new Exception("CalcuNg(long strikesNumber,double size,double yearNum)方法中年数和面积不能为0。");
        }

       
        #endregion
    }
}

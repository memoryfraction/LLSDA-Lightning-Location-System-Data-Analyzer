using LLSDA.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public class LightningStrikes_Basic
    {
        #region 构造函数
        public LightningStrikes_Basic(IEnumerable<LightningStrike_Basic> _lightningStrikes_Basic)
        {
            foreach (var tmpStrike in _lightningStrikes_Basic)
                strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic(IEnumerable<LightningStrike_Standard> _lightningStrikes_Standard)
        {
            foreach (var tmpStrike in _lightningStrikes_Standard)
                strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic(IEnumerable<LightningStrike_China> _lightningStrikes_China)
        {
            foreach (var tmpStrike in _lightningStrikes_China)
                strikes.Add(tmpStrike);
        }
        public LightningStrikes_Basic()
        { }
        #endregion


        #region Variables&Properties
        ConcurrentBag<LightningStrike_Basic> strikes = new ConcurrentBag<LightningStrike_Basic>();
        internal Int64 sumStrikesNum;
        internal Dictionary<int, int> hourDistribution, monthDistribution, yearDistribution;
        internal string hourDistributionDesc, monthDistributionDesc, yearDistributionDesc;
        internal LightningStrikeDays lightningStrikeDays;
        internal string areaName;
        internal List<int> _yearList;


        
        public ConcurrentBag<LightningStrike_Basic> Strikes
        {
            get { return strikes; }
            set { strikes = value; }
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
        #endregion


        /// <summary>
        /// readonly index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LightningStrike_Basic this[int index]
        {
            get { return strikes.ElementAt(index); }
        }


        #region 公开方法
       
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
            if (obj == null || !(obj is LightningStrikes_Basic))
                return false;
            else
            {
                LightningStrikes_Basic o = new LightningStrikes_Basic();
                o = (LightningStrikes_Basic)obj;
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

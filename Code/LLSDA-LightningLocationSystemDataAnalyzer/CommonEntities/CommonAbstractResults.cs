/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License Desc: https://creativecommons.org/licenses/by-nc-nd/3.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public abstract class CommonAbstractResults
    {
        public CommonAbstractResults()
        {
           
        }

        internal List<string> resultPicturesList;
        internal double ng, intensityAvg, intensityMax, intensityMin;
        internal Dictionary<int, double> probabilityDistribution;
        internal Dictionary<int, int> hourDistribution, hourDistributionPositive, hourDistributionNegative, monthDistribution, monthDistributionPositive, monthDistributionNegative, yearDistribution, yearDistributionPositive, yearDistributionNegative;
        internal string hourDistributionDesc, monthDistributionDesc, yearDistributionDesc, probabilityDistributionDesc, errorMsg;
        internal int lightningStrikeDays;

        
        public Int64 SumStrikesNumber { get; set; }


        /// <summary>
        /// 图片的相对路径
        /// </summary>
        
        public List<string> PicturesAbsolutePathList { get; set; }

        /// <summary>
        /// 结果图片的路径。如：http://xxx.xxx.xxx.xxx/LlsAnalysisPlatform.HLJ.WebApi/a.jpg
        /// </summary>
        
        public List<string> ResultPicturesList
        {
            get { return resultPicturesList; }
            set { resultPicturesList = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        
        public string ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }

        //
        public string ProbabilityDistributionDesc
        {
            get { return probabilityDistributionDesc; }
            set { probabilityDistributionDesc = value; }
        }

        /// <summary>
        /// 累积概率分布
        /// </summary>
        //
        public Dictionary<int, double> ProbabilityDistribution
        {
            get { return probabilityDistribution; }
            set { probabilityDistribution = value; }
        }

        //
        public string YearDistributionDesc
        {
            get { return yearDistributionDesc; }
            set { yearDistributionDesc = value; }
        }
        //
        public string MonthDistributionDesc
        {
            get { return monthDistributionDesc; }
            set { monthDistributionDesc = value; }
        }
        //
        public string HourDistributionDesc
        {
            get { return hourDistributionDesc; }
            set { hourDistributionDesc = value; }
        }

        //
        public Dictionary<int, int> YearDistributionNegative
        {
            get { return yearDistributionNegative; }
            set { yearDistributionNegative = value; }
        }
        //
        public Dictionary<int, int> YearDistributionPositive
        {
            get { return yearDistributionPositive; }
            set { yearDistributionPositive = value; }
        }
        //
        public Dictionary<int, int> YearDistribution
        {
            get { return yearDistribution; }
            set { yearDistribution = value; }
        }
        //
        public Dictionary<int, int> MonthDistributionNegative
        {
            get { return monthDistributionNegative; }
            set { monthDistributionNegative = value; }
        }
        //
        public Dictionary<int, int> MonthDistributionPositive
        {
            get { return monthDistributionPositive; }
            set { monthDistributionPositive = value; }
        }
        //
        public Dictionary<int, int> MonthDistribution
        {
            get { return monthDistribution; }
            set { monthDistribution = value; }
        }
        //
        public Dictionary<int, int> HourDistributionNegative
        {
            get { return hourDistributionNegative; }
            set { hourDistributionNegative = value; }
        }
        //
        public Dictionary<int, int> HourDistributionPositive
        {
            get { return hourDistributionPositive; }
            set { hourDistributionPositive = value; }
        }
        //
        public Dictionary<int, int> HourDistribution
        {
            get { return hourDistribution; }
            set { hourDistribution = value; }
        }
        
        public double IntensityAvg
        {
            get { return Math.Round(intensityAvg, 2); }
            set { intensityAvg = value; }
        }

        
        public double IntensityMax
        {
            get { return Math.Round(intensityMax, 2); }
            set { intensityMax = value; }
        }

        
        public double IntensityMin
        {
            get { return Math.Round(intensityMin, 2); }
            set { intensityMin = value; }
        }

        
        public double Ng
        {
            get { return Math.Round(ng, 4); }
            set { ng = value; }
        }

        /// <summary>
        /// 雷电日
        /// </summary>
        
        public int LightningStrikeDays
        {
            get { return lightningStrikeDays; }
            set { lightningStrikeDays = value; }
        }


    }
}

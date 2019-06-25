using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public interface IPointAnalysisResult
    {
        Dictionary<LightningStrikeDirectionEnum, double> RoseDistribution
        {
            get;
            set;
        }
        string PointName
        {
            get;
            set;
        }

        List<ResultElement> IntensityAvgList
        {
            get;
            set;
        }

        List<ResultElement> NgList
        {
            get;
            set;
        }

        string ProbabilityDistributionDesc
        {
            get;
            set;
        }

        /// <summary>
        /// 累积概率分布
        /// </summary>
        Dictionary<int, double> ProbabilityDistribution
        {
            get;
            set;
        }

        string YearDistributionDesc
        {
            get;
            set;
        }

        string MonthDistributionDesc
        {
            get;
            set;
        }

        string HourDistributionDesc
        {
            get;
            set;
        }
        Dictionary<int, int> YearDistributionNegative
        {
            get;
            set;
        }

        Dictionary<int, int> YearDistributionPositive
        {
            get;
            set;
        }

        Dictionary<int, int> YearDistribution
        {
            get;
            set;
        }

        Dictionary<int, int> MonthDistributionNegative
        {
            get;
            set;
        }

        Dictionary<int, int> MonthDistributionPositive
        {
            get;
            set;
        }

        Dictionary<int, int> MonthDistribution
        {
            get;
            set;
        }

        Dictionary<int, int> HourDistributionNegative
        {
            get;
            set;
        }

        Dictionary<int, int> HourDistributionPositive
        {
            get;
            set;
        }

        Dictionary<int, int> HourDistribution
        {
            get;
            set;
        }
        double IntensityAvg
        {
            get;
            set;
        }

        double Ng
        {
            get;
            set;
        }

        List<LightningStrikeStandard> Strikes
        {
            get;
            set;
        }

        LongitudeOrLatitude LongitudeInput
        {
            get;
            set;
        }

        LongitudeOrLatitude LatitudeInput
        {
            get;
            set;
        }

    }
}

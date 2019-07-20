/*****************************************************************
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{

    public enum ResultPictureTypeEnum
    {
        地闪时分布图,
        地闪月分布图,
        地闪年分布图,
        地闪地区分布图,
        地闪累计概率分布图,
        雷击大地密度分布图,
        雷电流强度分布图,
        雷击大地密度分布图含行政区划,
        雷电流强度分布图含行政区划,
        地闪分布玫瑰图,
    }

    public enum SeriesNameFlashType
    {
        正闪所占百分比,
        负闪所占百分比,
        总闪所占百分比,
        雷电强度分级,
        雷暴日
    }

    /// <summary>
    /// Chart Type
    /// </summary>
    public enum InterpolationType
    {
        Ng = 1,
        AvgIntensity = 2,
        IntensityDivision = 3,
        AdministrativeRegion = 4
    }


    //public enum LightningType
    //{
    //    Positive = 0,
    //    Negative = 1
    //}

    ///// <summary>
    ///// 行政区域级别，用于AdministrativeRegion类
    ///// </summary>
    //public enum AdministrativeLevel
    //{
        
    //    国家,
        
    //    省,
        
    //    市,
        
    //    县,
        
    //    乡镇
    //}

    /// <summary>
    /// 区间，文字描述，格式比如："1-2"
    /// </summary>
    public class Section
    {
        public double minValue, maxValue;
        string description;

        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        public double MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        /// <summary>
        /// 文字描述，格式比如："1-2"
        /// </summary>
        public string Description
        {
            get
            {
                description = minValue.ToString() + "-" + maxValue.ToString();
                return description;
            }
            set { description = value; }
        }

    }

    /// <summary>
    /// 雷电方向，配合雷电主次导图使用 | Lightning Direction
    /// </summary>
    public enum LightningStrikeDirectionEnum
    {
        North = 0,
        
        NorthEast = 1,
        
        East = 2,
        
        SouthEast = 3,
        
        South = 4,
        
        SouthWest = 5,
        
        West = 6,
        
        NorthWest = 7,
        
        CenteralPoint
    }

    /// <summary>
    /// 按照雷电流强度划分的闪电定位数据
    /// </summary>
    public enum LightningStrikeIntensityClassTypeEnum
    {
        [EnumMember]
        强度20kA以下,
        [EnumMember]
        强度20kA到50kA之间,
        [EnumMember]
        强度50kA到100kA之间,
        [EnumMember]
        强度100kA以上
    }

    /// <summary>
    /// 点，包含一个经度、纬度
    /// </summary>
    public class PointLocation
    {
        public PointLocation(double lng, double lat)
        {
            longitude = lng;
            latitude = lat;
        }
        public PointLocation()
        {
        }
        double longitude, latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
    }
}

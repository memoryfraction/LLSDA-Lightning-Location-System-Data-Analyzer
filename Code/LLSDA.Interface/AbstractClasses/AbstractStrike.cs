/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Interface
{
    /// <summary>
    /// 包含闪击：时间、经度、纬度 || DateTime,  Longitude ,  Latitude
    /// </summary>
    public abstract class AbstractStrike_Basic
    {
        public string ID { get; set;  }
        public DateTime DateAndTime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public abstract AbstractStrike_Standard ConvertToIStrike_Standard();
    }

    public abstract class AbstractStrike_CompactEdition : AbstractStrike_Basic
    {
        public LightningType LightningType { get; set; }
    }

    public abstract class AbstractStrike_Standard : AbstractStrike_CompactEdition
    {
        public double Slope { get; set; }
        public double Error { get; set; }
        public string LocationMode { get; set; }
        public double Intensity { get; set; }
        public new LightningType LightningType
        {
            get
            {
                if (Intensity > 0) return LightningType.Positive;
                else if (Intensity < 0) return LightningType.Negative;
                else throw new ArgumentOutOfRangeException("Invalid 0 intensity.");
            }
            set { LightningType = value; }
        }
        public abstract AbstractStrike_Basic ConvertThisToStrikeBasic();
        public abstract AbstractStrike_China ConvertThisToStrikeChina();
    }

    public abstract class AbstractStrike_China : AbstractStrike_Standard
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
    }

}

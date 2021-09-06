/*****************************************************************

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
    public abstract class BaseStrikeBasic
    {
        public string ID { get; set;  }
        public DateTime DateAndTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public abstract BaseStrikeStandard ConvertToIStrike_Standard();
    }

    public abstract class BaseStrikeCompactEdition : BaseStrikeBasic
    {
        public LightningType LightningType { get; set; }
    }

    public abstract class BaseStrikeStandard : BaseStrikeCompactEdition
    {
        public double Slope { get; set; }
        public double Error { get; set; }
        public string LocationMode { get; set; }
        public double Intensity { get; set; }
        public abstract BaseStrikeBasic ConvertThisToStrikeBasic();
        public abstract BaseStrikeChina ConvertThisToStrikeChina();
    }

    public abstract class BaseStrikeChina : BaseStrikeStandard
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
    }

}

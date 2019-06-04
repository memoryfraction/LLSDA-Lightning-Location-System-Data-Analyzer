/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License Desc: https://creativecommons.org/licenses/by-nc-nd/3.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    /// <summary>
    /// 包含闪击：时间、经度、纬度 | Date  Longitude Latitude
    /// </summary>
    public interface IStrike_Basic
    {
        
        DateTime DateAndTime { get; set; }
        
        double Latitude { get; set; }
        
        double Longitude { get; set; }
        IStrike_Standard ConvertToIStrike_Standard();
    }

    public interface IStrike_Intensity : IStrike_Basic
    {
        
        double Intensity { get; set; }
    }

    public interface IStrike_Standard : IStrike_Intensity
    {
        
        double Slope { get; set; }
        
        double Error { get; set; }
        
        string LocationMode { get; set; }
        LightningStrike_Basic ConvertThisToStrikeBasic();
        LightningStrike_China ConvertThisToStrikeChina();
        LightningStrike_Standard ConvertThisToStrikeStandard();
    }
}

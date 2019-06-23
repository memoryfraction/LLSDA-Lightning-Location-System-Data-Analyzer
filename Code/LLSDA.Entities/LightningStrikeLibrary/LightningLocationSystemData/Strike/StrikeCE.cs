/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public class LightningStrikeCE
    {
        public LightningStrikeCE() { }
        public LightningStrikeCE(DateTime datetime, double lng, double lat, LightningType strikeType)
        {
            Longitude = lng;
            Latitude = lat;
            LightningType = strikeType;
            DateTime = datetime;
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public LightningType LightningType { get; set; }
        public DateTime DateTime { get; set; }
    }
}

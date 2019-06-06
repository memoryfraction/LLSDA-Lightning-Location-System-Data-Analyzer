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

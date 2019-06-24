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
    public class LightningStrike_CompactEdition : AbstractStrike_CompactEdition
    {
        public LightningStrike_CompactEdition() { }
        public LightningStrike_CompactEdition(DateTime datetime, double lng, double lat, LightningType strikeType)
        {
            this.Longitude = lng;
            this.Latitude = lat;
            this.LightningType = strikeType;
            this.DateAndTime = datetime;
        }
        //public double Longitude { get; set; }
        //public double Latitude { get; set; }
        //public LightningType LightningType { get; set; }
        //public DateTime DateTime { get; set; }

        //应该把所有的转换放在服务层，然后通过Interface注入的方式来实现; 1 集中化管理； 2 方便维护; 
        public override AbstractStrike_Standard ConvertToIStrike_Standard()
        {
            var strike = new LightningStrike_Standard() {
                ID = this.ID,
                DateAndTime = this.DateAndTime,
                Longitude = this.Longitude,
                Latitude = this.Latitude,
                LightningType = this.LightningType
            };
            return strike;
        }
    }
}

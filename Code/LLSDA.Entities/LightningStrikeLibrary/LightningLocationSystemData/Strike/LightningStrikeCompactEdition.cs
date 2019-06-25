/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public class LightningStrikeCompactEdition : BaseStrikeCompactEdition
    {
        public LightningStrikeCompactEdition() { }
        public LightningStrikeCompactEdition(DateTime datetime, double lng, double lat, LightningType strikeType)
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
        public override BaseStrikeStandard ConvertToIStrike_Standard()
        {
            var strike = new LightningStrikeStandard() {
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

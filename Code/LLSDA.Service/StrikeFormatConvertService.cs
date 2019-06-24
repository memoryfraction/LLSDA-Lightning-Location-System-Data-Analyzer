using LLSDA.Entities;
using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Service
{
    public class StrikeFormatConvertService : IStrikeFormatConvertService
    {
        public AbstractStrike_Standard ConvertBasicStrikToStandard(AbstractStrike_Basic strike)
        {
            var res = new LightningStrike_Standard() {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public AbstractStrike_Basic ConvertChineseStrikToBasic(AbstractStrike_China strike)
        {
            var res = new LightningStrike_Basic()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public AbstractStrike_Standard ConvertChineseStrikToStandard(AbstractStrike_China strike)
        {
            var res = new LightningStrike_Standard()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude,
                Intensity = strike.Intensity,
                Slope = strike.Slope,
                Error = strike.Error,
                LocationMode = strike.LocationMode,
                LightningType = strike.LightningType
            };
            return res;
        }

        public AbstractStrike_Basic ConvertStandardStrikToBasic(AbstractStrike_Standard strike)
        {
            var res = new LightningStrike_Basic()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public AbstractStrike_China ConvertStandardStrikToChina(AbstractStrike_Standard strike)
        {
            var res = new LightningStrike_China()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude,
                Intensity = strike.Intensity,
                Slope = strike.Slope,
                Error = strike.Error,
                LocationMode = strike.LocationMode,
                LightningType = strike.LightningType
            };
            return res;
        }
    }
}

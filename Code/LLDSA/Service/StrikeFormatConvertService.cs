using LLSDA.Entities;
using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Service
{
    public class StrikeFormatConvertService : IStrikeFormatConvertService
    {
        public BaseStrikeStandard ConvertBasicStrikToStandard(BaseStrikeBasic strike)
        {
            var res = new LightningStrikeStandard() {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public BaseStrikeBasic ConvertChineseStrikToBasic(BaseStrikeChina strike)
        {
            var res = new LightningStrikeBasic()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public BaseStrikeStandard ConvertChineseStrikToStandard(BaseStrikeChina strike)
        {
            var res = new LightningStrikeStandard()
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

        public BaseStrikeBasic ConvertStandardStrikToBasic(BaseStrikeStandard strike)
        {
            var res = new LightningStrikeBasic()
            {
                ID = strike.ID,
                DateAndTime = strike.DateAndTime,
                Longitude = strike.Longitude,
                Latitude = strike.Latitude
            };
            return res;
        }

        public BaseStrikeChina ConvertStandardStrikToChina(BaseStrikeStandard strike)
        {
            var res = new LightningStrikeChina()
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

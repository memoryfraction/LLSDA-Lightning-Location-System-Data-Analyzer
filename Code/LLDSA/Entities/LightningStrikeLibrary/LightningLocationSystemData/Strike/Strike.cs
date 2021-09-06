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
    
    public class LightningStrikeBasic : BaseStrikeBasic
    {
        private IStrikeFormatConvertService iStrikeFormatConvertService;
        public LightningStrikeBasic(IStrikeFormatConvertService _iStrikeFormatConvertService)
        {
            IStrikeFormatConvertService = _iStrikeFormatConvertService;
        }
        public LightningStrikeBasic() { }

        public LightningStrikeBasic(DateTime dateTime, double longitude, double latitude)
        {
            this._DateAndTime = dateTime;
            this._Longitude = longitude;
            this._Latitude = latitude;
        }

        string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private DateTime _DateAndTime;

        public DateTime DateAndTime
        {
            get { return _DateAndTime; }
            set { _DateAndTime = value; }
        }

        private double _Latitude;

        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        private double _Longitude;

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        public IStrikeFormatConvertService IStrikeFormatConvertService { get => iStrikeFormatConvertService; set => iStrikeFormatConvertService = value; }

        public override BaseStrikeStandard ConvertToIStrike_Standard()
        {
            BaseStrikeStandard strike = new LightningStrikeStandard()
            {
                ID = this.ID,
                DateAndTime = this.DateAndTime,
                Longitude = this.Longitude,
                Latitude = this.Latitude
            };
            return strike;
        }

        public override string ToString()
        {
            return "DateTime: " + this._DateAndTime.ToString() + "\r\n"
                + "Longitude: " + _Longitude.ToString() + "\r\n"
                + "Latitude" + _Latitude.ToString() + "\r\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LightningStrikeBasic))
                return false;
            else
            {
                LightningStrikeBasic o = new LightningStrikeBasic();
                o = (LightningStrikeBasic)obj;
                if (o.DateAndTime == this.DateAndTime && o.Latitude == this.Latitude && o.Longitude == this.Longitude)
                    return true;
                else
                    return false;
            }
        }
        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                + 19 * this.Longitude.GetHashCode()
                + 23 * this.Latitude.GetHashCode();
        }

        
    }

    
    public class LightningStrikeStandard : BaseStrikeStandard
    {
        private IStrikeFormatConvertService iStrikeFormatConvertService;
        public LightningStrikeStandard(IStrikeFormatConvertService _iStrikeFormatConvertService)
        {
            IStrikeFormatConvertService = _iStrikeFormatConvertService;
        }
        public LightningStrikeStandard() { }

        //public LightningStrike_Standard(DateTime dateTime, double longitude, double latitude, double intensity) : base(dateTime, longitude, latitude)
        //{
        //    this.Intensity = intensity;
        //}

        //private double _Intensity;
        //public double Intensity
        //{
        //    get { return _Intensity; }
        //    set { _Intensity = value; }
        //}
        //private double _Slope;
        //public double Slope
        //{
        //    get { return _Slope; }
        //    set { _Slope = value; }
        //}
        //private double _Error;
        //public double Error
        //{
        //    get { return _Error; }
        //    set { _Error = value; }
        //}

        //private string _LocationMode;
        //public string LocationMode
        //{
        //    get { return _LocationMode; }
        //    set { _LocationMode = value; }
        //}

        public IStrikeFormatConvertService IStrikeFormatConvertService { get => iStrikeFormatConvertService; set => iStrikeFormatConvertService = value; }

        public override BaseStrikeBasic ConvertThisToStrikeBasic()
        {
            return iStrikeFormatConvertService.ConvertStandardStrikToBasic(this);
        }

        public override BaseStrikeStandard ConvertToIStrike_Standard()
        {
            return this;
        }


        /// <summary>
        /// Need shp Gis file to support, if fail return null;
        /// 需要地图支持，如果失败，则返回null
        /// </summary>
        /// <returns></returns>
        public override BaseStrikeChina ConvertThisToStrikeChina()
        {
            return iStrikeFormatConvertService.ConvertStandardStrikToChina(this);
        }


        public override string ToString()
        {
            return "DateTime: " + this.DateAndTime.ToString() + "\r\n"
                + "Longitude: " + base.Longitude.ToString() + "\r\n"
                + "Latitude" + this.Latitude.ToString() + "\r\n"
                + "Intensity" + this.Intensity.ToString() + "\r\n"
                + "Slope" + this.Slope.ToString() + "\r\n"
                + "Error" + this.Error.ToString() + "\r\n"
                + "LocationMode" + this.LocationMode.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LightningStrikeStandard))
                return false;
            else
            {
                LightningStrikeStandard o = new LightningStrikeStandard();
                o = (LightningStrikeStandard)obj;
                if (o.DateAndTime == this.DateAndTime && o.Latitude == this.Latitude && o.Longitude == this.Longitude && o.Intensity == this.Intensity)
                    return true;
                else
                    return false;
            }
        }


        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                + 19 * this.Longitude.GetHashCode()
                + 23 * this.Latitude.GetHashCode()
                + 29 * this.Slope.GetHashCode()
                + 31 * this.Error.GetHashCode()
                + 37 * this.Intensity.GetHashCode();
        }

        
    }


    public class LightningStrikeWwlln : LightningStrikeBasic
    {
        double error;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }
        string locationMode;

        public string LocationMode
        {
            get { return locationMode; }
            set { locationMode = value; }
        }
        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                + 19 * this.Longitude.GetHashCode()
                + 23 * this.Latitude.GetHashCode()
                + 29 * this.error.GetHashCode();
        }
    }


    public class LightningStrikeChina : BaseStrikeChina
    {
        private IStrikeFormatConvertService iStrikeFormatConvertService;
        public LightningStrikeChina(IStrikeFormatConvertService _iStrikeFormatConvertService)
        {
            IStrikeFormatConvertService = _iStrikeFormatConvertService;
        }

        public LightningStrikeChina() { }

        //public LightningStrike_China(DateTime dateTime, double longitude, double latitude, double intensity)
        //    : base(dateTime, longitude, latitude, intensity) { }

        private string _Province;
        public string Province
        {
            get { return _Province; }
            set { _Province = value; }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _District;
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }

        /// <summary>
        /// 拥有省市县完整信息
        /// </summary>
        bool withFullLocation = false;
        public bool WithFullLocation
        {
            get { JudgeWhetherWithLocation(); return withFullLocation; }
        }

        public IStrikeFormatConvertService IStrikeFormatConvertService { get => iStrikeFormatConvertService; set => iStrikeFormatConvertService = value; }

        private void JudgeWhetherWithLocation()
        {
            bool withProvince = this._Province != string.Empty;
            bool withCity = this._City != string.Empty;
            bool withDistrict = this._District != string.Empty;
            if (withProvince && withCity && withDistrict)
            {
                withFullLocation = true;
            }
            else
                withFullLocation = false;
        }


        public override string ToString()
        {
            return "DateTime: " + this.DateAndTime.ToString() + "\r\n"
                + "Longitude: " + base.Longitude.ToString() + "\r\n"
                + "Latitude" + this.Latitude.ToString() + "\r\n"
                + "Intensity" + this.Intensity.ToString() + "\r\n"
                + "Slope" + this.Slope.ToString() + "\r\n"
                + "Error" + this.Error.ToString() + "\r\n"
                + "LocationMode" + this.LocationMode.ToString() + "\r\n"
                + "Province" + this.Province.ToString() + "\r\n"
                + "City" + this.City.ToString() + "\r\n"
                + "Country" + this.District.ToString();
        }


        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                + 19 * this.Longitude.GetHashCode()
                + 23 * this.Latitude.GetHashCode()
                + 29 * this.Slope.GetHashCode()
                + 31 * this.Error.GetHashCode()
                + 37 * this.Intensity.GetHashCode()

                + 43 * this.Province.GetHashCode()
                + 47 * this.City.GetHashCode()
                + 51 * this.District.GetHashCode();
        }

        public override BaseStrikeBasic ConvertThisToStrikeBasic()
        {
            return iStrikeFormatConvertService.ConvertChineseStrikToBasic(this);
        }

        public override BaseStrikeChina ConvertThisToStrikeChina()
        {
            return this;
        }

        public override BaseStrikeStandard ConvertToIStrike_Standard()
        {
            return iStrikeFormatConvertService.ConvertChineseStrikToStandard(this);
        }
    }
}

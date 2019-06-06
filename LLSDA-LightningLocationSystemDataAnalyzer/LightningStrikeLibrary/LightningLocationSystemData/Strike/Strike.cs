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
    
    public class LightningStrike_Basic
    {
        public LightningStrike_Basic() { }
        public LightningStrike_Basic(DateTime dateTime, double longitude, double latitude)
        {
            this._DateAndTime = dateTime;
            this._Longitude = longitude;
            this._Latitude = latitude;
        }

        long _ID;

        public long ID
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
        public LightningStrike_Standard ConvertToIStrike_Standard()
        {
            var strikeStandard = new LightningStrike_Standard();
            strikeStandard.DateAndTime = this.DateAndTime;
            strikeStandard.Longitude = this.Longitude;
            strikeStandard.Latitude = this.Latitude;
            return strikeStandard;
        }
        public override string ToString()
        {
            return "DateTime: " + this._DateAndTime.ToString() + "\r\n"
                + "Longitude: " + _Longitude.ToString() + "\r\n"
                + "Latitude" + _Latitude.ToString() + "\r\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LightningStrike_Basic))
                return false;
            else
            {
                LightningStrike_Basic o = new LightningStrike_Basic();
                o = (LightningStrike_Basic)obj;
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

    
    public class LightningStrike_Standard : LightningStrike_Basic
    {
        public LightningStrike_Standard() { }

        public LightningStrike_Standard(DateTime dateTime, double longitude, double latitude, double intensity) : base(dateTime, longitude, latitude)
        {
            this.Intensity = intensity;
        }

        private double _Intensity;
        public double Intensity
        {
            get { return _Intensity; }
            set { _Intensity = value; }
        }
        private double _Slope;
        public double Slope
        {
            get { return _Slope; }
            set { _Slope = value; }
        }
        private double _Error;
        public double Error
        {
            get { return _Error; }
            set { _Error = value; }
        }

        private string _LocationMode;
        public string LocationMode
        {
            get { return _LocationMode; }
            set { _LocationMode = value; }
        }

        public LightningStrike_Basic ConvertThisToStrikeBasic()
        {
            LightningStrike_Basic strikeBasic = new LightningStrike_Basic();
            strikeBasic.DateAndTime = this.DateAndTime;
            strikeBasic.Longitude = this.Longitude;
            strikeBasic.Latitude = this.Latitude;
            return strikeBasic;
        }

        public LightningStrike_Standard ConvertThisToStrikeStandard()
        {
            LightningStrike_Standard strikeStandard = new LightningStrike_Standard();
            strikeStandard.DateAndTime = this.DateAndTime;
            strikeStandard.Intensity = this.Intensity;
            strikeStandard.Longitude = this.Longitude;
            strikeStandard.Latitude = this.Latitude;
            strikeStandard.Slope = this.Slope;
            strikeStandard.Error = this.Error;
            strikeStandard.LocationMode = this.LocationMode;
            return strikeStandard;
        }

        /// <summary>
        /// Need shp Gis file to support, if fail return null;
        /// 需要地图支持，如果失败，则返回null
        /// </summary>
        /// <returns></returns>
        public LightningStrike_China ConvertThisToStrikeChina()
        {
            LightningStrike_China strikeChina = new LightningStrike_China();
            strikeChina.DateAndTime = this.DateAndTime;
            strikeChina.Longitude = this.Longitude;
            strikeChina.Latitude = this.Latitude;
            strikeChina.Intensity = this.Intensity;
            strikeChina.Slope = strikeChina.Slope;
            strikeChina.Error = strikeChina.Error;
            strikeChina.LocationMode = strikeChina.LocationMode;
            //JudgeLocationClass.SourceMapPathFile = AppDomain.CurrentDomain.BaseDirectory + @"\Map\中国地图\CHN_adm3.shp";
            //if (File.Exists(JudgeLocationClass.SourceMapPathFile))
            //{
            //    Location location = JudgeLocationClass.JudgeLocation(this.Longitude, this.Latitude);
            //    strikeChina.Province = location.Province;
            //    strikeChina.City = location.City;
            //    strikeChina.District = location.Distinct;              
            //}
            //else
            //    Console.WriteLine(@"shp文件不存在，请检查\Map\中国地图\CHN_adm3.shp是否存在。");
            return strikeChina;
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
            if (obj == null || !(obj is LightningStrike_Standard))
                return false;
            else
            {
                LightningStrike_Standard o = new LightningStrike_Standard();
                o = (LightningStrike_Standard)obj;
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


    public class LightningStrike_Wwlln : LightningStrike_Basic
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


    public class LightningStrike_China : LightningStrike_Standard
    {
        public LightningStrike_China() { }

        public LightningStrike_China(DateTime dateTime, double longitude, double latitude, double intensity)
            : base(dateTime, longitude, latitude, intensity) { }

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

        public new LightningStrike_Standard ConvertThisToStrikeStandard()
        {
            LightningStrike_Standard strikeStandard = new LightningStrike_Standard();
            strikeStandard.DateAndTime = this.DateAndTime;
            strikeStandard.Intensity = this.Intensity;
            strikeStandard.Longitude = this.Longitude;
            strikeStandard.Latitude = this.Latitude;
            strikeStandard.Slope = this.Slope;
            strikeStandard.Error = this.Error;
            strikeStandard.LocationMode = this.LocationMode;
            return strikeStandard;
        }


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

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || !(obj is LightningStrike_China))
        //        return false;
        //    else
        //    {
        //        LightningStrike_China o = new LightningStrike_China();
        //        if (o.DateAndTime == this.DateAndTime && o.Latitude == this.Latitude && o.Longitude == this.Longitude)
        //            return true;
        //        else
        //            return false;
        //    }
        //}

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

    }
}

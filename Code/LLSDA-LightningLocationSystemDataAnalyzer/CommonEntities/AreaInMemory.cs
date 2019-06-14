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
    public class AreaInMemory
    {
        bool _Existed;
        int _ID, _ProvinceID;
        DateTime _MinDateTime, _MaxDateTime;
        string _Name, _ParentName;
        AdministrativeLevel _AdministrativeLevelEnum;
        string _ProvinceName, _CityName, _DistrictName;
        double _MinLongitude, _MaxLongitude, _MinLatitude, _MaxLatitude, _CenterLongitude, _CenterLatitude, _Size;

        
        public int ProvinceID
        {
            get { return _ProvinceID; }
            set { _ProvinceID = value; }
        }

        
        public double MaxLongitude
        {
            get { return _MaxLongitude; }
            set { _MaxLongitude = value; }
        }

        
        public double CenterLatitude
        {
            get { return _CenterLatitude; }
            set { _CenterLatitude = value; }
        }

        
        public double CenterLongitude
        {
            get { return _CenterLongitude; }
            set { _CenterLongitude = value; }
        }

        
        public double MaxLatitude
        {
            get { return _MaxLatitude; }
            set { _MaxLatitude = value; }
        }

        
        public double MinLatitude
        {
            get { return _MinLatitude; }
            set { _MinLatitude = value; }
        }

        
        public double MinLongitude
        {
            get { return _MinLongitude; }
            set { _MinLongitude = value; }
        }
        /// <summary>
        /// 根据行政级别，如果为省级、市级，此项内容为空
        /// </summary>
        
        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }


        /// <summary>
        /// 如果为省级，此项内容为空。
        /// </summary>
        
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        
        public string ProvinceName
        {
            get { return _ProvinceName; }
            set { _ProvinceName = value; }
        }


        
        public AdministrativeLevel AdministrativeLevelEnum
        {
            get { return _AdministrativeLevelEnum; }
            set { _AdministrativeLevelEnum = value; }
        }
        /// <summary>
        /// 单位：平方公里||unit：sq km
        /// </summary>
        
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        /// <summary>
        /// 编号|ID
        /// </summary>
        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        
        public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; }
        }
        /// <summary>
        /// 行政区名称
        /// </summary>
        
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 本地区是否存在记录（仅针对省份）
        /// </summary>
        
        public bool Existed
        {
            get { return _Existed; }
            set { _Existed = value; }
        }
        /// <summary>
        /// 本地区最晚地闪日期时间(仅针对省份)
        /// </summary>
        
        public DateTime MaxDateTime
        {
            get { return _MaxDateTime; }
            set { _MaxDateTime = value; }
        }
        /// <summary>
        /// 本地区最早地闪日期时间(仅针对省份)
        /// </summary>
        
        public DateTime MinDateTime
        {
            get { return _MinDateTime; }
            set { _MinDateTime = value; }
        }
    }
}

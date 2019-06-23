/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/


using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public class ObservationStation
    {
        int stationID, areaID;
        double stationLongitude, stationLatitude, tdValue;
        string stationName, province;
        
        public int AreaID
        {
            get { return areaID; }
            set { areaID = value; }
        }

        
        public int StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }

        
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        
        public string StationName
        {
            get { return stationName; }
            set { stationName = value; }
        }

        
        public double TdValue
        {
            get { return tdValue; }
            set { tdValue = value; }
        }
        
        public double StationLatitude
        {
            get { return stationLatitude; }
            set { stationLatitude = value; }
        }
        
        public double StationLongitude
        {
            get { return stationLongitude; }
            set { stationLongitude = value; }
        }

    }
}

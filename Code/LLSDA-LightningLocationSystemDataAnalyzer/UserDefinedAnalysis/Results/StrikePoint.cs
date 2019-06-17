using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    /* 闪电点 */
    
    
    public class StrikePoint
    {
        public StrikePoint() { }

         
        public StrikePoint(double lng, double lat)
        {
            this.lng = lng;
            this.lat = lat;
        }

        private long id;

        private int intensityType;

        private double lng;

        private double lat;
         
        public long ID
        {
            get { return id; }
            set { id = value; }
        }
         
        public int IntensityType
        {
            get { return intensityType; }
            set { intensityType = value; }
        }
         
        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }
         
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }
    }
}

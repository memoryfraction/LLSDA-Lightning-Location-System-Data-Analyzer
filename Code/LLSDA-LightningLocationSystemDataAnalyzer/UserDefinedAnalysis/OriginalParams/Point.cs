using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    /* 点 */
    
    public class Point
    {
        public Point() { }

        public Point(double lng, double lat)
        {
            this.lng = lng;
            this.lat = lat;
        }

        private double lng;

        private double lat;
        
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

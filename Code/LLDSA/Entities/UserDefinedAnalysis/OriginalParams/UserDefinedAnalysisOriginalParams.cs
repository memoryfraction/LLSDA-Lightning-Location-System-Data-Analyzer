using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    
    
    public class UserDefinedAnalysisOriginalParams: IUserDefinedAnalysisOriginalParams
    {
        DateTimePeriod dateTimePeriod = new DateTimePeriod();      
        List<UserDefinedShape> userDefinedShapes=new List<UserDefinedShape> ();
        double minLng, minLat, maxLng, maxLat;
       
        public double MaxLat
        {
            get 
            {
                if (userDefinedShapes.Any() && maxLat==0)
                    maxLat = userDefinedShapes.Select(r => r.MaxLatitude).Max();
                return maxLat; 
            }
            set { maxLat = value; }
        }

        public double MaxLng
        {
            get
            {
                if (userDefinedShapes.Any() && maxLng == 0)
                    maxLng = userDefinedShapes.Select(r => r.MaxLongitude).Max();
                return maxLng; 
            }
            set { maxLng = value; }
        }

        public double MinLat
        {
            get
            {
                if (userDefinedShapes.Any() && minLat==0)
                    minLat = userDefinedShapes.Select(r => r.MinLatitude).Min();
                return minLat;
            }
            set { minLat = value; }
        }

        public double MinLng
        {
            get
            {
                if (userDefinedShapes.Any() && minLng==0)
                    minLng = userDefinedShapes.Select(r => r.MinLongitude).Min();
                return minLng;
            }
            set { minLng = value; }
        }

        
        public List<UserDefinedShape> UserDefinedShapes
        {
            get { return userDefinedShapes; }
            set { userDefinedShapes = value; }
        }

        
        public DateTimePeriod DateTimePeriod
        {
            get { return dateTimePeriod; }
            set { dateTimePeriod = value; }
        }
    }


    
}

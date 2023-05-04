using LLSDA.Entities;

namespace LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike
{
    public class LightningStrike_WWLLN : LightningStrikeBasic
    {
        /*
          Date and time are in UTC
          Lat, long in Fractional Degrees
          Resid is the residual fit error in micrfoseconds (always < 30 microseconds)
          Nsta is the number of WWLLN stations which detected the stroke (alway >5)
          Energy (J)  - RMS energy from 7 to 17 kHz in 1.3 ms sample time
          energy uncertainty (J) 
          nstn_power - subset of Nsta within the range 1000 to 8000 km distant from strok and used for power estimate
          
          More Questions?  
          Contact Prof. Robert Holzworth, Director of WWLLN, and Professor of Earth and Space Sciences
          University of Washington, Box 351310, Seattle, WA 98195   (bobholz@uw.edu)
         */

        public double Resid { get; set; }

        public double Nsta { get; set; }

        public double PowerkW { get; set; }

        public double PowerUncertaintyKw { get; set; }

        public double NstnPower { get; set; }


        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                   + 19 * this.Longitude.GetHashCode()
                   + 23 * this.Latitude.GetHashCode()
                   + 29 * this.Resid.GetHashCode();
        }
    }
}

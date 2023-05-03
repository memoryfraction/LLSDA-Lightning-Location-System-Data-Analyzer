using LLSDA.Entities;

namespace LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike
{
    public class LightningStrike_GLD360 : LightningStrikeBasic
    {
        public double PeakCurrent { get; set; }
        public double DegreeFreedom { get; set; }
        public double EllipseAngle { get; set; }
        public double EclipseSemimajorAxis { get; set; }
        public double EllipseSemiminorAxis { get; set; }
        public double Chisq { get; set; }
        public double RiseTime { get; set; }
        public double Peak2Zero { get; set; }
        public double MaxRateRise { get; set; }
        public double Sensors { get; set; }
        public bool Cloud { get; set; }


        public override int GetHashCode()
        {
            return 17 * this.DateAndTime.GetHashCode()
                   + 19 * this.Longitude.GetHashCode()
                   + 23 * this.Latitude.GetHashCode()
                   + 29 * this.PeakCurrent.GetHashCode();
        }
    }
}

using LLSDA.Entities;

namespace LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike
{
    public class LightningStrike_Wwlln : LightningStrikeBasic
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
}

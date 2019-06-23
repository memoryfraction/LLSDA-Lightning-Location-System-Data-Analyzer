using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
    public class UserDefinedAnalysisResult : CommonAbstractResults
    {
        public UserDefinedAnalysisResult()
        {
            strikesChina = new List<LightningStrike_China>();
        }

        List<LightningStrike_China> strikesChina;

        [JsonIgnore]
        public List<LightningStrike_China> StrikesChina
        {
            get { return strikesChina; }
            set { strikesChina = value; }
        }


    }
}

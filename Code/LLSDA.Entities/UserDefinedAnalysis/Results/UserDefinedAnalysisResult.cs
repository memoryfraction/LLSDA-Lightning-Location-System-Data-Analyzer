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
            strikesChina = new List<LightningStrikeChina>();
        }

        List<LightningStrikeChina> strikesChina;

        [JsonIgnore]
        public List<LightningStrikeChina> StrikesChina
        {
            get { return strikesChina; }
            set { strikesChina = value; }
        }


    }
}

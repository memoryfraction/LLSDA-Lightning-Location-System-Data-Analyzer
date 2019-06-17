using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    public interface IUserDefinedAnalysisOriginalParams
    {
        List<UserDefinedShape> UserDefinedShapes
        {
            get;
            set;
        }

        DateTimePeriod DateTimePeriod { get; set; }
    }
}

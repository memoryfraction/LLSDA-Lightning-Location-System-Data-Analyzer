using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LLSDA.Entities;
using LLSDA.Interface;

namespace LLDSA.Entities.FileOperator.LLSFileProcessor
{
    public abstract class LlsFileProcessor
    {
        //todo 
        public LlsFileProcessor() { }

        public abstract List<BaseStrikeCompactEdition> ReturnStrikes();

    }
}

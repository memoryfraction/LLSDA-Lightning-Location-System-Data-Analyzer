using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Interface
{
    public  interface IStrikeFormatConvertService
    {
        BaseStrikeStandard ConvertBasicStrikToStandard(BaseStrikeBasic strike);
        BaseStrikeBasic ConvertStandardStrikToBasic(BaseStrikeStandard strike);
        BaseStrikeChina ConvertStandardStrikToChina(BaseStrikeStandard strike);
        BaseStrikeBasic ConvertChineseStrikToBasic(BaseStrikeChina strike);
        BaseStrikeStandard ConvertChineseStrikToStandard(BaseStrikeChina strike);
    }
}

using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Interface
{
    public  interface IStrikeFormatConvertService
    {
        AbstractStrike_Standard ConvertBasicStrikToStandard(AbstractStrike_Basic strike);
        AbstractStrike_Basic ConvertStandardStrikToBasic(AbstractStrike_Standard strike);
        AbstractStrike_China ConvertStandardStrikToChina(AbstractStrike_Standard strike);
        AbstractStrike_Basic ConvertChineseStrikToBasic(AbstractStrike_China strike);
        AbstractStrike_Standard ConvertChineseStrikToStandard(AbstractStrike_China strike);
    }
}

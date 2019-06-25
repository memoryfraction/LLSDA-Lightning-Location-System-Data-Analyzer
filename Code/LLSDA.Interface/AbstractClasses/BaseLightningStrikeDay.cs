/*****************************************************************
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Interface
{
    public abstract class BaseLightningStrikeDay
    {
        public DateTime DateTime { get; set; }
        public string AdministrativeRegionName { get; set; }
    }
}

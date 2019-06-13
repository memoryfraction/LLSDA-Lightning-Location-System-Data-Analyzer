/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LLSDA.Entities
{
    public class ResultElement
    {
        double longitude, latitude, value;
        Color color;

        
        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }



    }
}

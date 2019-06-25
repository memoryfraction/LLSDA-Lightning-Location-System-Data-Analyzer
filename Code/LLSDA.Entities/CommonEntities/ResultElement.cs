/*****************************************************************

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

        public Color Color { get => color; set => color = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Value { get => value; set => this.value = value; }
    }
}

/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public class AngleClass
    {
        /// <summary>
        /// 输入两个点A（x1,y1）,点B（x2,y2）。计算向量AB从y轴算起的角度。-pi到pi。
        /// </summary>
        /// <param name="_x1">A点经度</param>
        /// <param name="_y1">A点纬度</param>
        /// <param name="_x2">B点经度</param>
        /// <param name="_y2">B点纬度</param>
        /// <returns>计算向量AB从y轴算起顺时针的角度(弧度制)。范围：1象限：(0,pi/2);2象限(pi/2,pi);3象限(-pi,-pi/2);4象限(-pi/2,0)</returns>
        public static double CalcueAngle(double _x1, double _y1, double _x2, double _y2)
        {
            //double pi = 360;
            //角度0-360度 | [0,360]
            double resultAngle = 0;
            double yDifference, xDifference;
            xDifference = _x2 - _x1;
            yDifference = _y2 - _y1;
            //double tanX = yDifference / xDifference;
            resultAngle = Math.Atan2(yDifference, xDifference);
            return resultAngle;
        }

        /// <summary>
        /// 输入AB向量角度(弧度制)，范围：满足(-pi,pi)。
        /// input AB Vector angles in radians; range: (-pi,pi)
        /// </summary>
        /// <returns></returns>
        public static LightningStrikeDirectionEnum GetLightningStrikeDirection(double _angle)
        {
            try
            {
                LightningStrikeDirectionEnum result = LightningStrikeDirectionEnum.North;//默认值
                if ((_angle >= (-1.0 / 8.0) * Math.PI && _angle < 0) || (_angle >= 0 && _angle < Math.PI * (1.0 / 8.0)))
                    result = LightningStrikeDirectionEnum.East;
                else if (_angle >= (1.0 / 8.0) * Math.PI && _angle < (3.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.NorthEast;
                else if (_angle >= (3.0 / 8.0) * Math.PI && _angle < (5.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.North;
                else if (_angle >= (5.0 / 8.0) * Math.PI && _angle < (7.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.NorthWest;
                else if ((_angle >= (7.0 / 8.0) * Math.PI && _angle <= Math.PI) || (_angle >= -Math.PI && _angle < (-7.0 / 8.0) * Math.PI))
                    result = LightningStrikeDirectionEnum.West;
                else if (_angle >= (-7.0 / 8.0) * Math.PI && _angle < (-5.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.SouthWest;
                else if (_angle >= (-5.0 / 8.0) * Math.PI && _angle < (-3.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.South;
                else if (_angle >= (-3.0 / 8.0) * Math.PI && _angle < (-1.0 / 8.0) * Math.PI)
                    result = LightningStrikeDirectionEnum.SouthEast;
                else
                    throw new ArgumentOutOfRangeException("Angle out of range");
                return result;
            }
            catch { throw; }
        }
    }
}

/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    public class LongitudeOrLatitude
    {
        double degree, minute, second, valueInMemory;


        public LongitudeOrLatitude()
        { }

        public LongitudeOrLatitude(double _value)
        { valueInMemory = _value; ValueToDegreeMinuteSecond(); }


        public LongitudeOrLatitude(double _degree, double _minute, double _second)
        {
            degree = _degree;
            minute = _minute;
            second = _second;
            DegreeMinuteSecondToValue();
        }


        

        public double Value
        {
            get { return valueInMemory; }
            set { valueInMemory = value; }
        }
        
        public double Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        
        public double Minute
        {
            get { return minute; }
            set { minute = value; }
        }
        
        public double Second
        {
            get { return second; }
            set { second = value; }
        }

        /// <summary>
        /// 从值到度分秒 || value to degree, minute and second
        /// </summary>
        private void ValueToDegreeMinuteSecond()
        {
            if (valueInMemory >= -180 && valueInMemory <= 180)
            {
                int degree = (int)valueInMemory;
                double tmp = valueInMemory - (int)valueInMemory;//度数的小数部分
                int minuteInt = (int)(tmp * 60);
                double minute = Convert.ToDouble(minuteInt);
                double second = 60 * (tmp * 60 - (int)(tmp * 60));
            }
            else
                throw new ArgumentOutOfRangeException("invalid value");
        }

        /// <summary>
        /// 度分秒到值; || degree minute second to value
        /// </summary>
        private void DegreeMinuteSecondToValue()
        {
            if (degree >= -180 && degree <= 180 && minute >= -60 && minute <= 60 && second >= -60 && second <= 60)
            {
                valueInMemory = degree + minute / (double)60 + second / (double)3600;
            }
            else
                throw new ArgumentOutOfRangeException("invalid value");

        }
    }
}

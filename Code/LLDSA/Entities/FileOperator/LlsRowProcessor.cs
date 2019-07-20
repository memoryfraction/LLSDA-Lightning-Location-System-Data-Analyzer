/*****************************************************************

** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace LLSDA.Entities
{
    /// <summary>
    /// 闪电定位数据行处理器 | LLS Row Processor
    /// </summary>
    public class LlsRowProcessor
    {
        public LlsRowProcessor(string _rowText)
        {
            rowText = _rowText;
        }

        private string province;

        string srcFileName;

        private string rowText;

        private char[] curCharSeparator = new char[] { ' ' };

        public string SrcFileName
        {
            get { return srcFileName; }
            set { srcFileName = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public char[] CurCharSeparator
        {
            get { return curCharSeparator; }
            set { curCharSeparator = value; }
        }
        public string RowText
        {
            get { return rowText; }
            set { rowText = value; }
        }

        /// <summary>
        /// 输入闪电记录文本，返会拆分后对应的数组
        /// </summary>
        private string[] ProcessStrikeRecordTextToArray(string strikeRecordText, char[] charSeparators)
        {
            string[] strCurLineArray = strikeRecordText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return strCurLineArray;
        }

        /// <summary>
        /// 传入类变量curLlsRowContent,默认分隔符为' ',如需改变，调用curCharSeparator变量
        /// </summary>
        /// <param name="charSeparators"></param>
        /// <returns></returns>
        private string[] ProcessStrikeRecordTextToArray()
        {
            return ProcessStrikeRecordTextToArray(rowText, curCharSeparator);
        }

        public LightningStrikeChina ReturnStrike()
        {
            try
            {
                LightningStrikeChina strike = new LightningStrikeChina();
                //读content并获取strike
                string[] strArray = ProcessStrikeRecordTextToArray();
                strike = LlsRowFormatFactory.GetStrikeFromRowArray(strArray);
                LlsRowFormatFactory.srcFileName = srcFileName;
                return strike;
            }
            catch
            { return null; }
        }
    }


    public abstract class LlsRowProcessorFormat
    {
        public LlsRowProcessorFormat(string[] _strLineArray)
        {
            strLineArray = _strLineArray;
        }
        string[] strLineArray;
        string province;

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        string srcFileName;

        public string SrcFileName
        {
            get { return srcFileName; }
            set { srcFileName = value; }
        }


        public string[] StrLineArray
        {
            get { return strLineArray; }
            set { strLineArray = value; }
        }

        /// <summary>
        /// 获取必备信息，返回LightningStrike_China实例
        /// </summary>
        /// <returns></returns>
        protected LightningStrikeChina ReturnStrike(DateTime dt, double intensity, double slope, double error, double longitude, double latitude, string locationMode, string province, string city, string district)
        {
            LightningStrikeChina newStrike = new LightningStrikeChina();
            newStrike.DateAndTime = dt;
            newStrike.Intensity = intensity;
            newStrike.Slope = slope;
            newStrike.Error = error;
            newStrike.Longitude = longitude;
            newStrike.Latitude = latitude;
            newStrike.LocationMode = locationMode;
            newStrike.Province = province;
            newStrike.City = city;
            newStrike.District = district;
            return newStrike;
        }

        /// <summary>
        /// 对每行数据进行处理,返回地闪实例
        /// </summary>
        /// <param name="strLineArray"></param>
        /// <param name="provinceName">如“河南省”</param>
        /// <returns></returns>
        public abstract LightningStrikeChina ProcessStrikeLineReturnStrikeFormat();
    }

    /// <summary>
    /// 输入字符数组和省份ID，返回LightningStrike_China实例
    /// </summary>
    public class LlsRowFormatFactory
    {
        public static string srcFileName;
        public static LightningStrikeChina GetStrikeFromRowArray(string[] strArray)
        {
            LightningStrikeChina strike = new LightningStrikeChina();
            LlsRowProcessorFormat Lrpf;
            try
            {
                Lrpf = new LlsRowProcessorFormat1(strArray);
                return Lrpf.ProcessStrikeLineReturnStrikeFormat();
            }
            catch
            {
                try
                {
                    Lrpf = new LlsRowProcessorFormat2(strArray);
                    return Lrpf.ProcessStrikeLineReturnStrikeFormat();
                }
                catch
                {
                    try
                    {
                        Lrpf = new LlsRowProcessorFormat3(strArray);
                        return Lrpf.ProcessStrikeLineReturnStrikeFormat();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
    
    public class LlsRowProcessorFormat1 : LlsRowProcessorFormat
    {
        public LlsRowProcessorFormat1(string[] _strLineArray) : base(_strLineArray) { }

        /// <summary>
        /// 返回LightningStrike_China类型，处理出错则返回null
        /// </summary>
        /// <param name="strLineArray"></param>
        /// <returns></returns>
        public override LightningStrikeChina ProcessStrikeLineReturnStrikeFormat()
        {
            string[] strLineArray = base.StrLineArray;
            try
            {
                int year = Convert.ToInt32(strLineArray[1].Substring(0, 4));
                int month = Convert.ToInt32(strLineArray[1].Substring(5, 2));
                int day = Convert.ToInt32(strLineArray[1].Substring(8, 2));
                int hour = Convert.ToInt32(strLineArray[2].Substring(0, 2));
                int minute = Convert.ToInt32(strLineArray[2].Substring(3, 2));
                int second = Convert.ToInt32(strLineArray[2].Substring(6, 2));
                int milisecond;
                string secondString = strLineArray[2].Split(':')[2];
                string miliSecondString = secondString.Split('.')[1];
                if (miliSecondString.Length <= 3)
                    milisecond = Convert.ToInt32(miliSecondString);
                else
                    milisecond = Convert.ToInt32(miliSecondString.Substring(0, 3));
                DateTime dt = new DateTime(year, month, day, hour, minute, second, milisecond);
                double intensity = Convert.ToDouble(strLineArray[5].Substring(3));
                double slope = Convert.ToDouble(strLineArray[6].Substring(3));
                double error = Convert.ToDouble(strLineArray[7].Substring(3));
                double latitude = Convert.ToDouble(strLineArray[3].Substring(3));
                double longitude = Convert.ToDouble(strLineArray[4].Substring(3));
                string locationmode = strLineArray[8].Substring(5);
                LightningStrikeChina newLightningStrike_China;
                if (strLineArray.Length > 9)
                {
                    string province = strLineArray[9].Substring(2);
                    string city = strLineArray[10].Substring(2);
                    string district = strLineArray[11].Substring(2);
                    newLightningStrike_China = ReturnStrike(dt, intensity, slope, error, longitude, latitude, locationmode, province, city, district);
                }
                else
                    newLightningStrike_China = ReturnStrike(dt, intensity, slope, error, longitude, latitude, locationmode, string.Empty, string.Empty, string.Empty);
                return newLightningStrike_China;
            }
            catch
            {
                throw;
            }
        }
    }
    public class LlsRowProcessorFormat2 : LlsRowProcessorFormat
    {
        public LlsRowProcessorFormat2(string[] _strLineArray) : base(_strLineArray) { }

        /// <summary>
        /// 返回LightningStrike_China类型，处理出错则返回null
        /// </summary>
        /// <param name="strLineArray"></param>
        /// <returns></returns>
        public override LightningStrikeChina ProcessStrikeLineReturnStrikeFormat()
        {
            string[] strLineArray = base.StrLineArray;
            try
            {
                int year = Convert.ToInt32(strLineArray[1].Substring(0, 4));
                int month = Convert.ToInt32(strLineArray[1].Substring(5, 2));
                int day = Convert.ToInt32(strLineArray[1].Substring(8, 2));
                int hour = Convert.ToInt32(strLineArray[2].Substring(0, 2));
                int minute = Convert.ToInt32(strLineArray[2].Substring(3, 2));
                int second = Convert.ToInt32(strLineArray[2].Substring(6, 2));
                int milisecond;
                string secondString = strLineArray[2].Split(':')[2];
                string miliSecondString = secondString.Split('.')[1];
                if (miliSecondString.Length <= 3)
                    milisecond = Convert.ToInt32(miliSecondString);
                else
                    milisecond = Convert.ToInt32(miliSecondString.Substring(0, 3));
                DateTime dt = new DateTime(year, month, day, hour, minute, second, milisecond);
                double intensity = Convert.ToDouble(strLineArray[5].Substring(3));
                double slope = Convert.ToDouble(strLineArray[6].Substring(3));
                double error = Convert.ToDouble(strLineArray[7].Substring(3));
                double latitude = Convert.ToDouble(strLineArray[3].Substring(3));
                double longitude = Convert.ToDouble(strLineArray[4].Substring(3));
                string locationmode = strLineArray[8].Substring(5);
                string province = base.Province;
                string city = strLineArray[10].Substring(2);
                string district = strLineArray[11].Substring(2);

                LightningStrikeChina newLightningStrike_China = ReturnStrike(dt, intensity, slope, error, longitude, latitude, locationmode, province, city, district);
                return newLightningStrike_China;
            }
            catch
            {
                throw;
            }


        }
    }
    public class LlsRowProcessorFormat3 : LlsRowProcessorFormat
    {
        public LlsRowProcessorFormat3(string[] _strLineArray) : base(_strLineArray) { }

        /// <summary>
        /// 返回LightningStrike_China类型，处理出错则返回null
        /// </summary>
        /// <param name="strLineArray"></param>
        /// <returns></returns>
        public override LightningStrikeChina ProcessStrikeLineReturnStrikeFormat()
        {
            string[] strLineArray = base.StrLineArray;
            try
            {
                int year = Convert.ToInt32(strLineArray[1].Substring(0, 4));
                int month = Convert.ToInt32(strLineArray[2].Substring(0, 2));
                int day = Convert.ToInt32(strLineArray[3].Substring(0, 2));
                int hour = Convert.ToInt32(strLineArray[4].Substring(0, 2));
                int minute = Convert.ToInt32(strLineArray[5].Substring(0, 2));
                int second = Convert.ToInt32(strLineArray[6].Substring(0, 2));
                int milisecond;
                string miliSecondString = strLineArray[7].Substring(0, 3);
                milisecond = Convert.ToInt32(miliSecondString);
                DateTime dt = new DateTime(year, month, day, hour, minute, second, milisecond);
                double intensity = Convert.ToDouble(strLineArray[10]);
                double slope = Convert.ToDouble(strLineArray[11]);
                double error = Convert.ToDouble(strLineArray[12]);
                double latitude = Convert.ToDouble(strLineArray[8]);
                double longitude = Convert.ToDouble(strLineArray[9]);
                string locationmode = strLineArray[8].Substring(5);
                string province = base.Province;
                string city = "";
                string district = "";

                LightningStrikeChina newLightningStrike_China = ReturnStrike(dt, intensity, slope, error, longitude, latitude, locationmode, province, city, district);
                return newLightningStrike_China;
            }
            catch
            {
                throw;
            }


        }
    }
}

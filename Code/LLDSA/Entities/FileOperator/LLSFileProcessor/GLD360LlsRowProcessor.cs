/*****************************************************************
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike;
using LLSDA.Entities;

namespace LLDSA.Entities.FileOperator.LLSFileProcessor
{
    /// <summary>
    /// 闪电定位数据行处理器 | LLS Row Processor
    /// </summary>
    public class GLD360LlsRowProcessor
    {
        public GLD360LlsRowProcessor(string _rowText)
        {
            rowText = _rowText;
        }

        private string province;

        string srcFileName;

        private string rowText;

        private char[] curCharSeparator = new char[] { ',' };

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
            string[] strCurLineArray = strikeRecordText.Split(charSeparators,  StringSplitOptions.RemoveEmptyEntries);
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

        public LightningStrike_GLD360 ReturnStrike()
        {
            try
            {
                var strike = new LightningStrike_GLD360();
                // 读content并获取strike
                string[] strArray = ProcessStrikeRecordTextToArray();
                strike = new LightningStrike_GLD360();
                
                strike = ParseRowText(strArray);
                LlsRowFormatFactory.srcFileName = srcFileName;
                return strike;
            }
            catch
            {
                return null;
            }
        }


        private LightningStrike_GLD360 ParseRowText(string[] array)
        {
            var strike = new LightningStrike_GLD360();
            strike.ID = Guid.NewGuid().ToString();
            strike.DateAndTime = Convert.ToDateTime(array[0]);
            strike.Latitude = Convert.ToDouble(array[1]);
            strike.Longitude = Convert.ToDouble(array[2]);
            strike.PeakCurrent = Convert.ToDouble(array[3]);
            strike.Sensors = Convert.ToDouble(array[4]);
            strike.DegreeFreedom = Convert.ToDouble(array[5]);
            strike.EllipseAngle = Convert.ToDouble(array[6]);
            strike.EclipseSemimajorAxis = Convert.ToDouble(array[7]);
            strike.EllipseSemiminorAxis = Convert.ToDouble(array[8]);
            strike.Chisq = Convert.ToDouble(array[9]);
            strike.RiseTime = Convert.ToDouble(array[10]);
            strike.Peak2Zero = Convert.ToDouble(array[11]);
            strike.MaxRateRise = Convert.ToDouble(array[12]);
            strike.Cloud = array[13] == "1";
            return strike;
        }


    }

}

using LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LLDSA.Entities.FileOperator.LLSFileProcessor.GLD360
{
    public class GLD360FileProcessor
    {

        #region 变量|Variables
        protected string sourceLlsFilePathName = null;
        protected string curLlsRowContent;
        protected int sumLineNum = 0;
        protected int curRow = 1;
        protected string province;
        protected char[] curCharSeparator;
        TimeSpan timeSpanElapsed = new TimeSpan();
        int currentPercent = 0;
        string fileNameLlsSrc;
        Encoding encode = Encoding.UTF8;

        #endregion


        /// <summary>
        /// 传入闪电定位数据路径及文件名| CONSTRUCTOR
        /// </summary>
        public GLD360FileProcessor(string _fulLlsPathFileName, Encoding _encode)
        {
            encode = _encode;
            if (File.Exists(_fulLlsPathFileName))
            {
                sourceLlsFilePathName = _fulLlsPathFileName;
            }
            else
                throw new FileNotFoundException("文件" + _fulLlsPathFileName + "不存在。");
        }


        /// <summary>
        /// 读取某文件，获取其总行数 | Get sum line number from text
        /// </summary>
        /// <param name="fulLlsPathFileName"></param>
        /// <returns></returns>
        private int GetSumLineNumFromText(string fulLlsPathFileName)
        {
            if (File.Exists(fulLlsPathFileName))
            {
                using (StreamReader strReader = new StreamReader(fulLlsPathFileName, Encoding.Default))
                {
                    int count = 0;
                    while (strReader.ReadLine() != null)
                        count++;
                    return count;
                }
            }
            else
                throw new FileNotFoundException("文件" + fulLlsPathFileName + "不存在。");
        }

        /// <summary>
        /// 读取当前文件的总行数，为sumLineNum赋值 | Get sum line number from text
        /// </summary>
        private void GetSumLineNumFromText()
        {
            sumLineNum = GetSumLineNumFromText(sourceLlsFilePathName);
        }


        public List<LightningStrike_GLD360> ReturnStrikes(bool skipTheFirstRow = true)
        {
            DateTime dtStart = DateTime.Now;
            string strBuffer;
            GetSumLineNumFromText();
            curRow = 1;
            var StrikesList = new List<LightningStrike_GLD360>();
            using (StreamReader strReader = new StreamReader(sourceLlsFilePathName, Encoding.UTF8))
            {
                while ((strBuffer = strReader.ReadLine()) != null)
                {
                    if (curRow == 1 && skipTheFirstRow)
                    {
                        curRow++;
                        continue;
                    }

                    try
                    {
                        curRow++;
                        currentPercent = 100 * curRow / sumLineNum;
                        var rowProcessor = new GLD360LlsRowProcessor(strBuffer);
                        rowProcessor.SrcFileName = sourceLlsFilePathName;
                        var strike = rowProcessor.ReturnStrike();
                        if (strike != null)
                            StrikesList.Add(strike);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            DateTime dtEnd = DateTime.Now;
            timeSpanElapsed = dtEnd - dtStart;
            return StrikesList;
        }
    }
}

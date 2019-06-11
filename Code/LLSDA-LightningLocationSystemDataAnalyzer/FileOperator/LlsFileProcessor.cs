/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LLSDA.Entities
{
    public class LlsFileProcessor
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


        #endregion


        #region 属性|properties
        /// <summary>
        /// 从1%到100% | from1%到100%
        /// </summary>

        public int CurrentPercent
        {
            get { return currentPercent; }
            set { currentPercent = value; }
        }

        public TimeSpan TimeSpanElapsed
        {
            get { return timeSpanElapsed; }
            set { timeSpanElapsed = value; }
        }

        public char[] CurCharSeparator
        {
            get { return curCharSeparator; }
            set { curCharSeparator = value; }
        }

        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        public string SourceLlsFilePathName
        {
            get { return sourceLlsFilePathName; }
            set { sourceLlsFilePathName = value; }
        }


        public string FileNameLlsSrc
        {
            get
            {
                fileNameLlsSrc = System.IO.Path.GetFileName(sourceLlsFilePathName);
                return fileNameLlsSrc;
            }
        }
        /// <summary>
        /// 文件总行数
        /// </summary>

        public int SumLineNum
        {
            get
            {
                GetSumLineNumFromText();
                return sumLineNum;
            }
        }
        /// <summary>
        /// 正在处理的行序号
        /// </summary>
        public int CurRow
        {
            get { return curRow; }
            set { curRow = value; }
        }
        #endregion


        #region 构造函数| Constructor
        /// <summary>
        /// 传入闪电定位数据路径及文件名| CONSTRUCTOR
        /// </summary>
        public LlsFileProcessor(string _fulLlsPathFileName)
        {
            if (File.Exists(_fulLlsPathFileName))
            {
                sourceLlsFilePathName = _fulLlsPathFileName;
            }
            else
                throw new FileNotFoundException("文件" + _fulLlsPathFileName + "不存在。");
        }
        #endregion


        #region 公开函数|public methods
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


        /// <summary>
        /// 返回LightningStrike_China列表，强制赋值省份信息。市县信息为空 
        /// </summary>
        /// <returns></returns>
        public List<LightningStrike_China> ReturnStrikesChinaByProcess(string provinceName)
        {
            List<LightningStrike_China> strikes = new List<LightningStrike_China>();
            strikes = ReturnStrikesChinaByProcess();
            for (int i = 0; i < strikes.Count; i++)
            {
                if (string.IsNullOrEmpty(strikes[i].Province))
                    strikes[i].Province = provinceName;
                if (string.IsNullOrEmpty(strikes[i].City))
                    strikes[i].City = string.Empty;
                if (string.IsNullOrEmpty(strikes[i].District))
                    strikes[i].District = string.Empty;
            }
            return strikes;
        }

        /// <summary>
        /// 返回LightningStrike_China列表
        /// </summary>
        /// <returns></returns>
        public List<LightningStrike_China> ReturnStrikesChinaByProcess()
        {
            DateTime dtStart = DateTime.Now;
            string strBuffer;//
            GetSumLineNumFromText();
            curRow = 1;
            List<LightningStrike_China> StrikesList = new List<LightningStrike_China>();
            using (StreamReader strReader = new StreamReader(SourceLlsFilePathName, Encoding.Default))
            {
                while ((strBuffer = strReader.ReadLine()) != null)
                {
                    try
                    {
                        curRow++;
                        currentPercent = 100 * curRow / sumLineNum;
                        LlsRowProcessor rowProcessor = new LlsRowProcessor(strBuffer);
                        rowProcessor.SrcFileName = sourceLlsFilePathName;
                        LightningStrike_China strike = rowProcessor.ReturnStrike();
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
        #endregion


        #region 析构函数 | Disposer
        //显示实现Dispose接口，避免同时出现Dispose方法和自定义命名方法(Close)
        public void Dispose()
        {
            //释放所有资源
            Dispose(true);
            //避免重复调用Finalize函数
            GC.SuppressFinalize(this);
        }

        //内部Dispose方法，真正试试资源释放工作
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                    // sqlDataBaseOperation.Dispose();
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }

        //在Finalize函数中调用内部的Dispose方法
        ~LlsFileProcessor()
        {
            //被自动回收是仅释放托管资源，不释放非托管资源
            Dispose(false);
        }

        private bool m_disposed;
        #endregion


    }


    #region 闪电定位txt源文件格式识别器
    /// <summary>
    /// 输入日期，返回文件格式如：
    /// </summary>
    public class LlsTxtFileLlsTxtFileFormatRecognizerFactory
    {
        public static string GetLlsFileName(DateTime _dt, LlsSrcFileType _llsFileType)
        {
            LlsTxtFileFormatRecognizer ltffr;
            if (_llsFileType == LlsSrcFileType.ChineseLls)
            {
                ltffr = new LlsTxtFileFormatRecognizer1(_dt);
                return ltffr.GetFileNameFromDate();
            }
            else if (_llsFileType == LlsSrcFileType.wwlln)
            {
                ltffr = new LlsTxtFileFormatRecognizer2(_dt);
                return ltffr.GetFileNameFromDate();
            }
            else//默认返回中国格式
            {
                ltffr = new LlsTxtFileFormatRecognizer1(_dt);
                return ltffr.GetFileNameFromDate();
            }
        }
    }

    public enum LlsSrcFileType
    {
        wwlln,
        ChineseLls
    }

    public abstract class LlsTxtFileFormatRecognizer
    {
        public LlsTxtFileFormatRecognizer(DateTime _dt)
        {
            dt = _dt;
        }
        DateTime dt;
        public DateTime Dt
        {
            get { return dt; }
            set { dt = value; }
        }
        public abstract string GetFileNameFromDate();
    }

    public class LlsTxtFileFormatRecognizer1 : LlsTxtFileFormatRecognizer
    {
        public LlsTxtFileFormatRecognizer1(DateTime _dt) : base(_dt) { }
        public override string GetFileNameFromDate()
        {
            string fileName = string.Empty;
            fileName = Dt.Year + "_" + Dt.Month.ToString() + "_" + Dt.Day.ToString() + ".txt";
            return fileName;
        }
    }
    public class LlsTxtFileFormatRecognizer2 : LlsTxtFileFormatRecognizer
    {
        public LlsTxtFileFormatRecognizer2(DateTime _dt) : base(_dt) { }
        public override string GetFileNameFromDate()
        {
            string fileName = string.Empty;
            fileName = "A" + Dt.Year.ToString() + Dt.Month.ToString() + Dt.Day.ToString() + ".txt";
            return fileName;
        }
    }

    #endregion
}

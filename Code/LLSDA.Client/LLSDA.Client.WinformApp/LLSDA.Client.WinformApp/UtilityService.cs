using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.IO;

namespace LLSDA.Client.Winform
{
    public class UtilityService
    {
        /// <summary>
        /// 保存chart中图片
        /// </summary>
        public static void SaveImage(Chart _chart, string _defaultName)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = _defaultName + ".Bmp";
            saveFileDialog1.Filter = "bmp File|*.bmp|All Files|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                _chart.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Bmp);

        }

        /// <summary>
        /// 复制图像到剪切板
        /// </summary>
        public static void CopyImage(Chart ChartName)
        {
            // create a memory stream to save the chart image    
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            // save the chart image to the stream    
            ChartName.SaveImage(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            // create a bitmap using the stream    
            Bitmap bmp = new Bitmap(stream);
            // save the bitmap to the clipboard    
            Clipboard.SetDataObject(bmp);
        }

        public static void SaveImageWithFullPathName(Chart _chart, string _PathFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(_PathFileName))
                {
                    ValidateFileFolderExistence(_PathFileName);
                    using (var stream = new FileStream(_PathFileName, FileMode.CreateNew))
                    { 
                        _chart.SaveImage(stream, ChartImageFormat.Bmp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 不存在则创建文件夹
        /// </summary>
        /// <param name="fullFileName"></param>
        public static void ValidateFileFolderExistence(string fullFileName)
        {
            string filePath = fullFileName.Substring(0, fullFileName.LastIndexOf("\\") + 1); // 文件路径
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);//不存在则创建文件夹 
            }

        }

    }
}

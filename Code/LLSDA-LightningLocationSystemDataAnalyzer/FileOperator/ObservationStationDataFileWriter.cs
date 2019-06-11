/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LLSDA.Entities.FileOperator
{
    /// <summary>
    /// Use to do  ObservationStation Data persistence||人工观测数据文件写入器
    /// </summary>
    public class ObservationStationDataFileWriter
    {
        public ObservationStationDataFileWriter(IEnumerable<ObservationStation> _ObservationStationList)
        {
            ObservationStationList = new ConcurrentBag<ObservationStation>();
            foreach (var tmp in _ObservationStationList)
            {
                ObservationStationList.Add(tmp);
            }
        }
        ConcurrentBag<ObservationStation> ObservationStationList;

        /// <summary>
        /// 创建结果文件，有抬头格式：Stid,lng,lat,value；无抬头格式：lng,lat,value
        /// Create result file, with title format Stid,lng,lat,valu; Or without title format: lng,lat,value
        /// </summary>
        /// <param name="pathFileName"></param>
        /// <param name="_HasTitle"></param>
        public bool CreateResultFileForSurfer(string pathFileName, bool _HasTitle)
        {
            try
            {
                if (File.Exists(pathFileName))//如果文件已经存在，则覆盖
                    File.Delete(pathFileName);
                using (StreamWriter strWriter = new StreamWriter(pathFileName))
                {
                    int i = 0;
                    if (_HasTitle)//是否需要抬头
                        strWriter.WriteLine("Longitude,Latitude,Value");
                    foreach (var tmp in ObservationStationList)
                    {
                        string curContent;
                        if (_HasTitle)
                            curContent = i.ToString() + "," + tmp.StationLongitude + "," + tmp.StationLatitude + "," + tmp.TdValue;
                        else
                            curContent = tmp.StationLongitude + "," + tmp.StationLatitude + "," + tmp.TdValue;
                        strWriter.WriteLine(curContent);
                        i++;
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }



    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LLSDA.Entities;

namespace LLSDA.Client.Winform
{
    public partial class RoseDiagramUCs : UserControl
    {
        public RoseDiagramUCs()
        {
            InitializeComponent();
            chartRose.Series.Clear();     
        }

        private Dictionary<string, double> sourceDataDictionary;

        string saveOriginalName;

        public string SaveOriginalName
        {
            get { return saveOriginalName; }
            set { saveOriginalName = value; }
        }
        /// <summary>
        /// 源数据字典，顺序为："北", "东北", "东", "东南", "南", "西南", "西", "西北"
        /// </summary>
        public Dictionary<string, double> SourceDataDictionary
        {
            get { return sourceDataDictionary; }
            set { sourceDataDictionary = value; }
        }

        public void SeriesClear()
        {
            this.chartRose.Series.Clear();
        }

        #region 按钮事件
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            UtilityService.CopyImage(chartRose);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UtilityService.SaveImage(chartRose,"雷电玫瑰图"); 
        }
        #endregion

        #region 方法
        /// <summary>
        /// 将数据绑定到玫瑰图上
        /// </summary>
        /// <param name="_sourceDictionary"></param>
        /// <param name="seriesName"></param>
        /// <param name="showValueAsLabel"></param>
        public void BindDataToRoseDiagram(Dictionary<LightningStrikeDirectionEnum, double> _sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            Dictionary<string, double> resultDictionary=new Dictionary<string,double>();
            foreach (var tmp in _sourceDictionary)
            {
                resultDictionary.Add(tmp.Key.ToString(), tmp.Value);
            }
            BindDataToRoseDiagram(resultDictionary, seriesName, showValueAsLabel);
        }

        /// <summary>
        /// 将数据绑定到玫瑰图上
        /// </summary>
        public void BindDataToRoseDiagram(Dictionary<string, double> _sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            //设置玫瑰图属性
           
            chartRose.Series.Add(seriesName);
            chartRose.Series[seriesName].ChartType = SeriesChartType.Radar;
            chartRose.Series[seriesName].MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            chartRose.Series[seriesName].MarkerSize = 8;
            chartRose.Series[seriesName].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chartRose.Series[seriesName].BorderWidth = 2;
            chartRose.Series[seriesName].Color = System.Drawing.Color.Red;
            chartRose.Series[seriesName].CustomProperties = "RadarDrawingStyle=Line, AreaDrawingStyle=Polygon, CircularLabelsStyle=Circular";
            chartRose.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chartRose.Series[seriesName].IsXValueIndexed = true;

            //在玫瑰图上显示数据
            foreach (KeyValuePair<string, double> tmpElement in _sourceDictionary)
            {
                chartRose.Series[seriesName].Points.AddXY(tmpElement.Key, Math.Round(tmpElement.Value, 0));
            }
        }
        #endregion

    }
}

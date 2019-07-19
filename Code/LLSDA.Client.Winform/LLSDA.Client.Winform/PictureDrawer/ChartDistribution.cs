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
//using LlsAnalysisPlatform.Entities;
//using LlsAnalysisPlatform.Common;


namespace LLSDA.Client.Winform
{
    public partial class ChartDistribution : UserControl
    {
        public ChartDistribution()
        {
            InitializeComponent();
            chart.Series.Clear();
        }

        Dictionary<int, int> sourceDictionary = new Dictionary<int, int>();
        string saveOriginalName;

        public string SaveOriginalName
        {
            get { return saveOriginalName; }
            set { saveOriginalName = value; }
        }
        public Dictionary<int, int> SourceDictionary
        {
            get { return sourceDictionary; }
            set { sourceDictionary = value; }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UtilityService.SaveImage(chart, saveOriginalName);
        }

        //public delegate void EventHandler(object sender, EventArgs e);
        //public event EventHandler buttonClick;
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            UtilityService.CopyImage(this.chart);
        }

        private void ChartDistribution_Load(object sender, EventArgs e)
        {
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.IntervalOffset = 1;
        }
        /// <summary>
        /// 设置文本域的描述性文字
        /// </summary>
        public void SetDescriptionText(string descriptionText)
        {
            this.richTextBox.Text = descriptionText;
        }

        public void SeriesClear()
        {
            this.chart.Series.Clear();
        }

        /// <summary>
        /// 配置ChartAreas，x、y轴相关信息
        /// </summary>
        public void ConfigChartAreasType(string AxisXName, string AxisYName)
        {
            chart.ChartAreas.Clear();
            chart.ChartAreas.Add("ChartArea1");
            chart.ChartAreas[0].AxisY.Title = AxisYName;
            chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Auto;
            chart.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;

            chart.ChartAreas[0].AxisX.Title = AxisXName;
            chart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
        }
        /// <summary>
        /// 绑定数据到有两条Y轴的图上
        /// </summary>
        /// <param name="sourceDictionary"></param>
        /// <param name="seriesName"></param>
        /// <param name="showValueAsLabel"></param>
        /// <param name="axistype"></param>  
        public void BindDataToDoubleAxisYChart(Dictionary<int, double> sourceDictionary, string seriesName, bool showValueAsLabel, AxisType axistype)
        {
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = chart.ChartAreas[0].AxisY.MajorGrid.Enabled = chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;//不显示网格线
            chart.Series.Add(seriesName);
            chart.Series[seriesName].YAxisType = axistype;
            switch (axistype)
            {
                case AxisType.Primary:
                    chart.Series[seriesName].ChartType = SeriesChartType.Column;
                    chart.Series[seriesName].Color = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(54)))), ((int)(((byte)(105)))));
                    break;
                case AxisType.Secondary:
                    chart.ChartAreas[0].AxisY2.LabelStyle.Format = "0%";
                    chart.Series[seriesName].ChartType = SeriesChartType.Line;
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Square;
                    chart.Series[seriesName].MarkerSize = 5;
                    chart.Series[seriesName].Color = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(78)))));
                    break;
            }
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            if (sourceDictionary != null)
                foreach (KeyValuePair<int, double> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value);
        }

        /// <summary>
        /// 将地闪次数分布定到图表
        /// </summary>
        public void BindDataToChart(Dictionary<int, int> sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            chart.Series.Add(seriesName);
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            if (sourceDictionary != null)
                foreach (KeyValuePair<int, int> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value);
        }


        public void BindDataToChartNew(Dictionary<int, double> sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            //chart = new Chart();
            chart.Series.Clear();
            chart.Series.Add(seriesName);
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet;
            chart.Series[seriesName].Color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(231)))), ((int)(((byte)(91)))));
            if (sourceDictionary != null)
                foreach (KeyValuePair<int, double> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value); //Math.Round(tmpElement.Value, 0)
        }

        public void BindDataToChartTriple(Dictionary<int, int> sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            chart.Series.Add(seriesName);
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            if (sourceDictionary != null)
                foreach (KeyValuePair<int, int> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value); //Math.Round(tmpElement.Value, 0)
        }

        /// <summary>
        ///绑定概率分布到图表
        /// </summary>
        public void BindDataToChart(Dictionary<int, double> sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            chart.ChartAreas[0].Name = "雷电流累计概率分布";
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].AxisY.Maximum = 1;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.Crossing = double.MinValue;
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Spline;
            chart.Series[seriesName].YValueType = ChartValueType.Double;
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            if (sourceDictionary != null)
                foreach (KeyValuePair<int, double> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value);
        }

        /// <summary>
        ///绑定"地闪强度分级百分比"分布到图表,y轴上限为100
        /// </summary>
        public void BindDataToChart(Dictionary<string, double> sourceDictionary, string seriesName, bool showValueAsLabel)
        {
            chart.ChartAreas[0].Name = "地闪强度百分比";
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.Crossing = double.MinValue;
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Spline;
            chart.Series[seriesName].YValueType = ChartValueType.Double;
            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;
            if (sourceDictionary != null)
                foreach (KeyValuePair<string, double> tmpElement in sourceDictionary)
                    chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value);
        }


        #region polygonLine
        /// <summary>
        /// 配置ChartAreasPolygonLine，x、y轴相关信息
        /// </summary>
        public void ConfigChartAreasTypePolygonLine(string AxisXName, string AxisYName)
        {

            chart.ChartAreas[0].AxisY.Title = AxisYName;
            chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Auto;
            chart.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0%";
            chart.ChartAreas[0].AxisY.Interval = 0.1;

            chart.ChartAreas[0].AxisX.Title = AxisXName;
            chart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;//不显示网格线
        }
        /// <summary>
        /// 将正闪、负闪、总闪绑定到图表，多段线专用
        /// </summary>
        public void BindDataToChartPolygonLine(Dictionary<int, double> sourceDictionary, SeriesNameFlashType _seriesFlashType, bool showValueAsLabel)
        {
            chart.Series.Clear();
            string seriesName = _seriesFlashType.ToString();
            ConfigPolygonLineStyle(this.chart, _seriesFlashType, showValueAsLabel);

            foreach (KeyValuePair<int, double> tmpElement in sourceDictionary)
            {
                this.chart.Series[seriesName].Points.AddXY(tmpElement.Key, tmpElement.Value);
            }
        }
        /// <summary>
        /// 绑定雷电强度分级
        /// </summary>
        /// <param name="sourceDictionary"></param>
        /// <param name="_seriesFlashType"></param>
        /// <param name="showValueAsLabel"></param>
        public void BindDataToChartPolygonLineForSingle(Dictionary<LightningStrikeIntensityClassTypeEnum, double> sourceDictionary, SeriesNameFlashType _seriesFlashType, bool showValueAsLabel)
        {
            chart.Series.Clear();
            string seriesName = _seriesFlashType.ToString();
            ConfigPolygonLineStyle(this.chart, _seriesFlashType, showValueAsLabel);

            foreach (KeyValuePair<LightningStrikeIntensityClassTypeEnum, double> tmpElement in sourceDictionary)
            {
                this.chart.Series[seriesName].Points.AddXY(tmpElement.Key.ToString(), tmpElement.Value);
            }
        }
        /// <summary>
        /// 配置折线图的样式
        /// </summary>
        private void ConfigPolygonLineStyle(Chart chart, SeriesNameFlashType _seriesFlashType, bool showValueAsLabel)
        {
            string seriesName = _seriesFlashType.ToString();
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Line;
            //chart.Series[seriesName].MarkerSize = 7;

            switch (seriesName)
            {
                case "正闪所占百分比":
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Square;
                    break;
                case "负闪所占百分比":
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[seriesName].Color = System.Drawing.Color.Green;
                    break;
                case "总闪所占百分比":
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Triangle;
                    chart.Series[seriesName].Color = System.Drawing.Color.Red;
                    break;
                case "雷电强度分级":
                    //chart.Series[seriesName].MarkerStyle = MarkerStyle.None;
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.Square;
                    chart.Series[seriesName].Color = System.Drawing.Color.Red;
                    //chart.Series[seriesName].BorderWidth = 2;
                    //chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                    //chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                    //chart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;//网格间隔
                    //chart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;//网格间隔
                    //chart.ChartAreas[0].AxisY.LabelStyle.Interval = 1;
                    break;
                case "雷暴日":
                    chart.Series[seriesName].MarkerStyle = MarkerStyle.None;
                    chart.Series[seriesName].Color = System.Drawing.Color.Blue;
                    chart.Series[seriesName].BorderWidth = 2;
                    chart.ChartAreas[0].AxisX.MajorGrid.Interval = 10;//网格间隔
                    chart.ChartAreas[0].AxisX.MajorTickMark.Size = 0;//取消刻度
                    chart.ChartAreas[0].AxisX.LabelStyle.Interval = 10;//X轴数值间隔
                    chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;//网格样式
                    break;

            }

            chart.Series[seriesName].IsValueShownAsLabel = showValueAsLabel;
            chart.Series[seriesName].IsXValueIndexed = true;


        }
        #endregion


    }
}

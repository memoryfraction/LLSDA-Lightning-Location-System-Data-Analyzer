using LLSDA.Entities;
using LLSDA.Interface;
using LLSDA.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLSDA.Client.Winform
{
    public partial class Form1 : Form
    {
        List<BaseStrikeChina> strikes;
        public event EventHandler SrcFileLoadCompleted;
        IStrikesDistributionStatisticService iStrikesDistributionStatisticService;
        LightningPictureDrawer lightningPictureDrawer;
        string baseDirectory;
        public Form1()
        {
            InitializeComponent();
            SrcFileLoadCompleted += Form1_srcFileLoadCompleted;
            strikes  = ReadDataAsync().Result;
            lightningPictureDrawer = new LightningPictureDrawer();
            iStrikesDistributionStatisticService = new StrikesDistributionStatisticService();
            baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Results\";
        }

        private void Form1_srcFileLoadCompleted(object sender, EventArgs e)
        {
            // Enable buttons
            MonthDistribution.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DrawMonthDistributionChart();
        }

        private void HourDistribution_Click(object sender, EventArgs e)
        {
            DrawHourDistributionChart();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            DrawYearDistributionChart();
        }


        /// <summary>
        /// 读取源文件，并获取数据到内存;
        /// </summary>
        private Task<List<BaseStrikeChina>> ReadDataAsync()
        {
            return Task<List<BaseStrikeChina>>.Run(() => {
                var strikes = new List<BaseStrikeChina>();
                var str = System.AppDomain.CurrentDomain.BaseDirectory;
                var srcFile1 = AppDomain.CurrentDomain.BaseDirectory + @"\data\2008_07_09.txt";
                var srcFile2 = AppDomain.CurrentDomain.BaseDirectory + @"\data\2008_07_10.txt";
                if (File.Exists(srcFile1))
                {
                    var fileProcessor = new LlsFileProcessor(srcFile1, Encoding.UTF8);
                    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
                }

                if (File.Exists(srcFile2))
                {
                    var fileProcessor = new LlsFileProcessor(srcFile2, Encoding.UTF8);
                    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
                }
                SrcFileLoadCompleted(this, new EventArgs());
                return strikes;
            });
        }


        #region MonthDistribution
        private Dictionary<int, int> GetMonthDistributionPositive(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuMonthDistributionPosive(strikes.Where(x => x.Intensity > 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetMonthDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuMonthDistributionNegative(strikes.Where(x => x.Intensity < 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetMonthDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuMonthDistributionNegative(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private void DrawMonthDistributionChart()
        {
            if (strikes != null && strikes.Count > 0)
            {
                var positiveDistribution = GetMonthDistributionPositive(strikes);
                var negativeDistribution = GetMonthDistributionNegative(strikes);
                var Distribution = GetMonthDistribution(strikes);

                // draw chart and show
                var chart = lightningPictureDrawer.BindMonthDistributionChart(distribution: Distribution, positiveDistribution, negativeDistribution, "");
                var fullFileName = baseDirectory + "MonthDistributionChart_" + Guid.NewGuid() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }
        #endregion


        #region HourDistribution
        private void DrawHourDistributionChart()
        {
            if (strikes != null && strikes.Count > 0)
            {
                var positiveDistribution = GetHourDistributionPositive(strikes);
                var negativeDistribution = GetHourDistributionNegative(strikes);
                var Distribution = GetHourDistribution(strikes);

                // draw chart and show
                var chart = lightningPictureDrawer.BindHourDistributionChart(distribution:Distribution,positiveDistribution,negativeDistribution,"");
                var fullFileName = baseDirectory + "HourDistributionChart_" + Guid.NewGuid().ToString() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
                Process.Start("mspaint.exe",fullFileName);
            }
        }

        private Dictionary<int, int> GetHourDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuHourDistribution(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetHourDistributionPositive(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuHourDistribution_Positive(strikes.Where(x => x.Intensity > 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetHourDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuHourDistribution_Negative(strikes.Where(x => x.Intensity < 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }
        #endregion


        #region YearDistribution
        private Dictionary<int, int> GetYearDistributionPositive(IEnumerable<BaseStrikeChina> strikes) {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuYearDistributionPositive(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetYearDistributionNegative(IEnumerable<BaseStrikeChina> strikes) {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuYearDistributionNegative(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }
        private Dictionary<int, int> GetYearDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return iStrikesDistributionStatisticService.CalcuYearDistribution(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private void DrawYearDistributionChart()
        {
            var positiveDistribution = GetYearDistributionPositive(strikes);
            var negativeDistribution = GetYearDistributionNegative(strikes);
            var Distribution = GetYearDistribution(strikes);

            // draw chart and show
            var chart = lightningPictureDrawer.BindYearDistributionChart(distribution: Distribution, positiveDistribution, negativeDistribution, "");
            var fullFileName = baseDirectory + "YearDistributionChart_" + Guid.NewGuid().ToString() + @".bmp";
            UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
            Process.Start("mspaint.exe", fullFileName);
        }
        #endregion


        private void buttonRoseDiagram_Click(object sender, EventArgs e)
        {
            // 雷电玫瑰图需要基于几何中心才能实现; 通常, 用于格点化分析中的格点;
            if (strikes != null && strikes.Count > 0)
            {
                var roseDiagramUCs1 = new RoseDiagramUCs();
                roseDiagramUCs1.SaveOriginalName = "LigithningRoseDistributionChart";

                Dictionary<LightningStrikeDirectionEnum, double> sourceDataDictionary =
                    iStrikesDistributionStatisticService.CalcuLightningStrikeDirectionProbabilityDistribution(strikes);
                Dictionary<string, double> SourceDataDictionaryString = new Dictionary<string, double>();
                foreach (var tmp in sourceDataDictionary)
                {
                    SourceDataDictionaryString.Add(tmp.Key.ToString(), tmp.Value);
                }
                roseDiagramUCs1.BindDataToRoseDiagram(SourceDataDictionaryString, "概率百分比", true);

                // Save File
                var fullFileName = baseDirectory + "RoseDiagramChart_" + Guid.NewGuid() + @".bmp";
                UtilityService.SaveImageWithFullPathName(roseDiagramUCs1.chartRose, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }


        private void buttonCurrent_Click(object sender, EventArgs e)
        {
            if (strikes != null && strikes.Count > 0)
            {
                // Generate chart
                ChartDistribution chartDistribution_Probablity_Dynamic = new ChartDistribution();
                chartDistribution_Probablity_Dynamic.SaveOriginalName = "LigithningIntensityProbabilityDistributionChart";

                chartDistribution_Probablity_Dynamic.richTextBox.Text = iStrikesDistributionStatisticService.GenerateProbabilityDistributionText(strikes);
                chartDistribution_Probablity_Dynamic.ConfigChartAreasType("强度(单位;kA)", "概率P");

                var ProbabilityDistribution = iStrikesDistributionStatisticService.CalcuProbabilityDistribution(strikes);
                chartDistribution_Probablity_Dynamic.BindDataToChart(ProbabilityDistribution, "概率分布", false);

                // Save File
                var fullFileName = baseDirectory + "IntensityProbabilityChart_" + Guid.NewGuid().ToString() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chartDistribution_Probablity_Dynamic.chart, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }
    }
}

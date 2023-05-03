using LLSDA.Client.Winform;
using LLSDA.Entities;
using LLSDA.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LLSDA.Client.WinformApp
{
    public partial class Form1 : Form
    {
        private List<BaseStrikeChina> _strikes;
        public event EventHandler SrcFileLoadCompleted;
        private IStrikesDistributionStatisticService _strikesDistributionStatisticService;
        private LightningPictureDrawer _lightningPictureDrawer;
        
        private ServiceCollection _services;
        private string _srcADTDFile1, _srcADTDFile2,_srcGLD360File;
        private string _baseResultDirectory, _baseDirectory;

        public Form1(IStrikesDistributionStatisticService strikesDistributionStatisticService)
        {
            InitializeComponent();
            
            _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _baseResultDirectory = _baseDirectory + @"Results\";
            _srcADTDFile1 = _baseDirectory + @"\data\LLS\ADTD\2008_07_09.txt";
            _srcADTDFile2 = _baseDirectory + @"\data\LLS\ADTD\2008_07_10.txt";
            _srcGLD360File = _baseDirectory + @"\data\GLD360\GLD360 2018_09_24_0800_24h 35N_43N_113E_119E.csv";

            SrcFileLoadCompleted += Form_srcFileLoadCompleted;
            _strikes = ReadDataAsync().Result;
            _lightningPictureDrawer = new LightningPictureDrawer();
            _strikesDistributionStatisticService = strikesDistributionStatisticService;
        }

        private void Form_srcFileLoadCompleted(object sender, EventArgs e)
        {
            // Enable buttons
            MonthDistribution.Enabled = true;
        }

        private void MonthDistribution_Click(object sender, EventArgs e)
        {
            DrawMonthDistributionChart();
        }

        
        private void buttonYearDistribution_Click(object sender, EventArgs e)
        {
            DrawYearDistributionChart();
        }

        private void HourDistribution_Click(object sender, EventArgs e)
        {
            DrawHourDistributionChart();
        }

        private void buttonRoseDiagram_Click(object sender, EventArgs e)
        {
            // 雷电玫瑰图需要基于几何中心才能实现; 通常, 用于格点化分析中的格点;
            if (_strikes != null && _strikes.Count > 0)
            {
                var roseDiagramUCs1 = new RoseDiagramUCs();
                roseDiagramUCs1.SaveOriginalName = "LigithningRoseDistributionChart";

                Dictionary<LightningStrikeDirectionEnum, double> sourceDataDictionary =
                    _strikesDistributionStatisticService.CalcuLightningStrikeDirectionProbabilityDistribution(_strikes);
                Dictionary<string, double> SourceDataDictionaryString = new Dictionary<string, double>();
                foreach (var tmp in sourceDataDictionary)
                {
                    SourceDataDictionaryString.Add(tmp.Key.ToString(), tmp.Value);
                }
                roseDiagramUCs1.BindDataToRoseDiagram(SourceDataDictionaryString, "概率百分比", true);

                // Save File
                var fullFileName = _baseResultDirectory + "RoseDiagramChart_" + Guid.NewGuid() + @".bmp";
                UtilityService.SaveImageWithFullPathName(roseDiagramUCs1.chartRose, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }

        private void buttonCurrent_Click(object sender, EventArgs e)
        {
            if (_strikes != null && _strikes.Count > 0)
            {
                // Generate chart
                ChartDistribution chartDistribution_Probablity_Dynamic = new ChartDistribution();
                chartDistribution_Probablity_Dynamic.SaveOriginalName = "LigithningIntensityProbabilityDistributionChart";

                chartDistribution_Probablity_Dynamic.richTextBox.Text = _strikesDistributionStatisticService.GenerateProbabilityDistributionText(_strikes);
                chartDistribution_Probablity_Dynamic.ConfigChartAreasType("强度(单位;kA)", "概率P");

                var ProbabilityDistribution = _strikesDistributionStatisticService.CalcuProbabilityDistribution(_strikes);
                chartDistribution_Probablity_Dynamic.BindDataToChart(ProbabilityDistribution, "概率分布", false);

                // Save File
                var fullFileName = _baseResultDirectory + "IntensityProbabilityChart_" + Guid.NewGuid().ToString() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chartDistribution_Probablity_Dynamic.chart, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }


        /// <summary>
        /// 读取源文件，并获取数据到内存;
        /// </summary>
        private Task<List<BaseStrikeChina>> ReadDataAsync()
        {
            return Task<List<BaseStrikeChina>>.Run(() => {
                var strikes = new List<BaseStrikeChina>();
                if (File.Exists(_srcADTDFile1))
                {
                    var fileProcessor = new LlsFileProcessor(_srcADTDFile1, Encoding.UTF8);
                    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
                }

                if (File.Exists(_srcADTDFile2))
                {
                    var fileProcessor = new LlsFileProcessor(_srcADTDFile2, Encoding.UTF8);
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
                return _strikesDistributionStatisticService.CalcuMonthDistributionPosive(strikes.Where(x => x.Intensity > 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetMonthDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuMonthDistributionNegative(strikes.Where(x => x.Intensity < 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetMonthDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuMonthDistributionNegative(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private void DrawMonthDistributionChart()
        {
            if (_strikes != null && _strikes.Count > 0)
            {
                var positiveDistribution = GetMonthDistributionPositive(_strikes);
                var negativeDistribution = GetMonthDistributionNegative(_strikes);
                var Distribution = GetMonthDistribution(_strikes);

                // draw chart and show
                var chart = _lightningPictureDrawer.BindMonthDistributionChart(distribution: Distribution, positiveDistribution, negativeDistribution, "");
                var fullFileName = _baseResultDirectory + "MonthDistributionChart_" + Guid.NewGuid() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }
        #endregion


        #region HourDistribution
        private void DrawHourDistributionChart()
        {
            if (_strikes != null && _strikes.Count > 0)
            {
                var positiveDistribution = GetHourDistributionPositive(_strikes);
                var negativeDistribution = GetHourDistributionNegative(_strikes);
                var Distribution = GetHourDistribution(_strikes);

                // draw chart and show
                var chart = _lightningPictureDrawer.BindHourDistributionChart(distribution: Distribution, positiveDistribution, negativeDistribution, "");
                var fullFileName = _baseResultDirectory + "HourDistributionChart_" + Guid.NewGuid().ToString() + @".bmp";
                UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
                Process.Start("mspaint.exe", fullFileName);
            }
        }

        private Dictionary<int, int> GetHourDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuHourDistribution(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetHourDistributionPositive(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuHourDistribution_Positive(strikes.Where(x => x.Intensity > 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetHourDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuHourDistribution_Negative(strikes.Where(x => x.Intensity < 0).Select(x => x));
            else
                throw new ArgumentOutOfRangeException();
        }
        #endregion


        #region YearDistribution
        private Dictionary<int, int> GetYearDistributionPositive(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuYearDistributionPositive(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private Dictionary<int, int> GetYearDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuYearDistributionNegative(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }
        private Dictionary<int, int> GetYearDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            if (strikes != null || strikes.Any())
                return _strikesDistributionStatisticService.CalcuYearDistribution(strikes);
            else
                throw new ArgumentOutOfRangeException();
        }

        private void DrawYearDistributionChart()
        {
            var positiveDistribution = GetYearDistributionPositive(_strikes);
            var negativeDistribution = GetYearDistributionNegative(_strikes);
            var Distribution = GetYearDistribution(_strikes);

            // draw chart and show
            var chart = _lightningPictureDrawer.BindYearDistributionChart(distribution: Distribution, positiveDistribution, negativeDistribution, "");
            var fullFileName = _baseResultDirectory + "YearDistributionChart_" + Guid.NewGuid().ToString() + @".bmp";
            UtilityService.SaveImageWithFullPathName(chart.chart, fullFileName);
            Process.Start("mspaint.exe", fullFileName);
        }
        #endregion

    }
}

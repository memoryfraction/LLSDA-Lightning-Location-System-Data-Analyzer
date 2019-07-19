using LLSDA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLSDA.Client.Winform
{
    public class LightningPictureDrawer
    {
        #region 变量
        string configrationXml = AppDomain.CurrentDomain.BaseDirectory + @"\Configration.xml";
        string srcNgFilePathName = AppDomain.CurrentDomain.BaseDirectory + @"\Surfer\ResultFile\Ng值文件.txt";
        string srcLigCurAvgFilePathName = AppDomain.CurrentDomain.BaseDirectory + @"\Surfer\ResultFile\平均雷电流文件.txt";
        string NgMap = AppDomain.CurrentDomain.BaseDirectory + @"\Surfer\ResultFile\NgMap.bmp";
        string curAvgMap = AppDomain.CurrentDomain.BaseDirectory + @"\Surfer\ResultFile\curAvgMap.bmp";
        ChartDistribution chartDistribution_Hours_Dynamic, chartDistribution_Month_Dynamic, chartDistribution_Probablity_Dynamic;
        RoseDiagramUCs roseDiagramUCs1;
        #endregion


        /// <summary>
        /// 绑定时分布chart
        /// </summary>
        public ChartDistribution BindHourDistributionChart(Dictionary<int,int> distribution, Dictionary<int, int> positiveDistribution, Dictionary<int, int> negativeDistribution,string desc)
        {
            chartDistribution_Hours_Dynamic = new ChartDistribution();
            chartDistribution_Hours_Dynamic.SaveOriginalName = ResultPictureTypeEnum.地闪时分布图.ToString();

            Dictionary<int, int> hourDistribution = distribution;
            Dictionary<int, int> hourDistributionPositive = positiveDistribution;
            Dictionary<int, int> hourDistributionNegative = negativeDistribution;
            chartDistribution_Hours_Dynamic.richTextBox.Text = desc;

            chartDistribution_Hours_Dynamic.ConfigChartAreasType("Hour", "Times");
            chartDistribution_Hours_Dynamic.BindDataToChart(hourDistribution, "Strike Times", true);
            chartDistribution_Hours_Dynamic.BindDataToChart(hourDistributionPositive, "Positive", false);
            chartDistribution_Hours_Dynamic.BindDataToChart(hourDistributionNegative, "Negative", false);
            return chartDistribution_Hours_Dynamic;
        }

        /// <summary>
        /// 绑定月份分布信息到chart
        /// </summary>
        public ChartDistribution BindMonthDistributionChart(Dictionary<int, int> distribution, Dictionary<int, int> positiveDistribution, Dictionary<int, int> negativeDistribution, string desc)
        {
            chartDistribution_Month_Dynamic = new ChartDistribution();
            chartDistribution_Month_Dynamic.SaveOriginalName = ResultPictureTypeEnum.地闪月分布图.ToString();

            Dictionary<int, int> monthDistribution = distribution;
            Dictionary<int, int> monthDistributionPositive = positiveDistribution;
            Dictionary<int, int> monthDistributionNegative = negativeDistribution;
            chartDistribution_Month_Dynamic.ConfigChartAreasType("Month", "Times");
            chartDistribution_Month_Dynamic.BindDataToChart(monthDistribution, "Strike Times", true);
            chartDistribution_Month_Dynamic.BindDataToChart(monthDistributionPositive, "Positive", false);
            chartDistribution_Month_Dynamic.BindDataToChart(monthDistributionNegative, "Negative", false);
            chartDistribution_Month_Dynamic.richTextBox.Text = desc;//月分布文字描述
            return chartDistribution_Month_Dynamic;
        }

        /// <summary>
        /// 绑定雷电流累计概率分布图
        /// </summary>
        private void BindProbabilityDistribution(PointAnalysisResults pointAnalysisResult)
        {
            Dictionary<int, double> ProbabilityDistribution = pointAnalysisResult.ProbabilityDistribution;
            chartDistribution_Probablity_Dynamic.richTextBox.Text = pointAnalysisResult.ProbabilityDistributionDesc;
            chartDistribution_Probablity_Dynamic.ConfigChartAreasType("Intensity(kA)", "Probability");
            chartDistribution_Probablity_Dynamic.BindDataToChart(ProbabilityDistribution, "Probability Distribution", false);
        }

        /// <summary>
        /// 绘制雷电玫瑰图
        /// </summary>
        private void BindStrikeRoseDistribution(PointAnalysisResults pointAnalysisResult)
        {
            Dictionary<LightningStrikeDirectionEnum, double> sourceDataDictionary = new Dictionary<LightningStrikeDirectionEnum, double>();
            sourceDataDictionary = pointAnalysisResult.RoseDistribution;
            Dictionary<string, double> SourceDataDictionaryString = new Dictionary<string, double>();
            foreach (var tmp in sourceDataDictionary)
            {
                SourceDataDictionaryString.Add(tmp.Key.ToString(), tmp.Value);
            }
            roseDiagramUCs1.BindDataToRoseDiagram(SourceDataDictionaryString, "Probability Percentage", true);
        }

    }
}

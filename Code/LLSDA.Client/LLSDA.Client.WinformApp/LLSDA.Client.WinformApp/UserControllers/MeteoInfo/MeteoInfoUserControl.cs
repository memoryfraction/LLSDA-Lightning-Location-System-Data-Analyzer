using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MeteoInfoC.Layer;
using MeteoInfoC.Data.MapData;
using MeteoInfoC.Map;
using MeteoInfoC.Layout;
using MeteoInfoC.Shape;
using MeteoInfoC.Legend;
using System.Diagnostics;
using LLSDA.Entities;
using LLSDA.Interface;
using PointD = MeteoInfoC.PointD;
using System.IO;
using LLSDA.Service;

namespace MeteoInfoControlLibrary
{
    public partial class MeteoInfoUserControl : UserControl
    {
        ToolStripButton _currentTool;
        public MeteoInfoUserControl()
        {
            InitializeComponent();
            mapView1.MouseTool = MouseTools.Pan;
            mapLayout1.MouseMode = MouseMode.Select;
        }

        private void TSB_AddLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            aDlg.Filter = "Supported Formats|*.shp;*.wmp;*.bln;*.bmp;*.gif;*.jpg;*.tif;*.png|Shape File (*.shp)|*.shp|WMP File (*.wmp)|*.wmp|BLN File (*.bln)|*.bln|" +
                "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|Tif Image (*.tif)|*.tif|Png Iamge (*.png)|*.png|All Files (*.*)|*.*";

            if (aDlg.ShowDialog() == DialogResult.OK)
            {
                string aFile = aDlg.FileName;
                AddLayer(aFile);
            }
        }
        /// <summary>
        /// 输入string，添加层
        /// </summary>
        public void AddLayer(string _srcPathFile)
        {
            if(File.Exists(_srcPathFile))
            { 
                string aFile = _srcPathFile;
                MapLayer aLayer = MapDataManage.OpenLayer(aFile);
                layersLegend1.ActiveMapFrame.AddLayer(aLayer);
                layersLegend1.Refresh();
            }
        }

        /// <summary>
        /// 扩展到合适比例显示
        /// </summary>
        public void ZoomExtent()
        {
            MeteoInfoC.Global.Extent aExtent = mapView1.Extent;
            mapView1.ZoomToExtent(aExtent);
        }

        private void TSB_RemoveDataLayers_Click(object sender, EventArgs e)
        {
            layersLegend1.ActiveMapFrame.RemoveMeteoLayers();
            layersLegend1.Refresh();
        }

        private void TSB_Select_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.SelectElements;
            mapLayout1.MouseMode = MouseMode.Select;
            SetCurrentTool((ToolStripButton)sender);
        }

        private void SetCurrentTool(ToolStripButton currentTool)
        {
            if (!(_currentTool == null))
            {
                _currentTool.Checked = false;
            }
            _currentTool = currentTool;
            _currentTool.Checked = true;
            TSSL_Status.Text = _currentTool.ToolTipText;
        }

        private void TSB_ZoomIn_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Zoom_In;
            mapLayout1.MouseMode = MouseMode.Map_ZoomIn;

            SetCurrentTool((ToolStripButton)sender);
        }

        private void TSB_ZoomOut_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Zoom_Out;
            mapLayout1.MouseMode = MouseMode.Map_ZoomOut;

            SetCurrentTool((ToolStripButton)sender);
        }

        private void TSB_Pan_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Pan;
            mapLayout1.MouseMode = MouseMode.Map_Pan;

            SetCurrentTool((ToolStripButton)sender);
        }

        private void TSB_FullExent_Click(object sender, EventArgs e)
        {
            MeteoInfoC.Global.Extent aExtent = mapView1.Extent;
            mapView1.ZoomToExtent(aExtent);
        }

        private void TSB_Identifer_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Identifer;
            mapLayout1.MouseMode = MouseMode.Map_Identifer;
            SetCurrentTool((ToolStripButton)sender);
        }

        private void TSB_About_Click(object sender, EventArgs e)
        {
            AboutBox1 aFrm = new AboutBox1();
            aFrm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlDisplayPad.SelectedIndex == 1)    //Map Layout
            {
                layersLegend1.IsLayoutView = true;

                mapLayout1.PaintGraphics();
                mapLayout1.Refresh();
            }
            else if (tabControlDisplayPad.SelectedIndex == 0)    //Map view
            {
                layersLegend1.IsLayoutView = false;

                mapView1.IsLayoutMap = false;
                mapView1.ZoomToExtent(mapView1.ViewExtent);
            }
        }

   

        /// <summary>
        /// 在当前图层上绘制闪电信息
       /// </summary>
       /// <param name="strikesStandard">闪电源</param>
       /// <param name="layerName">图层名字</param>
       /// <param name="isLabeled">是否标注强度</param>
        private void DrawLightningOnActivateMap(IEnumerable<BaseStrikeStandard> strikesStandard,string layerName,bool isLabeled)
        {
            //New layer
            VectorLayer aLayer = new VectorLayer(ShapeTypes.Point);
            aLayer.LayerName = layerName;
            aLayer.LegendScheme = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Red, 10);
            //((PointBreak)aLayer.LegendScheme.breakList[0]).Style = PointStyle.XCross; //标记为加号
            aLayer.Visible = true;

            //Add fields            
            aLayer.EditAddField("日期时间",typeof(DateTime));
            aLayer.EditAddField("经度", typeof(double));
            aLayer.EditAddField("纬度", typeof(double));
            aLayer.EditAddField("强度", typeof(double));
            aLayer.EditAddField("陡度", typeof(double));
            aLayer.EditAddField("误差", typeof(double));
            aLayer.EditAddField("探测方式", typeof(string));

            //Prepare coordinate data
            int sourceSumNum = strikesStandard.Count();

            //Add shape
            foreach (BaseStrikeStandard tmpStrike in strikesStandard)
            {
                PointShape aPS = new PointShape();
                PointD aPoint = new PointD();
                aPoint.X = tmpStrike.Longitude;
                aPoint.Y = tmpStrike.Latitude;
                aPS.Point = aPoint;
                int shapeNum = aLayer.ShapeNum;
                if (aLayer.EditInsertShape(aPS, shapeNum))
                {
                    //Edit record value
                    aLayer.EditCellValue("日期时间", shapeNum, tmpStrike.DateAndTime);
                    aLayer.EditCellValue("经度", shapeNum, aPoint.X);
                    aLayer.EditCellValue("纬度", shapeNum, aPoint.Y);
                    aLayer.EditCellValue("强度", shapeNum, tmpStrike.Intensity);
                    aLayer.EditCellValue("陡度", shapeNum, tmpStrike.Slope);
                    aLayer.EditCellValue("误差", shapeNum, tmpStrike.Error);
                    aLayer.EditCellValue("探测方式", shapeNum, tmpStrike.LocationMode);
                }
            }

            //是否标注文字强度
            if (isLabeled)
            {
                //Add Label
                aLayer.LabelSet.FieldName = "强度";
                //aLayer.LabelSet.LabelFont = new Font("Arial", 15);
                aLayer.LabelSet.YOffset = 30;
                aLayer.AddLabels();
            }
            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MapView.PaintLayers();
            layersLegend1.Refresh();
        }

        /// <summary>
        /// 添加lls数据并显示在当前图层
        /// </summary>
        public void AddLLSData(List<BaseStrikeStandard> _srcStrikes)
        {
            DrawLightningStrikes drawer = new DrawLightningStrikes (_srcStrikes, layersLegend1);
            drawer.DrawStrikes();
        }
        BackgroundWorker bg = new BackgroundWorker();
        string file = string.Empty;
        List<BaseStrikeStandard> strikeStandard = new List<BaseStrikeStandard>();
        Stopwatch stopwatch = new Stopwatch();
        BusyLoadingForm loadingForm;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bg.DoWork+=new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (DialogResult.OK == OFD.ShowDialog())
            {
                file = OFD.FileName;
            }
            if(File.Exists(file))
            { 
                bg.RunWorkerAsync();
                loadingForm = new BusyLoadingForm();
                loadingForm.ShowDialog();
            }
        }
        private void bg_DoWork(object sender, EventArgs e)
        {
            var llsFileProcessor = new LlsFileProcessor(file,Encoding.UTF8);
            stopwatch.Start();

            var strikeChinaList = llsFileProcessor.ReturnStrikesChinaByProcess();
            var strikeFormatConvertService = new StrikeFormatConvertService();
            foreach (var tmp in strikeChinaList)
            {         
                strikeStandard.Add(strikeFormatConvertService.ConvertChineseStrikToStandard(tmp));
            }
        }
        private void bg_RunWorkerCompleted(object sender,EventArgs e)
        {
            AddLLSData(strikeStandard);
            stopwatch.Stop();
            loadingForm.Close();
            Console.WriteLine("耗时：" + stopwatch.Elapsed.TotalSeconds + "秒，共有记录" + strikeStandard.Count + "条");
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            DetailParamForm detailForm = new DetailParamForm();
            detailForm.ShowDialog();
        }

       
    }
}

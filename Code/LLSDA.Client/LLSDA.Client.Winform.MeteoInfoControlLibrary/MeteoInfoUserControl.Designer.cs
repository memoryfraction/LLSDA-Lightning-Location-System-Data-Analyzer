namespace MeteoInfoControlLibrary
{
    partial class MeteoInfoUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            MeteoInfoC.Legend.LabelBreak labelBreak1 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak1 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak1 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak1 = new MeteoInfoC.Legend.PolyLineBreak();
            MeteoInfoC.Layer.LayerCollection layerCollection1 = new MeteoInfoC.Layer.LayerCollection();
            MeteoInfoC.Map.ProjectionSet projectionSet1 = new MeteoInfoC.Map.ProjectionSet();
            MeteoInfoC.Projections.ProjectionInfo projectionInfo1 = new MeteoInfoC.Projections.ProjectionInfo();
            MeteoInfoC.Projections.GeographicInfo geographicInfo1 = new MeteoInfoC.Projections.GeographicInfo();
            MeteoInfoC.Projections.Datum datum1 = new MeteoInfoC.Projections.Datum();
            MeteoInfoC.Projections.Spheroid spheroid1 = new MeteoInfoC.Projections.Spheroid();
            MeteoInfoC.Projections.Meridian meridian1 = new MeteoInfoC.Projections.Meridian();
            MeteoInfoC.Projections.AngularUnit angularUnit1 = new MeteoInfoC.Projections.AngularUnit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeteoInfoUserControl));
            MeteoInfoC.Projections.LongLat longLat1 = new MeteoInfoC.Projections.LongLat();
            MeteoInfoC.Projections.LinearUnit linearUnit1 = new MeteoInfoC.Projections.LinearUnit();
            MeteoInfoC.Legend.MapFrame mapFrame1 = new MeteoInfoC.Legend.MapFrame();
            MeteoInfoC.Legend.LabelBreak labelBreak2 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak2 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak2 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak2 = new MeteoInfoC.Legend.PolyLineBreak();
            this.mapView1 = new MeteoInfoC.Map.MapView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_AddLayer = new System.Windows.Forms.ToolStripButton();
            this.TSB_RemoveDataLayers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddLls = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Select = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.TSB_Pan = new System.Windows.Forms.ToolStripButton();
            this.TSB_FullExent = new System.Windows.Forms.ToolStripButton();
            this.TSB_Identifer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_About = new System.Windows.Forms.ToolStripButton();
            this.layersLegend1 = new MeteoInfoC.Legend.LayersLegend();
            this.mapLayout1 = new MeteoInfoC.Layout.MapLayout();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlSearchAndLayer = new System.Windows.Forms.TabControl();
            this.tabPageSearchCondition = new System.Windows.Forms.TabPage();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreSurferImage = new System.Windows.Forms.Button();
            this.groupBoxSquare = new System.Windows.Forms.GroupBox();
            this.textBoxNgSquare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAvgLigCurSquare = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBoxTimeSpan = new System.Windows.Forms.GroupBox();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAssessmentPoint = new System.Windows.Forms.GroupBox();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.TextBoxLatSecond = new RegexTextBox.RegexTextBox();
            this.TextBoxLatMinute = new RegexTextBox.RegexTextBox();
            this.TextBoxLatDegree = new RegexTextBox.RegexTextBox();
            this.TextBoxLngSecond = new RegexTextBox.RegexTextBox();
            this.TextBoxLngMinute = new RegexTextBox.RegexTextBox();
            this.TextBoxLngDegree = new RegexTextBox.RegexTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tabPageLayerControl = new System.Windows.Forms.TabPage();
            this.tabControlDisplayPad = new System.Windows.Forms.TabControl();
            this.tabPageMapView = new System.Windows.Forms.TabPage();
            this.tabPageLayout = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSL_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlSearchAndLayer.SuspendLayout();
            this.tabPageSearchCondition.SuspendLayout();
            this.groupBoxSquare.SuspendLayout();
            this.groupBoxTimeSpan.SuspendLayout();
            this.groupBoxAssessmentPoint.SuspendLayout();
            this.tabPageLayerControl.SuspendLayout();
            this.tabControlDisplayPad.SuspendLayout();
            this.tabPageMapView.SuspendLayout();
            this.tabPageLayout.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapView1
            // 
            this.mapView1.BackColor = System.Drawing.Color.White;
            this.mapView1.Cursor = System.Windows.Forms.Cursors.Default;
            labelBreak1.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak1.Angle = 0F;
            labelBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak1.Caption = "";
            labelBreak1.Color = System.Drawing.Color.Black;
            labelBreak1.DrawShape = true;
            labelBreak1.EndValue = 0;
            //labelBreak1.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak1.IsNoData = false;
            labelBreak1.StartValue = 0;
            labelBreak1.Text = "Text";
            labelBreak1.YShift = 0F;
            this.mapView1.DefLabelBreak = labelBreak1;
            pointBreak1.Angle = 0F;
            pointBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak1.Caption = "";
            pointBreak1.CharIndex = 0;
            pointBreak1.Color = System.Drawing.Color.Red;
            pointBreak1.DrawFill = true;
            pointBreak1.DrawOutline = true;
            pointBreak1.DrawShape = true;
            pointBreak1.EndValue = 0;
            pointBreak1.FontName = "Arial";
            pointBreak1.ImagePath = null;
            pointBreak1.IsNoData = false;
            pointBreak1.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak1.OutlineColor = System.Drawing.Color.Black;
            pointBreak1.Size = 10F;
            pointBreak1.StartValue = 0;
            pointBreak1.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapView1.DefPointBreak = pointBreak1;
            polygonBreak1.BackColor = System.Drawing.Color.Transparent;
            polygonBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak1.Caption = "";
            polygonBreak1.Color = System.Drawing.Color.LightYellow;
            polygonBreak1.DrawFill = true;
            polygonBreak1.DrawOutline = true;
            polygonBreak1.DrawShape = true;
            polygonBreak1.EndValue = 0;
            polygonBreak1.IsMaskout = false;
            polygonBreak1.IsNoData = false;
            polygonBreak1.OutlineColor = System.Drawing.Color.Black;
            polygonBreak1.OutlineSize = 1F;
            polygonBreak1.StartValue = 0;
            //polygonBreak1.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            //polygonBreak1.TransparencyPercent = 50;
            polygonBreak1.UsingHatchStyle = false;
            this.mapView1.DefPolygonBreak = polygonBreak1;
            polyLineBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak1.Caption = "";
            polyLineBreak1.Color = System.Drawing.Color.Red;
            polyLineBreak1.DrawPolyline = true;
            polyLineBreak1.DrawShape = true;
            polyLineBreak1.DrawSymbol = false;
            polyLineBreak1.EndValue = 0;
            polyLineBreak1.IsNoData = false;
            polyLineBreak1.Size = 2F;
            polyLineBreak1.StartValue = 0;
            //polyLineBreak1.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak1.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak1.SymbolInterval = 1;
            polyLineBreak1.SymbolSize = 8F;
            polyLineBreak1.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapView1.DefPolylineBreak = polyLineBreak1;
            this.mapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView1.DrawGridLine = false;
            this.mapView1.DrawGridTickLine = false;
            this.mapView1.DrawIdentiferShape = false;
            this.mapView1.DrawNeatLine = false;
            this.mapView1.ForeColor = System.Drawing.Color.Black;
            this.mapView1.GridLineColor = System.Drawing.Color.Black;
            this.mapView1.GridLineSize = 1;
            //this.mapView1.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.mapView1.GridXDelt = 10D;
            this.mapView1.GridXOrigin = 0D;
            this.mapView1.GridYDelt = 10D;
            this.mapView1.GridYOrigin = 0D;
            this.mapView1.IsGeoMap = true;
            this.mapView1.IsLayoutMap = false;
            this.mapView1.IsPaint = true;
            this.mapView1.IsSelectedInLayout = false;
            //layerCollection1.LayerNum = 0;
            layerCollection1.SelectedLayer = -1;
            this.mapView1.LayerSet = layerCollection1;
            this.mapView1.Location = new System.Drawing.Point(3, 3);
            this.mapView1.LockViewUpdate = false;
            this.mapView1.LonLatProjLayer = null;
            this.mapView1.MouseTool = MeteoInfoC.Map.MouseTools.None;
            this.mapView1.Name = "mapView1";
            this.mapView1.NeatLineColor = System.Drawing.Color.Black;
            this.mapView1.NeatLineSize = 1;
            projectionInfo1.CentralMeridian = null;
            projectionInfo1.FalseEasting = null;
            projectionInfo1.FalseNorthing = null;
            projectionInfo1.Geoc = false;
            datum1.DatumType = MeteoInfoC.Projections.DatumTypes.WGS84;
            datum1.Description = "WGS 1984";
            datum1.NadGrids = null;
            datum1.Name = "D_WGS_1984";
            spheroid1.EquatorialRadius = 6378137D;
            spheroid1.KnownEllipsoid = MeteoInfoC.Projections.Proj4Ellipsoids.WGS_1984;
            spheroid1.Name = "WGS_1984";
            spheroid1.PolarRadius = 6356752.3142451793D;
            datum1.Spheroid = spheroid1;
            datum1.ToWGS84 = new double[] {
        0D,
        0D,
        0D};
            geographicInfo1.Datum = datum1;
            meridian1.Longitude = 0D;
            meridian1.Name = null;
            geographicInfo1.Meridian = meridian1;
            geographicInfo1.Name = "GCS_WGS_1984";
            angularUnit1.Name = null;
            angularUnit1.Radians = 0.0174532925D;
            geographicInfo1.Unit = angularUnit1;
            projectionInfo1.GeographicInfo = geographicInfo1;
            projectionInfo1.IsGeocentric = false;
            projectionInfo1.IsLatLon = false;
            projectionInfo1.IsSouth = false;
            projectionInfo1.LatitudeOfOrigin = null;
            projectionInfo1.Name = null;
            projectionInfo1.NoDefs = false;
            projectionInfo1.Over = false;
            projectionInfo1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("projectionInfo1.Parameters")));
            projectionInfo1.ScaleFactor = 1D;
            projectionInfo1.StandardParallel1 = null;
            projectionInfo1.StandardParallel2 = null;
            longLat1.ProjectionName = MeteoInfoC.Projections.ProjectionNames.Lon_Lat;
            projectionInfo1.Transform = longLat1;
            linearUnit1.Meters = 1D;
            linearUnit1.Name = null;
            projectionInfo1.Unit = linearUnit1;
            projectionInfo1.Zone = null;
            projectionSet1.ProjInfo = projectionInfo1;
            projectionSet1.ProjStr = " +proj=lonlat +ellps=WGS84 +datum=WGS84 +no_defs= +k=1";
            projectionSet1.RefCutLon = 0D;
            projectionSet1.RefLon = 0D;
            this.mapView1.Projection = projectionSet1;
            this.mapView1.SelectColor = System.Drawing.Color.Yellow;
            this.mapView1.SelectedLayer = 0;
            this.mapView1.Size = new System.Drawing.Size(712, 463);
            //this.mapView1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.mapView1.TabIndex = 0;
            this.mapView1.XGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.XGridStrs")));
            this.mapView1.XYScaleFactor = 1.2D;
            this.mapView1.YGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.YGridStrs")));
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_AddLayer,
            this.TSB_RemoveDataLayers,
            this.toolStripButtonAddLls,
            this.toolStripSeparator1,
            this.TSB_Select,
            this.TSB_ZoomIn,
            this.TSB_ZoomOut,
            this.TSB_Pan,
            this.TSB_FullExent,
            this.TSB_Identifer,
            this.toolStripSeparator2,
            this.TSB_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(937, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_AddLayer
            // 
            this.TSB_AddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_AddLayer.Image = ((System.Drawing.Image)(resources.GetObject("TSB_AddLayer.Image")));
            this.TSB_AddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_AddLayer.Name = "TSB_AddLayer";
            this.TSB_AddLayer.Size = new System.Drawing.Size(23, 22);
            this.TSB_AddLayer.Text = "Add Layer";
            this.TSB_AddLayer.Click += new System.EventHandler(this.TSB_AddLayer_Click);
            // 
            // TSB_RemoveDataLayers
            // 
            this.TSB_RemoveDataLayers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RemoveDataLayers.Image = ((System.Drawing.Image)(resources.GetObject("TSB_RemoveDataLayers.Image")));
            this.TSB_RemoveDataLayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RemoveDataLayers.Name = "TSB_RemoveDataLayers";
            this.TSB_RemoveDataLayers.Size = new System.Drawing.Size(23, 22);
            this.TSB_RemoveDataLayers.Text = "Remove";
            this.TSB_RemoveDataLayers.Click += new System.EventHandler(this.TSB_RemoveDataLayers_Click);
            // 
            // toolStripButtonAddLls
            // 
            this.toolStripButtonAddLls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLls.Image = global::MeteoInfoControlLibrary.Properties.Resources.雷电数据分析2;
            this.toolStripButtonAddLls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLls.Name = "toolStripButtonAddLls";
            this.toolStripButtonAddLls.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddLls.Text = "AddLlsFile";
            this.toolStripButtonAddLls.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_Select
            // 
            this.TSB_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Select.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Select.Image")));
            this.TSB_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Select.Name = "TSB_Select";
            this.TSB_Select.Size = new System.Drawing.Size(23, 22);
            this.TSB_Select.Text = "Select Elements";
            this.TSB_Select.Click += new System.EventHandler(this.TSB_Select_Click);
            // 
            // TSB_ZoomIn
            // 
            this.TSB_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomIn.Image")));
            this.TSB_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomIn.Name = "TSB_ZoomIn";
            this.TSB_ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomIn.Text = "Zoom In";
            this.TSB_ZoomIn.Click += new System.EventHandler(this.TSB_ZoomIn_Click);
            // 
            // TSB_ZoomOut
            // 
            this.TSB_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomOut.Image")));
            this.TSB_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomOut.Name = "TSB_ZoomOut";
            this.TSB_ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomOut.Text = "Zoom Out";
            this.TSB_ZoomOut.Click += new System.EventHandler(this.TSB_ZoomOut_Click);
            // 
            // TSB_Pan
            // 
            this.TSB_Pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Pan.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Pan.Image")));
            this.TSB_Pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Pan.Name = "TSB_Pan";
            this.TSB_Pan.Size = new System.Drawing.Size(23, 22);
            this.TSB_Pan.Text = "Pan";
            this.TSB_Pan.Click += new System.EventHandler(this.TSB_Pan_Click);
            // 
            // TSB_FullExent
            // 
            this.TSB_FullExent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_FullExent.Image = ((System.Drawing.Image)(resources.GetObject("TSB_FullExent.Image")));
            this.TSB_FullExent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_FullExent.Name = "TSB_FullExent";
            this.TSB_FullExent.Size = new System.Drawing.Size(23, 22);
            this.TSB_FullExent.Text = "Full Extent";
            this.TSB_FullExent.Click += new System.EventHandler(this.TSB_FullExent_Click);
            // 
            // TSB_Identifer
            // 
            this.TSB_Identifer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Identifer.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Identifer.Image")));
            this.TSB_Identifer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Identifer.Name = "TSB_Identifer";
            this.TSB_Identifer.Size = new System.Drawing.Size(23, 22);
            this.TSB_Identifer.Text = "Identifer";
            this.TSB_Identifer.Click += new System.EventHandler(this.TSB_Identifer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_About
            // 
            this.TSB_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_About.Image = ((System.Drawing.Image)(resources.GetObject("TSB_About.Image")));
            this.TSB_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_About.Name = "TSB_About";
            this.TSB_About.Size = new System.Drawing.Size(23, 22);
            this.TSB_About.Text = "About";
            this.TSB_About.Click += new System.EventHandler(this.TSB_About_Click);
            // 
            // layersLegend1
            // 
            this.layersLegend1.AllowDrop = true;
            this.layersLegend1.BackColor = System.Drawing.Color.White;
            this.layersLegend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersLegend1.Font = new System.Drawing.Font("Arial", 8F);
            this.layersLegend1.ForeColor = System.Drawing.Color.Black;
            this.layersLegend1.IsLayoutView = false;
            this.layersLegend1.Location = new System.Drawing.Point(3, 3);
            mapFrame1.Active = true;
            mapFrame1.BackColor = System.Drawing.Color.White;
            mapFrame1.Checked = true;
            mapFrame1.DrawGridLabel = true;
            mapFrame1.DrawGridLine = false;
            mapFrame1.DrawGridTickLine = false;
            mapFrame1.DrawNeatLine = true;
            mapFrame1.ForeColor = System.Drawing.Color.Black;
            //mapFrame1.GridFont = new System.Drawing.Font("Arial", 8F);
            mapFrame1.GridLabelPosition = MeteoInfoC.Legend.GridLabelPosition.LeftBottom;
            mapFrame1.GridLineColor = System.Drawing.Color.Black;
            mapFrame1.GridLineSize = 1;
            //mapFrame1.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            mapFrame1.GridXDelt = 10D;
            mapFrame1.GridXOrigin = 0D;
            mapFrame1.GridYDelt = 10D;
            mapFrame1.GridYOrigin = 0D;
            mapFrame1.Height = 15;
            mapFrame1.IsFireMapViewUpdate = false;
            mapFrame1.LayoutBounds = new System.Drawing.Rectangle(100, 100, 300, 200);
            mapFrame1.Legend = null;
            mapFrame1.MapFrameName = "New Map Frame";
            mapFrame1.MapView = this.mapView1;
            mapFrame1.NeatLineColor = System.Drawing.Color.Black;
            mapFrame1.NeatLineSize = 1;
            mapFrame1.NodeType = MeteoInfoC.Legend.NodeTypes.MapFrameNode;
            mapFrame1.Order = 0;
            mapFrame1.Selected = false;
            mapFrame1.SelectedLayer = 0;
            mapFrame1.Text = "New Map Frame";
            mapFrame1.Top = 0;
            this.layersLegend1.MapFrames.Add(mapFrame1);
            this.layersLegend1.MapLayout = this.mapLayout1;
            this.layersLegend1.Name = "layersLegend1";
            this.layersLegend1.SelectedNode = null;
            this.layersLegend1.Size = new System.Drawing.Size(193, 463);
            this.layersLegend1.TabIndex = 0;
            // 
            // mapLayout1
            // 
            this.mapLayout1.AutoResize = false;
            this.mapLayout1.BackColor = System.Drawing.Color.DarkGray;
            labelBreak2.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak2.Angle = 0F;
            labelBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak2.Caption = "";
            labelBreak2.Color = System.Drawing.Color.Black;
            labelBreak2.DrawShape = true;
            labelBreak2.EndValue = 0;
            //labelBreak2.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak2.IsNoData = false;
            labelBreak2.StartValue = 0;
            labelBreak2.Text = "Text";
            labelBreak2.YShift = 0F;
            this.mapLayout1.DefLabelBreak = labelBreak2;
            pointBreak2.Angle = 0F;
            pointBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak2.Caption = "";
            pointBreak2.CharIndex = 0;
            pointBreak2.Color = System.Drawing.Color.Red;
            pointBreak2.DrawFill = true;
            pointBreak2.DrawOutline = true;
            pointBreak2.DrawShape = true;
            pointBreak2.EndValue = 0;
            pointBreak2.FontName = "Arial";
            pointBreak2.ImagePath = null;
            pointBreak2.IsNoData = false;
            pointBreak2.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak2.OutlineColor = System.Drawing.Color.Black;
            pointBreak2.Size = 10F;
            pointBreak2.StartValue = 0;
            pointBreak2.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapLayout1.DefPointBreak = pointBreak2;
            polygonBreak2.BackColor = System.Drawing.Color.Transparent;
            polygonBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak2.Caption = "";
            polygonBreak2.Color = System.Drawing.Color.LightYellow;
            polygonBreak2.DrawFill = true;
            polygonBreak2.DrawOutline = true;
            polygonBreak2.DrawShape = true;
            polygonBreak2.EndValue = 0;
            polygonBreak2.IsMaskout = false;
            polygonBreak2.IsNoData = false;
            polygonBreak2.OutlineColor = System.Drawing.Color.Black;
            polygonBreak2.OutlineSize = 1F;
            polygonBreak2.StartValue = 0;
            //polygonBreak2.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            //polygonBreak2.TransparencyPercent = 50;
            polygonBreak2.UsingHatchStyle = false;
            this.mapLayout1.DefPolygonBreak = polygonBreak2;
            polyLineBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak2.Caption = "";
            polyLineBreak2.Color = System.Drawing.Color.Red;
            polyLineBreak2.DrawPolyline = true;
            polyLineBreak2.DrawShape = true;
            polyLineBreak2.DrawSymbol = false;
            polyLineBreak2.EndValue = 0;
            polyLineBreak2.IsNoData = false;
            polyLineBreak2.Size = 2F;
            polyLineBreak2.StartValue = 0;
            //polyLineBreak2.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak2.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak2.SymbolInterval = 1;
            polyLineBreak2.SymbolSize = 8F;
            polyLineBreak2.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapLayout1.DefPolylineBreak = polyLineBreak2;
            this.mapLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapLayout1.Landscape = true;
            this.mapLayout1.Location = new System.Drawing.Point(3, 3);
            this.mapLayout1.MapFrames.Add(mapFrame1);
            this.mapLayout1.MouseMode = MeteoInfoC.Layout.MouseMode.Default;
            this.mapLayout1.Name = "mapLayout1";
            this.mapLayout1.PageBackColor = System.Drawing.Color.White;
            this.mapLayout1.PageBounds = new System.Drawing.Rectangle(0, 0, 720, 480);
            this.mapLayout1.PageForeColor = System.Drawing.Color.Black;
            this.mapLayout1.PageLocation = ((System.Drawing.PointF)(resources.GetObject("mapLayout1.PageLocation")));
            //this.mapLayout1.PaperSize = ((System.Drawing.Printing.PaperSize)(resources.GetObject("mapLayout1.PaperSize")));
            //this.mapLayout1.PrinterSetting = null;
            this.mapLayout1.Size = new System.Drawing.Size(712, 463);
            //this.mapLayout1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.mapLayout1.TabIndex = 0;
            this.mapLayout1.Zoom = 1F;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlSearchAndLayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlDisplayPad);
            this.splitContainer1.Size = new System.Drawing.Size(937, 495);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControlSearchAndLayer
            // 
            this.tabControlSearchAndLayer.Controls.Add(this.tabPageSearchCondition);
            this.tabControlSearchAndLayer.Controls.Add(this.tabPageLayerControl);
            this.tabControlSearchAndLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearchAndLayer.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearchAndLayer.Name = "tabControlSearchAndLayer";
            this.tabControlSearchAndLayer.SelectedIndex = 0;
            this.tabControlSearchAndLayer.Size = new System.Drawing.Size(207, 495);
            this.tabControlSearchAndLayer.TabIndex = 1;
            // 
            // tabPageSearchCondition
            // 
            this.tabPageSearchCondition.Controls.Add(this.btnShow);
            this.tabPageSearchCondition.Controls.Add(this.btnSave);
            this.tabPageSearchCondition.Controls.Add(this.btnCreSurferImage);
            this.tabPageSearchCondition.Controls.Add(this.groupBoxSquare);
            this.tabPageSearchCondition.Controls.Add(this.buttonSearch);
            this.tabPageSearchCondition.Controls.Add(this.groupBoxTimeSpan);
            this.tabPageSearchCondition.Controls.Add(this.groupBoxAssessmentPoint);
            this.tabPageSearchCondition.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearchCondition.Name = "tabPageSearchCondition";
            this.tabPageSearchCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearchCondition.Size = new System.Drawing.Size(199, 469);
            this.tabPageSearchCondition.TabIndex = 0;
            this.tabPageSearchCondition.Text = "查询条件";
            this.tabPageSearchCondition.UseVisualStyleBackColor = true;
            this.tabPageSearchCondition.Click += new System.EventHandler(this.tabPageSearchCondition_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Enabled = false;
            this.btnShow.Location = new System.Drawing.Point(57, 379);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(69, 23);
            this.btnShow.TabIndex = 141;
            this.btnShow.Text = "查看结果";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(57, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 23);
            this.btnSave.TabIndex = 140;
            this.btnSave.Text = "保存结果";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCreSurferImage
            // 
            this.btnCreSurferImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreSurferImage.Enabled = false;
            this.btnCreSurferImage.Location = new System.Drawing.Point(57, 342);
            this.btnCreSurferImage.Name = "btnCreSurferImage";
            this.btnCreSurferImage.Size = new System.Drawing.Size(69, 23);
            this.btnCreSurferImage.TabIndex = 139;
            this.btnCreSurferImage.Text = "等值线图";
            this.btnCreSurferImage.UseVisualStyleBackColor = true;
            // 
            // groupBoxSquare
            // 
            this.groupBoxSquare.Controls.Add(this.textBoxNgSquare);
            this.groupBoxSquare.Controls.Add(this.label7);
            this.groupBoxSquare.Controls.Add(this.label9);
            this.groupBoxSquare.Controls.Add(this.textBoxAvgLigCurSquare);
            this.groupBoxSquare.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSquare.Location = new System.Drawing.Point(3, 188);
            this.groupBoxSquare.Name = "groupBoxSquare";
            this.groupBoxSquare.Size = new System.Drawing.Size(193, 87);
            this.groupBoxSquare.TabIndex = 138;
            this.groupBoxSquare.TabStop = false;
            this.groupBoxSquare.Text = "计算结果";
            // 
            // textBoxNgSquare
            // 
            this.textBoxNgSquare.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNgSquare.Location = new System.Drawing.Point(126, 21);
            this.textBoxNgSquare.Name = "textBoxNgSquare";
            this.textBoxNgSquare.ReadOnly = true;
            this.textBoxNgSquare.Size = new System.Drawing.Size(61, 21);
            this.textBoxNgSquare.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 72;
            this.label7.Text = "评估点Ng[次/km2/年]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 80;
            this.label9.Text = "平均雷电流[kA]";
            // 
            // textBoxAvgLigCurSquare
            // 
            this.textBoxAvgLigCurSquare.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxAvgLigCurSquare.Location = new System.Drawing.Point(126, 50);
            this.textBoxAvgLigCurSquare.Name = "textBoxAvgLigCurSquare";
            this.textBoxAvgLigCurSquare.ReadOnly = true;
            this.textBoxAvgLigCurSquare.Size = new System.Drawing.Size(61, 21);
            this.textBoxAvgLigCurSquare.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(57, 305);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(69, 23);
            this.buttonSearch.TabIndex = 137;
            this.buttonSearch.Text = "查询";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimeSpan
            // 
            this.groupBoxTimeSpan.Controls.Add(this.dtpEndDateTime);
            this.groupBoxTimeSpan.Controls.Add(this.dtpStartDateTime);
            this.groupBoxTimeSpan.Controls.Add(this.label3);
            this.groupBoxTimeSpan.Controls.Add(this.label4);
            this.groupBoxTimeSpan.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTimeSpan.Location = new System.Drawing.Point(3, 112);
            this.groupBoxTimeSpan.Name = "groupBoxTimeSpan";
            this.groupBoxTimeSpan.Size = new System.Drawing.Size(193, 76);
            this.groupBoxTimeSpan.TabIndex = 1;
            this.groupBoxTimeSpan.TabStop = false;
            this.groupBoxTimeSpan.Text = "时段";
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTime.Location = new System.Drawing.Point(34, 45);
            this.dtpEndDateTime.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtpEndDateTime.MinDate = new System.DateTime(1900, 7, 14, 0, 0, 0, 0);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.Size = new System.Drawing.Size(142, 21);
            this.dtpEndDateTime.TabIndex = 130;
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateTime.Location = new System.Drawing.Point(33, 16);
            this.dtpStartDateTime.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtpStartDateTime.MinDate = new System.DateTime(1900, 7, 14, 0, 0, 0, 0);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.Size = new System.Drawing.Size(142, 21);
            this.dtpStartDateTime.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 128;
            this.label3.Text = "终止";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 127;
            this.label4.Text = "起始";
            // 
            // groupBoxAssessmentPoint
            // 
            this.groupBoxAssessmentPoint.Controls.Add(this.buttonDetail);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLatSecond);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLatMinute);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLatDegree);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLngSecond);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLngMinute);
            this.groupBoxAssessmentPoint.Controls.Add(this.TextBoxLngDegree);
            this.groupBoxAssessmentPoint.Controls.Add(this.label24);
            this.groupBoxAssessmentPoint.Controls.Add(this.label25);
            this.groupBoxAssessmentPoint.Controls.Add(this.label26);
            this.groupBoxAssessmentPoint.Controls.Add(this.label27);
            this.groupBoxAssessmentPoint.Controls.Add(this.label28);
            this.groupBoxAssessmentPoint.Controls.Add(this.label29);
            this.groupBoxAssessmentPoint.Controls.Add(this.label30);
            this.groupBoxAssessmentPoint.Controls.Add(this.label31);
            this.groupBoxAssessmentPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAssessmentPoint.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAssessmentPoint.Name = "groupBoxAssessmentPoint";
            this.groupBoxAssessmentPoint.Size = new System.Drawing.Size(193, 109);
            this.groupBoxAssessmentPoint.TabIndex = 0;
            this.groupBoxAssessmentPoint.TabStop = false;
            this.groupBoxAssessmentPoint.Text = "评估点查询";
            // 
            // buttonDetail
            // 
            this.buttonDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDetail.Location = new System.Drawing.Point(46, 75);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(100, 23);
            this.buttonDetail.TabIndex = 138;
            this.buttonDetail.Text = "范围设置";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // TextBoxLatSecond
            // 
            this.TextBoxLatSecond.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLatSecond.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLatSecond.Location = new System.Drawing.Point(141, 41);
            this.TextBoxLatSecond.Name = "TextBoxLatSecond";
            this.TextBoxLatSecond.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLatSecond.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLatSecond.TabIndex = 133;
            // 
            // TextBoxLatMinute
            // 
            this.TextBoxLatMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLatMinute.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLatMinute.Location = new System.Drawing.Point(82, 41);
            this.TextBoxLatMinute.Name = "TextBoxLatMinute";
            this.TextBoxLatMinute.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLatMinute.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLatMinute.TabIndex = 132;
            // 
            // TextBoxLatDegree
            // 
            this.TextBoxLatDegree.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLatDegree.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLatDegree.Location = new System.Drawing.Point(23, 41);
            this.TextBoxLatDegree.Name = "TextBoxLatDegree";
            this.TextBoxLatDegree.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLatDegree.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLatDegree.TabIndex = 131;
            // 
            // TextBoxLngSecond
            // 
            this.TextBoxLngSecond.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLngSecond.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLngSecond.Location = new System.Drawing.Point(141, 14);
            this.TextBoxLngSecond.Name = "TextBoxLngSecond";
            this.TextBoxLngSecond.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLngSecond.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLngSecond.TabIndex = 130;
            // 
            // TextBoxLngMinute
            // 
            this.TextBoxLngMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLngMinute.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLngMinute.Location = new System.Drawing.Point(82, 14);
            this.TextBoxLngMinute.Name = "TextBoxLngMinute";
            this.TextBoxLngMinute.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLngMinute.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLngMinute.TabIndex = 129;
            // 
            // TextBoxLngDegree
            // 
            this.TextBoxLngDegree.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextBoxLngDegree.ForeColor = System.Drawing.Color.Black;
            this.TextBoxLngDegree.Location = new System.Drawing.Point(23, 14);
            this.TextBoxLngDegree.Name = "TextBoxLngDegree";
            this.TextBoxLngDegree.Regex = "^(\\+|\\-|\\d){0,1}\\d*\\.{0,1}\\d*$";
            this.TextBoxLngDegree.Size = new System.Drawing.Size(37, 21);
            this.TextBoxLngDegree.TabIndex = 128;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(121, 47);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 127;
            this.label24.Text = "秒";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(-110, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 12);
            this.label25.TabIndex = 121;
            this.label25.Text = "经度:";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(62, 47);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 12);
            this.label26.TabIndex = 120;
            this.label26.Text = "分";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(-110, 47);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 12);
            this.label27.TabIndex = 122;
            this.label27.Text = "纬度:";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 47);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 126;
            this.label28.Text = "度";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 123;
            this.label29.Text = "度";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(62, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 124;
            this.label30.Text = "分";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(121, 17);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 125;
            this.label31.Text = "秒";
            // 
            // tabPageLayerControl
            // 
            this.tabPageLayerControl.Controls.Add(this.layersLegend1);
            this.tabPageLayerControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageLayerControl.Name = "tabPageLayerControl";
            this.tabPageLayerControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLayerControl.Size = new System.Drawing.Size(199, 469);
            this.tabPageLayerControl.TabIndex = 1;
            this.tabPageLayerControl.Text = "图层控制";
            this.tabPageLayerControl.UseVisualStyleBackColor = true;
            // 
            // tabControlDisplayPad
            // 
            this.tabControlDisplayPad.Controls.Add(this.tabPageMapView);
            this.tabControlDisplayPad.Controls.Add(this.tabPageLayout);
            this.tabControlDisplayPad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDisplayPad.Location = new System.Drawing.Point(0, 0);
            this.tabControlDisplayPad.Name = "tabControlDisplayPad";
            this.tabControlDisplayPad.SelectedIndex = 0;
            this.tabControlDisplayPad.Size = new System.Drawing.Size(726, 495);
            this.tabControlDisplayPad.TabIndex = 0;
            this.tabControlDisplayPad.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageMapView
            // 
            this.tabPageMapView.Controls.Add(this.mapView1);
            this.tabPageMapView.Location = new System.Drawing.Point(4, 22);
            this.tabPageMapView.Name = "tabPageMapView";
            this.tabPageMapView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMapView.Size = new System.Drawing.Size(718, 469);
            this.tabPageMapView.TabIndex = 0;
            this.tabPageMapView.Text = "MapView";
            this.tabPageMapView.UseVisualStyleBackColor = true;
            // 
            // tabPageLayout
            // 
            this.tabPageLayout.Controls.Add(this.mapLayout1);
            this.tabPageLayout.Location = new System.Drawing.Point(4, 22);
            this.tabPageLayout.Name = "tabPageLayout";
            this.tabPageLayout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLayout.Size = new System.Drawing.Size(718, 469);
            this.tabPageLayout.TabIndex = 1;
            this.tabPageLayout.Text = "Layout";
            this.tabPageLayout.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(937, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSL_Status
            // 
            this.TSSL_Status.Name = "TSSL_Status";
            this.TSSL_Status.Size = new System.Drawing.Size(43, 17);
            this.TSSL_Status.Text = "Status";
            // 
            // MeteoInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MeteoInfoUserControl";
            this.Size = new System.Drawing.Size(937, 520);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlSearchAndLayer.ResumeLayout(false);
            this.tabPageSearchCondition.ResumeLayout(false);
            this.groupBoxSquare.ResumeLayout(false);
            this.groupBoxSquare.PerformLayout();
            this.groupBoxTimeSpan.ResumeLayout(false);
            this.groupBoxTimeSpan.PerformLayout();
            this.groupBoxAssessmentPoint.ResumeLayout(false);
            this.groupBoxAssessmentPoint.PerformLayout();
            this.tabPageLayerControl.ResumeLayout(false);
            this.tabControlDisplayPad.ResumeLayout(false);
            this.tabPageMapView.ResumeLayout(false);
            this.tabPageLayout.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_AddLayer;
        private System.Windows.Forms.ToolStripButton TSB_RemoveDataLayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_Select;
        private System.Windows.Forms.ToolStripButton TSB_ZoomIn;
        private System.Windows.Forms.ToolStripButton TSB_ZoomOut;
        private System.Windows.Forms.ToolStripButton TSB_Pan;
        private System.Windows.Forms.ToolStripButton TSB_FullExent;
        private System.Windows.Forms.ToolStripButton TSB_Identifer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_About;
        private MeteoInfoC.Legend.LayersLegend layersLegend1;
        private MeteoInfoC.Map.MapView mapView1;
        private MeteoInfoC.Layout.MapLayout mapLayout1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlDisplayPad;
        private System.Windows.Forms.TabPage tabPageMapView;
        private System.Windows.Forms.TabPage tabPageLayout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_Status;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLls;
        private System.Windows.Forms.TabControl tabControlSearchAndLayer;
        private System.Windows.Forms.TabPage tabPageSearchCondition;
        private System.Windows.Forms.TabPage tabPageLayerControl;
        private System.Windows.Forms.GroupBox groupBoxAssessmentPoint;
        private RegexTextBox.RegexTextBox TextBoxLatSecond;
        private RegexTextBox.RegexTextBox TextBoxLatMinute;
        private RegexTextBox.RegexTextBox TextBoxLatDegree;
        private RegexTextBox.RegexTextBox TextBoxLngSecond;
        private RegexTextBox.RegexTextBox TextBoxLngMinute;
        private RegexTextBox.RegexTextBox TextBoxLngDegree;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxTimeSpan;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreSurferImage;
        private System.Windows.Forms.GroupBox groupBoxSquare;
        private System.Windows.Forms.TextBox textBoxNgSquare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAvgLigCurSquare;
    }
}

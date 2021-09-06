using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeteoInfoC.Layer;
using MeteoInfoC.Shape;
using MeteoInfoC.Legend;
using MeteoInfoC.Drawing;
using System.Drawing;
using MeteoInfoC;
using LLSDA.Entities;
using LLSDA.Interface;

namespace MeteoInfoControlLibrary
{
    class DrawLightningStrikes
    {
        public DrawLightningStrikes(List<BaseStrikeStandard> _strikes, LayersLegend _targetLayerLegend)
        {
            strikesSource = _strikes;
            ClassifyStrikes(strikesSource);
            targetLayerLegend = _targetLayerLegend;
        }
        
        #region 属性变量
        List<BaseStrikeStandard> strikesSource=new List<BaseStrikeStandard>();
        List<BaseStrikeStandard> strikesSourceNegative, strikesSourcePositive;
        LayersLegend targetLayerLegend;
        string layerNameNegative = "NegativeFlashesLayer";
        string layerNamePositive = "PositiveFlashesLayer";

        public string LayerNamePositive
        {
            get { return layerNamePositive; }
            set { layerNamePositive = value; }
        }

        public string LayerNameNegative
        {
            get { return layerNameNegative; }
            set { layerNameNegative = value; }
        }
        public List<BaseStrikeStandard> StrikesSource
        {
            get { return strikesSource; }
            set { strikesSource = value; }
        }
        public LayersLegend TargetLayerLegend
        {
            get { return targetLayerLegend; }
            set { targetLayerLegend = value; }
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 给strikesSourceNegative、strikesSourcePositive赋值
        /// </summary>
        private void ClassifyStrikes(List<BaseStrikeStandard> _strikesSource)
        {
            strikesSourceNegative = new List<BaseStrikeStandard>();
            strikesSourcePositive = new List<BaseStrikeStandard>();
            strikesSourceNegative = _strikesSource.Where(r => r.Intensity <= 0).Select(r => r).ToList();
            strikesSourcePositive = _strikesSource.Where(r => r.Intensity > 0).Select(r => r).ToList();
        }

        /// <summary>
        /// 添加负闪图层，用蓝色"-"表示
        /// </summary>
        /// <param name="_strikesSourceNegative"></param>
        private void DrawStrikesSourceNegative(List<BaseStrikeStandard> _strikesSourceNegative)
        {
            //New layer
            VectorLayer aLayer = new VectorLayer(ShapeTypes.Point);
            aLayer.LayerName = layerNameNegative;
            aLayer.LegendScheme = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Blue, 10);
            //((PointBreak)aLayer.LegendScheme.breakList[0]).Style = PointStyle.Plus; // 标记为加号
            //减号标记未知，等待王老师增加Point.Minus
            ((PointBreak)aLayer.LegendScheme.LegendBreaks[0]).MarkerType = MarkerType.Character;
            ((PointBreak)aLayer.LegendScheme.LegendBreaks[0]).CharIndex = 45;// 减号
            //((PointBreak)aLayer.LegendScheme.breakList[0]).CharIndex = 43;// 加号
            aLayer.Visible = true;

            //Add fields            
            aLayer.EditAddField("日期时间", typeof(DateTime));
            aLayer.EditAddField("经度", typeof(double));
            aLayer.EditAddField("纬度", typeof(double));
            aLayer.EditAddField("强度", typeof(double));
            aLayer.EditAddField("陡度", typeof(double));
            aLayer.EditAddField("误差", typeof(double));
            aLayer.EditAddField("探测方式", typeof(string));

            ////Prepare coordinate data
            //int sourceSumNum = _strikesSourceNegative.Count();

            //Add shape
            foreach (BaseStrikeStandard tmpStrike in _strikesSourceNegative)
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


            //Add layer
            targetLayerLegend.ActiveMapFrame.AddLayer(aLayer);
            targetLayerLegend.ActiveMapFrame.MapView.PaintLayers();
            targetLayerLegend.Refresh();
        }
        /// <summary>
        /// 添加负闪图层，用红色"+"表示
        /// </summary>
        /// <param name="_strikesSourcePositive"></param>
        private void DrawStrikesSourcePositive(List<BaseStrikeStandard> _strikesSourcePositive)
        {
            //New layer
            VectorLayer aLayer = new VectorLayer(ShapeTypes.Point);
            aLayer.LayerName = layerNamePositive;
            aLayer.LegendScheme = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Red, 10);
            //((PointBreak)aLayer.LegendScheme.breakList[0]).Style = PointStyle.Plus; //标记为加号
            //减号标记未知，等待王老师增加Point.Minus
            ((PointBreak)aLayer.LegendScheme.LegendBreaks[0]).MarkerType = MarkerType.Character;
            //((PointBreak)aLayer.LegendScheme.LegendBreaks[0]).CharIndex = 45;//减号
            ((PointBreak)aLayer.LegendScheme.LegendBreaks[0]).CharIndex = 43;//加号
            aLayer.Visible = true;

            //Add fields            
            aLayer.EditAddField("日期时间", typeof(DateTime));
            aLayer.EditAddField("经度", typeof(double));
            aLayer.EditAddField("纬度", typeof(double));
            aLayer.EditAddField("强度", typeof(double));
            aLayer.EditAddField("陡度", typeof(double));
            aLayer.EditAddField("误差", typeof(double));
            aLayer.EditAddField("探测方式", typeof(string));

            ////Prepare coordinate data
            //int sourceSumNum = _strikesSourceNegative.Count();

            //Add shape
            foreach (BaseStrikeStandard tmpStrike in _strikesSourcePositive)
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
            //Add layer
            targetLayerLegend.ActiveMapFrame.AddLayer(aLayer);
            targetLayerLegend.ActiveMapFrame.MapView.PaintLayers();
            targetLayerLegend.Refresh();
        }
        #endregion

        /// <summary>
        /// 绘制闪电图层，需要strikesSourceNegative, strikesSourcePositive
        /// </summary>
        public void DrawStrikes()
        {
            DrawStrikesSourcePositive(strikesSourcePositive);
            DrawStrikesSourceNegative(strikesSourceNegative);
        }

    }

}
/*****************************************************************
** License|知识产权:  Creative Commons| 知识共享
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LLSDA.Entities
{
        /// <summary>
        /// 点评估输入的配置信息||point assessment input configuration
        /// </summary>
        public class PointAnalysisOriginalParams
        {
            bool parallel = true;
            LongitudeOrLatitude longitudeInput = new LongitudeOrLatitude(120);
            LongitudeOrLatitude latitudeInput = new LongitudeOrLatitude(30);
            DateTime minDateTime = new DateTime(2007, 1, 1);
            DateTime maxDateTime = DateTime.Now.AddDays(-DateTime.Now.DayOfYear);
            int eachSideShapeNumber = 9;
            string assessmentName = "Assessment Point";
            ShapeType shapeType = ShapeType.Square;
            double lengthSquare = 3, rCircle = 2.5;

            public double LengthSquare
            {
                get { return lengthSquare; }
                set { lengthSquare = value; }
            }
             
            public double RCircle
            {
                get { return rCircle; }
                set { rCircle = value; }
            }
             
            public ShapeType ShapeType
            {
                get { return shapeType; }
                set { shapeType = value; }
            }
             
            public DateTime MinDateTime
            {
                get { return minDateTime; }
                set { minDateTime = value; }
            }
             
            public DateTime MaxDateTime
            {
                get { return maxDateTime; }
                set { maxDateTime = value; }
            }
             
            public int EachSideShapeNumber
            {
                get { return eachSideShapeNumber; }
                set { eachSideShapeNumber = value; }
            }
             
            public LongitudeOrLatitude LatitudeInput
            {
                get { return latitudeInput; }
                set { latitudeInput = value; }
            }
             
            public LongitudeOrLatitude LongitudeInput
            {
                get { return longitudeInput; }
                set { longitudeInput = value; }
            }
             
            public string AssessmentName
            {
                get { return assessmentName; }
                set { assessmentName = value; }
            }
             //
            public bool Parallel
            {
                get { return parallel; }
                set { parallel = value; }
            }
        }
    }


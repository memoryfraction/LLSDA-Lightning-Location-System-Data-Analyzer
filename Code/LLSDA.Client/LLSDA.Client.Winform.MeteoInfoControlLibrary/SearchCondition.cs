using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonUseLibrary;

namespace MeteoInfoControlLibrary
{
    class SearchCondition
    {
        bool paralel = true;
        LongitudeOrLatitude longitudeInput = new LongitudeOrLatitude(120);
        LongitudeOrLatitude latitudeInput = new LongitudeOrLatitude(30);
        DateTime minDateTime = new DateTime(2009, 1, 1);
        DateTime maxDateTime = DateTime.Now.AddDays(-DateTime.Now.DayOfYear);
        int eachSideSquareNumber = 9;
        string assessmentName = "评估点";
        ShapeTypeEnum shapeType = ShapeTypeEnum.Square;
        double lengthSquare = 5, rCircle = 5;


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
        public ShapeTypeEnum ShapeType
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
        public int EachSideSquareNumber
        {
            get { return eachSideSquareNumber; }
            set { eachSideSquareNumber = value; }
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
        public bool Paralel
        {
            get { return paralel; }
            set { paralel = value; }
        } 
    }

    public enum ShapeTypeEnum
    {
        Circle = 0,
        Square = 1,
    }


}

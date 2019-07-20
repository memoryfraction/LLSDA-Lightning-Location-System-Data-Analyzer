/*****************************************************************


** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LLSDA.Entities
{
    
    public interface IPointAnalysisOriginalParams
    {
         List<PictureResultObject> PictureResultObjList
         {
             get;
             set;
         }
         int UserID
         {
             get;
             set;
         }
         double LengthSquare
         {
             get;
             set;
         }
         double RCircle
         {
             get;
             set;
         }
         ShapeType ShapeType
         {
             get;
             set;
         }
         DateTime MinDateTime
         {
             get;
             set;
         }
         DateTime MaxDateTime
         {
             get;
             set;
         }
         int EachSideShapeNumber
         {
             get;
             set;
         }
         LongitudeOrLatitude LatitudeInput
         {
             get;
             set;
         }
         LongitudeOrLatitude LongitudeInput
         {
             get;
             set;
         }
         string AssessmentName
         {
             get;
             set;
         }
         bool Parallel
         {
             get;
             set;
         }
    }
}

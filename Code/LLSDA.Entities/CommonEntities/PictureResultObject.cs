/*****************************************************************
** License|知识产权:  Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)| 署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)
** License Desc: https://creativecommons.org/licenses/by-nc/4.0/deed.zh
** Author|创建人:     Rong(Rex) Fan|樊荣
** DESC|描述:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LLSDA.Entities
{
    public class PictureResultObject
    {
        string _picturePathFile, _pictureDescription;
        ResultPictureType _pictureType;
        
        public ResultPictureType PictureType
        {
            get { return _pictureType; }
            set { _pictureType = value; }
        }

        Bitmap _pictureContent;

        public Bitmap PictureContent
        {
            get { return _pictureContent; }
            set { _pictureContent = value; }
        }

        /// <summary>
        /// 图片描述
        /// </summary>

        public string PictureDescription
        {
            get { return _pictureDescription; }
            set { _pictureDescription = value; }
        }

        /// <summary>
        /// 图片路径和文件
        /// </summary>
        
        public string PicturePathFile
        {
            get { return _picturePathFile; }
            set { _picturePathFile = value; }
        }
    }

    public class PictureResultObjectEqualityComparer : IEqualityComparer<PictureResultObject>
    {
        //如果图片名字相同，就返回相同|| Only compare pic name
        public bool Equals(PictureResultObject p1, PictureResultObject p2)
        {
            if (p1.PictureType == p2.PictureType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(PictureResultObject pro)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(pro, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = pro.PictureType == new ResultPictureType() ? 0 : pro.PictureType.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = pro.PictureType.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public static class CheckBase64
    {
        #region 判断一个字符串是否是base64字符串
        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str)
        {
            byte[] bytes = null;
            return IsBase64(base64Str, out bytes);
        }

        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <param name="bytes">字符串转换成的字节数组</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str, out byte[] bytes)
        {
            //string strRegex = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";
            bytes = null;
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Contains(","))
                    base64Str = base64Str.Split(',')[1];
                if (base64Str.Length % 4 != 0)
                    return false;
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            try
            {
                bytes = Convert.FromBase64String(base64Str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private static char[] base64CodeArray = new char[]
        {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
        };
        #endregion

        #region 获取图片后缀
        /// <summary>
        /// 获取图片后缀
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string GetImageExt(Image image)
        {
            string imageExt = "";
            var RawFormatGuid = image.RawFormat.Guid;
            if (ImageFormat.Png.Guid == RawFormatGuid)
            {
                imageExt = "png";
            }
            if (ImageFormat.Jpeg.Guid == RawFormatGuid)
            {
                imageExt = "jpg";
            }
            if (ImageFormat.Bmp.Guid == RawFormatGuid)
            {
                imageExt = "bmp";
            }
            if (ImageFormat.Gif.Guid == RawFormatGuid)
            {
                imageExt = "gif";
            }
            if (ImageFormat.Icon.Guid == RawFormatGuid)
            {
                imageExt = "icon";
            }
            return imageExt;
        }
        #endregion
    }
}

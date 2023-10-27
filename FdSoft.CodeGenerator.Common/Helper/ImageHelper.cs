using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public class ImageHelper
    {
        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="flag"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] CompressImage(Stream sFile, int flag = 50, int size = 400)
        {
            var iSource = System.Drawing.Image.FromStream(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW, sH;
            //按比例缩放
            Size tem_size = new(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new();
            long[] qy = new long[1];
            qy[0] = flag; //设置压缩的比例1-100
            EncoderParameter eParam = new(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                MemoryStream save_Ms = new();
                if (jpegICIinfo != null)
                {
                    ob.Save(save_Ms, jpegICIinfo, ep);
                    if (save_Ms.Length > 1024 * size)
                    {
                        if (flag <= 10)
                            flag -= 1;
                        else
                            flag -= 10;
                        if (flag <= 0)
                            flag = 1;
                        if (flag == 1)
                        {
                            ob.Save(save_Ms, tFormat);
                            return save_Ms.ToArray();
                        }
                        CompressImage(sFile, flag, size);
                    }
                }
                else
                {
                    ob.Save(save_Ms, tFormat);
                }
                return save_Ms.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
                sFile.Dispose();
            }
        }
    }
}

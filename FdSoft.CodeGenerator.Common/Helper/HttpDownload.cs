using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public static class HttpDownload
    {
        /// <summary>
        /// URL图片下载
        /// </summary>
        /// <param name="photourl"></param>
        /// <returns></returns>
        public static byte[] DownloadImgToBytes(string photourl)
        {
            var failCount = 0;
        TryAgain:
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(0, 0, 5);
                var file = client.GetByteArrayAsync(photourl).Result;
                if (file.Length < 1)
                {
                    failCount++;
                    if (failCount >= 3)
                        throw new Exception("图片下载失败");
                    else
                    {
                        Thread.Sleep(700);
                        goto TryAgain;
                    }
                }
                return file;
            }
            catch (Exception ex)
            {
                failCount++;
                if (failCount >= 3)
                    return null;
                else
                {
                    Thread.Sleep(700);
                    goto TryAgain;
                }
            }
        }
    }
}

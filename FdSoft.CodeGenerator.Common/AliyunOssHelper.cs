using Aliyun.OSS;
using Aliyun.OSS.Common;
using FdSoft.CodeGenerator.Common.Helper;
using Org.BouncyCastle.Utilities;
using SqlSugar;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace FdSoft.CodeGenerator.Common
{
    public class AliyunOssHelper
    {
        static string accessKeyId = AppSettings.GetConfig("ALIYUN_OSS:KEY");
        static string accessKeySecret = AppSettings.GetConfig("ALIYUN_OSS:SECRET");
        static string endpoint = AppSettings.GetConfig("ALIYUN_OSS:REGIONID");
        static string bucketName1 = AppSettings.GetConfig("ALIYUN_OSS:bucketName");

        /// <summary>
        /// 上传到阿里云
        /// </summary>
        /// <param name="filestreams"></param>
        /// <param name="dirPath">存储路径 eg： upload/2020/01/01/xxx.png</param>
        /// <param name="bucketName">存储桶 如果为空默认取配置文件</param>
        public static System.Net.HttpStatusCode PutObjectFromFile(Stream filestreams, string dirPath, string bucketName = "")
        {
            OssClient client = new(endpoint, accessKeyId, accessKeySecret);
            if (string.IsNullOrEmpty(bucketName)) { bucketName = bucketName1; }
            try
            {
                dirPath = dirPath.Replace("\\", "/");
                PutObjectResult putObjectResult = client.PutObject(bucketName, dirPath, filestreams);
                // Console.WriteLine("Put object:{0} succeeded", directory);

                return putObjectResult.HttpStatusCode;
            }
            catch (OssException ex)
            {
                Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                  ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed with error info: {0}", ex.Message);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        public static System.Net.HttpStatusCode DeleteFile(string dirPath, string bucketName = "")
        {
            if (string.IsNullOrEmpty(bucketName)) { bucketName = bucketName1; }
            try
            {
                OssClient client = new(endpoint, accessKeyId, accessKeySecret);
                DeleteObjectResult putObjectResult = client.DeleteObject(bucketName, dirPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return System.Net.HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// 批量删除指定前缀的所有文件
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="prefix"></param>
        public static void DeleteFileByPrefix(string bucketName, string prefix)
        {
            if (string.IsNullOrEmpty(bucketName)) { bucketName = bucketName1; }
            try
            {
                OssClient client = new(endpoint, accessKeyId, accessKeySecret);
                ObjectListing listResult = default;
                while ((listResult = client.ListObjects(bucketName, prefix)).ObjectSummaries.Any())
                {
                    var request = new DeleteObjectsRequest(bucketName, listResult.ObjectSummaries.Select(o => o.Key).ToList(), true);
                    client.DeleteObjects(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 下载资源
        /// </summary>
        /// <param name="bucketKey"></param>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static Stream DownloadFile(string bucketKey, string dirPath)
        {
            if (string.IsNullOrEmpty(bucketKey) || string.IsNullOrEmpty(dirPath)) return null;
            try
            {
                OssClient client = new(endpoint, accessKeyId, accessKeySecret);
                OssObject ossObject = client.GetObject(bucketKey, dirPath);
                return ossObject.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// 下载byte字节集合
        /// </summary>
        /// <param name="bucketKey"></param>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static byte[] DownloadBytes(string bucketKey, string dirPath, string process = default)
        {
            var bytes = new byte[0];
            if (string.IsNullOrEmpty(bucketKey) || string.IsNullOrEmpty(dirPath)) return bytes;
            try
            {
                OssClient client = new(endpoint, accessKeyId, accessKeySecret);
                OssObject ossObject;
                if (string.IsNullOrEmpty(process))
                    ossObject = client.GetObject(bucketKey, dirPath);
                else
                    ossObject = client.GetObject(new GetObjectRequest(bucketKey, dirPath, process));
                using (var ms = new MemoryStream())
                {
                    ossObject.Content.CopyToAsync(ms).Wait(1000 * 5);
                    bytes = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex.Message);
            }
            return bytes;
        }

        /// <summary>
        /// Stream转byte[]字节集合
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            var bytes = new byte[0];
            if (stream is null) return bytes;
            try
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyToAsync(ms).Wait(1000 * 30);
                    bytes = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex.Message);
            }
            return bytes;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="bucketKey"></param>
        /// <param name="stream"></param>
        public static bool UploadFile(string bucket, string bucketKey, Stream stream)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            var putObjectResult = client.PutObject(bucket, bucketKey, stream);
            if (putObjectResult == null)
                return false;
            return putObjectResult.HttpStatusCode == HttpStatusCode.OK;
        }

        public static bool UploadFile(string bucket, string bucketKey, string fileToUpload)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            var putObjectResult = client.PutObject(bucket, bucketKey, fileToUpload);
            if (putObjectResult == null)
                return false;
            return putObjectResult.HttpStatusCode == HttpStatusCode.OK;
        }

        public static bool DeleteFileByBucket(string bucket, string bucketKey)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            var deleteObjectResult = client.DeleteObject(bucket, bucketKey);
            if (deleteObjectResult == null)
                return false;
            return !deleteObjectResult.DeleteMarker;
        }

        /// <summary>
        /// 获取图片url
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="key"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string GetImageUri(string bucket, string key, double width, double height)
        {
            var process = $"image/resize,m_fixed,w_{width},h_{height}";
            var req = new GeneratePresignedUriRequest(bucket, key, SignHttpMethod.Get)
            {
                Expiration = DateTime.Now.AddHours(1),
                Process = process
            };
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            var uri = client.GeneratePresignedUri(req);
            return Regex.Unescape(uri.ToString());
        }
        /// <summary>
        /// 判断BucketName是否存在
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        public static bool DoesBucketExist(string bucketName)
        {
            if (string.IsNullOrWhiteSpace(bucketName))
                return false;

            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            return client.DoesBucketExist(bucketName);
        }
    }
}

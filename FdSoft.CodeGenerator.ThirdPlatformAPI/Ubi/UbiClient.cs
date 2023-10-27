using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Common.Helper;
using FdSoft.CodeGenerator.Model.Enums;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi
{
    public class UbiClient
    {
        public const string uploadFilePath = "D:\\wwwroot\\cloud.findong.com\\webapi\\";

        #region 宇泛海思沃
        public const int woSyncType = (int)SyncTypeEnum.宇泛智能海思;
        public const int woTokenExpHour = 24;
        public const string woApiUrl = "http://wo-api.uni-ubi.com/";
        public static ConcurrentDictionary<string, HttpClientWrapper> woClients = new ConcurrentDictionary<string, HttpClientWrapper>();

        public static HttpClientWrapper GetWoClient(string appId, string appKey, string appSecret)
        {
            HttpClientWrapper client = default;
            woClients = woClients ?? new ConcurrentDictionary<string, HttpClientWrapper>();

            if (woClients.ContainsKey(appId) && woClients[appId].TokeIllegalFlag)
            {
                woClients[appId].ApiToken.ExpirationTime = DateTime.Now.AddDays(-1);
                woClients[appId].TokeIllegalFlag = false;
            }

            if (!woClients.ContainsKey(appId) || woClients[appId].ApiToken.ExpirationTime.AddMinutes(-5) < DateTime.Now)//提前5分钟换TOKEN
            {
                try
                {
                    HttpClientWrapper wap = null;
                    var token = RedisHelper.HGet<mApiToken>("UbiTokens", appId);

                    if (token != null && token.ExpirationTime.AddMinutes(-5) > DateTime.Now)
                    {
                        wap = new HttpClientWrapper();
                        var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                        var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(woApiUrl + "v1/") };
                        _httpClient.DefaultRequestHeaders.ExpectContinue = false;
                        _httpClient.Timeout = TimeSpan.FromSeconds(5);
                        wap.ApiToken = token;
                        wap.HttpClient = _httpClient;
                        wap.HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken.Token);
                        wap.HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
                    }
                    else
                    {
                        wap = GetWoTokenAndClient(appId, appKey, appSecret);
                        wap.ApiToken.ExpirationTime = DateTime.Now.AddHours(woTokenExpHour).AddMinutes(-1);
                        try
                        {
                            RedisHelper.HSet("UbiTokens", appId, wap.ApiToken);
                        }
                        catch { }
                    }

                    if (woClients.ContainsKey(appId))
                    {
                        woClients[appId].ApiToken = wap.ApiToken;
                        woClients[appId].HttpClient.DefaultRequestHeaders.Remove("token");
                        woClients[appId].HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken.Token);
                        woClients[appId].HttpClient.DefaultRequestHeaders.Remove("projectGuid");
                        woClients[appId].HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
                        client = woClients[appId];
                    }
                    else
                    {
                        woClients.TryAdd(appId, wap);
                        client = wap;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
                client = woClients[appId];
            return client;
        }

        private static HttpClientWrapper GetWoTokenAndClient(string appId, string appKey, string appSecret)
        {
            HttpClientWrapper wap = new HttpClientWrapper();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(woApiUrl + "v1/") };
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
            wap.ApiToken = GetWoToken(appId, appKey, appSecret, _httpClient);
            wap.HttpClient = _httpClient;
            wap.HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken.Token);
            wap.HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
            return wap;
        }

        private static mApiToken GetWoToken(string appId, string appKey, string appSecret, HttpClient client = null)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            if (client == null)
            {
                client = new HttpClient(handler) { BaseAddress = new Uri(woApiUrl + "v1/") };
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.Timeout = TimeSpan.FromSeconds(5);
            }
            var t = DateTime.Now.DateTimeToLong().ToString();
            client.DefaultRequestHeaders.Add("appKey", appKey);
            client.DefaultRequestHeaders.Add("timestamp", t);
            client.DefaultRequestHeaders.Add("sign", Md5Helper.GetMd5Hash(appKey + t + appSecret).ToLower());
            var response = client.GetAsync($"{appId}/auth").Result;
            response.EnsureSuccessStatusCode();
            client.DefaultRequestHeaders.Remove("appKey");
            client.DefaultRequestHeaders.Remove("timestamp");
            client.DefaultRequestHeaders.Remove("sign");
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, new { result = 1, code = string.Empty, msg = string.Empty, data = string.Empty });
            if (result.result != 1) throw new Exception("申请Token失败：" + result.code);
            return new mApiToken { Token = result.data, ExpirationTime = DateTime.Now.AddDays(1).AddMilliseconds(-1) };
        }
        #endregion

        #region 宇泛海思安卓
        public const int androidSyncType = (int)SyncTypeEnum.宇泛智能安卓;
        public const int androidTokenExpHour = 24;
        public const string androidApiUrl = "http://gs-api.uface.uni-ubi.com/";
        public static HttpClientWrapper GetAndroidClient(string appId, string appKey, string appSecret)
        {
            HttpClientWrapper wap = new HttpClientWrapper();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(androidApiUrl + "v1/") };
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
            var token = GetAndroidToken(appId, appKey, appSecret, _httpClient);
            wap.ApiToken = token;
            wap.HttpClient = _httpClient;
            return wap;
        }
        public static HttpClientWrapper GetAndroidTokenAndClient(mApiToken token, string appId)
        {
            HttpClientWrapper wap = new HttpClientWrapper();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(androidApiUrl + "v1/") };
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
            wap.ApiToken = token;
            wap.HttpClient = _httpClient;
            wap.HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken?.Token);
            wap.HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
            return wap;
        }

        public static mApiToken GetAndroidToken(string appId, string appKey, string appSecret, HttpClient client = null)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            if (client == null)
            {
                client = new HttpClient(handler) { BaseAddress = new Uri(androidApiUrl + "v1/") };
                client.DefaultRequestHeaders.ExpectContinue = false;
                client.Timeout = TimeSpan.FromSeconds(5);
            }
            var timestamp = DateTime.Now.DateTimeToLong().ToString();
            var sign = Md5Helper.GetMd5Hash(appKey + timestamp + appSecret).ToLower();
            Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "appKey", appKey }, { "timestamp", timestamp }, { "sign", sign } };
            var content = new FormUrlEncodedContent(dic);
            var response = client.PostAsync($"{appId}/auth", content).Result;
            response.EnsureSuccessStatusCode();
            string resultStr = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeAnonymousType(resultStr, new { result = 1, code = string.Empty, msg = string.Empty, data = string.Empty });
            if (result.result != 1)
            {
                NLogHelper.Error(resultStr);
                throw new Exception("申请Token失败：" + result.code);
            }
            return new mApiToken { Token = result.data, ExpirationTime = DateTime.Now.AddDays(1).AddMilliseconds(-1) };
        }
        #endregion

        #region 获取Base64
        public static string GetFileBase64FromStore(string fileKey, bool withBase64Str = false, string appendParams = "", string process = "")
        {
            if (string.IsNullOrEmpty(fileKey)) return string.Empty;
            string bucketname, bucketkey;
            if (fileKey.StartsWith("face"))
            {
                bucketname = "findong-face";
                bucketkey = fileKey.Replace("face", appendParams.ToUpper());//appendParams = proId
                var file = AliyunOssHelper.DownloadBytes(bucketname, bucketkey, process);
                if (file == null) return string.Empty;
                return withBase64Str ? "data:image/jpeg;base64," + Convert.ToBase64String(file) : Convert.ToBase64String(file);
            }
            else if (fileKey.StartsWith("idcard"))
            {
                bucketname = "findong-idcard";
                bucketkey = fileKey.Replace("idcard/", "");
                var file = AliyunOssHelper.DownloadBytes(bucketname, bucketkey);
                if (file == null) return string.Empty;
                return withBase64Str ? "data:image/jpeg;base64," + Convert.ToBase64String(file) : Convert.ToBase64String(file);
            }
            else if (fileKey.StartsWith("attendance"))
            {
                bucketname = "findong-attendance";
                bucketkey = fileKey.Replace("attendance", appendParams.ToUpper());//appendParams = proId
                var file = AliyunOssHelper.DownloadBytes(bucketname, bucketkey, process);
                if (file == null) return string.Empty;
                return withBase64Str ? "data:image/jpeg;base64," + Convert.ToBase64String(file) : Convert.ToBase64String(file);
            }
            else if (fileKey.StartsWith("/UploadFiles/"))
            {
                string file = Path.Combine(uploadFilePath, fileKey.Substring(1));
                if (!File.Exists(file)) return string.Empty;
                return withBase64Str ? "data:image/jpeg;base64," + Convert.ToBase64String(File.ReadAllBytes(file)) : Convert.ToBase64String(File.ReadAllBytes(file));
            }
            return string.Empty;
        }
        #endregion

    }
}

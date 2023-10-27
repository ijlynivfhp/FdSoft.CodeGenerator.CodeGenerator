using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.NingBo
{
    public class NingBoV2Sdk
    {
        public const int syncType = 1024;
        public const string ningBoApiUrl = "http://183.136.157.18:7334/"; //测试地址：http://183.136.157.18:7332 正式地址：http://183.136.157.18:7334
        readonly static ThreadLocal<SHA256> sha256 = new ThreadLocal<SHA256>(() => SHA256.Create());

        /// <summary>
        /// 甬建码查询
        /// </summary>
        /// <returns></returns>
        public dynamic GetWorkerCode(HttpClientWrapper client, string idCardNo, string apiUser, string apiPass, string projectGuid)
        {
            var result = new object();
            var data = new Dictionary<string, string>();
            data.Add("IdentityCard", idCardNo);
            data.Add("ProjectGuid", projectGuid);

            var response = GetData(apiUser, apiPass, "EnterpriseWorker/GetWorkerCode", data);
            var body = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = JsonConvert.DeserializeObject<dynamic>(body);
                result = new { code = 1, msg = body, success = true, data = json.WorkerCode };
            }
            else
            {
                result = new { code = -1, msg = body, success = false, data = "" };
            }
            return result.ToDyc();
        }

        private HttpResponseMessage GetData(string apiUser, string apiPass, string action, Dictionary<string, string> postData)
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in postData)
            {
                if (string.IsNullOrEmpty(item.Value)) continue;
                if (stringBuilder.Length > 0)
                    stringBuilder.Append('&');

                stringBuilder.Append(Uri.EscapeDataString(item.Key).Replace("%20", "+"));
                stringBuilder.Append('=');
                stringBuilder.Append(Uri.EscapeDataString(item.Value.Replace("%20", "+")));
            }

            TimeSpan ts = DateTime.UtcNow - new DateTime(2000, 1, 1);   //计算时间差
            var curtime = ts.TotalSeconds.ToString();
            string hash = BitConverter.ToString(sha256.Value.ComputeHash(Encoding.UTF8.GetBytes(apiPass + curtime))).Replace("-", string.Empty);  //计算校验和

            //填充header
            var header = new Dictionary<string, string>();
            header.Add("AppKey", apiUser);
            header.Add("CurTime", curtime);
            header.Add("Checksum", hash);

            HttpClient httpClient = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            httpClient = new HttpClient(handler) { BaseAddress = new Uri(ningBoApiUrl) };
            foreach (var item in header)
            {
                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
            return httpClient.GetAsync(action + "?" + stringBuilder.ToString(), HttpCompletionOption.ResponseContentRead).Result;
        }

        private HttpResponseMessage PostData(string apiUser, string apiPass, string action, string postData)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(2000, 1, 1);   //计算时间差
            var curtime = ts.TotalSeconds.ToString();
            string hash = BitConverter.ToString(sha256.Value.ComputeHash(Encoding.UTF8.GetBytes(apiPass + curtime))).Replace("-", string.Empty);  //计算校验和

            //填充header
            var header = new Dictionary<string, string>();
            header.Add("AppKey", apiUser);
            header.Add("CurTime", curtime);
            header.Add("Checksum", hash);

            HttpClient httpClient = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            httpClient = new HttpClient(handler) { BaseAddress = new Uri(ningBoApiUrl) };
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            foreach (var item in header)
            {
                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
            return httpClient.PostAsync(action, content).Result;
        }
    }
}

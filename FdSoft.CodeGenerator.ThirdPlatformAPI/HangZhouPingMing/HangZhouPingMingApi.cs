using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst;
using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FdSoft.CodeGenerator.Common.Extension;
using Newtonsoft.Json;
using FdSoft.CodeGenerator.Common.Helper;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing
{
    public class HangZhouPingMingApi
    {
        HttpClient client;
        private string apiDomain = "http://115.233.209.232:9089/";

        public HangZhouPingMingApi()
        {
            client = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler) { BaseAddress = new Uri(apiDomain) };
            client.DefaultRequestHeaders.ExpectContinue = false;
        }

        /// <summary>
        /// 2.1.6 查询项目工人进/退场信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WorkerEntryExitQueryResponse? GetEntryQuitHistory(WorkerEntryExitQueryRequest request)
        {
            if (request == null  || !request.Valid()) throw new Exception("查询项目工人进/退场信息：请求参数错误");

            string methodName = "WorkerEntryExit.Query";

            if (!string.IsNullOrEmpty(request.idCardNumber))
            {
                request.idCardNumber = request.idCardNumber.AESEncode2(request.ApiPass);
            }
            string postResponse = SendData(methodName, request.projectCode, request.ApiPass, JsonHelper.Serialize(request));
            if (string.IsNullOrEmpty(postResponse))
            {
                NLogHelper.Error($"获取工人进退场记录杭州平台返回为空,request={JsonHelper.Serialize(request)}");
                return null;
            }
            //NLogHelper.Info($"请求到的进退场记录：{postResponse},request={JsonConvert.SerializeObject(request)}");
            var response = JsonConvert.DeserializeObject<WorkerEntryExitQueryResponse>(postResponse);
            if (response?.code != 0)
            {
                NLogHelper.Error($"HangZhouPingMingApi.GetEntryQuitHistory失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        /// <summary>
        /// 2.1.7查询工人考勤 只能按天查询（可以是当天所有人的考勤，也可以是单个工人当天的所有考勤）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WorkerAttendanceQueryResponse? GetWorkerAttendance(WorkerAttendanceQueryRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("查询工人考勤：请求参数错误");

            string methodName = "WorkerAttendance.Query";
            if (!string.IsNullOrEmpty(request.idCardNumber))
            {
                request.idCardNumber = request.idCardNumber.AESEncode2(request.ApiPass);
            }
            string postResponse = SendData(methodName, request.projectCode, request.ApiPass, JsonHelper.Serialize(request));
            if (string.IsNullOrEmpty(postResponse))
            {
                NLogHelper.Error($"查询工人考勤杭州平台返回为空,request={JsonHelper.Serialize(request)}");
                return null;
            }
            var response = JsonConvert.DeserializeObject<WorkerAttendanceQueryResponse>(postResponse);
            if (response?.code != 0)
            {
                NLogHelper.Error($"HangZhouPingMingApi.GetWorkerAttendance失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }



        /// <summary>
        /// 查询项目工人信息 根据身份证号查询单个工人的信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProjectWorkerResponse? GetProjectWorker(ProjectWorkerRequest request) {
            if (request == null || !request.Valid()) throw new Exception("查询项目工人信息：请求参数错误");

            string methodName = "ProjectWorker.Query";

            if (!string.IsNullOrEmpty(request.idCardNumber))
            {
                request.idCardNumber = request.idCardNumber.AESEncode2(request.ApiPass);
            }
            string postResponse = SendData(methodName, request.projectCode, request.ApiPass, JsonHelper.Serialize(request));
            if (string.IsNullOrEmpty(postResponse))
            {
                NLogHelper.Error($"查询项目工人信息杭州平台返回为空,request={JsonHelper.Serialize(request)}");
                return null;
            }
            var response = JsonConvert.DeserializeObject<ProjectWorkerResponse>(postResponse);
            if (response?.code != 0)
            {
                NLogHelper.Error($"HangZhouPingMingApi.GetProjectWorker失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            else if (response?.code == 0 && response.data != null && response.data.rows != null)
            {
                foreach (var item in response.data.rows)
                {
                    if(!string.IsNullOrEmpty(item.idCardNumber))
                        item.idCardNumber = item.idCardNumber.AESDecode2(request.ApiPass);
                    if (!string.IsNullOrEmpty(item.payRollBankCardNumber))
                        item.payRollBankCardNumber = item.payRollBankCardNumber.AESDecode2(request.ApiPass);
                }
            }

            return response;
        }

        /// <summary>
        /// 查询班组信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public GroupResponse? GeGroup(GroupRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("查询班组信息：请求参数错误");

            string methodName = "Team.Query";

            string postResponse = SendData(methodName, request.projectCode, request.ApiPass, JsonHelper.Serialize(request));
            if (string.IsNullOrEmpty(postResponse))
            {
                NLogHelper.Error($"查询班组信息杭州平台返回为空,request={JsonHelper.Serialize(request)}");
                return null;
            }
            var response = JsonConvert.DeserializeObject<GroupResponse>(postResponse);
            if (response?.code != 0)
            {
                NLogHelper.Error($"HangZhouPingMingApi.GeGroup失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            else if (response?.code == 0 && response.data != null && response.data.rows != null)
            {
                foreach (var item in response.data.rows)
                {
                    if (!string.IsNullOrEmpty(item.teamLeaderIDNumber))
                        item.teamLeaderIDNumber = item.teamLeaderIDNumber.AESDecode2(request.ApiPass);
                }
            }
            return response;
        }

        /// <summary>
        /// 查询项目参建单位信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ProjectSubResponse? GeProjectSub(ProjectSubRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("查询项目参建单位信息：请求参数错误");

            string methodName = "ProjectSubContractor.Query";

            string postResponse = SendData(methodName, request.projectCode, request.ApiPass, JsonHelper.Serialize(request));
            if (string.IsNullOrEmpty(postResponse))
            {
                NLogHelper.Error($"查询项目参建单位信息杭州平台返回为空,request={JsonHelper.Serialize(request)}");
                return null;
            }
            var response = JsonConvert.DeserializeObject<ProjectSubResponse>(postResponse);
            if (response?.code != 0)
            {
                NLogHelper.Error($"HangZhouPingMingApi.GeProjectSub失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        #region Common Funcs


        private string SendData(string action, string projectCode, string apiPass, string data)
        {
            Dictionary<string, string> bag = GenSecretSign(action, data, projectCode, apiPass);
            var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
            //var content = new FormUrlEncodedContent(bag);
            var content = new StringContent(String.Join("&", encodedItems), Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = client.PostAsync($"open.api", content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }


        /// <summary>
        /// 添加时间戳、随机码
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GenSecretSign(string method, string data, string projectCode, string apiPass)
        {
            var strData = new StringBuilder();
            var newDataBag = new Dictionary<string, string>();
            var dataBag = new Dictionary<string, string> {
                { "method", method },
                { "version", "1.0" },
                { "appid", projectCode },
                { "format", "json" },
                { "timestamp", DateTime.Now.ToString("yyyyMMddHHmmss") },
                { "nonce", Guid.NewGuid().ToString() },
                { "data", data }
            };

            foreach (var item in dataBag.OrderBy(a => a.Key).ToList())
            {
                strData.Append($"{item.Key}={item.Value}&");
                newDataBag.Add(item.Key, item.Value);
            }

            //添加企业签名
            //if (!string.IsNullOrEmpty(corpkey))
            //{
            //    var corpsign = corpkey + postData["timestamp"];
            //    corpsign = corpsign.AESEncode2(spConfig.ApiPass);
            //    newPostData.Add("corpsign", corpsign);
            //    data.Append($"corpsign={corpsign}&");
            //}

            strData.Append("appSecret=" + apiPass);
            newDataBag.Add("sign", strData.ToString().ToLower().SHA256x16());
            return newDataBag;
        }
        #endregion

    }
}

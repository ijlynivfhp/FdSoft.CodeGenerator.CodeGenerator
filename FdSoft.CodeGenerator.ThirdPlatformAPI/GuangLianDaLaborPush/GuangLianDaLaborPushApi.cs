using CSRedis;
using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Extension;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Common.Helper;
using FdSoft.CodeGenerator.Model.Enums;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Response;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush
{
    /// <summary>
    /// 劳务数据推送到{SyncType}
    /// </summary>
    public class GuangLianDaLaborPushApi
    {
        HttpClient client;
        private string apiDomain = "https://glm.glodon.com/";//"https://glm.glodon.com/"; https://glm-test.glodon.com/
        public const SyncTypeEnum SyncType = SyncTypeEnum.广联达劳务;

        public GuangLianDaLaborPushApi()
        {
            client = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler) { BaseAddress = new Uri(apiDomain) };
            client.DefaultRequestHeaders.ExpectContinue = false;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="action"></param>
        /// <param name="baseRequest"></param>
        /// <returns></returns>
        public T? SendData<T>(string action, BaseRequest baseRequest)
        {
            GenSecretSign(action, baseRequest);
            var content = new StringContent(JsonConvert.SerializeObject(baseRequest), Encoding.UTF8, "application/json");
            var urlPath = $"sync/trd/standard/v1/{action}";
            var response = client.PostAsync(urlPath, content).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(body))
            {
                NLogHelper.Error($"推送{SyncType}返回为空，action={action}，request={JsonHelper.Serialize(baseRequest)}");
                return default;
            }
            return JsonConvert.DeserializeObject<T>(body);
        }

        /// <summary>
        /// Sign生成
        /// </summary>
        /// <returns></returns>
        private void GenSecretSign(string method, BaseRequest baseRequest)
        {
            var strData = new StringBuilder();
            baseRequest.data = baseRequest.data.AESEncode5(baseRequest.secret);
            baseRequest.nonce = Guid.NewGuid().ToString();
            baseRequest.timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var dataBag = new Dictionary<string, string> {
                { "appid", baseRequest.appId },
                { "projectCode", baseRequest.projectCode },
                { "nonce", baseRequest.nonce },
                { "timestamp", baseRequest.timestamp },
                { "data", baseRequest.data }
            };

            var dataBagOrerBy = dataBag.OrderBy(a => a.Key).ToList();
            for (int i = 0; i < dataBagOrerBy.Count(); i++)
            {
                var item = dataBagOrerBy[i];
                if (i == (dataBagOrerBy.Count() - 1))
                    strData.Append($"{item.Key}={item.Value}");
                else
                    strData.Append($"{item.Key}={item.Value}&");
            }

            strData.Insert(0, baseRequest.secret);
            strData.Append(baseRequest.secret);
            baseRequest.sign = strData.ToString().ToLower().GetStrMd5_32D();
        }

        /// <summary>
        /// 1.2.1新增和修改企业信息
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public BaseResponse? PushProjectCorporation(ProjectCorporationRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送新增和修改企业信息：请求参数错误");

            request.data = JsonConvert.SerializeObject(request.Body);
            var response = SendData<BaseResponse>("uploadCompany", request);
            if (response?.code == eCode.成功或重复上传)
            {
                return response;
            }
            else if (response?.code == eCode.参数不正确)
            {
                if (response.message.Contains("存在"))
                {
                    //此项目中已存在此企业，存在的companyCode：5086188，如需更新请传入companyCode参数！企业名称：杭州凡东科技有限公司
                    try
                    {
                        var companyCode = response.message.Split("：")[1].Split("，")[0];
                        response.code = eCode.成功或重复上传;
                        response.message = "通过已存在数据解析出{SyncType}的参建单位主键";
                        response.data = companyCode;
                    }
                    catch (Exception ex)
                    {
                        response.code = eCode.其他;
                        response.message = $"解析已存在{SyncType}的参建单位主键失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}";
                    }
                }
            }
            else
            {
                if (response?.code == eCode.其他)
                {
                    //分包商名称或统一社会信用代码重复，已存在分包商: 
                    if (response.message.Contains("重复") && response.message.Contains("已存在分包商"))
                        response.message = "请确保凡东和广联达系统参建单位名称和统一社会信用编码一致和正确性！";
                }

                NLogHelper.Error($"推送{SyncType}失败，MethodName={CommonHelper.GetMethodName()}，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        /// <summary>
        /// 1.2.2新增和修改班组信息
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public BaseResponse? PushTeamGroup(TeamGroupRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送新增和修改班组信息：请求参数错误");

            request.data = JsonConvert.SerializeObject(request.Body);
            var response = SendData<BaseResponse>("uploadGroup", request);
            if (response?.code == eCode.成功或重复上传)
            {
                return response;
            }
            else if (response?.code == eCode.参数不正确)
            {
                if (response.message.Contains("存在"))
                {
                    //此项目中已存在
                    try
                    {
                        var groupCode = response.message.Split("：")[1].Split(",")[0];
                        response.code = eCode.成功或重复上传;
                        response.message = $"通过已存在数据解析出{SyncType}的班组主键";
                        response.data = groupCode;
                    }
                    catch (Exception ex)
                    {
                        response.code = eCode.其他;
                        response.message = $"解析已存在{SyncType}的班组主键失败，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}";
                    }
                }
            }
            else
            {
                NLogHelper.Error($"推送{SyncType}失败，MethodName={CommonHelper.GetMethodName()}，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        /// <summary>
        /// 1.2.3新增和修改人员信息
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public BaseResponse? PushWorker(WorkerRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送新增和修改人员信息：请求参数错误");

            request.data = JsonConvert.SerializeObject(request.Body);
            var response = SendData<BaseResponse>("uploadWorker", request);
            if (response?.code == eCode.成功或重复上传)
            {
                return response;
            }
            else
            {
                if (response?.code == eCode.未找到错误 && response.message.Contains("存在，暂不支持更新"))
                {
                    //重复上传进场人员，当作成功！ 骆其富人员已存在，暂不支持更新！
                    response.code = eCode.成功或重复上传;
                }
                else
                if (response?.code == eCode.未找到错误 && response.message.Contains("未找到人员进场记录"))
                {
                    //第一次推送人员是退场的，当作成功！ 张忠武未找到人员进场记录！
                    response.code = eCode.成功或重复上传;
                }

                NLogHelper.Error($"推送{SyncType}失败，MethodName={CommonHelper.GetMethodName()}，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        /// <summary>
        /// 1.2.4批量上传考勤信息
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public AttendanceResponse? PushAttendances(AttendanceRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送批量上传考勤信息：请求参数错误");

            request.data = JsonConvert.SerializeObject(request.Body);
            var response = SendData<AttendanceResponse>("uploadAttendances", request);
            if (response?.code == eCode.成功或重复上传)
            {
                response.Body = JsonConvert.DeserializeObject<AttendanceResponse.Attendance>(response.data) ?? new AttendanceResponse.Attendance();
                return response;
            }
            else
            {
                if (response?.code == eCode.未找到错误 && response.message.Contains("存在"))
                {
                }
                NLogHelper.Error($"推送{SyncType}失败，MethodName={CommonHelper.GetMethodName()}，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

        /// <summary>
        /// 1.2.5 异步查询接口
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public AsyncResultResponse? PushAsyncResult(AsyncResultRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送批量上传考勤信息：请求参数错误");

            request.data = JsonConvert.SerializeObject(request.Body);
            var response = SendData<AsyncResultResponse>("queryAsyncResult", request);
            if (response?.code == eCode.成功或重复上传)
            {
                return response;
            }
            else
            {
                NLogHelper.Error($"推送{SyncType}失败，MethodName={CommonHelper.GetMethodName()}，request= {JsonHelper.Serialize(request)},response={JsonHelper.Serialize(response)}");
            }
            return response;
        }

    }
}

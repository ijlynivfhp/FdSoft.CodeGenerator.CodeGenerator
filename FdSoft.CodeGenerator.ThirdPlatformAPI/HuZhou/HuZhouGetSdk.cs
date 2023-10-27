using FdSoft.CodeGenerator.Common.Extension;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Request;
using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Response;
using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Requst;
using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response;
using FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.GroupResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.ProjectSubResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Response.ProjectWorkerResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzAttendanceResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceAccessResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceOnOffLineResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzDeviceResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzGroupResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzProjectSubResponse;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou.Model.HzProjectWorkerResponse;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.HuZhou
{
    public class HuZhouGetSdk
    {
        HttpClient client;
        private string ApiUrl = "http://220.191.216.118:8085";//测试："http://www.jiandu365.site:8093/"; 正式：http://220.191.216.118:8085

        public HuZhouGetSdk()
        {
            client = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler) { BaseAddress = new Uri(ApiUrl) };
            client.DefaultRequestHeaders.ExpectContinue = false;
            client.Timeout = TimeSpan.FromSeconds(5);
        }

        #region 工人
        public List<HzProjectWorkerRow> GetProjectWorker(HzProjectWorkerRequest request)
        {
            var result = new List<HzProjectWorkerRow>();
            var response = new HzProjectWorkerResponse();
            do
            {
                int tryCount = 0;
            TryHzProjectWorkerRequest:
                try
                {
                    if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                    if (!string.IsNullOrEmpty(request.idCardNumber))
                        request.idCardNumber = request.idCardNumber.AESEncode2(request.appSecret);
                    var body = SendDataWithLabor("ProjectWorkerQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                    response = JsonConvert.DeserializeObject<HzProjectWorkerResponse>(body);

                    if (response?.Code == 0 && response.Data.totalCount > 0 && response.Data.rows.Count > 0)
                    {
                        foreach (var item in response.Data.rows)
                        {
                            if (!string.IsNullOrEmpty(item.idCardNumber))
                                item.idCardNumber = item.idCardNumber.AESDecode2(request.appSecret);
                        }
                        result.AddRange(response.Data.rows);
                    }

                    request.pageIndex++;
                    tryCount = default;
                }
                catch
                {
                    tryCount++;
                    if (tryCount <= 3)
                    {
                        Thread.Sleep(1000); goto TryHzProjectWorkerRequest;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            while (request.pageIndex < Math.Ceiling(response.Data.totalCount * 1.0 / request.pageSize));

            return result;
        }
        #endregion

        #region 班组
        public List<HzGroupRow> GetGroup(HzGroupRequest request)
        {
            var result = new List<HzGroupRow>();
            var response = new HzGroupResponse();
            do
            {
                int tryCount = 0;
            TryHzGroupRequest:
                try
                {
                    if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                    var body = SendDataWithLabor("TeamQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                    response = JsonConvert.DeserializeObject<HzGroupResponse>(body);

                    if (response?.Code == 0 && response.Data.totalCount > 0 && response.Data.rows.Count > 0)
                    {
                        response.Data.rows.ForEach(o =>
                        {
                            if (!string.IsNullOrEmpty(o.responsiblePersonIDNumber))
                                o.responsiblePersonIDNumber = o.responsiblePersonIDNumber.AESDecode2(request.appSecret);
                        });
                        result.AddRange(response.Data.rows);
                    }

                    request.pageIndex++;
                    tryCount = default;
                }
                catch
                {
                    tryCount++;
                    if (tryCount <= 3)
                    {
                        Thread.Sleep(1000); goto TryHzGroupRequest;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            while (request.pageIndex < Math.Ceiling(response.Data.totalCount * 1.0 / request.pageSize));

            return result;
        }
        #endregion

        #region 参建单位
        public List<HzProjectSubRow> GetProjectSub(HzProjectSubRequest request)
        {
            var result = new List<HzProjectSubRow>();
            var response = new HzProjectSubResponse();
            do
            {
                int tryCount = 0;
            TryHzProjectSubRequest:
                try
                {
                    if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                    var body = SendDataWithLabor("ProjectSubContractorQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                    response = JsonConvert.DeserializeObject<HzProjectSubResponse>(body);

                    if (response?.Code == 0 && response.Data.totalCount > 0 && response.Data.rows.Count > 0)
                        result.AddRange(response.Data.rows);

                    request.pageIndex++;
                    tryCount = default;
                }
                catch
                {
                    tryCount++;
                    if (tryCount <= 3)
                    {
                        Thread.Sleep(1000); goto TryHzProjectSubRequest;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            while (request.pageIndex < Math.Ceiling(response.Data.totalCount * 1.0 / request.pageSize));

            return result;
        }
        #endregion

        #region 考勤数据
        public List<HzAttendanceResponseRow> GetAttendance(HzAttendanceRequest request)
        {
            var result = new List<HzAttendanceResponseRow>();
            var response = new HzAttendanceResponse();
            do
            {
                int tryCount = 0;
            TryHzAttendanceRequest:
                try
                {
                    if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                    if (!string.IsNullOrEmpty(request.idCardNumber))
                        request.idCardNumber = request.idCardNumber.AESEncode2(request.appSecret);
                    var body = SendDataWithLabor("AttendanceQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));

                    response = JsonConvert.DeserializeObject<HzAttendanceResponse>(body);

                    if (response?.Code == 0 && response.Data.totalCount > 0 && response.Data.rows.Count > 0)
                    {
                        foreach (var item in response.Data.rows)
                        {
                            if (!string.IsNullOrEmpty(item.idCardNumber))
                                item.idCardNumber = item.idCardNumber.AESDecode2(request.appSecret);
                        }
                        result.AddRange(response.Data.rows);
                    }

                    request.pageIndex++;
                    tryCount = default;
                }
                catch
                {
                    tryCount++;
                    if (tryCount <= 3)
                    {
                        Thread.Sleep(1000); goto TryHzAttendanceRequest;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            while (request.pageIndex < Math.Ceiling(response.Data.totalCount * 1.0 / request.pageSize));

            return result;
        }
        #endregion

        #region 获取设备详情信息
        public List<HzDeviceRow> GetDevices(HzDeviceRequest request)
        {
            int tryCount = 0;
            var result = new List<HzDeviceRow>();
        TryHzDeviceRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("DeviceDetailsQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzDeviceResponse>(body);

                if (response?.Code == 0 && response.Data.Count > 0)
                    result.AddRange(response.Data);
            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzDeviceRequest;
                }
                else
                {
                    return result;
                }
            }
            return result;
        }
        #endregion 

        #region 获取设备秘钥信息
        public List<HzDeviceAccessRow> GetDeviceAccesss(HzDeviceAccessRequest request)
        {
            int tryCount = 0;
            var result = new List<HzDeviceAccessRow>();
        TryHzDeviceAccessRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("DeviceAccessQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzDeviceAccessResponse>(body);

                if (response?.Code == 0 && response.Data.Count > 0)
                    result.AddRange(response.Data);
            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzDeviceAccessRequest;
                }
                else
                {
                    return result;
                }
            }
            return result;
        }
        #endregion 

        #region 添加授权
        public bool AddAuthority(HzAddAuthorityRequest request)
        {
            var result = false;
            int tryCount = 0;
        TryHzAddAuthorityRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("AuthorAdd", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzAddAuthorityResponse>(body);

                if (response?.Code == 0) result = true;

            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzAddAuthorityRequest;
                }
            }

            return result;
        }

        public HzAddAuthorityResponse AddAuthority2(HzAddAuthorityRequest request)
        {
            HzAddAuthorityResponse result = new HzAddAuthorityResponse();
            int tryCount = 0;
        TryHzAddAuthorityRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("AuthorAdd", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                result = JsonConvert.DeserializeObject<HzAddAuthorityResponse>(body);


            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzAddAuthorityRequest;
                }
            }

            return result;
        }
        #endregion 

        #region 删除授权
        public bool RemoveAuthority(HzRemoveAuthorityRequest request)
        {
            var result = false;
            int tryCount = 0;
        TryHzRemoveAuthorityRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("AuthorDelete", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzRemoveAuthorityResponse>(body);

                if (response?.Code == 0) result = true;

            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzRemoveAuthorityRequest;
                }
            }

            return result;
        }

        public HzRemoveAuthorityResponse RemoveAuthority2(HzRemoveAuthorityRequest request)
        {
            HzRemoveAuthorityResponse result = new HzRemoveAuthorityResponse();
            int tryCount = 0;
        TryHzRemoveAuthorityRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("AuthorDelete", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                result = JsonConvert.DeserializeObject<HzRemoveAuthorityResponse>(body);
            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzRemoveAuthorityRequest;
                }
            }
            return result;
        }
        #endregion 

        #region 设备清空数据
        public bool DeviceClear(HzDeviceClearRequest request)
        {
            var result = false;
            int tryCount = 0;
        TryHzDeviceClearRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("DeviceRevoke", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzDeviceClearResponse>(body);

                if (response?.Code == 0) result = true;

            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzDeviceClearRequest;
                }
            }

            return result;
        }
        #endregion 

        #region 获取设备在离线状态
        public List<HzDeviceOnOffLineRow> GetDeviceOnOffLines(HzDeviceOnOffLineRequest request)
        {
            int tryCount = 0;
            var result = new List<HzDeviceOnOffLineRow>();
        TryHzDeviceOnOffLineRequest:
            try
            {
                if (string.IsNullOrEmpty(request.appKey)) request.appKey = request.projectCode;
                var body = SendDataWithDevice("DeviceOnlineQuery", request.appKey, request.appSecret, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<HzDeviceOnOffLineResponse>(body);

                if (response?.Code == 0 && response.Data.Count > 0)
                    result.AddRange(response.Data);
            }
            catch
            {
                tryCount++;
                if (tryCount <= 3)
                {
                    Thread.Sleep(1000); goto TryHzDeviceOnOffLineRequest;
                }
            }
            return result;
        }
        #endregion 

        #region 公共方法
        /// <summary>
        /// Http请求发送数据
        /// </summary>
        /// <param name="action"></param>
        /// <param name="projectCode"></param>
        /// <param name="apiPass"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private string SendDataWithLabor(string action, string projectCode, string apiPass, string data)
        {
            Dictionary<string, string> bag = GenSecretSign(action, data, projectCode, apiPass);
            var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
            //var content = new FormUrlEncodedContent(bag);
            var content = new StringContent(JsonConvert.SerializeObject(bag), Encoding.UTF8, "application/json");
            var response = client.PostAsync($"citywso/open/api", content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Http请求发送数据
        /// </summary>
        /// <param name="action"></param>
        /// <param name="projectCode"></param>
        /// <param name="apiPass"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private string SendDataWithDevice(string action, string projectCode, string apiPass, string data)
        {
            Dictionary<string, string> bag = GenSecretSign(action, data, projectCode, apiPass);
            var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
            //var content = new FormUrlEncodedContent(bag);
            var content = new StringContent(JsonConvert.SerializeObject(bag), Encoding.UTF8, "application/json");
            var response = client.PostAsync($"citywso/open/deviceApi", content).Result;
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
                { "version", "1.3" },
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

            strData.Append("appSecret=" + apiPass);
            newDataBag.Add("sign", strData.ToString().ToLower().SHA256x16());
            return newDataBag;
        }
        #endregion
    }
}

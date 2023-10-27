using FdSoft.CodeGenerator.Common.Extension;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Common.Helper;
using FdSoft.CodeGenerator.Model.DtoExt.IoTSys;
using FdSoft.CodeGenerator.Model.Enums;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.HangZhouPingMing.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.AIAlarmRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.DeviceStatusRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.ElevatorGroupRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.ElevatorRealtimeRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetAlarmRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetTrackRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.HelmetVideoRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerAlarmRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerRealTimeRequest;
using static FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Request.TowerVideoRequest;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen
{
    /// <summary>
    /// Iot设备数据推送到余杭五色平台蓝宸开发
    /// </summary>
    public class YuHangWuSeLanChenApi
    {
        HttpClient client;
        private string apiDomain = "http://121.40.246.53:8082/";
        public const SyncTypeEnum SyncType = SyncTypeEnum.余杭五色平台;

        public YuHangWuSeLanChenApi()
        {
            client = new HttpClient();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            client = new HttpClient(handler) { BaseAddress = new Uri(apiDomain) };
            client.DefaultRequestHeaders.ExpectContinue = false;
        }

        /// <summary>
        /// 推送数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="action"></param>
        /// <param name="projectCode"></param>
        /// <param name="apiPass"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public BaseResponse? SendData<T>(BaseRequest<T> baseRequest)
        {
            Dictionary<string, string> bag = GenSecretSign(baseRequest);
            var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
            var content = new StringContent(String.Join("&", encodedItems), Encoding.UTF8, "application/x-www-form-urlencoded");
            content.Headers.ContentType.CharSet = string.Empty;
            var response = client.PostAsync(baseRequest.action, content).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(body))
            {
                NLogHelper.Error($"推送{SyncType}返回为空，request={JsonHelper.Serialize(baseRequest)}");
                return default;
            }
            return JsonConvert.DeserializeObject<BaseResponse>(body);
        }

        /// <summary>
        /// Sign生成
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GenSecretSign<T>(BaseRequest<T> baseRequest)
        {
            var strData = new StringBuilder();
            var newDataBag = new Dictionary<string, string>();
            //文档要求升序排序，因第三方平台有BUG，请按照本顺序排序
            var dataBag = new Dictionary<string, string> {
                { "deviceSerialNo", baseRequest.deviceSerialNo },
                { "data", baseRequest.data },
                { "nonce", baseRequest.nonce },
                { "timestamp", baseRequest.timestamp.ToString() },
            };

            foreach (var item in dataBag.ToList())
            {
                strData.Append($"{item.Key}={item.Value}&");
                newDataBag.Add(item.Key, item.Value);
            }

            strData.Append("hardwareSecretKey=" + baseRequest.hardwareSecretKey);
            strData.Append("&softwareSecretKey=" + baseRequest.softwareSecretKey);
            strData.Append("&projectSecretKey=" + baseRequest.ProjectCode);
            baseRequest.sign = strData.ToString().ToLower().SHA256x16();
            newDataBag.Add("sign", baseRequest.sign);
            return newDataBag;
        }

        /// <summary>
        /// 2.1.1 上传设备状态
        /// </summary>
        /// <param name="client"></param>
        /// <param name="row"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public BaseResponse? PushDeviceStatus(DeviceStatusRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送塔吊、升降机、安全帽设备在线状态：请求参数错误");
            request.action = "openapi/device/status";
            return SendData<DeviceStatus>(request);
        }

        /// <summary>
        /// 2.1.2 上传AI分析告警数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushAIAlarm(AIAlarmRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送AI分析告警数据：请求参数错误");
            request.action = "openapi/device/ai/alarm";
            return SendData<AIAlarm>(request);
        }

        /// <summary>
        /// 2.1.3 上传升降机实时数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushElevatorRealtime(ElevatorRealtimeRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送升降机实时数据：请求参数错误");
            request.action = "openapi/device/lift/realtimeData";
            return SendData<ElevatorRealtime>(request);
        }

        /// <summary>
        /// 2.1.4 上传升降机工作循环数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushElevatorGroup(ElevatorGroupRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送升降机循环数据：请求参数错误");
            request.action = "openapi/device/lift/workCycleData";
            return SendData<ElevatorGroup>(request);
        }

        /// <summary>
        /// 2.1.5 上传塔吊实时数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushTowerRealtime(TowerRealTimeRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送塔吊实时数据：请求参数错误");
            request.action = "openapi/device/towerCrane/realtimeData";
            return SendData<TowerRealTime>(request);
        }

        /// <summary>
        /// 2.1.6 上传塔吊告警数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushTowerAlarm(TowerAlarmRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送塔吊报警数据：请求参数错误");
            request.action = "openapi/device/towerCrane/alarm";
            return SendData<TowerAlarm>(request);
        }

        /// <summary>
        /// 2.1.7 上传塔吊摄像头视频数据
        /// </summary>
        /// <returns></returns>
        public BaseResponse? PushTowerVideo(TowerVideoRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送塔吊摄像头视频数据：请求参数错误");
            request.action = "openapi/device/towerCrane/video";
            return SendData<TowerVideo>(request);
        }

        /// <summary>
        /// 2.1.8 上传安全帽报警数据
        /// </summary>
        /// <param name="message"></param>
        public BaseResponse? PushHelmetAlarm(HelmetAlarmRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送安全帽报警数据：请求参数错误");
            request.action = "openapi/device/helmet/alarm";
            return SendData<HelmetAlarm>(request);
        }

        /// <summary>
        /// 2.1.9 上传安全帽定位数据
        /// </summary>
        /// <param name="message"></param>
        public BaseResponse? PushHelmetTrack(HelmetTrackRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送安全帽定位数据：请求参数错误");
            request.action = "openapi/device/helmet/track";
            return SendData<HelmetTrack>(request);
        }

        /// <summary>
        /// 2.1.10 上传安全帽视频数据
        /// </summary>
        /// <param name="message"></param>
        public BaseResponse? PushHelmetVideo(HelmetVideoRequest request)
        {
            if (request == null || !request.Valid()) throw new Exception("推送安全帽视频数据：请求参数错误");
            request.action = "openapi/device/helmet/video";
            return SendData<HelmetVideo>(request);
        }
    }
}

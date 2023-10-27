using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun.Enums;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YingShiYun
{
    public class YingShiYunApi
    {
        const string domain = "https://open.ys7.com";
        const string ysAppKey = "aa14739543fb46e5978dce85ec666839";
        const string ysSecret = "afc515441def39bc4684ef8ec3724f46";

        /// <summary>
        /// 获取直播地址（视频编码：m3u8）
        /// </summary>
        /// <returns></returns>
        public BaseResponse GetPlayAddress(string deviceSerial, int channelNo = 1, int protocol = 1, int expireTime = 60 * 60 * 24 * 7)
        {
            var response = new BaseResponse();

            string accessTokenStr = accessToken();
            if (string.IsNullOrEmpty(accessTokenStr))
            {
                response.message = $"未获取到账户Token";
                return response;    
            }
            string url = $"{domain}/api/lapp/v2/live/address/get";
            Dictionary<string, object> parmsDic = new Dictionary<string, object>() {
                { "accessToken",accessTokenStr},
                { "deviceSerial",deviceSerial},
                { "channelNo",channelNo},
                { "protocol",protocol},
                { "expireTime",expireTime},
            };

            ysDRO<PlayVideoDRO_Protocol> result = HttpClientAction<ysDRO<PlayVideoDRO_Protocol>>(parmsDic, url);

            response.code = (CodeResponseEnum)Convert.ToInt32(result.code);
            if (result.code == "200")
            {
                response.data = JsonConvert.SerializeObject(result.data);
                response.message = "成功";
            }
            else
            {
                switch (result.code)
                {
                    case "10001": response.message = "参数错误"; break;
                    case "10002": response.message = "accessToken异常或过期"; break;
                    case "10004": response.message = "用户不存在"; break;
                    case "10005": response.message = "appKey异常"; break;
                    case "10017": response.message = "	appKey不存在"; break;
                    case "10026": response.message = "	设备数量超出个人版限制，当前设备无法操作，请充值企业版	"; break;
                    case "20002": response.message = "设备不存在"; break;
                    case "20007": response.message = "设备不在线"; break;
                    case "20014": response.message = "deviceSerial不合法"; break;
                    case "20018": response.message = "该用户不拥有该设备"; break;
                    case "20032": response.message = "该用户下通道不存在"; break;
                    case "60020": response.message = "不支持该命令"; break;
                    case "60060": response.message = "地址未绑定"; break;
                    case "49999": response.message = "数据异常"; break;
                    default: response.message = "操作成功"; break;
                }
            }

            return response;
        }

        /// <summary>
        /// 萤石云token（超管）
        /// </summary>
        /// <returns></returns>
        private string accessToken()
        {
            //获取超管token
            string accessToken = (string)CacheHelper.GetCache(GlobalConstant.Cache_YingShiYunApi_Token);
            //没获取到，重新设置
            if (string.IsNullOrEmpty(accessToken))
            {
                Dictionary<string, object> parmsDic = new Dictionary<string, object>() { { "appKey", ysAppKey }, { "appSecret", ysSecret } };
                string url = $"{domain}/api/lapp/token/get";
                accessToken = getAccessToken(parmsDic, url, string.Empty);
            }
            return accessToken;
        }

        /// <summary>
        /// 重新设置accessToken
        /// </summary>
        private string getAccessToken(Dictionary<string, object> parmsDic, string url, string accessUser)
        {
            string accessToken = string.Empty;
            try
            {
                ysDRO<AccessTokenDRO> ysAccessToken = HttpClientAction<ysDRO<AccessTokenDRO>>(parmsDic, url);
                if (ysAccessToken.code == "200")
                {
                    accessToken = ysAccessToken.data.accessToken;
                    string cacheKey = string.IsNullOrEmpty(accessUser) ? "AccessToken" : $"{accessUser}_AccessToken";

                    var end = new TimeSpan(ysAccessToken.data.expireTime.LongToDateTime().Ticks);
                    var start = new TimeSpan(DateTime.Now.Ticks);
                    var diff = Convert.ToInt32((end - start).TotalMinutes);
                    CacheHelper.SetCache(GlobalConstant.Cache_YingShiYunApi_Token, accessToken, diff);
                }
                else
                {
                    string errMessage = errCodeStr(ysAccessToken.code);
                }
            }
            catch (Exception err)
            {
                throw new Exception(message: "设置accessToken出错：" + err.StackTrace);
            }
            return accessToken;
        }

        /// <summary>
        /// 错误码对照
        /// </summary>
        /// <param name="errCode"></param>
        /// <returns></returns>
        private string errCodeStr(string errCode)
        {
            string codeStr = string.Empty;
            switch (errCode)
            {
                case "200": codeStr = "操作成功"; break;
                case "10001": codeStr = "参数错误"; break;
                case "10005": codeStr = "appKey异常"; break;
                case "10017": codeStr = "appKey不存在"; break;
                case "10030": codeStr = "appkey和appSecret不匹配	"; break;
                default: codeStr = "数据异常"; break;
            }
            return codeStr;
        }

        #region HttpClient-POST-Content-Type: application/x-www-form-urlencoded

        /// <summary>
        /// HttpClient-POST请求统一调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parms"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static T HttpClientAction<T>(Dictionary<string, object> parms, string uri)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    List<string> parmsList = new List<string>();
                    foreach (var item in parms)
                    {
                        parmsList.Add(item.Key + "=" + item.Value);
                    }
                    string parmsStr = string.Join("&", parmsList);
                    StringContent stringContent = new StringContent(parmsStr, System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                    var response = httpClient.PostAsync(new Uri(uri), stringContent).Result;
                    response.Content.Headers.ContentType.CharSet = "UTF-8";
                    T resultObj = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return resultObj;
                }
            }
            catch (Exception e)
            {
                string err = e.Message.ToString();
                return default(T);
            }
        }

        #endregion
    }

    #region 解析临时类
    class defDRO
    {
        public string code { get; set; }
        public string msg { get; set; }
    }

    /// <summary>
    /// 回传基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ysDRO<T>
    {
        public Pager page { get; set; }
        public T data { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
    /// <summary>
    /// 分页信息
    /// </summary>
    public class Pager
    {
        public int total { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
    /// <summary>
    /// token类
    /// </summary>
    class AccessTokenDRO
    {
        public string accessToken { get; set; }
        public long expireTime { get; set; }
    }
    /// <summary>
    /// 设备类
    /// </summary>
    class DeviceDRO
    {
        public string deviceSerial { get; set; }
        public string deviceName { get; set; }
        public string deviceType { get; set; }
        public int status { get; set; }
        public int defence { get; set; }
        public string deviceVersion { get; set; }
    }
    /// <summary>
    /// 设备详情类
    /// </summary>
    class DeDeviceDetailDRO
    {
        public string deviceSerial { get; set; }
        public string deviceName { get; set; }
        public string model { get; set; }
        public int isEncrypt { get; set; }
        public int alarmSoundMode { get; set; }
        public int offlineNotify { get; set; }
        public string category { get; set; }
        public string netType { get; set; }
        public string signal { get; set; }
    }

    class DeDeviceDetailDROExt : DeDeviceDetailDRO
    {
        public string ProName { get; set; }
        public string ProId { get; set; }
    }

    /// <summary>
    /// 子账户类
    /// </summary>
    class AccessInfoDRO
    {
        public string accountId { get; set; }
        public string accountName { get; set; }
        public string appKey { get; set; }
        //子账户状态，0为停用，1为启用
        public int accountStatus { get; set; }
        public PolicyDRO policy { get; set; }
    }
    /// <summary>
    /// 授权类
    /// </summary>
    class PolicyDRO
    {
        public List<StatementDRO> Statement { get; set; }
    }
    /// <summary>
    /// 权限列，资源列
    /// </summary>
    class StatementDRO
    {
        public string Permission { get; set; }
        public List<string> Resource { get; set; }
    }
    /// <summary>
    /// 创建子用户
    /// </summary>
    class CreateAccessDRO
    {
        public string accountId { get; set; }
    }

    /// <summary>
    /// 通道
    /// </summary>
    class ChannelDRO
    {
        public string deviceSerial { get; set; }
        public string ipcSerial { get; set; }
        public int channelNo { get; set; }
        public string deviceName { get; set; }
        public string channelName { get; set; }
        //状态（已废弃）
        public int status { get; set; }
        public string isShared { get; set; }
        //封面
        public string picUrl { get; set; }
        //isEncrypt - 是否加密 0-不加密 1-加密
        public int isEncrypt { get; set; }
        //视频质量 0-流程 1-均衡 2-高清 3-超清
        public int videoLevel { get; set; }
        //是否关联IPC true-是 false-否
        public bool relatedIpc { get; set; }
    }
    /// <summary>
    /// 播放
    /// </summary>
    public class PlayVideoDRO_Protocol
    {
        public string id { get; set; }
        public string url { get; set; }
        public DateTime? expireTime { get; set; }
    }
    #endregion
}

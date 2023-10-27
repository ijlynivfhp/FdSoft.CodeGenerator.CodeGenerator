using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Common.Helper;
using FdSoft.CodeGenerator.Model.BO.DataCenter;
using FdSoft.CodeGenerator.Model.Models.Labor;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi.Model;
using Mapster;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi
{
    public class UbiWoV1Sdk
    {
        public HttpClientWrapper GetTokenAndClient(string appId, string appKey, string appSecret)
        {
            HttpClientWrapper wap = new HttpClientWrapper();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(UbiClient.woApiUrl + "v1/") };
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
            wap.ApiToken = GetToken(appId, appKey, appSecret, _httpClient);
            wap.HttpClient = _httpClient;
            wap.HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken.Token);
            wap.HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
            return wap;
        }
        public HttpClientWrapper GetTokenAndClient(mApiToken token, string appId)
        {
            HttpClientWrapper wap = new HttpClientWrapper();
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(UbiClient.woApiUrl + "v1/") };
            _httpClient.DefaultRequestHeaders.ExpectContinue = false;
            wap.ApiToken = token;
            wap.HttpClient = _httpClient;
            wap.HttpClient.DefaultRequestHeaders.Add("token", wap.ApiToken?.Token);
            wap.HttpClient.DefaultRequestHeaders.Add("projectGuid", appId);
            return wap;
        }
        public mApiToken GetToken(string appId, string appKey, string appSecret, HttpClient client = null)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            if (client == null)
            {
                client = new HttpClient(handler) { BaseAddress = new Uri(UbiClient.woApiUrl + "v1/") };
                client.DefaultRequestHeaders.ExpectContinue = false;
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
        public dynamic AddDevice(HttpClientWrapper client, string appId, string deviceKey, string deviceId, string deviceName)
        {
            try
            {
                var resultModel = new
                {
                    result = 1,
                    code = string.Empty,
                    msg = string.Empty,
                    data = new { state = 0, onlineState = 0, versionNo = string.Empty, lastActiveTime = string.Empty, type = 0, deviceKey = string.Empty }
                };
                var content = new StringContent(JsonConvert.SerializeObject(new { tag = deviceId, name = deviceName }));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.HttpClient.PostAsync($"{appId}/device/{deviceKey}/recType/1", content).Result;
                response.EnsureSuccessStatusCode();
                var resultStr = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeAnonymousType(resultStr, resultModel);
                return result.ToDyc();
            }
            catch (Exception ex)
            {
                return new { result = 0, msg = ex.Message };
            }
        }
        /// <summary>
        /// 初始化设备参数
        /// </summary>
        /// <param name="client"></param>
        /// <param name="appId"></param>
        /// <param name="deviceKey"></param>
        /// <returns></returns>
        public virtual dynamic InitDevice(HttpClientWrapper client, FaceDeviceConfigDTO dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { faceDetectionType = 2 }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PutAsync($"{dto.appId}/device/{dto.deviceNo}/setting", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
            return result.ToDyc();
        }

        public dynamic RemoveDevice(HttpClientWrapper client, string appId, string deviceKey)
        {

            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/device/{deviceKey}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();

        }
        /// <summary>
        /// 查询设备状态(只返回在线的设备)
        /// </summary>
        /// <param name="client"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetDeviceOnlineState(HttpClientWrapper client, string appId, params string[] deviceKey)
        {
            Dictionary<string, bool> vals = new Dictionary<string, bool>();
            try
            {
                var resultModel = new
                {
                    result = 1,
                    code = string.Empty,
                    msg = string.Empty,
                    data = new { total = 0, content = new[] { new { deviceKey = string.Empty, onlineState = false } } }
                };
                var response = client.HttpClient.GetAsync($"{appId}/device/onlineState?deviceKeys=" + string.Join(",", deviceKey)).Result;
                response.EnsureSuccessStatusCode();
                var resultStr = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeAnonymousType(resultStr, resultModel);
                if (result.result == 1 && result.data != null && result.data.content.Length > 0)
                {
                    return result.data.content.Where(item => item.onlineState).Select(item => item.deviceKey);
                }
            }
            catch { }
            return null;
        }

        public dynamic GetDeviceAuths(HttpClientWrapper client, string appId, string deviceKey)
        {
            var response = client.HttpClient.GetAsync($"{appId}/person/authorization?deviceKey={deviceKey}&length=10000").Result;
            response.EnsureSuccessStatusCode();
            var resultStr = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<dynamic>(resultStr);
        }

        public Dictionary<string, DateTime> GetDeviceOnlineStateByAppId(HttpClientWrapper client, string appId)
        {
            Dictionary<string, DateTime> vals = new Dictionary<string, DateTime>();
            try
            {
                var list = new List<dynamic>();
                var pageSize = 50; var pageIndex = 0; var totalCount = 0;
                do
                {
                    pageIndex++;
                    var response = client.HttpClient.GetAsync($"{appId}/device?length={pageSize}&index={pageIndex}").Result;
                    response.EnsureSuccessStatusCode();
                    var resultStr = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<dynamic>(resultStr);
                    if (result.result == 1 && result.data.content.Count > 0)
                    {
                        totalCount = result.data.total;
                        list.AddRange(result.data.content);
                    }
                }
                while (pageIndex < Math.Ceiling(totalCount * 1.0 / pageSize));

                foreach (var item in list)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(item.lastActiveTime))) continue;
                    //var datetime = (DateTime)item.lastActiveTime;
                    var datetime = DateTime.MinValue;
                    if (item.onlineState == 1) datetime = DateTime.Now;
                    vals.Add((string)item.deviceKey, datetime);
                }
            }
            catch (Exception ex) { }
            return vals;
        }

        public dynamic AddPerson(HttpClientWrapper client, string appId, string name, string tag, string idCardNo)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new { guid = string.Empty }
            };
            var content = new StringContent(JsonConvert.SerializeObject(new { name = name, tag = tag, cardNo = tag.Trim(','), idCardNo = idCardNo }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PostAsync($"{appId}/person", content).Result;
            response.EnsureSuccessStatusCode();
            var resultStr = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeAnonymousType(resultStr, resultModel);
            return result.ToDyc();
        }
        public dynamic UpdatePerson(HttpClientWrapper client, string appId, string name, string personGuid, string tag, string idCardNo)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = string.Empty
            };
            var content = new StringContent(JsonConvert.SerializeObject(new { name = name, tag = tag, cardNo = tag.Trim(','), idCardNo = idCardNo }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PutAsync($"{appId}/person/{personGuid}", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }
        public virtual dynamic RemovePerson(HttpClientWrapper client, string appId, string personGuids)
        {

            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/person?personGuids={personGuids}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            if (result.code == "WO_EXP-400")
            {
                return resultModel;
            }
            return result.ToDyc();
        }
        public dynamic GetPerson(HttpClientWrapper client, string appId, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new { guid = string.Empty, tag = string.Empty, faces = new[] { new { guid = string.Empty, faceUrl = string.Empty } } }
            };
            var response = client.HttpClient.GetAsync($"{appId}/person/{personGuid}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }


        public mUbiResult AddOrUpdatePerson(HttpClientWrapper client, string appId, string name, string tag, string idCardNo)
        {
            tag = "," + tag + ",";
            mUbiResult result = new mUbiResult { result = 0 };
            var oldData = GetPersonByTag(client, appId, tag);
            if (oldData.result == 1)
            {
                if (oldData.data.total == 0)
                {
                    var r = AddPerson(client, appId, name, tag, idCardNo);
                    if (r.result == 1)
                        return new mUbiResult { result = 1, data = r.data.guid };
                    else
                        return new mUbiResult { result = 0, msg = r.msg, code = r.code };
                }
                else
                {
                    var p = oldData.data.content[0];
                    var pGuid = Convert.ToString(p.guid);
                    var r = UpdatePerson(client, appId, name, pGuid, tag, idCardNo);
                    if (r.result == 1)
                        return new mUbiResult { result = 1, data = p.guid };
                    else
                        return new mUbiResult { result = 0, msg = r.msg, code = r.code };
                }
            }
            else
                return new mUbiResult { result = 0, msg = oldData.msg, code = oldData.code };
        }
        public dynamic GetPersonByTag(HttpClientWrapper client, string appId, string tag)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new { total = 0, content = new[] { new { guid = string.Empty, tag = string.Empty, faces = new[] { new { guid = string.Empty, faceUrl = string.Empty } } } } }
            };
            var response = client.HttpClient.GetAsync($"{appId}/person?tag=" + tag).Result;
            response.EnsureSuccessStatusCode();
            var resultStr = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();

        }
        public virtual dynamic GetPersonByWorkerName(HttpClientWrapper client, string appId, string workerName)
        {
            var resultModel = new UbiWoV1Person();
            var response = client.HttpClient.GetAsync($"{appId}/person?name=" + workerName).Result;
            response.EnsureSuccessStatusCode();
            var resultStr = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();

        }

        public virtual dynamic GetPersonByAdmitGuids(HttpClientWrapper client, string appId, string workerName)
        {
            throw new NotImplementedException();
        }

        public dynamic AddFaceFromStore(HttpClientWrapper client, string appId, string personGuid, string proId, string ossKey)
        {
            var faildResult = new { result = 0, msg = "not face img", code = "WO_EXP-300" };
            var base64 = UbiClient.GetFileBase64FromStore(ossKey, false, proId.ToUpper());
            if (string.IsNullOrEmpty(base64)) return faildResult;
            return AddFace(client, appId, personGuid, base64);
        }
        public dynamic AddFace(HttpClientWrapper client, string appId, string personGuid, string base64)
        {

            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new { guid = string.Empty }
            };
            var content = new StringContent(JsonConvert.SerializeObject(new { base64 = base64, personGuid = personGuid }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PostAsync($"{appId}/face", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();

        }
        public dynamic AddOrUpdateFace(HttpClientWrapper client, string appId, string personGuid, string faceInfos, string PkValueThird, string proId)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new { guid = string.Empty }
            };
            var info = GetPerson(client, appId, personGuid);
            if (info.result != 1) return new mUbiResult { result = 0, msg = info.msg, code = info.code };
            var oldFaces = info.data?.faces;
            Dictionary<string, string> idMapDicOld = new Dictionary<string, string>();
            Dictionary<string, string> idMapDicNew = new Dictionary<string, string>();
            string msg = string.Empty, code = string.Empty, errorMsg = string.Empty; Dictionary<string, string> badResults = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(faceInfos) || faceInfos == "[]")//清空人脸
            {
                if (oldFaces != null)
                    foreach (var f in oldFaces)
                    {
                        string tempResGuid = Convert.ToString(f.guid);
                        var tempResult = RemoveFace(client, appId, tempResGuid, personGuid);
                        if (tempResult.result != 1) return new mUbiResult { result = 0, msg = tempResult.msg, code = tempResult.code };
                    }
            }
            else
            {
                var faces = JsonConvert.DeserializeObject<List<FaceInfoBo>>(faceInfos);


                if (!string.IsNullOrEmpty(PkValueThird))
                {
                    try
                    {
                        idMapDicOld = JsonConvert.DeserializeObject<Dictionary<string, string>>(PkValueThird);
                    }
                    catch { }
                }

                List<string> oldfaceIds = new List<string>();
                if (oldFaces != null)
                    foreach (var f in oldFaces)
                    {
                        string tempResGuid = Convert.ToString(f.guid);
                        if (!idMapDicOld.ContainsValue(tempResGuid) || !faces.Exists(item => idMapDicOld.ContainsKey(item.FaceId) && idMapDicOld[item.FaceId] == tempResGuid))
                        {
                            var tempResult = RemoveFace(client, appId, tempResGuid, personGuid);
                            //if (tempResult.result != 1) throw new Exception(tempResult.msg);
                        }
                        oldfaceIds.Add(tempResGuid);
                    }

                faces.ForEach(item =>
                {
                    if (!idMapDicOld.ContainsKey(item.FaceId) || !oldfaceIds.Exists(it => it == idMapDicOld[item.FaceId]))
                    {
                        var tempResult = AddFaceFromStore(client, appId, personGuid, proId, item.FileName);
                        if (tempResult.result == 1)
                        {
                            string tempResGuid = Convert.ToString(tempResult.data.guid);
                            if (!idMapDicNew.ContainsKey(item.FaceId))
                                idMapDicNew.Add(item.FaceId, tempResGuid);
                            else
                                idMapDicNew[item.FaceId] = tempResGuid;
                        }
                        else
                        {
                            string tempResCode = Convert.ToString(tempResult.code);
                            errorMsg += $"{tempResult?.msg};";
                            if (!badResults.ContainsKey(item.FaceId))
                                badResults.Add(item.FaceId, tempResCode);
                        }
                    }
                    else
                    {
                        if (!idMapDicNew.ContainsKey(item.FaceId))
                            idMapDicNew.Add(item.FaceId, idMapDicOld[item.FaceId]);
                        else
                            idMapDicNew[item.FaceId] = idMapDicOld[item.FaceId];
                    }
                });
            }
            var resObj = new { result = errorMsg.IsEmpty() ? 1 : 0, data = idMapDicNew.Count > 0 ? JsonConvert.SerializeObject(idMapDicNew) : string.Empty, msg = errorMsg.IsEmpty() ? msg : errorMsg, code = code, data1 = badResults };
            return resObj.ToDyc();
        }

        public dynamic RemovePersonFace(HttpClientWrapper client, string appId, string personGuid)
        {
            return AddOrUpdateFace(client, appId, personGuid, string.Empty, string.Empty, string.Empty);
        }
        public dynamic RemoveFace(HttpClientWrapper client, string appId, string faceGuid, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/face/{faceGuid}?personGuid={personGuid}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public dynamic AddAuth(HttpClientWrapper client, string appId, string deviceKey, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var content = new StringContent(JsonConvert.SerializeObject(new { }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PutAsync($"{appId}/device/{deviceKey}/person/{personGuid}/type/1", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }
        public dynamic AddAuthBatch(HttpClientWrapper client, string appId, string deviceKey, string personGuids)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var content = new StringContent(JsonConvert.SerializeObject(new { deviceKey = deviceKey, personGuids = personGuids, type = 1, passTime = "", permissionTime = "", facePermission = 2 }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = client.HttpClient.PutAsync($"{appId}/device/batchBind", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public virtual dynamic RemoveAuth(HttpClientWrapper client, string appId, string deviceKey, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/device/{deviceKey}/person/{personGuid}/type/1").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public dynamic SetCallBackUrl(HttpClientWrapper client, string appId, int type, string url)
        {
            try
            {
                var resultModel = new
                {
                    result = 1,
                    code = string.Empty,
                    msg = string.Empty
                };
                var content = new StringContent(JsonConvert.SerializeObject(new { url }));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.HttpClient.PutAsync($"{appId}/webhook/{type}", content).Result;
                response.EnsureSuccessStatusCode();
                var resultStr = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
                return result.ToDyc();
            }
            catch (Exception ex)
            {
                return new { result = 0, msg = ex.Message };
            }
        }
    }

    public class mUbiResult
    {
        public int result { get; set; }
        public string code { get; set; }

        public string msg { get; set; }

        public dynamic data { get; set; }
    }
}

using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Model.BO.DataCenter;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Base;
using FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi.Model;
using Mapster;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi
{
    public class UbiAndriodV1Sdk
    {
        public dynamic AddDevice(HttpClientWrapper client, string appId, string deviceKey, string deviceId, string deviceName)
        {
            try
            {
                var resultModel = new
                {
                    result = 1,
                    code = string.Empty,
                    msg = string.Empty,
                    data = new { deviceKey = string.Empty }
                };
                Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "deviceKey", deviceKey }, { "name", deviceName } };
                var content = new FormUrlEncodedContent(dic);
                var response = client.HttpClient.PostAsync($"{appId}/device", content).Result;
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

        public dynamic InitDevice(HttpClientWrapper client, FaceDeviceConfigDTO dto)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            string urlParams = $"?token={client.ApiToken.Token}&ttsModType=2&displayModType=1&comModType=1&recDisModType=2&ttsModStrangerType=1&wiegandType=1&recModeFaceEnable=2&recModeCardEnable=1&recModeCardFaceEnable=1&recModeIdcardFaceEnable=1&recIdcardWhiteEnable=1&recTimeWindow=1";
            var response = client.HttpClient.PutAsync($"{dto.appId}/device/{dto.deviceNo}/setting" + urlParams, null).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
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
            var response = client.HttpClient.DeleteAsync($"{appId}/device/{deviceKey}" + "?token=" + client.ApiToken.Token).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();

        }

        public Dictionary<string, DateTime> GetDeviceOnlineStateByAppId(HttpClientWrapper client, string appId)
        {
            Dictionary<string, DateTime> vals = new Dictionary<string, DateTime>();
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "length", "50" }, { "index", "1" } };
                var list = new List<dynamic>();
                var pageSize = 50; var pageIndex = 0; var totalCount = 0;
                do
                {
                    pageIndex++; dic["index"] = pageIndex.ToString();
                    var content = new FormUrlEncodedContent(dic);
                    var response = client.HttpClient.PostAsync($"{appId}/devices/search", content).Result;
                    response.EnsureSuccessStatusCode();
                    var resultStr = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<dynamic>(resultStr);
                    if (result.result == 1 && result.data.content.Count > 0)
                    {
                        totalCount = result.data.pagination.total;
                        list.AddRange(result.data.content);
                    }
                }
                while (pageIndex < Math.Ceiling(totalCount * 1.0 / pageSize));
                if (list.Count > 0)
                    return list.ToDictionary(item => (string)item.deviceKey, item => item.status == 1 ? DateTime.Now : DateTime.MinValue);
            }
            catch (Exception ex) { }
            return vals;
        }
        public dynamic GetDeviceAuths(HttpClientWrapper client, string appId, string deviceKey)
        {
            var response = client.HttpClient.GetAsync($"{appId}/device/{deviceKey}/people?token={client.ApiToken.Token}").Result;
            response.EnsureSuccessStatusCode();
            var resultStr = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<dynamic>(resultStr);
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
            Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "name", name }, { "tag", tag } };
            var content = new FormUrlEncodedContent(dic);
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
            var response = client.HttpClient.PutAsync($"{appId}/person/{personGuid}?token={client.ApiToken.Token}&name={name}&tag={tag}", null).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }
        public dynamic RemovePerson(HttpClientWrapper client, string appId, string personGuid)
        {

            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/person/{personGuid}?token={client.ApiToken.Token}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            if (result.code == "GS_EXP-212")
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
            var response = client.HttpClient.GetAsync($"{appId}/person/{personGuid}?token={client.ApiToken.Token}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public dynamic GetPersonFaces(HttpClientWrapper client, string appId, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty,
                data = new[] { new { guid = string.Empty, faceUrl = string.Empty } }
            };
            var response = client.HttpClient.GetAsync($"{appId}/person/{personGuid}/faces?token={client.ApiToken.Token}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public mUbiResult AddOrUpdatePerson(HttpClientWrapper client, string appId, string name, string tag, string idCardNo)
        {
            mUbiResult result = new mUbiResult { result = 0 };
            var oldData = GetPersonByTag(client, appId, tag);
            if (oldData.result == 1)
            {
                if (oldData.data.content.Count == 0)
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
                    string pGuid = Convert.ToString(p.guid);
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
                data = new { total = 0, content = new[] { new { guid = string.Empty, tag = string.Empty } } }
            };
            Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "tag", tag } };
            var content = new FormUrlEncodedContent(dic);
            var response = client.HttpClient.PostAsync($"{appId}/people/search", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }
        public dynamic GetPersonByWorkerName(HttpClientWrapper client, string appId, string workerName)
        {
            return null;

        }
        public dynamic AddFaceFromStore(HttpClientWrapper client, string appId, string personGuid, string proId, string ossKey)
        {
            var faildResult = new { result = 0, msg = "not face img", code = "GS_EXP-609" };
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
            string data = $"token={client.ApiToken.Token}&img={System.Web.HttpUtility.UrlEncode(base64)}&validLevel=0";
            var content = new StringContent(data, Encoding.UTF8);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //base64 = "https://appapi.findong.com/api/FileViewer?proId=c1967e8d-4012-46cb-af77-abc1011e8a85&tokenId=&fileName=face/B05975F79107489EB24E1850857C7034.jpg";
            //Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "guid", personGuid }, { "img", base64 }, { "validLevel", "0" } };
            //var content = new FormUrlEncodedContent(dic);
            var response = client.HttpClient.PostAsync($"{appId}/person/{personGuid}/face/valid", content).Result;
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
            var info = GetPersonFaces(client, appId, personGuid);
            if (info.result != 1) return new mUbiResult { result = 0, msg = info.msg, code = info.code };
            var oldFaces = info.data;
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
            return new { result = errorMsg.IsEmpty() ? 1 : 0, data = idMapDicNew.Count > 0 ? JsonConvert.SerializeObject(idMapDicNew) : string.Empty, msg = errorMsg.IsEmpty() ? msg : errorMsg, code = code, data1 = badResults }.ToDyc();
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
            var response = client.HttpClient.DeleteAsync($"{appId}/person/{personGuid}/face/{faceGuid}?token={client.ApiToken.Token}").Result;
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
            Dictionary<string, string> dic = new Dictionary<string, string> { { "appId", appId }, { "token", client.ApiToken.Token }, { "personGuids", personGuids }, { "deviceKey", deviceKey } };
            var content = new FormUrlEncodedContent(dic);
            var response = client.HttpClient.PostAsync($"{appId}/device/{deviceKey}/people", content).Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }

        public dynamic RemoveAuth(HttpClientWrapper client, string appId, string deviceKey, string personGuid)
        {
            var resultModel = new
            {
                result = 1,
                code = string.Empty,
                msg = string.Empty
            };
            var response = client.HttpClient.DeleteAsync($"{appId}/device/{deviceKey}/people?token={client.ApiToken.Token}&personGuid={personGuid}").Result;
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeAnonymousType(response.Content.ReadAsStringAsync().Result, resultModel);
            return result.ToDyc();
        }
        public dynamic SetCallBackUrl(HttpClientWrapper client, string appId, int type, string url)
        {
            return null;
        }

        public dynamic GetPersonByAdmitGuids(HttpClientWrapper client, string appId, string workerName)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Extensions;
using FdSoft.CodeGenerator.Model.Labor;
using FdSoft.CodeGenerator.Model.Models;
using SqlSugar;
using SqlSugar.IOC;

namespace FdSoft.CodeGenerator.Service.System
{
    public class CacheService
    {
        private readonly static SqlSugarScopeProvider db = DbScoped.SugarScope.GetConnectionScope(0);

        #region 用户权限 缓存
        public static List<string> GetUserPerms(string key)
        {
            return (List<string>)CacheHelper.GetCache(key);
        }

        public static void SetUserPerms(string key, object data)
        {
            CacheHelper.SetCache(key, data);
        }
        public static void RemoveUserPerms(string key)
        {
            CacheHelper.Remove(key);
        }
        #endregion

        /// <summary>
        /// 根据项目，设备编号从缓存获取设备信息
        /// </summary>
        /// <param name="proId"></param>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        public static LaborDevice GetDeviceByCache(string deviceNo, string proId = default)
        {
            if (proId.IsEmpty()) proId = Guid.Empty.ToString();
            var deviceKey = $"GetDeviceByCache:{proId}:{deviceNo}";
            var device = CacheHelper.GetCache<LaborDevice>(deviceKey);
            if (device.IsNull() || true)
            {
                device = db.Ado.SqlQuerySingle<LaborDevice>($"SELECT ProId,DeviceId,DeviceSubType,InOutType,GateId FROM dbo.Labor_Device WHERE {(proId == Guid.Empty.ToString() ? default : $"ProId='{proId}' AND ")} DeviceNo='{deviceNo}' AND DeleteStatus=0 ORDER BY Id DESC");
                if (device.IsNull() && proId != Guid.Empty.ToString())
                    device = db.Ado.SqlQuerySingle<LaborDevice>($"SELECT ProId,DeviceId,DeviceSubType,InOutType,GateId FROM dbo.Labor_Device WHERE DeviceNo='{deviceNo}' AND DeleteStatus=0 ORDER BY Id DESC");
                if (device.IsNull())
                    device = db.Ado.SqlQuerySingle<LaborDevice>($"SELECT ProId,DeviceId,DeviceSubType,InOutType,GateId FROM dbo.Labor_Device WHERE {(proId == Guid.Empty.ToString() ? default : $"ProId='{proId}' AND ")} DeviceNo='{deviceNo}' ORDER BY Id DESC");
                if (device.IsNull() && proId != Guid.Empty.ToString())
                    device = db.Ado.SqlQuerySingle<LaborDevice>($"SELECT ProId,DeviceId,DeviceSubType,InOutType,GateId FROM dbo.Labor_Device WHERE DeviceNo='{deviceNo}' ORDER BY Id DESC");
                if (device.IsNull())
                    device = new LaborDevice()
                    {
                        DeviceId = Guid.Empty.ToString(),
                        InOutType = 0,
                        ProId = proId
                    };
                CacheHelper.SetCache(deviceKey, device, 5);
            }
            return device;
        }

        public static string GetRoutingKeyBySyncProConfig(string proId)
        {
            var proKey = $"GetSyncProConfig:{proId}";
            var routingKey = CacheHelper.GetCache<string>(proKey);
            if (routingKey.IsEmpty() || true)
            {
                var syncTypes = db.Ado.SqlQuery<int>($@"SELECT spc.SyncType
                    FROM dbo.Labor_SyncProjectConfig spc
                        INNER JOIN dbo.Labor_SyncType st
                            ON st.SyncType = spc.SyncType
                               AND st.PlatformType = 1
                               AND st.SyncStatus = 1
                    WHERE spc.ProId = '{proId}'
                          AND spc.SyncStatus = 1");
                if (syncTypes.Count > 0)
                {
                    routingKey = string.Join(".", syncTypes.Select(o => $"st{o}_"));
                    CacheHelper.SetCache(proKey, routingKey, 5);
                }
            }
            return routingKey;
        }

        /// <summary>
        /// 根据设备获取项目ProId
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        public static string GetProIdByDeviceNo(string deviceNo = default)
        {
            if (deviceNo.IsEmpty()) return string.Empty;
            var deviceKey = $"GetProIdByDeviceNo:{deviceNo}";
            var proId = CacheHelper.GetCache<string>(deviceKey) ?? string.Empty;
            if (proId.IsEmpty() || true)
            {
                proId = db.Ado.GetString($"SELECT ProId FROM dbo.Labor_Device WHERE DeviceNo='{deviceNo}' AND DeleteStatus=0 ORDER BY Id DESC");
                if (proId.IsNotEmpty())
                    CacheHelper.SetCache(deviceKey, proId, 5);
            }
            return proId;
        }
    }
}

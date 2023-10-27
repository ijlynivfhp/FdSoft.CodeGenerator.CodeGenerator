using FdSoft.CodeGenerator.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.Ubi.Model
{
    public class mAuthBatchModel
    {
        /// <summary>
        /// 1是删除行为
        /// </summary>
        public int? BatchType { get; set; }
        public string DeviceKey { get; set; }

        public string PersonGuid { get; set; }

        public LaborSyncWorkerAuthResult AddModel { get; set; }

        public LaborSyncWorkerAuthQueue AddModelV2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums.Labor
{
    public enum SingleDoubleMethodEnum
    {
        [Description("设备上线：心跳（5分钟）")]
        onLine = 5,
        [Description("人员注册")]
        personCreate = 10,
        [Description("人员照片注册")]
        faceCreate = 15,
        [Description("人员删除")]
        personDelete = 20,
        [Description("识别记录上传")]
        uploadRecord = 25,
        [Description("uploadRecord-ACK")]
        uploadRecordAck = 30,
        [Description("配置获取")]
        getDeviceConfig = 35,
        [Description("getDeviceConfig-ACK")]
        getDeviceConfigAck = 40,
        [Description("配置设置")]
        setDeviceConfig = 45,
        [Description("setDeviceConfig-ACK")]
        setDeviceConfigAck = 50,
        [Description("设备重启")]
        reboot = 55,
        [Description("reboot-ACK")]
        rebootAck = 60,
        [Description("设备重置")]
        deviceReset = 65,
        [Description("deviceReset-ACK")]
        deviceResetAck = 70,
        [Description("online-ACK")]
        onlineAck = 75,
        [Description("faceCreate-ACK")]
        faceCreateAck = 80,
        [Description("personDelete-ACK")]
        personDeleteAck = 85,
        [Description("personFindByPage")]
        personFindByPage = 90,
        [Description("personFindByPage-ACK")]
        personFindByPageAck = 95,
    }
}

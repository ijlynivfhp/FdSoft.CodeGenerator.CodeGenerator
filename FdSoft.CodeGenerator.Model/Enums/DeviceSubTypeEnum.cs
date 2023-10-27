using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    public enum DeviceSubTypeEnum
    {
        [Description("")]
        其它 = -1,
        [Description("YF-JYW")]
        宇泛局域网 = 0,
        [Description("NONE-HUZ-ZF")]
        品牌未知湖州直发 = 2993,
        [Description("YF-HZ-ZF")]
        宇泛杭州直发 = 2994,
        [Description("YF-HZ-DZSF")]
        宇泛杭州定制双发 = 2995,
        [Description("YF-HZ-DF")]
        宇泛杭州单发 = 2996,
        [Description("YF-HZ-SF")]
        宇泛杭州双发 = 2997,
        [Description("HQ-NB-SF")]
        海清宁波双发 = 2998,
        [Description("YF-WT-AZ")]
        宇泛沃土安卓 = 2999,
        [Description("YF-WO-HS")]
        宇泛沃海思 = 3000,
    }
}

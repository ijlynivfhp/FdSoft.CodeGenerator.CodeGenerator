using FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush.Enums;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.GuangLianDaLaborPush
{
    /// <summary>
    /// 凡东字典转广联达字典
    /// </summary>
    public static class FdDictionaryToGLDDictionary
    {
        /// <summary>
        /// 凡东参建单位转广联达参建单位
        /// </summary>
        /// <param name="corpType"></param>
        /// <returns></returns>
        public static string FdCorpTypeToGLDCorpType(this string corpType)
        {
            switch (corpType)
            {
                case "009":
                    return ((int)eProjectCorporationTypeEnum.总包单位).ToString();
                case "001":
                    return ((int)eProjectCorporationTypeEnum.专业分包).ToString();
                case "006":
                    return ((int)eProjectCorporationTypeEnum.劳务分包).ToString();
                case "002":
                    return ((int)eProjectCorporationTypeEnum.设备分包).ToString();
                case "003":
                    return ((int)eProjectCorporationTypeEnum.材料分包).ToString();
                case "004":
                    return ((int)eProjectCorporationTypeEnum.后勤服务).ToString();
                case "005":
                    return ((int)eProjectCorporationTypeEnum.特殊设备).ToString();
                case "007":
                    return ((int)eProjectCorporationTypeEnum.监理单位).ToString();
                case "008":
                    return ((int)eProjectCorporationTypeEnum.建设单位).ToString();
                case "010":
                    return ((int)eProjectCorporationTypeEnum.勘察单位).ToString();
                case "011":
                    return ((int)eProjectCorporationTypeEnum.设计单位).ToString();
                default:
                    return ((int)eProjectCorporationTypeEnum.其他合作单位).ToString();
            }
        }

        /// <summary>
        /// 凡东民族转广联达民族
        /// </summary>
        public static string FdNationToGLDNation(this string nation)
        {
            switch (nation)
            {
                case "汉": return "01";
                case "蒙古": return "02";
                case "回": return "03";
                case "藏": return "04";
                case "维吾尔": return "05";
                case "苗": return "06";
                case "彝": return "07";
                case "壮": return "08";
                case "布依": return "09";
                case "朝鲜": return "10";
                case "满": return "11";
                case "侗": return "12";
                case "瑶": return "13";
                case "白": return "14";
                case "土家": return "15";
                case "哈尼": return "16";
                case "哈萨克": return "17";
                case "傣": return "18";
                case "黎": return "19";
                case "傈僳": return "20";
                case "佤": return "21";
                case "畲": return "22";
                case "高山": return "23";
                case "拉祜": return "24";
                case "水": return "25";
                case "东乡": return "26";
                case "纳西": return "27";
                case "景颇": return "28";
                case "柯尔克孜": return "29";
                case "土": return "30";
                case "达斡尔": return "31";
                case "仫佬": return "32";
                case "羌": return "33";
                case "布朗": return "34";
                case "撒拉": return "35";
                case "毛难": return "36";
                case "仡佬": return "37";
                case "锡伯": return "38";
                case "阿昌": return "39";
                case "普米": return "40";
                case "塔吉克": return "41";
                case "怒": return "42";
                case "乌孜别克": return "43";
                case "俄罗斯": return "44";
                case "鄂温克": return "45";
                case "德昂": return "46";
                case "保安": return "47";
                case "裕固": return "48";
                case "京": return "49";
                case "塔塔尔": return "50";
                case "独龙": return "51";
                case "鄂伦春": return "52";
                case "赫哲": return "53";
                case "门巴": return "54";
                case "珞巴": return "55";
                case "基诺": return "56";
                case "穿青": return "57";

                case "汉族": return "01";
                case "蒙古族": return "02";
                case "回族": return "03";
                case "藏族": return "04";
                case "维吾尔族": return "05";
                case "苗族": return "06";
                case "彝族": return "07";
                case "壮族": return "08";
                case "布依族": return "09";
                case "朝鲜族": return "10";
                case "满族": return "11";
                case "侗族": return "12";
                case "瑶族": return "13";
                case "白族": return "14";
                case "土家族": return "15";
                case "哈尼族": return "16";
                case "哈萨克族": return "17";
                case "傣族": return "18";
                case "黎族": return "19";
                case "傈僳族": return "20";
                case "佤族": return "21";
                case "畲族": return "22";
                case "高山族": return "23";
                case "拉祜族": return "24";
                case "水族": return "25";
                case "东乡族": return "26";
                case "纳西族": return "27";
                case "景颇族": return "28";
                case "柯尔克孜族": return "29";
                case "土族": return "30";
                case "达斡尔族": return "31";
                case "仫佬族": return "32";
                case "羌族": return "33";
                case "布朗族": return "34";
                case "撒拉族": return "35";
                case "毛南族": return "36";
                case "仡佬族": return "37";
                case "锡伯族": return "38";
                case "阿昌族": return "39";
                case "普米族": return "40";
                case "塔吉克族": return "41";
                case "怒族": return "42";
                case "乌孜别克族": return "43";
                case "俄罗斯族": return "44";
                case "鄂温克族": return "45";
                case "德昂族": return "46";
                case "保安族": return "47";
                case "裕固族": return "48";
                case "京族": return "49";
                case "塔塔尔族": return "50";
                case "独龙族": return "51";
                case "鄂伦春族": return "52";
                case "赫哲族": return "53";
                case "门巴族": return "54";
                case "珞巴族": return "55";
                case "基诺族": return "56";
                case "穿青族": return "57";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 凡东工种转广联达工种
        /// </summary>
        /// <param name="workerTypeCode"></param>
        /// <returns></returns>
        public static string FdWorkerTypeCodeToGLDWorkerTypeCode(this string workerTypeCode)
        {
            switch (workerTypeCode)
            {
            case "020": return "020";//钢筋工
            case "030": return "030";//架子工
            case "040": return "040";//混凝土工
            case "070": return "070";//通风工
            case "130": return "130";//电工 建筑电工
            case "150": return "150";//机械司机
            case "汉族": return "192";//油漆工
            //case "汉族": return "193";//镶嵌工
            //case "汉族": return "194";//涂裱工
            case "230": return "230";//防水工
            case "250": return "250";//石工
            case "270": return "270";//电焊工
            case "310": return "310";//线路架设工
            //case "汉族": return "G401";//抹灰工（泥工）
            case "300": return "G402";//测量放线工
            case "080": return "G403";//塔吊司机（起重工）安装起重工
            case "170": return "G404";//塔吊指挥（信号工） 起重信号工
            case "210": return "G405";//幕墙安装工 建筑门窗幕墙安装工
            case "060": return "G406";//机械安装拆卸工	机械设备安装工
            case "240": return "G407";//木工
            case "010": return "G408";//砌筑工（瓦工）
            case "110": return "G409";//水暖工（管道工）
            //case "汉族": return "G410";//普工
            case "390": return "G411";//杂工
            case "900": return "G412";//分包管理人员
            case "050": return "G413";//模板工
            //case "汉族": return "G414";//机动车驾驶员
            //case "汉族": return "G415";//安装工
            //case "汉族": return "G416";//外用电梯司机
            //case "汉族": return "G417";//工长
            //case "汉族": return "G418";//钢结构
            //case "汉族": return "G419";//消防安装工
            //case "汉族": return "G420";//土方
            //case "汉族": return "G421";//植筋工
            //case "汉族": return "G422";//保温
            //case "汉族": return "G423";//降水
            //case "汉族": return "G424";//人防
            //case "汉族": return "G425";//电梯安装工
            //case "汉族": return "G426";//二次结构
            //case "汉族": return "G427";//吊车司机
            //case "汉族": return "G428";//机修工
            //case "汉族": return "G429";//挖机司机
            //case "汉族": return "G430";//栋号长
            //case "汉族": return "G431";//基坑支护
            case "190": return "G432";//装饰装修工
            //case "汉族": return "G433";//铲车司机
            //case "汉族": return "G434";//铆工
            //case "汉族": return "G435";//放线工
            //case "汉族": return "G436";//护坡工
            //case "汉族": return "G437";//精装修工
            //case "汉族": return "G438";//锚索工
            //case "汉族": return "G439";//门窗安装工
            //case "汉族": return "G440";//喷浆工
            //case "汉族": return "G441";//弱电
            //case "汉族": return "G442";//支护工
            case "160": return "G443";//桩机操作工
            //case "汉族": return "G444";//加固工
            //case "汉族": return "G445";//绿化工
            //case "汉族": return "G446";//修理工
            //case "汉族": return "G447";//修改补
            //case "汉族": return "G448";//电器设备安装工
            //case "汉族": return "G449";//预应力
            case "280": return "G450";//爆破工
            //case "汉族": return "G452";//水电工
            //case "汉族": return "G453";//司钻员
            //case "汉族": return "G454";//筑路工
            //case "汉族": return "G455";//桥隧工
            case "120": return "G456";//强电 变电安装工
            case "090": return "G457";//安装钳工
            //case "汉族": return "G458";//气焊气割工
            //case "汉族": return "G459";//管片拼装工
            //case "汉族": return "G460";//双轨梁操作手
            //case "汉族": return "G461";//螺杆工
            //case "汉族": return "G462";//司索工
            //case "汉族": return "G463";//拌浆站操作员
            //case "汉族": return "G464";//轨线工
            //case "汉族": return "G465";//盾构机司机
            //case "汉族": return "G466";//电机车司机
            //case "汉族": return "G467";//龙门吊司机
            //case "汉族": return "G468";//装载机司机
            //case "汉族": return "G469";//叉车司机
            //case "汉族": return "G470";//热处理工
            //case "汉族": return "G471";//仪表工
            //case "汉族": return "G472";//旋挖钻机手
            //case "汉族": return "G473";//顶管工
            //case "汉族": return "G474";//隔墙板工
            //case "汉族": return "G475";//履带吊司机
            //case "汉族": return "G476";//成槽机司机
            //case "汉族": return "G477";//双轮铣司机
            //case "汉族": return "G478";//布鲁克操作手
            //case "汉族": return "G479";//二次注浆工
            //case "汉族": return "G480";//接触网工
            //case "汉族": return "G481";//翻译
            case "100": return "G482";//电力电气工程师 电气设备安装调试工
            //case "汉族": return "G483";//通信专业工程师
            //case "汉族": return "G484";//信号专业工程师
            //case "汉族": return "G485";//文施清扫
            //case "汉族": return "G486";//开挖工
            //case "汉族": return "G487";//二衬工
            //case "汉族": return "G488";//出渣工
            //case "汉族": return "G489";//仰拱工
            case "380": return "G490";//金属工
            case "140": return "G491";//司泵工
            case "320": return "G492";//古建筑传统石工
            //case "汉族": return "G493";//石雕工
            //case "汉族": return "G494";//砧细工
            case "330": return "G495";//古建筑传统瓦工
            //case "汉族": return "G496";//砧刻工
            //case "汉族": return "G497";//砌花街工
            //case "汉族": return "G498";//泥塑工
            //case "汉族": return "G499";//古建瓦工
            case "340": return "G500";//古建筑传统彩画工
            //case "汉族": return "G501";//彩绘工
            case "350": return "G502";//古建筑传统木工
            //case "汉族": return "G503";//木雕工
            //case "汉族": return "G504";//匾额工
            case "360": return "G505";//古建筑传统油工
            //case "汉族": return "G506";//推光漆工
            //case "汉族": return "G507";//古建油漆
            //case "汉族": return "G508";//瓷砖工
            //case "汉族": return "G509";//锅炉作业(含水质化验)
            //case "汉族": return "G510";//压力容器作业
            //case "汉族": return "G511";//制冷作业
            //case "汉族": return "G512";//危险物品作业
            //case "汉族": return "G513";//力工
            //case "汉族": return "G514";//管工
            //case "汉族": return "G515";//防火工
            //case "汉族": return "G516";//衬里工
            //case "汉族": return "G517";//防腐工
            //case "汉族": return "G518";//物料提升机司机
            //case "汉族": return "G519";//机动车司机
            //case "汉族": return "G520";//临时工种
            case "26": return "G521";//焊工
            //case "汉族": return "G522";//压力焊
            default:
                    return "G451"; //其它
            }
        }

        /// <summary>
        /// 凡东岗位转广联达岗位
        /// </summary>
        /// <param name="workerTypeCode"></param>
        /// <returns></returns>
        public static string FdManagerTypeCodeToGLDManagerTypeCode(this string workerTypeCode)
        {
            switch (workerTypeCode)
            {
                //case "汉族": return "M000";//管理者
                case "1009": return "M001";//项目经理
                //case "汉族": return "M002";//书记
                //case "汉族": return "M003";//总工
                //case "汉族": return "M004";//安全总监
                //case "汉族": return "M005";//执行经理
                //case "汉族": return "M006";//商务经理
                case "1031": return "M007";//生产经理
                case "1018": return "M008";//安全员
                case "汉族": return "M009";//技术员
                case "1020": return "M010";//材料员
                //case "汉族": return "M011";//库管员
                //case "汉族": return "M012";//计量员
                case "1025": return "M013";//测量员
                //case "汉族": return "M014";//旁站员
                case "1019": return "M015";//标准员
                case "1022": return "M016";//劳务员
                //case "汉族": return "M017";//民管员
                //case "汉族": return "M018";//设备员
                case "1016": return "M019";//施工员
                case "1026": return "M020";//试验员
                //case "汉族": return "M021";//调度员
                //case "汉族": return "M022";//预算员
                //case "汉族": return "M023";//质检员
                case "1023": return "M024";//资料员
                //case "汉族": return "M025";//行政文员
                //case "汉族": return "M026";//财务
                //case "汉族": return "M027";//后勤
                //case "汉族": return "M028";//业主（建设单位）
                //case "汉族": return "M029";//监理单位
                //case "汉族": return "M030";//设计单位
                //case "汉族": return "M031";//工长
                //case "汉族": return "M032";//区段长
                //case "汉族": return "M033";//保安
                //case "汉族": return "M034";//保洁
                //case "汉族": return "M035";//厨师
                //case "汉族": return "M037";//监督员
                //case "汉族": return "M038";//经理助理
                //case "汉族": return "M039";//BIM 中心经理
                //case "汉族": return "M040";//BIM 工程师
                //case "汉族": return "M041";//劳资员
                //case "汉族": return "M042";//钢筋翻样
                //case "汉族": return "M043";//行保员
                //case "汉族": return "M044";//部长
                //case "汉族": return "M045";//副部长
                //case "汉族": return "M046";//主任
                //case "汉族": return "M047";//主管
                //case "汉族": return "M048";//架子队队长
                //case "汉族": return "M049";//架子队副队长
                //case "汉族": return "M050";//指挥长
                //case "汉族": return "M051";//常务指挥长
                //case "汉族": return "M052";//商务指挥长
                //case "汉族": return "M053";//现场指挥长
                //case "汉族": return "M054";//副书记
                //case "汉族": return "M055";//工区总
                //case "汉族": return "M056";//工区长
                //case "汉族": return "M057";//科员
                //case "汉族": return "M058";//土木工程师
                case "1007": return "M059";//安全工程师 	监理安全员	
                //case "汉族": return "M060";//公用设备工程师
                //case "汉族": return "M061";//建造师
                case "1005": return "M062";//监理工程师
                //case "汉族": return "M063";//造价工程师
                //case "汉族": return "M064";//环保工程师
                //case "汉族": return "M065";//机械工程师
                //case "汉族": return "M066";//钢结构工程师
                //case "汉族": return "M067";//电气工程师
                //case "汉族": return "M068";//部门经理
                //case "汉族": return "M069";//工会主席
                //case "汉族": return "M070";//项目副经理
                //case "汉族": return "M071";//电工
                //case "汉族": return "M072";//现场队长
                //case "汉族": return "M073";//总经济师
                //case "汉族": return "M074";//BIM 中心主任
                case "1012": return "M075";//工程师 项目工程师
                //case "汉族": return "M076";//计划员
                case "1013": return "M077";//项目负责人 项目管理员
                //case "汉族": return "M078";//机务员
                //case "汉族": return "M079";//常务副经理
                //case "汉族": return "M080";//质量总监
                //case "汉族": return "M081";//第三方监测人员
                //case "汉族": return "M082";//供应商人员
                //case "汉族": return "M083";//总调度长
                //case "汉族": return "M084";//副总经济师
                //case "汉族": return "M085";//商务副经理
                //case "汉族": return "M086";//副总调度长
                //case "汉族": return "M087";//副总工
                //case "汉族": return "M088";//安全监督官
                //case "汉族": return "M089";//前期经理
                case "1030": return "M090";//技术负责人 
                case "1028": return "M091";//质量负责人
                //case "汉族": return "M092";//机修师
                //case "汉族": return "M093";//盾构机司机
                //case "汉族": return "M094";//机电经理
                //case "汉族": return "M095";//机电工程师
                //case "汉族": return "M096";//司磅员
                //case "汉族": return "M097";//QHSE 总监
                //case "汉族": return "M098";//副机组长
                //case "汉族": return "M099";//机组长
                //case "汉族": return "M100";//文控员
                //case "汉族": return "M101";//信息化管理员
                //case "汉族": return "M102";//副主任
                //case "汉族": return "M103";//总会计师
                //case "汉族": return "M104";//队长
                //case "汉族": return "M105";//副队长
                case "1001": return "M106";//总监理工程师
                case "1002": return "M107";//副总监理工程师
                case "1003": return "M108";//安全副总监理工程师 安全监理工程师
                case "1024": return "M109";//总监理工程师代表
                //case "汉族": return "M110";//合同预概算监理工程师
                //case "汉族": return "M111";//测量专业监理工程师
                //case "汉族": return "M112";//试验专业监理工程师
                //case "汉族": return "M113";//计划统计监理工程师
                //case "汉族": return "M114";//资料监理工程师
                //case "汉族": return "M115";//信息管理监理工程师
                case "1006": return "M116";//监理员
                //case "汉族": return "M117";//科长
                //case "汉族": return "M118";//出纳员
                //case "汉族": return "M119";//副经理
                //case "汉族": return "M120";//机电副总监理工程师
                //case "汉族": return "M121";//土建总监代表
                //case "汉族": return "M122";//机电总监代表
                //case "汉族": return "M123";//安全专业监理工程师
                //case "汉族": return "M124";//机电专业监理工程师
                //case "汉族": return "M125";//土建专业监理工程师
                case "1004": return "M126";//专业监理工程师
                //case "汉族": return "M127";//管片专业监理工程师
                //case "汉族": return "M128";//地质专业监理工程师
                //case "汉族": return "M129";//专职卫生员
                //case "汉族": return "M068";//部门经理
                //case "汉族": return "M130";//门卫
                //case "汉族": return "M131";//会计
                //case "汉族": return "M132";//总经理
                //case "汉族": return "M133";//技术经理
                //case "汉族": return "M134";//副总经理
                //case "汉族": return "M134";//副总经理
                //case "汉族": return "M135";//部门副经理
                //case "汉族": return "M136";//岗位经理
                //case "汉族": return "M137";//生产副经理
                case "1008": return "M138";//项目总工 项目总工程师
                //case "汉族": return "M139";//项目副总工
                //case "汉族": return "M140";//项目书记
                //case "汉族": return "M141";//材料主任
                //case "汉族": return "M142";//物资部长
                //case "汉族": return "M143";//技术部长
                //case "汉族": return "M144";//技术副部长
                //case "汉族": return "M145";//工程部长
                //case "汉族": return "M146";//工程副部长
                //case "汉族": return "M147";//架子队长
                //case "汉族": return "M148";//架子副队长
                //case "汉族": return "M149";//项目总指挥
                //case "汉族": return "M150";//行政管理配管工程师
                //case "汉族": return "M151";//土建工程师
                //case "汉族": return "M152";//设备工程师
                //case "汉族": return "M153";//仪表工程师
                //case "汉族": return "M154";//焊接工程师
                //case "汉族": return "M155";//质量工程师
                //case "汉族": return "M156";//采购工程师
                //case "汉族": return "M157";//合同工程师
                //case "汉族": return "M158";//材料控制工程师
                //case "汉族": return "M159";//文档控制工程师
                //case "汉族": return "M160";//质检工程师
                //case "汉族": return "M161";//无损检测员
                //case "汉族": return "M162";//无损检测工程师
                //case "汉族": return "M163";//计划工程师
                case "1017": return "M164";//质量员
                //case "汉族": return "M165";//市场管理员
                //case "汉族": return "M166";//管理人员
                //case "汉族": return "M167";//小车司机
                //case "汉族": return "M168";//董事长
                default:
                    return "M036";//其他
            }
        }
    }
}

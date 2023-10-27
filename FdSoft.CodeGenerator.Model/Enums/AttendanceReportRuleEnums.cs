using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Model.Enums
{
    public enum WorkHourRuleType
    {
        /// <summary>
        /// 工时计算规则:当天06:00进门，07:00进门,08:00出门: 10:00进门，11:00出门，12:00出门:工时计算1 (07:00~8:00) +1 (11:00~11:00)，记2工时
        ///  跨夜工时计算:当天22.00进第二天06.00出则系统自动会在00:00插入一条出门和进门的记录, 工时分前后两天结算。当天记2个工时(22:00~24:00)，第二天记6个工时(00:00 ~ 06;00)。
        /// </summary>
        闭合时间段累加 = 1
    }

    public enum WorkDayRuleType
    {
        有考勤算一工日 = 1,
        半工 = 2,
        整工 = 3,
        比例换算工日 = 4
    }

}

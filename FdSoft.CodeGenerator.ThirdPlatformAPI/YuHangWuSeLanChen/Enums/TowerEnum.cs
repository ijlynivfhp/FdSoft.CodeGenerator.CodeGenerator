using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.ThirdPlatformAPI.YuHangWuSeLanChen.Enums
{

    /// <summary>
    /// 3.8 塔吊预警类型字典
    /// </summary>
    public enum TowerAlarmEnum
    {
        碰撞提醒 = 1,
        限行区提醒 = 2,
        超载提醒 = 4,
        防碰撞左转提醒 = 5,
        防碰撞右转提醒 = 6,
        防碰撞小车出提醒 = 7,
        防碰撞小车进提醒 = 8,
        左转环境提醒 = 9,
        右转环境提醒 = 10,
        小车出环境提醒 = 11,
        小车进环境提醒 = 12,
        最大幅度限位提醒 = 13,
        最小幅度限位提醒 = 14,
        高度上限位提醒 = 15,
        高度下限位提醒 = 16,
        回转左限位提醒 = 17,
        回转右限位提醒 = 18,
        防碰撞停车角提醒 = 19,
        防碰撞刹车角提醒 = 20,
        力矩提醒 = 21,
        力提醒 = 22,
        吊装提醒 = 23,
        进入区域提醒 = 24,
        回转异常提醒 = 25,
        吊重异常提醒 = 26,
        倾斜报警 = 27,
        风速报警 = 28,
        安拆模式风速报警 = 29,
        安拆模式力矩不平衡报警 = 30,
        幅度超限报警 = 36,
        高度超限报警 = 3,
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FdSoft.CodeGenerator.Common
{
    public class Tools
    {
        /// <summary>
        /// 要分割的字符串 eg: 1,3,10,00
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split">分割的字符串</param>
        /// <returns></returns>
        public static long[] SpitLongArrary(string str, char split = ',')
        {
            if (string.IsNullOrEmpty(str)) { return Array.Empty<long>(); }
            str = str.TrimStart(split).TrimEnd(split);
            string[] strIds = str.Split(split, (char)StringSplitOptions.RemoveEmptyEntries);
            long[] infoIdss = Array.ConvertAll(strIds, s => long.Parse(s));
            return infoIdss;
        }

        public static int[] SpitIntArrary(string str, char split = ',')
        {
            if (string.IsNullOrEmpty(str)) { return Array.Empty<int>(); }
            string[] strIds = str.Split(split, (char)StringSplitOptions.RemoveEmptyEntries);
            int[] infoIdss = Array.ConvertAll(strIds, s => int.Parse(s));
            return infoIdss;
        }

        /// <summary>
        /// 根据日期获取星期几
        /// </summary>
        public static string GetWeekByDate(DateTime dt)
        {
            var day = new[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return day[Convert.ToInt32(dt.DayOfWeek.ToString("d"))];
        }

        /// <summary>
        /// 得到这个月的第几周
        /// </summary>
        /// <param name="daytime">年月日</param>
        /// <returns>传递过来的时间是第几周</returns>
        public static int GetWeekNumInMonth(DateTime daytime)
        {
            int dayInMonth = daytime.Day;
            //本月第一天
            DateTime firstDay = daytime.AddDays(1 - daytime.Day);
            //本月第一天是周几
            int weekday = (int)firstDay.DayOfWeek == 0 ? 7 : (int)firstDay.DayOfWeek;
            //本月第一周有几天
            int firstWeekEndDay = 7 - (weekday - 1);
            //当前日期和第一周之差
            int diffday = dayInMonth - firstWeekEndDay;
            diffday = diffday > 0 ? diffday : 1;
            //当前是第几周,如果整除7就减一天
            int weekNumInMonth = ((diffday % 7) == 0
                ? (diffday / 7 - 1)
                : (diffday / 7)) + 1 + (dayInMonth > firstWeekEndDay ? 1 : 0);
            return weekNumInMonth;
        }
        /// <summary>
        /// 判断一个字符串是否为url
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 计算密码强度
        /// </summary>
        /// <param name="password">密码字符串</param>
        /// <returns></returns>
        public static bool PasswordStrength(string password)
        {
            //空字符串强度值为0
            if (string.IsNullOrEmpty(password)) return false;

            //字符统计
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9') iNum++;
                else if (c >= 'a' && c <= 'z') iLtt++;
                else if (c >= 'A' && c <= 'Z') iLtt++;
                else iSym++;
            }

            if (iLtt == 0 && iSym == 0) return false; //纯数字密码
            if (iNum == 0 && iLtt == 0) return false; //纯符号密码
            if (iNum == 0 && iSym == 0) return false; //纯字母密码

            if (password.Length >= 6 && password.Length < 16) return true;//长度不大于6的密码

            if (iLtt == 0) return true; //数字和符号构成的密码
            if (iSym == 0) return true; //数字和字母构成的密码
            if (iNum == 0) return true; //字母和符号构成的密码

            return true; //由数字、字母、符号构成的密码
        }

        #region LZW算法压缩解压缩C#实现(2013.1.16.ydz)
        /// <summary>
        /// LZW算法压缩
        /// </summary>
        /// <param name="strNormalString"></param>
        /// <returns></returns>
        public static string LZWCompressStr(string strNormalString)
        {
            string strCompressedString = "";

            Dictionary<int, int> ht = new Dictionary<int, int>();
            for (int i = 0; i < 128; i++)
            {
                ht.Add(i, i);
            }

            int used = 128;
            int intLeftOver = 0;
            int intOutputCode = 0;
            int pcode = 0;
            int ccode = 0;
            int k = 0;

            for (int i = 0; i < strNormalString.Length; i++)
            {
                ccode = (int)strNormalString[i];
                k = (pcode << 8) | ccode;
                if (ht.ContainsKey(k))
                {
                    pcode = ht[k];
                }
                else
                {
                    intLeftOver += 12;
                    intOutputCode <<= 12;
                    intOutputCode |= pcode;
                    pcode = ccode;
                    if (intLeftOver >= 16)
                    {
                        strCompressedString += new string(new char[] { (char)(intOutputCode >> (intLeftOver - 16)) });
                        intOutputCode &= (int)(Math.Pow(2, (intLeftOver - 16)) - 1);
                        intLeftOver -= 16;
                    }
                    if (used < 4096)
                    {
                        used++;
                        ht.Add(k, used - 1);
                    }
                }
            }

            if (pcode != 0)
            {
                intLeftOver += 12;
                intOutputCode <<= 12;
                intOutputCode |= pcode;
            }

            if (intLeftOver >= 16)
            {
                strCompressedString += new string(new char[] { (char)(intOutputCode >> (intLeftOver - 16)) });
                intOutputCode &= (int)(Math.Pow(2, (intLeftOver - 16)) - 1);
                intLeftOver -= 16;
            }

            if (intLeftOver > 0)
            {
                intOutputCode <<= (16 - intLeftOver);
                strCompressedString += new string(new char[] { (char)(intOutputCode) });
            }
            return strCompressedString;
        }
        /// <summary>
        /// LZW算法解压方法(2013.1.16.ydz)。
        /// </summary>
        /// <param name="strCompressedString"></param>
        /// <returns></returns>
        public static string LZWDecompressStr(string strCompressedString)
        {
            var strNormalString = "";

            Dictionary<int, string> ht = new Dictionary<int, string>();
            for (int i = 0; i < 128; i++)
            {
                ht.Add(i, new string(new char[] { (char)i }));
            }
            int used = 128;
            int intLeftOver = 0;
            int intOutputCode = 0;
            int ccode = 0;
            int pcode = 0;
            string key = new string(new char[] { (char)0 });

            for (int i = 0; i < strCompressedString.Length; i++)
            {
                intLeftOver += 16;
                intOutputCode <<= 16;
                intOutputCode |= (int)strCompressedString[i];

                while (true)
                {
                    if (intLeftOver >= 12)
                    {
                        ccode = intOutputCode >> (intLeftOver - 12);
                        if (ht.ContainsKey(ccode))
                        {
                            key = ht[ccode];
                            strNormalString += key;
                            if (used > 128)
                            {
                                ht.Add(ht.Count, ht[pcode] + key.Substring(0, 1));
                            }
                            pcode = ccode;
                        }
                        else
                        {
                            key = ht[pcode] + ht[pcode].Substring(0, 1);
                            strNormalString += key;
                            ht.Add(ht.Count, ht[pcode] + key.Substring(0, 1));
                            pcode = ht.Count - 1;
                        }

                        used++;
                        intLeftOver -= 12;
                        intOutputCode &= (int)(Math.Pow(2, intLeftOver) - 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return strNormalString.TrimEnd('\0');
        }
        #endregion
    }
}

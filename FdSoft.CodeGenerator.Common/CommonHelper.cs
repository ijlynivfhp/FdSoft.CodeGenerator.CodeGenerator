using FdSoft.CodeGenerator.Common;
using FdSoft.CodeGenerator.Common.Helper;
using JinianNet.JNTemplate.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common
{
    public class CommonHelper
    {
        private static readonly object fileLocker = new object();
        public static string GetImageDomain()
        {
            string imageDomain = AppSettings.GetAppConfig<string>("Upload:uploadUrl");
            return imageDomain;
        }

        ///   <summary> 
        ///   将指定字符串按指定长度进行截取并加上指定的后缀
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string StringTryCat(string oldStr, int maxLength, string endWith)
        {
            //判断原字符串是否为空
            if (string.IsNullOrEmpty(oldStr))
                return oldStr + endWith;

            //返回字符串的长度必须大于1
            if (maxLength < 1) maxLength = 1;

            //判断原字符串是否大于最大长度
            if (oldStr.Length > maxLength)
            {
                //截取原字符串
                string strTmp = oldStr.Substring(0, maxLength);

                //判断后缀是否为空
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
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

        /// <summary>写入日志信息,写入控制台，自动删除上月日志
        /// 写入日志信息,写入控制台，自动删除上月日志
        /// </summary>
        /// <param name="strLog"></param>
        public static void WriteMesseage(string strLog, bool consoleStr = false)
        {
            try
            {
                var dt = DateTime.Now;
                string sFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + dt.ToString("yyyyMM");
                string sFilePathOld = System.AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + dt.AddMonths(-1).ToString("yyyyMM");
                string sFileName = "日志" + dt.ToString("dd") + ".log";
                sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
                Monitor.Enter(fileLocker);
                if (!Directory.Exists(sFilePath))//验证路径是否存在
                {
                    Directory.CreateDirectory(sFilePath);
                    //不存在则创建
                }
                try
                {
                    if (Directory.Exists(sFilePathOld))
                        Directory.Delete(sFilePathOld, true);
                }
                catch (Exception ex) { strLog += "；" + ex.Message; }

                FileStream fs;
                StreamWriter sw;
                if (File.Exists(sFileName))
                //验证文件是否存在，有则追加，无则创建
                {
                    fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
                }
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "---" + strLog);
                if (consoleStr)
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "---" + strLog);
                sw.Close();
                fs.Close();
            }
            catch (Exception) { }
            finally
            {
                Monitor.Exit(fileLocker);
            }
        }

        /// <summary>
        /// 硬件设备通讯密钥加密获取规则
        /// </summary>
        /// <param name="proId">项目ID</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string IoTPwdMD5(Guid proId, string salt)
        {
            string cl = proId.ToString().ToLower() + salt.ToLower();
            string pwd = string.Empty;
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd += s[i].ToString("X2");
            }
            return pwd;
        }

        #region FormData转换帮助类
        /// <summary>
        /// 利用反射机制将formCollection中的键值对的值赋值给对象对应属性，并确保类型一致性
        /// <para>目前暂不支持form表单中含有List类型，支持到字符串数组如string[]</para>
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="t">外部操作的全新的实体ref</param>
        /// <param name="form">form表单</param>
        /// <returns></returns>
        public static int FormToModel<T>(ref T t, IFormCollection form)
        {
            int u = 0;
            var pi = t.GetType().GetProperties();
            foreach (var p in pi)
            {
                if (form.TryGetValue(p.Name, out StringValues strs))
                {
                    try
                    {
                        if (IsIEnumerable(p))//数组或列表或字典（本意是分别对列表list和字典分别做处理，暂时只做了数组，后续待补充）
                        {
                            if (IsArray(p))//数组判断
                            {
                                var strArr = strs.ToArray();
                                var tempArr = Activator.CreateInstance(p.PropertyType, strArr.Length) as Array;//临时创建一个数组对象，以p的数组类型创建，长度以strArr长度为准
                                for (int i = 0; i < strArr.Length; i++)
                                {
                                    if (strArr[i] == "undefined") strArr[i] = null;
                                    if (strArr[i] == null) continue;
                                    var v = Convert.ChangeType(strArr[i], p.PropertyType.GetElementType());
                                    tempArr.SetValue(v, i);
                                }
                                p.SetValue(t, tempArr, null);//反射赋值给对象的属性，同时转换类型
                                continue;
                            }
                        }
                        else//普通属性
                        {
                            if (strs.ToArray()[0] == "undefined") continue;
                            var val = Convert.ChangeType(strs.ToArray()[0], p.PropertyType);
                            p.SetValue(t, val, null);//反射赋值给对象的属性，同时转换类型
                        }
                        u++;
                    }
                    catch (Exception ex)
                    {
                        NLogHelper.Error(ex.Message);//日志记录报错信息
                    }
                }
            }
            return u;
        }

        public static dynamic FormToDyc(IFormCollection formCollection)
        {
            var dycData = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
            foreach (var formDic in formCollection)
            {
                if (formDic.Value.Count == 1)
                    dycData.Add(formDic.Key, formDic.Value.First());
                else if (formDic.Value.Count > 1)
                {
                    dycData.Add(formDic.Key, formDic.Value.ToList());
                }
            }
            return dycData;
        }

        /// <summary>
        /// 判断是否实现枚举接口 数组、字典、集合均实现了枚举接口
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsIEnumerable(PropertyInfo p)
        {
            //List和Array均实现了枚举 IEnumerable 接口，通过判断是否实现该接口得知是否为[List或Array]
            return p.PropertyType.GetInterface("IEnumerable", false) != null;
        }
        /// <summary>
        /// 判断是否为数组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsArray(PropertyInfo p)
        {
            return p.PropertyType.IsArray;
        }
        /// <summary>
        /// 判断是否为字典
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsDictionary(PropertyInfo p)
        {
            return typeof(IDictionary).IsAssignableFrom(p.PropertyType);
        }

        /// <summary>
        /// 判断是否为集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsList(PropertyInfo p)
        {
            return typeof(IList).IsAssignableFrom(p.PropertyType);
        }
        #endregion

        /// <summary>
        /// 获取上两级方法名称（不包含当前方法）
        /// </summary>
        /// <returns></returns>
        public static string GetMethodName(int top = 1, bool isIntercept = true, bool isTwoLevel = true)
        {
            var methodName = $"{(isTwoLevel ? $"C:{new StackTrace(true).GetFrame(top + 1).GetMethod().Name}:" : default)}{new StackTrace(true).GetFrame(top).GetMethod().Name}";
            if (isIntercept && methodName.Length > 50) methodName = methodName.Substring(methodName.Length - 50);
            return methodName;
        }

        #region 判断一个字符串是否是base64字符串
        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str)
        {
            byte[] bytes;
            return IsBase64(base64Str, out bytes);
        }

        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <param name="bytes">字符串转换成的字节数组</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str, out byte[] bytes)
        {
            //string strRegex = "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$";
            bytes = null;
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Contains(","))
                    base64Str = base64Str.Split(',')[1];
                if (base64Str.Length % 4 != 0)
                    return false;
                var base64CodeArray = new char[]
                {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
                };
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            try
            {
                bytes = Convert.FromBase64String(base64Str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion
    }
}

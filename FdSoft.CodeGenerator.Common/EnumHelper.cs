using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common
{


    public class EnumHelper
    {
        public static List<EnumItem> GetEnumItems<T>()
        {
            var result = new List<EnumItem>();

            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                return result;
            }

            string[] fieldstrs = Enum.GetNames(enumType);

            foreach (var item in fieldstrs)
            {
                string description = string.Empty;
                var field = enumType.GetField(item);
                object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组
                if (arr != null && arr.Length > 0)
                {
                    description = ((DescriptionAttribute)arr[0]).Description;   //属性描述
                }
                else
                {
                    description = item;  //描述不存在取字段名称
                }
                result.Add(new EnumItem
                {
                    Name = item,
                    Value = (int)Enum.Parse(enumType, item),
                    Descprtion = description,

                });
            }

            return result;
        }


        /// <summary>
        /// 返回指定枚举类型的指定值的描述
        /// </summary>
        /// <param name="t">枚举类型</param>
        /// <param name="v">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(System.Type t, object v)
        {
            try
            {
                FieldInfo oFieldInfo = t.GetField(GetName(t, v));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])oFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes.Length > 0) ? attributes[0].Description : GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }


        public static string GetName(System.Type t, object v)
        {
            try
            {
                return Enum.GetName(t, v);
            }
            catch
            {
                return "UNKNOWN";
            }
        }


        /// <summary>
        /// 根据枚举名称集合获取枚举值集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="names"></param>
        /// <returns></returns>
        public static List<int> GetValuesByNames<T>(string names)
        {
            List<int> valueList = new List<int>();
            if (!string.IsNullOrEmpty(names))
            {
                string[] nameArray = names.Split(',');

                List<EnumItem> enumItemList = GetEnumItems<T>();
                List<string> enumNameList = enumItemList.Select(x => x.Name).ToList();
                
                foreach (string name in nameArray)
                {
                    if (enumNameList.Contains(name))
                    {
                        valueList.Add(enumItemList.FirstOrDefault(x => x.Name == name).Value);
                    }
                }
            }
            return valueList;
        }
    }

    public class EnumItem
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Descprtion { get; set; }
    }

}

//using Microsoft.AspNetCore.Http;
//using Snowflake.Core;
using System;
using FdSoft.CodeGenerator.Common;
using Microsoft.AspNetCore.Http;

namespace FdSoft.CodeGenerator.Core.Extensions
{
    public static class EntityExtension
    {
        public static TSource ToCreate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null) return source;
            if (types.GetProperty("ProId") != null)
            {
                types.GetProperty("ProId")?.SetValue(source, Guid.NewGuid().ToString(), null);
            }

            if (types.GetProperty("AddTime") != null)
            {
                types.GetProperty("AddTime")?.SetValue(source, DateTimeHelper.ToUnixTimestampBySeconds(DateTime.Now), null);
            }
            if (types.GetProperty("AddDate") != null)
            {
                types.GetProperty("AddDate")?.SetValue(source, DateTime.Now, null);
            }
            if (types.GetProperty("UpdateTime") != null)
            {
                types.GetProperty("UpdateTime")?.SetValue(source, DateTimeHelper.ToUnixTimestampBySeconds(DateTime.Now), null);
            }
            if (types.GetProperty("UpdateDate") != null)
            {
                types.GetProperty("UpdateDate")?.SetValue(source, DateTime.Now, null);
            }
            if (types.GetProperty("Creator") != null && context != null)
            {
                types.GetProperty("Creator")?.SetValue(source, context.GetName()??"", null);
            }
            if (types.GetProperty("CreateUserId") != null && context != null)
            {
                types.GetProperty("CreateUserId")?.SetValue(source, context.GetUId(), null);
            }
            if (types.GetProperty("LastEditor") != null && context != null)
            {
                types.GetProperty("LastEditor")?.SetValue(source, context.GetName()??"", null);
            }
            if (types.GetProperty("LastEditUserId") != null && context != null)
            {
                types.GetProperty("LastEditUserId")?.SetValue(source, context.GetUId(), null);
            }
            return source;
        }

        public static TSource ToUpdate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null) return source;
            if (types.GetProperty("UpdateTime") != null)
            {
                try
                {
                    types.GetProperty("UpdateTime")?.SetValue(source, DateTimeHelper.ToUnixTimestampBySeconds(DateTime.Now), null);
                }
                catch { }
                try
                {
                    types.GetProperty("UpdateTime")?.SetValue(source, DateTimeHelper.ToUnixTimestampBySeconds(DateTime.Now), null);
                }
                catch { }
            }
            if (types.GetProperty("UpdateDate") != null)
            {
                types.GetProperty("UpdateDate")?.SetValue(source, DateTime.Now, null);
            }
            if (types.GetProperty("LastEditor") != null && context != null)
            {
                types.GetProperty("LastEditor")?.SetValue(source, context.GetName() ?? "", null);
            }
            if (types.GetProperty("LastEditUserId") != null && context != null)
            {
                types.GetProperty("LastEditUserId")?.SetValue(source, context.GetUId(), null);
            }
            return source;
        }
        public static TSource ForUpdate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null) return source;
            if (types.GetProperty("UpdateTime") != null)
            {
                try
                {
                    types.GetProperty("UpdateTime")?.SetValue(source, DateTimeHelper.DtToInt(DateTime.Now), null);
                }
                catch { }
            }
            if (types.GetProperty("UpdateDate") != null)
            {
                types.GetProperty("UpdateDate")?.SetValue(source, DateTime.Now, null);
            }
            if (types.GetProperty("LastEditor") != null && context != null)
            {
                types.GetProperty("LastEditor")?.SetValue(source, context.GetName() ?? "", null);
            }
            if (types.GetProperty("LastEditUserId") != null && context != null)
            {
                types.GetProperty("LastEditUserId")?.SetValue(source, context.GetUId(), null);
            }
            return source;
        }

    }
}

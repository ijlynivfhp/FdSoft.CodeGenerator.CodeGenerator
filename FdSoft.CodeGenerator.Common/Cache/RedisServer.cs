using CSRedis;

namespace FdSoft.CodeGenerator.Common.Cache
{
    public class RedisServer
    {
        public static CSRedisClient Default;
        public static CSRedisClient Cache;
        public static CSRedisClient Session;

        public static void Initalize()
        {
            Default = new CSRedisClient(AppSettings.GetConfig("RedisServer:Default"));
            Cache = new CSRedisClient(AppSettings.GetConfig("RedisServer:Cache"));
            Session = new CSRedisClient(AppSettings.GetConfig("RedisServer:Session"));
        }
    }
}

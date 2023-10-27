using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NLog.Targets;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    /// <summary>
    /// RabbitMQ帮助类
    /// </summary>
    public class RabbitMQHelper
    {
        private static int ConsumerCount = default;

        private static ConcurrentDictionary<string, IConnection> connDic = new ConcurrentDictionary<string, IConnection>();
        private static ConcurrentDictionary<string, IModel> channelDic = new ConcurrentDictionary<string, IModel>();
        private readonly static object connLock = new object();
        private readonly static object channelLock = new object();

        /// <summary>
        /// 获取RabbitMQ链接对象（支持不同链接）
        /// </summary>
        /// <param name="rabbitmqConn"></param>
        /// <param name="exchangeName"></param>
        /// <returns></returns>
        public static IConnection GetConn(string rabbitmqConn = RabbitConst.RabbitmqConn, string virtualStr = RabbitConst.IotReceiverVir)
        {
            if (string.IsNullOrEmpty(AppSettings.GetConfig(rabbitmqConn))) throw new Exception("RabbitMQ缺少配置链接！");
            var uristring = string.Format(AppSettings.GetConfig(rabbitmqConn), virtualStr);
            if (!connDic.ContainsKey(uristring))
            {
                lock (connLock)
                {
                    if (!connDic.ContainsKey(uristring))
                        GetRealConn();
                };
            }
            else
            {
                if (connDic[uristring] == default || !connDic[uristring].IsOpen)
                {
                    lock (connLock)
                    {
                        if (connDic[uristring] == default || !connDic[uristring].IsOpen)
                        {
                            try
                            {
                                connDic[uristring]?.Close();
                            }
                            catch { }
                            GetRealConn(false);
                        }
                    };
                }
            }
            return connDic[uristring];

            #region 获取真实rabbitmq连接
            void GetRealConn(bool isAdd = true)
            {
                var factory = new ConnectionFactory();
                factory.AutomaticRecoveryEnabled = true;
                factory.Uri = new Uri(uristring);
                if (isAdd)
                    connDic.TryAdd(uristring, factory.CreateConnection());
                else
                {
                    connDic[uristring] = factory.CreateConnection();
                }
            }
            #endregion
        }

        /// <summary>
        /// 获取信道（支持不同链接，创建消费者时不可用此方法）
        /// </summary>
        /// <param name="rabbitmqConn"></param>
        /// <param name="virtualStr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IModel GetChannel(string rabbitmqConn = RabbitConst.RabbitmqConn, string virtualStr = RabbitConst.IotReceiverVir, string exchangeName = RabbitConst.ExchangeName, string queueName = RabbitConst.QueueName)
        {
            if (string.IsNullOrEmpty(AppSettings.GetConfig(rabbitmqConn))) throw new Exception("RabbitMQ缺少配置链接！");
            var uristring = $"{string.Format(AppSettings.GetConfig(rabbitmqConn), virtualStr)}{exchangeName}{queueName}";
            if (!channelDic.ContainsKey(uristring))
            {
                lock (channelLock)
                {
                    if (!channelDic.ContainsKey(uristring))
                        GetRealChannel();
                }
            }
            else
            {
                if (channelDic[uristring] == default || !channelDic[uristring].IsOpen)
                {
                    lock (channelLock)
                    {
                        if (channelDic[uristring] == default || !channelDic[uristring].IsOpen)
                        {
                            try
                            {
                                channelDic[uristring]?.Close();
                            }
                            catch { }
                            GetRealChannel(false);
                        }
                    }
                }
            }
            return channelDic[uristring];

            #region 获取真实channel
            void GetRealChannel(bool isAdd = true)
            {
                if (isAdd)
                    channelDic.TryAdd(uristring, GetConn(rabbitmqConn, virtualStr).CreateModel());
                else
                {
                    channelDic[uristring] = GetConn(rabbitmqConn, virtualStr).CreateModel();
                }
            }
            #endregion
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routingKey"></param>
        /// <param name="channel"></param>
        /// <param name="rabbitmqConn"></param>
        /// <param name="virtualStr"></param>
        public static void Publish(string message, string routingKey, string exchangeName = RabbitConst.IotReceiverEx, IModel channel = default, string rabbitmqConn = RabbitConst.RabbitmqConn, string virtualStr = RabbitConst.IotReceiverVir, byte priority = default)
        {
            try
            {
                var thisChannel = channel ?? GetChannel(rabbitmqConn, virtualStr);
                var body = Encoding.UTF8.GetBytes(message);
                var properties = thisChannel.CreateBasicProperties();
                properties.Persistent = true;
                properties.Priority = priority;
                thisChannel.BasicPublish(exchange: exchangeName, routingKey: routingKey, mandatory: false, basicProperties: properties, body: body);
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex.Message);
            }
            NLogHelper.Info($"{CommonHelper.GetMethodName()}：发送一条消息！");
        }

        /// <summary>
        /// 初始化队列
        /// </summary>
        /// <param name="queueList"></param>
        /// <param name="exchangeName"></param>
        /// <param name="conn"></param>
        /// <param name="commonConn"></param>
        /// <param name="virtualStr"></param>
        /// <param name="exchangeType"></param>
        public static void InitMqQueue(List<string> queueList = default, string exchangeName = RabbitConst.ExchangeName, IConnection conn = default, string commonConn = RabbitConst.RabbitmqConn, string virtualStr = RabbitConst.IotReceiverVir, string exchangeType = ExchangeType.Direct, byte priority = default)
        {
            queueList = queueList ?? new List<string>();
            if (queueList.Count == 0) return;
            var thisConn = conn ?? GetConn(commonConn, virtualStr);
            var thisChannel = thisConn.CreateModel();
            try
            {
                queueList.ForEach(o =>
                {
                    //声名交换机
                    thisChannel.ExchangeDeclare(exchange: exchangeName, type: exchangeType, durable: true);

                    //设置队列属性
                    var isArguments = priority > 0 ? true : false;
                    if (isArguments)
                    {
                        var queueArguments = new Dictionary<string, object>();
                        //设置队列优先级，取值范围在0~255之间。
                        if (priority > 0)
                            queueArguments.Add("x-max-priority", priority);
                        //声名队列
                        thisChannel.QueueDeclare(o, true, default, default, queueArguments);
                    }
                    else
                    {
                        //声名队列
                        thisChannel.QueueDeclare(o, true, default, default);
                    }

                    //队列绑定交换机
                    thisChannel.QueueBind(queue: o, exchange: exchangeName, routingKey: o);
                    //间隔一秒
                    Thread.Sleep(RabbitConst.InitQueueInterval);
                });
            }
            catch (Exception ex)
            {
                NLogHelper.Info($"初始化队列（{CommonHelper.GetMethodName(isIntercept: false)}）异常：{ex.Message}");
            }
            finally
            {
                thisChannel?.Close();
            }
        }

        /// <summary>
        /// 初始化消费者
        /// </summary>
        public static void InitConsumer(string queueName, Action<string> action, IModel channel = default, string rabbitmqConn = RabbitConst.RabbitmqConn, string virtualStr = RabbitConst.IotReceiverVir, bool isConsole = true, ushort prefetchCount = 1)
        {
            //创建通道
            var thisChannel = channel ?? GetConn(rabbitmqConn, virtualStr).CreateModel();

            #region 创建消费者监听

            //公平分发、同一时间只处理一个消息。
            thisChannel.BasicQos(0, prefetchCount, false);

            //创建消费者
            var consumer = new EventingBasicConsumer(thisChannel);

            consumer.Received += (model, ea) =>
            {
                try
                {
                    #region 初始化计时器
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    #endregion

                    #region 业务逻辑
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    action.Invoke(message);
                    #endregion

                    #region 计时结果
                    stopwatch.Stop();
                    if (isConsole)
                        Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}---消费消息（{queueName}）:耗时：{stopwatch.ElapsedMilliseconds}毫秒");
                    #endregion
                    //回复确认
                    thisChannel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    //重新放入队列
                    thisChannel.BasicNack(ea.DeliveryTag, false, true);
                    ////抛弃此条消息
                    //channel.BasicNack(ea.DeliveryTag, false, false);
                    CommonHelper.WriteMesseage($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}---重新放入队列一条消息：异常信息:{ex.Message}", true);
                }
            };
            thisChannel.BasicConsume(queue: queueName,
                                    autoAck: false,
                                    consumer: consumer);
            CommonHelper.WriteMesseage($"第{++ConsumerCount}个消费者（{queueName}）：启动成功", true);

            //间隔一秒
            Thread.Sleep(RabbitConst.InitConsumerInterval);
            #endregion
        }
    }

    public class RabbitConst
    {
        #region 连接
        public const string RabbitmqConn = "RabbitMQ:Node1";
        #endregion

        #region 虚拟机
        public const string IotReceiverVir = "IotReceiverVir";
        public const string VirtualStr = "VirtualStr";
        public const string Laborhost = "laborhost";
        #endregion

        #region 交换机
        public const string ExchangeName = "ExchangeName";
        public const string IotReceiverEx = "IotReceiverEx";
        public const string AttendanceRecordBaseEx = "AttendanceRecordBaseEx";
        #endregion

        #region 队列
        /// <summary>
        /// 公用创建队列时间间隔
        /// </summary>
        public const int InitQueueInterval = 1000;
        /// <summary>
        /// 公用创建消费者时间间隔
        /// </summary>
        public const int InitConsumerInterval = 1000;
        /// <summary>
        /// 默认队列名称
        /// </summary>
        public const string QueueName = "QueueName";
        /// <summary>
        /// 用于控制单双发设备（人员新增，人员删除）
        /// </summary>
        public const string SingleDoubleDeviceQueue = "SingleDoubleDeviceQueue";
        /// <summary>
        /// 用于控制单双发设备基础（配置更新，设备重启，设备重置，配置查询）
        /// </summary>
        public const string SingleDoubleDeviceConfigQueue = "SingleDoubleDeviceConfigQueue";
        /// <summary>
        /// 用于接收双发设备（人员新增，人员删除）通知
        /// </summary>
        public const string SingleDoubleAddOrDelQueue = "SingleDoubleAddOrDelQueue";
        /// <summary>
        /// 单双发设备考勤数据
        /// </summary>
        public const string SingleDoubleAttendanceQueue = "SingleDoubleAttendanceQueue";
        /// <summary>
        /// 单双发设备考勤数据
        /// </summary>
        public const string SingleDoubleOnOffLineQueue = "SingleDoubleOnOffLineQueue";
        /// <summary>
        /// 设备配置Mq队列Service名称
        /// </summary>
        public const string ConfigToDeviceServiceQueue = "ConfigToDeviceServiceQueue";
        /// <summary>
        /// 设备配置Mq队列消费者名称
        /// </summary>
        public const string ConfigToDeviceQueue = "ConfigToDeviceQueue";
        // <summary>
        /// 设备授权销权Mq队列Service名称
        /// </summary>
        public const string AuthorityToDeviceServiceQueue = "AuthorityToDeviceServiceQueue";
        /// <summary>
        /// 设备授权销权Mq队列消费者名称
        /// </summary>
        public const string AuthorityToDeviceQueue = "AuthorityToDeviceQueue";
        /// <summary>
        /// 设备考勤队列Service名称
        /// </summary>
        public const string AttendanceServiceQueue = "AttendanceServiceQueue";
        /// <summary>
        /// 设备考勤队列消费者名称
        /// </summary>
        public const string AttendanceQueue = "AttendanceQueue";
        /// <summary>
        /// 设备在线离线队列Service名称
        /// </summary>
        public const string DeviceOnOffLineServiceQueue = "DeviceOnOffLineServiceQueue";
        /// <summary>
        /// 设备在线离线队列消费者名称
        /// </summary>
        public const string DeviceOnOffLineQueue = "DeviceOnOffLineQueue";
        /// <summary>
        /// 项目工人队列Service名称
        /// </summary>
        public const string ProjectWorkerServiceQueue = "ProjectWorkerServiceQueue";
        /// <summary>
        /// 项目工人列消费者名称
        /// </summary>
        public const string ProjectWorkerQueue = "ProjectWorkerQueue";
        /// <summary>
        /// 海清设备交互队列名称
        /// </summary>
        public const string IotFaceQueue = "IotFaceQueue";

        /// <summary>
        /// 授权后更新授权日志，授权，项目工人
        /// </summary>
        public const string SetStatusAfterAuthQueue = "SetStatusAfterAuthQueue";
        /// <summary>
        /// 塔吊设备数据队列名称
        /// </summary>
        public const string IotTowerQueue = "IotTower";

        /// <summary>
        /// 查询设备中的人员队列名称
        /// </summary>
        public const string DevicePersonsQueryQueue = "DevicePersonsQueryQueue";

        /// <summary>
        /// 处理设备中的人员队列名称
        /// </summary>
        public const string DevicePersonsHandleQueue = "DevicePersonsHandleQueue";

        /// <summary>
        /// 推送IoT数据到余杭蓝宸平台队列名称 余杭V1版
        /// </summary>
        public const string PushIoTToYuHangLanChenQueue = "Iot_SyncType_4095";

        /// <summary>
        /// 推送IoT数据到余杭五色平台队列名称 余杭V2版
        /// </summary>
        public const string PushIoTToYuHangWuSeQueue = "Iot_SyncType_4097";

        /// <summary>
        /// 推送IoT数据到省建工平台队列名称
        /// </summary>
        public const string PushIoTToShengJianGongQueue = "Iot_SyncType_5000";

        /// <summary>
        /// 推送IoT数据到品茗桩桩平台队列名称
        /// </summary>
        public const string PushIoTToPinMingZhuangZhuangQueue = "Iot_SyncType_5001";

        /// <summary>
        /// 推送IoT数据到平湖方欣平台队列名称
        /// </summary>
        public const string PushIoTToPinHuFangXinQueue = "Iot_SyncType_5002";

        /// <summary>
        /// 推送IoT数据到运河辰祥平台队列名称
        /// </summary>
        public const string PushIoTToYunHeChenXiangQueue = "Iot_SyncType_5004";

        /// <summary>
        /// 推送IoT数据到衢州方欣平台队列名称
        /// </summary>
        public const string PushIotToQuZhouFangXinQueue = "Iot_SyncType_5005";

        /// <summary>
        /// 推送IoT数据到润腾华润平台队列名称
        /// </summary>
        public const string PushIoTToRunTengHuaRunQueue = "Iot_SyncType_5006";

        /// <summary>
        /// 推送IoT数据到广联达平台队列名称
        /// </summary>
        public const string PushIoTToGuangLianDaQueue = "Iot_SyncType_5007";
        #endregion
    }

    //RabbitMQ服务配置
    //"RabbitMQ": {
    //  "Node1": "amqp://sa:123456@127.0.0.1:5672/{0}",
    //  "Node2": "amqp://sa:123456@127.0.0.1:5672/{0}"
    //}

    //创建消费者

}

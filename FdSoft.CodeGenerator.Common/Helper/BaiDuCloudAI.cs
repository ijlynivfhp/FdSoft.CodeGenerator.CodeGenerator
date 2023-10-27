using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public class BaiDuCloudAI
    {
        private static string Token = string.Empty;
        private static object Token_Lock = new object();
        private static DateTime TokenDateTime;

        public static void GetBaiDuToken()
        {
            lock (Token_Lock)
            {
                if (TokenDateTime != null && TokenDateTime >= DateTime.Now)
                    return;

                string key = AppSettings.GetConfig("BaiDuAI:BaiduKey");
                string secret = AppSettings.GetConfig("BaiDuAI:BaiduSecret");
                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", key));
                paraList.Add(new KeyValuePair<string, string>("client_secret", secret));
                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Token = JsonConvert.DeserializeObject<dynamic>(result).access_token;
                TokenDateTime = DateTime.Now.AddHours(6);
            }
        }

        public static Stream PostBaiDuApiImageData(Stream imgStream)
        {
            try
            {
                byte[] bytes;
                imgStream.Seek(0, SeekOrigin.Begin);
                using (var memoryStream = new MemoryStream())
                {
                    imgStream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
                string imgBase64Str = Convert.ToBase64String(bytes);

                GetBaiDuToken();
                string url = "https://aip.baidubce.com/rest/2.0/image-classify/v1/body_seg?access_token=" + Token;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                var httpClient = new HttpClient(handler) { BaseAddress = new Uri(url) };

                var bag = new Dictionary<string, string>();
                bag.Add("type", "foreground");
                bag.Add("image", imgBase64Str);
                var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
                //var content = new FormUrlEncodedContent(bag);
                var content = new StringContent(String.Join("&", encodedItems), Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = httpClient.PostAsync($"", content).Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;
                imgBase64Str = JsonConvert.DeserializeObject<dynamic>(result).foreground;
                if (string.IsNullOrEmpty(imgBase64Str)) return null;
                return new MemoryStream(Convert.FromBase64String(imgBase64Str));
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public static string PostBaiDuApiImageData(string imgBase64Str)
        {
            try
            {
                GetBaiDuToken();
                string url = "https://aip.baidubce.com/rest/2.0/image-classify/v1/body_seg?access_token=" + Token;
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                var httpClient = new HttpClient(handler) { BaseAddress = new Uri(url) };

                var bag = new Dictionary<string, string>();
                bag.Add("type", "foreground");
                bag.Add("image", imgBase64Str);
                var encodedItems = bag.Select(i => WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
                //var content = new FormUrlEncodedContent(bag);
                var content = new StringContent(String.Join("&", encodedItems), Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = httpClient.PostAsync($"", content).Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<dynamic>(result).foreground;
            }
            catch (Exception e)
            {
            }

            return string.Empty;
        }
    }
}

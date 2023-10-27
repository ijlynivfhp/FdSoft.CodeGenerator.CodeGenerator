using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FdSoft.CodeGenerator.Common.Extension
{
    public static class EncryptExtensions
    {

        private static byte[] AESKeys = UTF8Encoding.UTF8.GetBytes("Framework");
        public static string AESEncode(this string encryptString, string encryptKey)
        {
            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = AESKeys;
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        public static string AESDecode(this string decryptString, string decryptKey)
        {
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
                rijndaelProvider.IV = AESKeys;
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 字段加密（上传信息至全国建筑工人管理服务平台）
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns>Base64字符串</returns>
        public static string AESEncode2(this string encryptString, string encryptKey)
        {
            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Mode = CipherMode.CBC;
            rijndaelProvider.Padding = PaddingMode.PKCS7;
            rijndaelProvider.BlockSize = 128;
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = UTF8Encoding.UTF8.GetBytes(encryptKey.Substring(0, 16));
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        public static string AESDecode2(this string decryptString, string decryptKey)
        {
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Mode = CipherMode.CBC;
                rijndaelProvider.Padding = PaddingMode.PKCS7;
                rijndaelProvider.BlockSize = 128;
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 32));
                rijndaelProvider.IV = UTF8Encoding.UTF8.GetBytes(decryptKey.Substring(0, 16));
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 字段加密（上传信息至中豪建设工人管理服务平台）
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns>Base64字符串</returns>
        public static string AESEncode3(this string encryptString, string encryptKey)
        {
            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Mode = CipherMode.CBC;
            rijndaelProvider.Padding = PaddingMode.PKCS7;
            rijndaelProvider.BlockSize = 128;
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey);
            rijndaelProvider.IV = UTF8Encoding.UTF8.GetBytes(encryptKey.Substring(0, 16));
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        public static string AESDecode3(this string decryptString, string decryptKey)
        {
            try
            {
                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Mode = CipherMode.CBC;
                rijndaelProvider.Padding = PaddingMode.PKCS7;
                rijndaelProvider.BlockSize = 128;
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
                rijndaelProvider.IV = UTF8Encoding.UTF8.GetBytes(decryptKey);
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 字段加密（上传信息至兰联服务平台）
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns>Base64字符串</returns>
        public static string AESEncode4(this string plainText, string key, string iv, CipherMode cipher = CipherMode.CBC, PaddingMode pading = PaddingMode.PKCS7)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            using (RijndaelManaged rmd = new RijndaelManaged())
            {
                rmd.Key = Encoding.UTF8.GetBytes(key);
                rmd.IV = Encoding.UTF8.GetBytes(iv);
                rmd.Mode = cipher;
                rmd.Padding = pading;
                ICryptoTransform encryptor = rmd.CreateEncryptor(rmd.Key, rmd.IV);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(encrypt))
                        {
                            sw.Write(plainText);
                        }
                        encrypted = stream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// 字段加密（上传劳务信息至广联达平台）
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns>Base64字符串</returns>
        public static string AESEncode5(this string encryptString, string encryptKey)
        {
            if (string.IsNullOrEmpty(encryptString)) return encryptString;

            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Mode = CipherMode.CBC;
            rijndaelProvider.Padding = PaddingMode.PKCS7;
            rijndaelProvider.BlockSize = 128;
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = UTF8Encoding.UTF8.GetBytes(encryptKey.Substring(0, 16));
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// 用种子获取密钥字节，对应JAVA的构造密钥生成器
        /// </summary>
        /// <param name="strKey">密钥种子</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="nLen">密钥长度（一般为16，不清楚时不要随意动）</param>
        /// <returns></returns>
        public static byte[] GetKeyBySeed(this string strKey, Encoding encoding, int nLen = 16)
        {
            byte[] bySeed = encoding.GetBytes(strKey);
            byte[] byKeyArray = null;
            using (var st = new SHA1CryptoServiceProvider())
            {
                using (var nd = new SHA1CryptoServiceProvider())
                {
                    var rd = nd.ComputeHash(st.ComputeHash(bySeed));
                    byKeyArray = rd.Take(nLen).ToArray();
                }
            }
            return byKeyArray;
        }

        private static byte[] DESKeys = UTF8Encoding.UTF8.GetBytes("Framework");
        public static string DESEncode(this string encryptString, string encryptKey)
        {

            byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
            byte[] rgbIV = DESKeys;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        public static string DESDecode(this string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = DESKeys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch { return string.Empty; }
        }

        public static string Base64Encode(this string encryptString)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(encbuff);
        }
        public static string Base64Decode(this string decryptString)
        {
            byte[] decbuff = Convert.FromBase64String(decryptString);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }

        public static string RSADecrypt(this string s, string key)
        {
            string result = null;

            if (string.IsNullOrEmpty(s)) throw new ArgumentException("An empty string value cannot be encrypted.");

            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Cannot decrypt using an empty key. Please supply a decryption key.");

            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = key;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            string[] decryptArray = s.Split(new string[] { "-" }, StringSplitOptions.None);
            byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (a => Convert.ToByte(byte.Parse(a, System.Globalization.NumberStyles.HexNumber))));

            byte[] bytes = rsa.Decrypt(decryptByteArray, true);

            result = UTF8Encoding.UTF8.GetString(bytes);

            return result;
        }
        public static string RSAEncrypt(this string s, string key)
        {
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("An empty string value cannot be encrypted.");

            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Cannot encrypt using an empty key. Please supply an encryption key.");

            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = key;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            byte[] bytes = rsa.Encrypt(UTF8Encoding.UTF8.GetBytes(s), true);

            return BitConverter.ToString(bytes);
        }

        public static string MD5(this string str)
        {
            string cl1 = str;
            string pwd = "";
            MD5 md5 = System.Security.Cryptography.MD5.Create();// 加密后是一个字节类型的数组 
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl1));
            for (int i = 0; i < s.Length; i++)
            {// 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得 
                pwd = pwd + s[i].ToString("x");// 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
            }
            return pwd;
        }

        /// <summary>
        ///  如果用这个标准的会有一个问题，就是丢失位数，所以字节转换成字符串的时候要保证是2位宽度啊，某个字节为0转换成字符串的时候必须是00的，否则就会丢失位数啊。不仅是0，1～9也一样。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5(this string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(str);//
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        public static string GetMD5_2(this string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(myString);//
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                //这个是很常见的错误，你字节转换成字符串的时候要保证是2位宽度啊，某个字节为0转换成字符串的时候必须是00的，否则就会丢失位数啊。不仅是0，1～9也一样。
                //byte2String += targetData[i].ToString("x");//这个会丢失
                byte2String = byte2String + targetData[i].ToString("x2");
            }

            return byte2String;
        }

        public static string MD5CSP(this string encypStr)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            inputBye = Encoding.GetEncoding("UTF8").GetBytes(encypStr);

            outputBye = m5.ComputeHash(inputBye);

            retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToLower();
            return retStr;
        }

        /// <summary>
        /// 16位大写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str_16D(this string ConvertString) 
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// 16位小写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str_16X(this string ConvertString) 
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            t2 = t2.Replace("-", "");


            t2 = t2.ToLower();


            return t2;
        }

        /// <summary>
        /// 32位大写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetStrMd5_32D(this string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)));
            t2 = t2.Replace("-", "");
            return t2;
        }


        /// <summary>
        /// 32位小写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetStrMd5_32X(this string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)));
            t2 = t2.Replace("-", "");
            return t2.ToLower();

        }

        public static string HmacSha1(this string strOrgData, string secret)
        {
            var hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(secret));
            var dataBuffer = Encoding.UTF8.GetBytes(strOrgData);
            var hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }

        public static string SHA256(this string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        /// <summary>
        /// 64位16进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns>64位16进制</returns>
        public static string SHA256x16(this string str)
        {
            byte[] SHA256Data = Encoding.UTF8.GetBytes(str);
            SHA256Managed Sha256 = new SHA256Managed();
            byte[] bytes = Sha256.ComputeHash(SHA256Data);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); 
        }
    }
}
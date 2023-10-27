using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FdSoft.CodeGenerator.Common.Helper
{
    public class TextHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content">要加密的串</param>
        /// <param name="aesKey">密钥</param>
        /// <returns></returns>
        public static string AesEncryptECB(string content, string aesKey)
        {
            byte[] byteKEY = Encoding.UTF8.GetBytes(aesKey);

            byte[] byteContnet = Encoding.UTF8.GetBytes(content);

            var _aes = new RijndaelManaged();
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Mode = CipherMode.ECB;
            _aes.Key = byteKEY;

            var _crypto = _aes.CreateEncryptor();
            byte[] decrypted = _crypto.TransformFinalBlock(byteContnet, 0, byteContnet.Length);

            _crypto.Dispose();

            return Convert.ToBase64String(decrypted);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">要解密的串</param>
        /// <param name="aesKey">密钥</param>        
        /// <returns></returns>
        public static string AesDecryptECB(string decryptStr, string aesKey)
        {
            byte[] byteKEY = Encoding.UTF8.GetBytes(aesKey);
            byte[] byteDecrypt = System.Convert.FromBase64String(decryptStr);

            var _aes = new RijndaelManaged();
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Mode = CipherMode.ECB;
            _aes.Key = byteKEY;

            var _crypto = _aes.CreateDecryptor();
            byte[] decrypted = _crypto.TransformFinalBlock(byteDecrypt, 0, byteDecrypt.Length);

            _crypto.Dispose();

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}

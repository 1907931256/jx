using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RegisterLib
{
     public class XorHex
    {
        private const string KEY = "VicoSoft";            // 密钥

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Encrypt(string txt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] bs = System.Text.Encoding.Default.GetBytes(txt);        // 原字符串转换成字节数组
                byte[] keys = System.Text.Encoding.Default.GetBytes(KEY);        // 密钥转换成字节数组

                // 异或
                for (int i = 0; i < bs.Length; i++)
                {
                    bs[i] = (byte)(bs[i] ^ keys[i % keys.Length]);
                }

                // 编码成16进制数组
                foreach (byte b in bs)
                {
                    sb.AppendFormat("{0:x2}", b);
                }
                return sb.ToString();
            }
            catch (System.Exception)
            {
                return string.Empty;
            }          
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Decrypt(string txt)
        {
           try
           {
               int len = txt.Length;
               byte[] bs = new byte[len / 2];

               // 16进制数组转换会byte数组
               for (int i = 0; i < len / 2; i++)
               {
                   bs[i] = (byte)(Convert.ToInt32(txt.Substring(i * 2, 2), 16));
               }

               byte[] keys = System.Text.Encoding.Default.GetBytes(KEY);        // 密钥转换成字节数组

               // 异或
               for (int i = 0; i < bs.Length; i++)
               {
                   bs[i] = (byte)(bs[i] ^ keys[i % keys.Length]);
               }

               // byte数组还原成字符串
               return System.Text.Encoding.Default.GetString(bs);
           }
           catch (System.Exception)
           {
               return string.Empty;
           }
        }

    }

    /// <summary> 
    /// 一个实现MD5散列字符串的类 
    /// </summary> 
    public sealed class MD5Hashing
    {
        private static MD5 md5 = MD5.Create();
        //私有化构造函数 
        private MD5Hashing()
        {
        }
        /// <summary> 
        /// 使用utf8编码将字符串散列 
        /// </summary> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(string sourceString)
        {
            return HashString(Encoding.UTF8, sourceString);
        }
        /// <summary> 
        /// 使用指定的编码将字符串散列 
        /// </summary> 
        /// <param name="encode">编码</param> 
        /// <param name="sourceString">要散列的字符串</param> 
        /// <returns>散列后的字符串</returns> 
        public static string HashString(Encoding encode, string sourceString)
        {
            byte[] source = md5.ComputeHash(encode.GetBytes(sourceString));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sBuilder.Append(source[i].ToString("x"));
            }
            return sBuilder.ToString();
        }
    }

}


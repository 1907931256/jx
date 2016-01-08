using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RegisterLib
{
     public class XorHex
    {
        private const string KEY = "VicoSoft";            // ��Կ

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Encrypt(string txt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] bs = System.Text.Encoding.Default.GetBytes(txt);        // ԭ�ַ���ת�����ֽ�����
                byte[] keys = System.Text.Encoding.Default.GetBytes(KEY);        // ��Կת�����ֽ�����

                // ���
                for (int i = 0; i < bs.Length; i++)
                {
                    bs[i] = (byte)(bs[i] ^ keys[i % keys.Length]);
                }

                // �����16��������
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
        /// ����
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Decrypt(string txt)
        {
           try
           {
               int len = txt.Length;
               byte[] bs = new byte[len / 2];

               // 16��������ת����byte����
               for (int i = 0; i < len / 2; i++)
               {
                   bs[i] = (byte)(Convert.ToInt32(txt.Substring(i * 2, 2), 16));
               }

               byte[] keys = System.Text.Encoding.Default.GetBytes(KEY);        // ��Կת�����ֽ�����

               // ���
               for (int i = 0; i < bs.Length; i++)
               {
                   bs[i] = (byte)(bs[i] ^ keys[i % keys.Length]);
               }

               // byte���黹ԭ���ַ���
               return System.Text.Encoding.Default.GetString(bs);
           }
           catch (System.Exception)
           {
               return string.Empty;
           }
        }

    }

    /// <summary> 
    /// һ��ʵ��MD5ɢ���ַ������� 
    /// </summary> 
    public sealed class MD5Hashing
    {
        private static MD5 md5 = MD5.Create();
        //˽�л����캯�� 
        private MD5Hashing()
        {
        }
        /// <summary> 
        /// ʹ��utf8���뽫�ַ���ɢ�� 
        /// </summary> 
        /// <param name="sourceString">Ҫɢ�е��ַ���</param> 
        /// <returns>ɢ�к���ַ���</returns> 
        public static string HashString(string sourceString)
        {
            return HashString(Encoding.UTF8, sourceString);
        }
        /// <summary> 
        /// ʹ��ָ���ı��뽫�ַ���ɢ�� 
        /// </summary> 
        /// <param name="encode">����</param> 
        /// <param name="sourceString">Ҫɢ�е��ַ���</param> 
        /// <returns>ɢ�к���ַ���</returns> 
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.CourseManagement.Common
{
    public static class Encrytor
    {
        private static string GetHexString(byte[] data)
        {
            var sBuilder = new StringBuilder();
            foreach (var b in data)
            {
                sBuilder.Append(b.ToString("x2")); // one byte -> two hex
            }
            return sBuilder.ToString();
        }

        private static string ComputeCryptoHash(HashAlgorithm algo, string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashData = algo.ComputeHash(bytes);
            return GetHexString(hashData);
        }

        /// <summary>
        /// Compute the MD5 hash for the input string <paramref name="str"/>.
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>MD5 value represented by 32 hexadecimal digits in lower case</returns>
        public static string ComputeMD5(string str)
        {
            using var md5 = MD5.Create();
            return ComputeCryptoHash(md5, str);
        }
    }
}

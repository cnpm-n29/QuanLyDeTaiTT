using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Core
{
    public class PasswordHash
    {
        private static string MD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static string GeneratePasswordSalt()
        {
            Random rd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[rd.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Mã hóa dữ liệu với password và salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>Mật khẩu đã mã hóa</returns>
        public static string EncryptionPasswordWithSalt(string password, string salt)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt))
            {
                return null;
            }
            return MD5Hash(password + salt);
        }
    }
}

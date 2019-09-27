using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApiOficial.Utils
{
    public static class Criptografia
    {
        private static readonly RC2CryptoServiceProvider _key;

        static Criptografia()
        {
            _key = new RC2CryptoServiceProvider
            {
                IV = new byte[] { 137, 220, 146, 142, 243, 0, 169, 32 },
                Key = new byte[] { 242, 186, 54, 173, 133, 182, 147, 252, 77, 181, 139, 132, 80, 110, 159, 21 }
            };
        }

        public static string CriptografeRC2(string textoNormal)
        {
            using (var ms = new MemoryStream())
            {
                using (var encStream = new CryptoStream(ms, _key.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(encStream))
                    {
                        sw.WriteLine(textoNormal);
                    }
                }
                var buffer = ms.ToArray();
                return Convert.ToBase64String(buffer);
            }
        }

        public static string DescriptografeRC2(string textoCriptografado)
        {
            using (var ms = new MemoryStream(Convert.FromBase64String(textoCriptografado)))
            {
                using (var encStream = new CryptoStream(ms, _key.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(encStream))
                    {
                        var val = sr.ReadToEnd().Trim();
                        return val;
                    }
                }
            }
        }

        public static string CriptografeMD5(string textoNormal)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var sb = new StringBuilder(32);
                foreach (var var in md5.ComputeHash(Encoding.UTF8.GetBytes(textoNormal)))
                {
                    sb.Append(var.ToString("x2"));
                }

                return sb.ToString().ToUpper();
            }
        }
    }
}
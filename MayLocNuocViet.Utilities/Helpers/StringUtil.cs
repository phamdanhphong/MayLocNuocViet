using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MLT.MayLocNuocViet.Utilities.Helpers
{
    public static class StringUtil
    {
        public static string GetHash(string input)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);

                var byteHash = hashAlgorithm.ComputeHash(byteValue);

                return Convert.ToBase64String(byteHash);
            }
        }

        public static int ConvertToInt(string stringValue)
        {
            int value;
            return int.TryParse(stringValue, out value) ? value : 0;
        }

        public static string Generate(int length)
        {
            return Generate(length, false, false, false);
        }

        public static string Generate(int length, bool hasNumber, bool hasUppercaseChar, bool hasSpecialChar)
        {
            var random = new Random();
            var seed = random.Next(1, int.MaxValue);

            const string allowedChars = "abcdefghijkmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            const string numberChars = "0123456789";
            const string specialChars = @"!#$%&'()*+,-./:;<=>?@[\]_";

            var chars = new char[length];
            var rd = new Random(seed);

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            var randomIndexs = new List<int>();
            var randomIndex = -1;

            if (hasNumber)
            {
                do
                {
                    randomIndex = rd.Next(0, length);
                    if (!randomIndexs.Contains(randomIndex))
                    {
                        randomIndexs.Add(randomIndex);
                        break;
                    }
                } while (randomIndexs.Contains(randomIndex));

                chars[randomIndex] = numberChars[rd.Next(0, numberChars.Length)];
            }

            if (hasUppercaseChar)
            {
                do
                {
                    randomIndex = rd.Next(0, length);
                    if (!randomIndexs.Contains(randomIndex))
                    {
                        randomIndexs.Add(randomIndex);
                        break;
                    }
                } while (randomIndexs.Contains(randomIndex));

                chars[randomIndex] = upperChars[rd.Next(0, upperChars.Length)];
            }

            if (hasSpecialChar)
            {
                do
                {
                    randomIndex = rd.Next(0, length);
                    if (!randomIndexs.Contains(randomIndex))
                    {
                        randomIndexs.Add(randomIndex);
                        break;
                    }
                } while (randomIndexs.Contains(randomIndex));

                chars[randomIndex] = specialChars[rd.Next(0, specialChars.Length)];
            }

            return new string(chars);
        }

        public static string ReplaceTokens(string template, Dictionary<string, string> replacements)
        {
            var rex = new Regex(@"\{([^}]+)}");
            return rex.Replace(
                template,
                delegate (Match m)
                {
                    var key = m.Groups[1].Value;
                    var rep = replacements.ContainsKey(key) ? replacements[key] : m.Value;
                    return rep;
                });
        }

        public static bool IsBase64String(string str)
        {
            try
            {
                Convert.FromBase64String(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNumber(string stringValue)
        {
            try
            {
                Convert.ToInt32(stringValue, CultureInfo.CurrentCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string MakeFullName(string firstName, string lastName)
        {
            return string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName)
                ? string.Empty
                : string.Format(CultureInfo.CurrentCulture, "{0}, {1}", lastName, firstName);
        }

        public static string MakeNewFileName(string oldName, int number, string fileExt)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} ({1}){2}", oldName, number, fileExt);
        }

        public static string WildCardForKeyword(string keyword)
        {
            var kw = keyword?.Replace("%", "[%]").Replace("_", "[_]").Replace("*", "%");
            return !string.IsNullOrWhiteSpace(kw) && !kw.StartsWith("%", StringComparison.CurrentCulture) &&
                   !kw.EndsWith("%", StringComparison.CurrentCulture)
                ? string.Format(CultureInfo.CurrentCulture, "%{0}%", kw)
                : kw;
        }

        public static string BindSqlQueryLike(params string[] fields)
        {
            var sql = string.Empty;
            Array.ForEach(fields, fieldName =>
            {
                if (!string.IsNullOrWhiteSpace(fieldName))
                {
                    sql += string.IsNullOrWhiteSpace(sql)
                        ? string.Format(CultureInfo.CurrentCulture, " {0} like @p0 ", fieldName)
                        : string.Format(CultureInfo.CurrentCulture, " or {0} like @p0 ", fieldName);
                }
            });

            return string.Format(CultureInfo.CurrentCulture, " where ({0})", sql);
        }
        
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="plainText">String to be encrypted</param>
        /// <param name="password">Password</param>
        public static string Encrypt(string plainText, string password)
        {
            if (plainText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = StringUtil.Encrypt(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <param name="password">Password used during encryption</param>
        /// <exception cref="FormatException"></exception>
        public static string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = StringUtil.Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }



    }

}

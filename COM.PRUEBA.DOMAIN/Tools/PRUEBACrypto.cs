using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COM.PRUEBA.DOMAIN.Tools
{
    public class PRUEBACrypto
    {
        public static string DescifrarClave(string dataToDecrypt, string password, string salt)
        {
            try
            {
                dataToDecrypt = dataToDecrypt.Replace(" ", "+");

                using (var aes = Aes.Create())
                {
                    using (var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 10000, HashAlgorithmName.SHA256))
                    {
                        aes.Key = key.GetBytes(32); // AES-256
                        aes.IV = key.GetBytes(16);

                        using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                        using (var ms = new MemoryStream())
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            byte[] bytes = Convert.FromBase64String(dataToDecrypt);
                            cs.Write(bytes, 0, bytes.Length);
                            cs.FlushFinalBlock();
                            return Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string CifrarClave(string dataToEncrypt, string password, string salt)
        {
            using (var aes = Aes.Create())
            {
                using (var key = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 10000, HashAlgorithmName.SHA256))
                {
                    aes.Key = key.GetBytes(32); // AES-256
                    aes.IV = key.GetBytes(16);

                    using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(dataToEncrypt);
                        cs.Write(bytes, 0, bytes.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

    }
}

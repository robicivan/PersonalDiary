using System.Security.Cryptography;
using System.Text;

namespace PersonalDiary.Services
{
    public class EncryptionService
    {
        /// <summary>
        /// Encrypts plain text using the provided user-specific key and IV (both base64-encoded).
        /// </summary>
        public string Encrypt(string plainText, string keyBase64, string ivBase64)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            var key = Convert.FromBase64String(keyBase64);
            var iv = Convert.FromBase64String(ivBase64);

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (StreamWriter sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Decrypts cipher text using the provided user-specific key and IV (both base64-encoded).
        /// </summary>
        public string Decrypt(string cipherText, string keyBase64, string ivBase64)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            var key = Convert.FromBase64String(keyBase64);
            var iv = Convert.FromBase64String(ivBase64);

            using Aes aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Generates a cryptographically random AES-256 key (32 bytes) as a base64 string.
        /// </summary>
        public static string GenerateKey()
        {
            var key = new byte[32];
            RandomNumberGenerator.Fill(key);
            return Convert.ToBase64String(key);
        }

        /// <summary>
        /// Generates a cryptographically random AES IV (16 bytes) as a base64 string.
        /// </summary>
        public static string GenerateIV()
        {
            var iv = new byte[16];
            RandomNumberGenerator.Fill(iv);
            return Convert.ToBase64String(iv);
        }
    }
}

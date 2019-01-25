using System;
using System.Security.Cryptography;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge7
    {
        public static  string SolveChallenge(string input, string key)
        {
            return AESDecrypt(input, key);
        }

        private static string AESDecrypt(string cipherText, string key)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] output = new byte[cipherText.Length];

            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = CipherMode.ECB;
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Padding = PaddingMode.None;
                aes.Key = key.ToByteArray();

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptor.TransformBlock(cipherBytes, 0, cipherBytes.Length, output, 0);
            }

            return output.ToASCIIString();
        }
    }
}

using System;
using System.Security.Cryptography;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge7
    {
        private readonly string _cipherText;
        private readonly string _key;

        public Challenge7(string cipherText, string key)
        {
            _cipherText = cipherText;
            _key = key;
        }

        public string SolveChallenge()
        {
            return AESDecrypt();
        }

        private string AESDecrypt()
        {
            byte[] cipherBytes = Convert.FromBase64String(_cipherText);
            byte[] output = new byte[cipherBytes.Length];

            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = CipherMode.ECB;
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Padding = PaddingMode.None;
                aes.Key = _key.ToByteArray();

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptor.TransformBlock(cipherBytes, 0, cipherBytes.Length, output, 0);
            }

            return output.ToASCIIString();
        }
    }
}

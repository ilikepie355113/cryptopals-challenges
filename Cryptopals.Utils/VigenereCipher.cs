using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class VigenerCipher : ICryptography
    {
        public string Encrypt(PlainText text, string key, CipherTextFormat format = CipherTextFormat.HEXADECIMAL)
        {
            byte[] plainBytes = text.Bytes;
            byte[] expandedKey = ExpandKey(key.ToByteArray(), plainBytes.Length);
            byte[] cipherBytes = plainBytes.XorWith(expandedKey);

            return (format == CipherTextFormat.BASE64) ? Convert.ToBase64String(cipherBytes) : cipherBytes.ToHexString();
        }

        public string Decrypt(CipherText cipherText, string key)
        {
            byte[] expandedKey = ExpandKey(key.ToByteArray(), cipherText.Length);

            return expandedKey.XorWith(cipherText.Bytes).ToASCIIString();
        }

        private static byte[] ExpandKey(byte[] key, int length)
        {
            byte[] expandedKey = new byte[length];

            for (int i = 0; i < length; i++)
            {
                expandedKey[i] = key[i % key.Length];
            }

            return expandedKey;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class VigenereDecrypt : IDecryptor
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class VigenereEncrypt : IEncryptor
    {
        public string Encrypt(PlainText text, string key, CipherTextFormat format = CipherTextFormat.HEXADECIMAL)
        {
            byte[] plainBytes = text.Bytes;
            byte[] expandedKey = ExpandKey(key.ToByteArray(), plainBytes.Length);
            byte[] cipherBytes = plainBytes.XorWith(expandedKey);

            return (format == CipherTextFormat.BASE64) ? Convert.ToBase64String(cipherBytes) : cipherBytes.ToHexString();
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

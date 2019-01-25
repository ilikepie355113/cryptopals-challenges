using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public enum CipherTextFormat { BASE64, HEXADECIMAL }

    public class CipherText
    {
        public string Text { get; }
        public byte[] Bytes { get; }
        public int Length { get; }
        public CipherTextFormat Format { get; }

        public CipherText(string text, CipherTextFormat format)
        {
            Text = text;
            Bytes = (format == CipherTextFormat.BASE64) ? Convert.FromBase64String(text) : text.HexToBytes();
            Length = Bytes.Length;
            Format = format;
        }

        public CipherText(byte[] cipherBytes, CipherTextFormat format = CipherTextFormat.HEXADECIMAL)
        {
            Text = (format == CipherTextFormat.BASE64) ? Convert.ToBase64String(cipherBytes) : cipherBytes.ToHexString();
            Bytes = cipherBytes;
            Length = Bytes.Length;
            Format = format;
        }

        public string Decrypt(IDecryptor decryptor, string key)
        {
            return decryptor.Decrypt(this, key);
        }

        public DecipherText Crack(ICracker cracker, int keyLegnth = 0)
        {
            return cracker.Crack(this, keyLegnth);
        }
    }
}

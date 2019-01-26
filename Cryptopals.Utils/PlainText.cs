using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public struct PlainText
    {
        public string Text { get; }
        public byte[] Bytes { get; }

        public PlainText(string text)
        {
            Text = text;
            Bytes = text.ToByteArray();
        }

        public string Encrypt(ICryptography encryptor, string key, CipherTextFormat format = CipherTextFormat.HEXADECIMAL)
        {
            return encryptor.Encrypt(this, key, format);
        }
    }
}

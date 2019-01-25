using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public interface IEncryptor
    {
        string Encrypt(PlainText text, string key, CipherTextFormat format);
    }
}

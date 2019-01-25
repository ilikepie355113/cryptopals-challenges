using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public interface ICracker
    {
        DecipherText Crack(CipherText cipherText, int keyLength);
    }
}

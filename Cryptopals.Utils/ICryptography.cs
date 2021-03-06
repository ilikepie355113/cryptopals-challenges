﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public interface ICryptography
    {
        string Encrypt(PlainText text, string key, CipherTextFormat format);
        string Decrypt(CipherText cipherText, string key);
    }
}

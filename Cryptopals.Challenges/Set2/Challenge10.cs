using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set2
{
    public class Challenge10
    {
        private readonly string _input;
        private readonly string _key;
        private readonly byte[] _iv;

        public Challenge10(string input, string key, byte[] iv)
        {
            _input = input;
            _key = key;
            _iv = iv;
        }

        public string SolveChallenge()
        {
            AESCipher aes = new AESCipher(CipherMode.CBC, PaddingMode.None, _iv);
            return aes.Decrypt(new CipherText(_input, CipherTextFormat.BASE64), _key);
        }
    }
}

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
            AESCipher aes = new AESCipher(CipherMode.ECB, PaddingMode.None);
            return aes.Decrypt(new CipherText(_cipherText, CipherTextFormat.BASE64), _key);
        }
    }
}

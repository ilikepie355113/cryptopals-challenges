using System.Collections.Generic;
using System.Linq;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge4
    {
        private readonly List<string> _ciphers;
        private readonly ICracker _cracker;
        private const int KEYLENGTH = 1;

        public Challenge4(List<string> ciphers, ICracker cracker)
        {
            _ciphers = ciphers;
            _cracker = cracker;
        }

        public string SolveChallenge()
        {
            var decipheredTexts = new List<DecipherText>();

            foreach (var cipher in _ciphers)
            {
                var cipherText = new CipherText(cipher, CipherTextFormat.HEXADECIMAL);
                decipheredTexts.Add(cipherText.Crack(_cracker, KEYLENGTH));
            }

            decipheredTexts.Sort();

            return decipheredTexts.First().CipherText.Text;
        }
    }
}

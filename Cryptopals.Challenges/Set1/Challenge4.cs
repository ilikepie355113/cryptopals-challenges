using System.Collections.Generic;
using System.Linq;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge4
    {
        public static string SolveChallenge(List<string> ciphers)
        {
            var decipheredTexts = new List<DecipherText>();

            foreach (var cipher in ciphers)
            {
                var cipherText = new CipherText(cipher, CipherTextFormat.HEXADECIMAL);
                decipheredTexts.Add(cipherText.Crack(new VigenereCrack(), 1));
            }

            decipheredTexts.Sort();

            return decipheredTexts.First().CipherText.Text;
        }
    }
}

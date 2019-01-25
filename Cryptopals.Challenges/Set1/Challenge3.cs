using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge3
    {
        public string SolveChallenge(string input)
        {
            CipherText cipherText = new CipherText(input, CipherTextFormat.HEXADECIMAL);

            return cipherText.Crack(new VigenereCrack(), 1).DecipheredText;
        }
    }
}

using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge6
    {
        public string SolveChallenge(string input)
        {
            CipherText cipherText = new CipherText(input, CipherTextFormat.BASE64);

            return cipherText.Crack(new VigenereCrack()).DecipheredText;
        }
    }
}

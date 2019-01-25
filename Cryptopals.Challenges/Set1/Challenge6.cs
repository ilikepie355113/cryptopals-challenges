using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge6
    {
        public static string SolveChallenge(string input)
        {
            CipherText cipherText = new CipherText(input, CipherTextFormat.BASE64);

            return cipherText.Crack(new VigenereCrack()).DecipheredText;
        }
    }
}

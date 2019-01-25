using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge5
    {
        public static string SolveChallenge(string input)
        {
            PlainText plainText = new PlainText(input);
            return plainText.Encrypt(new VigenereEncrypt(), "ICE");
        }
    }
}

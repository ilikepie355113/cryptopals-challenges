using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge5
    {
        public string SolveChallenge(string input)
        {
            PlainText plainText = new PlainText(input);
            return plainText.Encrypt(new VigenereEncrypt(), "ICE");
        }
    }
}

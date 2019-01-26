using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge5
    {
        private readonly PlainText _plainText;
        private readonly string _key;
        private readonly ICryptography _encryptor;

        public Challenge5(string plainText, string key, ICryptography encryptor)
        {
            _plainText = new PlainText(plainText);
            _key = key;
            _encryptor = encryptor;
        }

        public string SolveChallenge()
        {
            return _plainText.Encrypt(_encryptor, _key);
        }
    }
}

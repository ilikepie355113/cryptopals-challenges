using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge6
    {
        private readonly CipherText _cipherText;
        private readonly ICracker _cracker;

        public Challenge6(string cipherText, ICracker cracker)
        {
            _cipherText = new CipherText(cipherText, CipherTextFormat.BASE64);
            _cracker = cracker;
        }
        public string SolveChallenge()
        {
            return _cipherText.Crack(_cracker).DecipheredText;
        }
    }
}

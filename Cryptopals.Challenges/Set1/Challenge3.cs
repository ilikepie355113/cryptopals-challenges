using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge3
    {
        private readonly ICracker _cracker;
        private readonly CipherText _cipherText;

        public Challenge3(ICracker cracker, string hexCipher)
        {
            _cracker = cracker;
            _cipherText = new CipherText(hexCipher, CipherTextFormat.HEXADECIMAL);
        }


        public string SolveChallenge()
        {
            return _cipherText.Crack(_cracker, 1).DecipheredText;
        }
    }
}

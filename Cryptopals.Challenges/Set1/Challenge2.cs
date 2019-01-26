using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge2
    {
        private readonly string _hex1;
        private readonly string _hex2;

        public Challenge2(string hex1, string hex2)
        {
            _hex1 = hex1;
            _hex2 = hex2;
        }
        public string SolveChallenge()
        {
            return _hex1.HexToBytes()
                       .XorWith(_hex2.HexToBytes())
                       .ToHexString();
        }
    }
}

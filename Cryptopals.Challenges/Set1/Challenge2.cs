using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge2
    {
        public string SolveChallenge(string hex1, string hex2)
        {
            return hex1.HexToBytes()
                       .XorWith(hex2.HexToBytes())
                       .ToHexString();
        }
    }
}

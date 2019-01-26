using System;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge1
    {
        private readonly string _hexString;

        public Challenge1(string hexString)
        {
            _hexString = hexString;
        }

        public string SolveChallenge()
        {
            return Convert.ToBase64String(_hexString.HexToBytes());
        }
    }
}

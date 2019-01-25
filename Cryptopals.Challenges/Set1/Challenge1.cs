using System;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge1
    {
        public string SolveChallenge(string input)
        {
            return Convert.ToBase64String(input.HexToBytes());
        }
    }
}

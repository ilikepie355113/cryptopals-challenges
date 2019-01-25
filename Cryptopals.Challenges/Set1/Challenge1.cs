using System;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge1
    {
        public static string SolveChallenge(string input)
        {
            return Convert.ToBase64String(input.HexToBytes());
        }
    }
}

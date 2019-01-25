﻿using System.Collections.Generic;
using System.Linq;

namespace Cryptopals.Challenges.Set1
{
    public static class Challenge8
    {
        public static string SolveChallenge(List<string> ciphers)
        {
            return FindECBCiphers(ciphers).First();
        }

        public static List<string> FindECBCiphers(List<string> ciphers)
        {
            return ciphers.Where(x => ContainsDupeBlocks(GetBlocks(x))).ToList();
        }

        private static List<string> GetBlocks(string cipher)
        {
            int numBlocks = cipher.Length / 32; // size of AES-ECB is 16 bytes (which is 32 hex chars)
            var blocks = new List<string>(numBlocks);

            for (int i = 0; i < numBlocks; i++)
            {
                blocks.Add(cipher.Substring(32 * i, 32));
            }

            return blocks;
        }

        private static bool ContainsDupeBlocks(List<string> blocks)
        {
            return blocks.GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .Count() > 0;
        }
    }
}

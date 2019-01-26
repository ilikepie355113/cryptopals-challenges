using System.Collections.Generic;
using System.Linq;

namespace Cryptopals.Challenges.Set1
{
    public class Challenge8
    {
        private readonly List<string> _ciphers;

        public Challenge8(List<string> ciphers)
        {
            _ciphers = ciphers;
        }

        public string SolveChallenge()
        {
            return FindECBCiphers().First(); // challenge only contains 1, so just return first
        }

        public List<string> FindECBCiphers()
        {
            return _ciphers.Where(x => ContainsDupeBlocks(GetBlocks(x))).ToList();
        }

        private List<string> GetBlocks(string cipher)
        {
            int numBlocks = cipher.Length / 32; // size of AES-ECB is 16 bytes (which is 32 hex chars)
            var blocks = new List<string>(numBlocks);

            for (int i = 0; i < numBlocks; i++)
            {
                blocks.Add(cipher.Substring(32 * i, 32));
            }

            return blocks;
        }

        private bool ContainsDupeBlocks(List<string> blocks)
        {
            return blocks.GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .Count() > 0;
        }
    }
}

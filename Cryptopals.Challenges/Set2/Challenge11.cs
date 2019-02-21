using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set2
{
    public class Challenge11
    {

        // The key to this challenge is that we control the plaintext into the oracle. So if we send a plaintext
        // of sufficient length we can guaruntee that two identical blocks are encrypted and that is all it takes
        // for us to detect if the encryption was done in ECB as ECB is deterministic
        public string EncryptionOracle(string plainText)
        {
            PlainText message = new PlainText(RandomizeMessageLength(plainText));
            string randKey = GetRandomKey(16).ToASCIIString();

            Random random = new Random();
            CipherMode mode = (random.Next(2) == 0) ? CipherMode.ECB : CipherMode.CBC;
            // DEBUG:
            Console.WriteLine((mode == CipherMode.ECB) ? "ECB" : "CBC");

            AESCipher aes = new AESCipher(mode, PaddingMode.PKCS7);

            return aes.Encrypt(message, randKey, CipherTextFormat.HEXADECIMAL);
        }

        // only implemented for hex strings currently
        public CipherMode DetectionOracle(string cipherText)
        {
            return (ContainsDupeBlocks(GetBlocks(cipherText))) ? CipherMode.ECB : CipherMode.CBC;
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

        private byte[] GetRandomKey(int size)
        {
            Random random = new Random();
            byte[] array = new byte[size];
            random.NextBytes(array);

            return array;
        }

        private string RandomizeMessageLength(string plainText)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            sb.Append(Enumerable.Repeat("O", random.Next(5, 10)));
            sb.Append(plainText);
            sb.Append(Enumerable.Repeat("O", random.Next(5, 10)));

            return sb.ToString();
        }
    }
}

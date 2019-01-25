using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class VigenereCrack : ICracker
    {
        public DecipherText Crack(CipherText cipherText, int keyLength = 0)
        {
            if (keyLength == 0) keyLength = FindKeyLength(cipherText.Bytes);
            string key = GetKey(cipherText.Bytes, keyLength);

            return new DecipherText(cipherText, key, new VigenereDecrypt());
        }

        // need to normalize, and add error checking and bounds for keysizes if implenting outside of specific challenge.
        // Using the method from my Crypto 445 textbook, which differes slightly from the one outlined on cryptopals
        private int FindKeyLength(byte[] cipherBytes)
        {
            var dict = new SortedDictionary<int, int>();

            for (int keyLength = 2; keyLength < 40; keyLength++)
            {
                int length = cipherBytes.Length - keyLength;
                byte[] b1 = new byte[length];
                byte[] b2 = new byte[length];

                Array.Copy(cipherBytes, 0, b1, 0, length);
                Array.Copy(cipherBytes, keyLength, b2, 0, length);

                int hamming = HammingDistance(b1, b2);

                if (!dict.ContainsKey(hamming))
                {
                    dict.Add(hamming, keyLength);
                }
            }

            return dict.First().Value;
        }

        private string GetKey(byte[] cipherBytes, int keyLength)
        {
            StringBuilder sb = new StringBuilder(keyLength);

            for (int i = 0; i < keyLength; i++)
            {
                byte[] transposed = cipherBytes.Where((x, index) => (index - i) % keyLength == 0).ToArray();
                sb.Append(BruteForceSingleByteKey(transposed));
            }

            return sb.ToString();
        }

        private string BruteForceSingleByteKey(byte[] cipherBytes)
        {
            var keys = Enumerable.Range(0, 128).ToArray();
            var decipheredTexts = new List<DecipherText>();

            foreach (char key in keys)
            {
                var dt = new DecipherText(new CipherText(cipherBytes), key.ToString(), new VigenereDecrypt());
                decipheredTexts.Add(dt);
            }

            decipheredTexts.Sort(); 

            return decipheredTexts.First().Key;

        }

        private static List<byte[]> GetSingleByteKeys(int minKeyVal, int maxKeyVal, int keyLength)
        {
            var bytes = new List<byte[]>();

            for (int i = minKeyVal; i <= maxKeyVal; i++)
            {
                bytes.Add(Enumerable.Repeat((byte)i, keyLength).ToArray());
            }

            return bytes;
        }

        private static int HammingDistance(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) throw new ArgumentException("Arrays must be equal in length");

            int distance = 0;

            for (int i = 0; i < b1.Length; i++)
            {
                distance += HammingDistance(b1[i], b2[i]);

            }

            return distance;
        }

        private static int HammingDistance(byte b1, byte b2)
        {
            int distance = 0;

            for (int i = 0; i < 8; i++)
            {
                if ((b1 & 1) != (b2 & 1)) distance++;
                b1 = (byte)(b1 >> 1);
                b2 = (byte)(b2 >> 1);
            }

            return distance;
        }
    }
}

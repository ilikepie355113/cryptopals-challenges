using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set2
{
    public class Challenge10
    {
        private readonly string _input;
        private readonly string _key;

        public Challenge10(string input, string key)
        {
            _input = input;
            _key = key;
        }

        public string SolveChallenge()
        {
            return CBCDecryptByHand(_input, _key, new byte[16]);
        }

        private string CBCDecryptByHand(string cipherText, string key, byte[] IV )
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            List<byte> plainBytes = new List<byte>(cipherBytes.Length);

            byte[] previousBlock = (byte[]) IV.Clone();

            for (int i = 0; i < cipherBytes.Length; i += 16)
            {
                byte[] block = cipherBytes.Skip(i).Take(16).ToArray();
                plainBytes.AddRange(AESDecryptSingleBlockECB(block, key).XorWith(previousBlock));
                previousBlock = block;
            }

            return plainBytes.ToArray().ToASCIIString();
        }

        private byte[] AESDecryptSingleBlockECB(byte[] block, string key)
        {
            byte[] decrypted;

            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = CipherMode.ECB;
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.Padding = PaddingMode.None;
                aes.Key = key.ToByteArray();

                ICryptoTransform decryptor = aes.CreateDecryptor();
                decrypted = decryptor.TransformFinalBlock(block, 0, 16);
            }

            return decrypted;
        }
    }
}

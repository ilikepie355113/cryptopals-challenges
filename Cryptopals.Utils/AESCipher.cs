using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptopals.Utils
{
    public class AESCipher : ICryptography
    {
        private byte[] _key;

        public CipherMode Mode { get; set; } 
        public PaddingMode Padding {get; set; }
        public byte[] IV { get; set; }
        public string Key
        {
            get => _key.ToASCIIString(); 
            set => _key = value.ToByteArray(); 
        }

        public AESCipher(CipherMode mode, PaddingMode padding, byte[] iv)
        {
            Mode = mode;
            Padding = padding;
            IV = iv;
        }

        public string Encrypt(PlainText text, string key, CipherTextFormat format)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(CipherText cipherText, string key)
        {
            throw new NotImplementedException();
        }

        private string CBCEncryptByHand(string plainText)
        {

            byte[] plainBytes = Convert.FromBase64String(plainText);
            List<byte> cipherBytes = new List<byte>(plainBytes.Length);

            byte[] previousBlock = (byte[]) IV.Clone();

            for (int i = 0; i < plainBytes.Length; i += 16)
            {
                byte[] block = plainBytes.Skip(i).Take(16).ToArray().XorWith(previousBlock);
                byte[] encrypted = EncryptSingleBlockECB(block);
                cipherBytes.AddRange(encrypted);
                previousBlock = encrypted;
            }

            // TODO need to make this correct for chosen format
            return cipherBytes.ToArray().ToASCIIString();
        }

        private string CBCDecryptByHand(string cipherText)
        {

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            List<byte> plainBytes = new List<byte>(cipherBytes.Length);

            byte[] previousBlock = (byte[]) IV.Clone();

            for (int i = 0; i < cipherBytes.Length; i += 16)
            {
                byte[] block = cipherBytes.Skip(i).Take(16).ToArray();
                plainBytes.AddRange(DecryptSingleBlockECB(block).XorWith(previousBlock));
                previousBlock = block;
            }

            return plainBytes.ToArray().ToASCIIString();
        }

        private byte[] EncryptSingleBlockECB(byte[] block)
        {
            byte[] encrypted;

            using (AesManaged aes = InitalizeAESManaged())
            {
                ICryptoTransform encryptor = _aes.CreateEncryptor();
                encrypted = encryptor.TransformFinalBlock(block, 0, 16);
            }

            return encrypted;
        }

        private byte[] DecryptSingleBlockECB(byte[] block)
        {
            byte[] decrypted;

            using (AesManaged aes = InitalizeAESManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor();
                decrypted = decryptor.TransformFinalBlock(block, 0, 16);
            }

            return decrypted;
        }

        private AesManaged InitalizeAESManaged()
        {
            AesManaged aes = new AesManaged
            {
                Mode = Mode,
                BlockSize = 128,
                KeySize = 128,
                Padding = Padding,
                Key = _key,
                IV = _iv
            };

            return aes;
        }
    }
}

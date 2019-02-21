using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptopals.Utils
{
    public class PKCS7
    {
        public int BlockSize { get; }

        public PKCS7(int blockSize)
        {
            BlockSize = blockSize;
        }

        public byte[] AddPadding(byte[] message)
        {
            int value = BlockSize - message.Length % BlockSize;
            var padding = Enumerable.Repeat((byte) value, value);

            return message.Concat(padding).ToArray();
        }

        public byte[] RemovePadding(byte[] message)
        {
            return message.Take(message.Length - message.Last()).ToArray();
        }
    }

    public class AESCipher : ICryptography
    {
        private byte[] _key;
        private const int BLOCK_SIZE = 128; // constant for all challenges so far, may need to change to property later

        public CipherMode Mode { get; set; } 
        public PaddingMode Padding {get; set; }
        public byte[] IV { get; set; }
        public string Key
        {
            get => _key.ToASCIIString(); 
            set => _key = value.ToByteArray(); 
        }

        public AESCipher(CipherMode mode, PaddingMode padding, byte[] iv = null)
        {
            Mode = mode;
            Padding = padding;
            IV = iv ?? (new byte[16]);
        }

        public string Encrypt(PlainText text, string key, CipherTextFormat format)
        {
            Key = key;
            byte[] messageBytes = (Padding == PaddingMode.PKCS7) ? new PKCS7(BLOCK_SIZE / 8).AddPadding(text.Bytes) : text.Bytes; 
            byte[] cipherBytes = (Mode == CipherMode.CBC) ? CBCEncryptByHand(messageBytes) : ECBEncrypt(messageBytes);

            return (format == CipherTextFormat.BASE64) ? Convert.ToBase64String(cipherBytes) : cipherBytes.ToHexString();
        }

        public string Decrypt(CipherText cipherText, string key)
        {
            Key = key;
            byte[] decrypted = (Mode == CipherMode.CBC) ? CBCDecryptByHand(cipherText.Bytes) : ECBDecrypt(cipherText.Bytes);

            return (Padding == PaddingMode.PKCS7) ? new PKCS7(BLOCK_SIZE / 8).RemovePadding(decrypted).ToASCIIString() : decrypted.ToASCIIString();
        }

        private byte[] CBCEncryptByHand(byte[] plainBytes)
        {
            List<byte> cipherBytes = new List<byte>(plainBytes.Length);

            byte[] previousBlock = (byte[]) IV.Clone();

            for (int i = 0; i < plainBytes.Length; i += 16)
            {
                
                byte[] block = plainBytes.Skip(i).Take(16).ToArray().XorWith(previousBlock);
                byte[] encrypted = EncryptSingleBlockECB(block);
                cipherBytes.AddRange(encrypted);
                previousBlock = encrypted;
            }

            return cipherBytes.ToArray();
        }

        private byte[] CBCDecryptByHand(byte[] cipherBytes)
        {
            List<byte> plainBytes = new List<byte>(cipherBytes.Length);

            byte[] previousBlock = (byte[]) IV.Clone();

            for (int i = 0; i < cipherBytes.Length; i += 16)
            {
                byte[] block = cipherBytes.Skip(i).Take(16).ToArray();
                plainBytes.AddRange(DecryptSingleBlockECB(block).XorWith(previousBlock));
                previousBlock = block;
            }

            return plainBytes.ToArray();
        }

        private byte[] ECBEncrypt(byte[] plainBytes)
        {
            byte[] encrypted = new byte[plainBytes.Length];

            using (AesManaged aes = InitializeAESManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor();
                encryptor.TransformBlock(plainBytes, 0, plainBytes.Length, encrypted, 0);
            }

            return encrypted;
        }

        private byte[] ECBDecrypt(byte[] cipherBytes)
        {
            byte[] decrypted = new byte[cipherBytes.Length];

            using (AesManaged aes = InitializeAESManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor();
                decryptor.TransformBlock(cipherBytes, 0, cipherBytes.Length, decrypted, 0);
            }

            return decrypted;
        }

        private byte[] EncryptSingleBlockECB(byte[] block)
        {
            byte[] encrypted;

            using (AesManaged aes = InitializeAESManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor();
                encrypted = encryptor.TransformFinalBlock(block, 0, 16);
            }

            return encrypted.Take(16).ToArray(); // Strips padding in case of PCKS7 mode.
        }

        private byte[] DecryptSingleBlockECB(byte[] block)
        {
            byte[] decrypted;

            using (AesManaged aes = InitializeAESManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor();
                decrypted = decryptor.TransformFinalBlock(block, 0, 16);
            }

            return decrypted;
        }

        private AesManaged InitializeAESManaged()
        {
            AesManaged aes = new AesManaged
            {
                Mode = Mode,
                BlockSize = BLOCK_SIZE,
                KeySize = BLOCK_SIZE,
                Padding = Padding,
                Key = _key,
                IV = IV
            };

            return aes;
        }
    }
}

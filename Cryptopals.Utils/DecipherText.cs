using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public class DecipherText : IComparable<DecipherText>
    {
        public CipherText CipherText { get; }
        public string DecipheredText { get; }
        public string Key { get; }
        public double Score { get; }

        public DecipherText(CipherText cipherText, string key, ICryptography decryptor)
        {
            CipherText = cipherText;
            DecipheredText = decryptor.Decrypt(cipherText, key);
            Key = key;
            Score = new FrequencyAnalysis(DecipheredText).Score;
        }

        public int CompareTo(DecipherText that)
        {
            if (Score < that.Score) return -1;
            else if (Score > that.Score) return 1;
            else return DecipheredText.CompareTo(that.DecipheredText);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptopals.Utils;

namespace Cryptopals.Challenges.Set2
{
    public class Challenge9
    {
        private readonly string _input;
        private readonly int _size;

        public Challenge9(string input, int size)
        {
            _input = input;
            _size = size;
        }

        public string SolveChallenge()
        {
            return PadBlock(_input.ToByteArray(), _size).ToASCIIString();
        }

        private byte[] PadBlock(byte[] block, int size)
        {
            byte[] paddedBlock = new byte[size];
            int paddingLength = size - block.Length;
            block.CopyTo(paddedBlock, 0);

            for (int i = 1; i <= paddingLength; i++)
            {
                paddedBlock[size - i] = (byte) paddingLength;
            }

            return paddedBlock;
        }
    }
}

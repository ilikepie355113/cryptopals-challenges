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
            return new PKCS7(_size).AddPadding(_input.ToByteArray()).ToASCIIString();
        }
    }
}

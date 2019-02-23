using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cryptopals.Challenges.Set2;
using System.Security.Cryptography;

namespace Cryptopals.Tests.Set2
{
    public class Challenge11Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInput()
        {
            string plainText = string.Join("", Enumerable.Repeat("0", 48));
            Challenge11 challenge11 = new Challenge11(plainText);
            CipherMode expected;
            CipherMode actual;

            for (int i = 0; i < 10; i++)
            {
                expected = challenge11.SolveChallenge();
                actual = challenge11.Mode;

                Assert.Equal(expected, actual);
            }
        }
    }
}

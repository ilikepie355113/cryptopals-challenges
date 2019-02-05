using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cryptopals.Challenges.Set2;

namespace Cryptopals.Tests.Set2
{
    public class Challenge10Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInput()
        {
            string cipherText = Properties.Resources.challenge10.Replace("\n", string.Empty);
            string expected = "I'm back and I'm ringin' the bell"; // If you can read that, the rest of it is correct

            string actual = new Challenge10(cipherText, "YELLOW SUBMARINE").SolveChallenge().Substring(0, expected.Length);

            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Cryptopals.Utils;

namespace Cryptopals.Tests.Set2
{
    public class Challenge9Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInput()
        {
            string input = "YELLOW SUBMARINE";
            int size = 20;
            string expected = "YELLOW SUBMARINE\u0004\u0004\u0004\u0004";

            string actual = new Challenges.Set2.Challenge9(input, size).SolveChallenge();

            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge4Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInputs()
        {
            string inputText = Properties.Resources.challenge4;
            List<string> ciphers = inputText.Split(new[] { "\n" }, StringSplitOptions.None).ToList();
            string expected = "7b5a4215415d544115415d5015455447414c155c46155f4058455c5b523f";

            string actual = Challenge4.SolveChallenge(ciphers);

            Assert.Equal(expected, actual);
        }
    }
}

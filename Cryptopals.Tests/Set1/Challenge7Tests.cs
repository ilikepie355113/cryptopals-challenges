using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge7Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInput()
        {
            string cipherText = Properties.Resources.challenge7.Replace("\n", string.Empty);
            string expected = "I'm back and I'm ringin' the bell"; // If you can read that, the rest of it is correct

            string actual = new Challenge7().SolveChallenge(cipherText, "YELLOW SUBMARINE").Substring(0, expected.Length);

            Assert.Equal(expected, actual);
        }
    }
}

using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge6Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeInput()
        {
            string input = Properties.Resources.challenge6.Replace("\n", string.Empty);
            string expected = Properties.Resources.challenge6expected.Replace("\r\n", "");

            string actual = new Challenge6().SolveChallenge(input).Replace(" \n", "").Replace("\n", ""); //change to regex when not lazy

            Assert.Equal(expected, actual);
        }
    }
}

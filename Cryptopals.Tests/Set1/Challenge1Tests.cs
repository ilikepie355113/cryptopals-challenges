using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge1Tests
    {
        [Fact]
        public void SolveChallenge_ShouldSolveChallengeString()
        {
            string input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";

            string actual = new Challenge1(input).SolveChallenge();

            Assert.Equal(expected, actual);
        }
    }
}

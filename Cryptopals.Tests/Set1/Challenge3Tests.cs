using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge3Tests
    {
        [Fact]
        public static void SolveChallenge_ShouldSolveChallengeInputs()
        {
            string input = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
            string expected = "Cooking MC's like a pound of bacon";

            string actual = new  Challenge3().SolveChallenge(input);

            Assert.Equal(expected, actual);
        }
    }
}

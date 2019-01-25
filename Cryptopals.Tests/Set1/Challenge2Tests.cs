using Xunit;
using Cryptopals.Challenges.Set1;

namespace Cryptopals.Tests.Set1
{
    public class Challenge2Tests
    {
        [Fact]
        public static void SolveChallenge_ShouldSolveChallenge()
        {
            string hex1 = "1c0111001f010100061a024b53535009181c";
            string hex2 = "686974207468652062756c6c277320657965";
            string expected = "746865206b696420646f6e277420706c6179";

            string actual = new Challenge2().SolveChallenge(hex1, hex2);

            Assert.Equal(expected, actual);
        }
    }
}

using Xunit;
using Cryptopals.Challenges.Set1;
using Cryptopals.Utils;

namespace Cryptopals.Tests.Set1
{
    public class Challenge5Tests
    {
        [Fact]
        public static void SolveChallenge_ShouldSolveChallenge()
        {
            string input = "Burning 'em, if you ain't quick and nimble\nI go crazy when I hear a cymbal";
            string expected = "0b3637272a2b2e63622c2e69692a23693a2a3c6324202d623d63343c2a26226324272765272a282b2f20430a652e2c652a3124333a653e2b2027630c692b20283165286326302e27282f";

            string actual = new Challenge5(input, "ICE", new VigenerCipher()).SolveChallenge();

            Assert.Equal(expected, actual);
        }
    }
}

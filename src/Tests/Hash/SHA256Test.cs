using Sonoda.Cryptography;
using System.Security.Cryptography;
using Xunit;

namespace Tests.Hash
{
    public class SHA256Test
    {
        [Fact]
        public void HashBytes()
        {
            var BytesUTF8 = Constants.SampleText.Hash<SHA256>();
            var BytesUnicode = Constants.SampleText.Hash<SHA256>(Constants.Unicode);

            Assert.NotEmpty(BytesUTF8);
            Assert.NotEmpty(BytesUnicode);
            Assert.True(BytesUTF8.Length == 32);
            Assert.True(BytesUnicode.Length == 32);
            Assert.NotEqual(BytesUTF8, BytesUnicode);
        }

        [Fact]
        public void HashHexRepresentation()
        {
            var HashUTF8 = Constants.SampleText.Hash<SHA256>().ToHex();
            var HashUnicode = Constants.SampleText.Hash<SHA256>(Constants.Unicode).ToHex();

            Assert.NotNull(HashUTF8);
            Assert.NotNull(HashUnicode);
            Assert.Equal(Constants.HashSHA256_Hex_UTF8, HashUTF8);
            Assert.Equal(Constants.HashSHA256_Hex_Unicode, HashUnicode);
        }

        [Fact]
        public void HashBase64Representation()
        {
            var HashUTF8 = Constants.SampleText.Hash<SHA256>().ToBase64();
            var HashUnicode = Constants.SampleText.Hash<SHA256>(Constants.Unicode).ToBase64();

            Assert.NotNull(HashUTF8);
            Assert.NotNull(HashUnicode);
            Assert.Equal(Constants.HashSHA256_Base64_UTF8, HashUTF8);
            Assert.Equal(Constants.HashSHA256_Base64_Unicode, HashUnicode);
        }
    }
}
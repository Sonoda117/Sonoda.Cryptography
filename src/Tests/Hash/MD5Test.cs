using Sonoda.Cryptography;
using System.Security.Cryptography;
using Xunit;

namespace Tests.Hash
{
    public class MD5Test
    {
        [Fact]
        public void HashBytes()
        {
            var BytesUTF8 = Constants.SampleText.Hash<MD5>();
            var BytesUnicode = Constants.SampleText.Hash<MD5>(Constants.Unicode);

            Assert.NotEmpty(BytesUTF8);
            Assert.NotEmpty(BytesUnicode);
            Assert.True(BytesUTF8.Length == 16);
            Assert.True(BytesUnicode.Length == 16);
            Assert.NotEqual(BytesUTF8, BytesUnicode);
        }

        [Fact]
        public void HashHexRepresentation()
        {
            var HashUTF8 = Constants.SampleText.Hash<MD5>().ToHex();
            var HashUnicode = Constants.SampleText.Hash<MD5>(Constants.Unicode).ToHex();

            Assert.NotNull(HashUTF8);
            Assert.NotNull(HashUnicode);
            Assert.Equal(Constants.HashMD5_Hex_UTF8, HashUTF8);
            Assert.Equal(Constants.HashMD5_Hex_Unicode, HashUnicode);
        }

        [Fact]
        public void HashBase64Representation()
        {
            var HashUTF8 = Constants.SampleText.Hash<MD5>().ToBase64();
            var HashUnicode = Constants.SampleText.Hash<MD5>(Constants.Unicode).ToBase64();

            Assert.NotNull(HashUTF8);
            Assert.NotNull(HashUnicode);
            Assert.Equal(Constants.HashMD5_Base64_UTF8, HashUTF8);
            Assert.Equal(Constants.HashMD5_Base64_Unicode, HashUnicode);
        }
    }
}
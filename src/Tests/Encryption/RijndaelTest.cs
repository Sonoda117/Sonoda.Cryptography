using Sonoda.Cryptography;
using System.Security.Cryptography;
using Xunit;

namespace Tests.Encryption
{
    public class RijndaelTest
    {
        [Fact]
        public void CipheredBytes()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.UTF8);
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.Unicode);

            Assert.NotEmpty(EncryptedUTF8);
            Assert.NotEmpty(EncryptedUnicode);
            Assert.True(EncryptedUTF8.Length == 48);
            Assert.True(EncryptedUnicode.Length == 80);
            Assert.NotEqual(EncryptedUTF8, EncryptedUnicode);
        }

        [Fact]
        public void HexEncryption()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.UTF8).ToHex();
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.Unicode).ToHex();

            Assert.NotNull(EncryptedUTF8);
            Assert.NotNull(EncryptedUnicode);
            Assert.Equal(Constants.OutRijndael_Hex_UTF8, EncryptedUTF8);
            Assert.Equal(Constants.OutRijndael_Hex_Unicode, EncryptedUnicode);
        }

        [Fact]
        public void Base64Encryption()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.UTF8).ToBase64();
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<Rijndael>(Constants.Key, Constants.IV, Constants.Unicode).ToBase64();

            Assert.NotNull(EncryptedUTF8);
            Assert.NotNull(EncryptedUnicode);
            Assert.Equal(Constants.OutRijndael_Base64_UTF8, EncryptedUTF8);
            Assert.Equal(Constants.OutRijndael_Base64_Unicode, EncryptedUnicode);
        }

        [Fact]
        public void HexDecryption()
        {
            var DecryptedUTF8 = Constants.OutRijndael_Hex_UTF8.DecryptSymmetric<Rijndael>(Constants.Key, Constants.IV).ToString(Constants.UTF8);
            var DecryptedUnicode = Constants.OutRijndael_Hex_Unicode.DecryptSymmetric<Rijndael>(Constants.Key, Constants.IV).ToString(Constants.Unicode);

            Assert.NotNull(DecryptedUTF8);
            Assert.NotNull(DecryptedUnicode);
            Assert.Equal(Constants.SampleText, DecryptedUTF8);
            Assert.Equal(Constants.SampleText, DecryptedUnicode);
        }

        [Fact]
        public void Base64Decryption()
        {
            var DecryptedUTF8 = Constants.OutRijndael_Base64_UTF8.DecryptSymmetric<Rijndael>(Constants.Key, Constants.IV).ToString(Constants.UTF8);
            var DecryptedUnicode = Constants.OutRijndael_Base64_Unicode.DecryptSymmetric<Rijndael>(Constants.Key, Constants.IV).ToString(Constants.Unicode);

            Assert.NotNull(DecryptedUTF8);
            Assert.NotNull(DecryptedUnicode);
            Assert.Equal(Constants.SampleText, DecryptedUTF8);
            Assert.Equal(Constants.SampleText, DecryptedUnicode);
        }
    }
}
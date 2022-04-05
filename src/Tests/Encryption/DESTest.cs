using Sonoda.Cryptography;
using System.Security.Cryptography;
using Xunit;

namespace Tests.Encryption
{
    public class DESTest
    {
        [Fact]
        public void CipheredBytes()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.UTF8);
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.Unicode);

            Assert.NotEmpty(EncryptedUTF8);
            Assert.NotEmpty(EncryptedUnicode);
            Assert.True(EncryptedUTF8.Length == 40);
            Assert.True(EncryptedUnicode.Length == 72);
            Assert.NotEqual(EncryptedUTF8, EncryptedUnicode);
        }

        [Fact]
        public void HexEncryption()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.UTF8).ToHex();
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.Unicode).ToHex();

            Assert.NotNull(EncryptedUTF8);
            Assert.NotNull(EncryptedUnicode);
            Assert.Equal(Constants.OutDES_Hex_UTF8, EncryptedUTF8);
            Assert.Equal(Constants.OutDES_Hex_Unicode, EncryptedUnicode);
        }

        [Fact]
        public void Base64Encryption()
        {
            var EncryptedUTF8 = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.UTF8).ToBase64();
            var EncryptedUnicode = Constants.SampleText.EncryptSymmetric<DES>(Constants.Key, Constants.IV, Constants.Unicode).ToBase64();

            Assert.NotNull(EncryptedUTF8);
            Assert.NotNull(EncryptedUnicode);
            Assert.Equal(Constants.OutDES_Base64_UTF8, EncryptedUTF8);
            Assert.Equal(Constants.OutDES_Base64_Unicode, EncryptedUnicode);
        }

        [Fact]
        public void HexDecryption()
        {
            var DecryptedUTF8 = Constants.OutDES_Hex_UTF8.DecryptSymmetric<DES>(Constants.Key, Constants.IV).ToString(Constants.UTF8);
            var DecryptedUnicode = Constants.OutDES_Hex_Unicode.DecryptSymmetric<DES>(Constants.Key, Constants.IV).ToString(Constants.Unicode);

            Assert.NotNull(DecryptedUTF8);
            Assert.NotNull(DecryptedUnicode);
            Assert.Equal(Constants.SampleText, DecryptedUTF8);
            Assert.Equal(Constants.SampleText, DecryptedUnicode);
        }

        [Fact]
        public void Base64Decryption()
        {
            var DecryptedUTF8 = Constants.OutDES_Base64_UTF8.DecryptSymmetric<DES>(Constants.Key, Constants.IV).ToString(Constants.UTF8);
            var DecryptedUnicode = Constants.OutDES_Base64_Unicode.DecryptSymmetric<DES>(Constants.Key, Constants.IV).ToString(Constants.Unicode);

            Assert.NotNull(DecryptedUTF8);
            Assert.NotNull(DecryptedUnicode);
            Assert.Equal(Constants.SampleText, DecryptedUTF8);
            Assert.Equal(Constants.SampleText, DecryptedUnicode);
        }
    }
}
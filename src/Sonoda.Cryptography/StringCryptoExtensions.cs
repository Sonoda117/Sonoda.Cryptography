using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Sonoda.Cryptography
{
    public static class StringCryptoExtensions
    {
        public static byte[] EncryptSymmetric<T>(this string Value, byte[] Key, byte[] IV, Encoding Encoding) where T : SymmetricAlgorithm
        {
            using var Crypto = CreateSymmetricCrypto<T>(Key, IV);
            var Bytes = Encoding.GetBytes(Value);

            using var MStream = new MemoryStream();
            using var CStream = new CryptoStream(MStream, Crypto.CreateEncryptor(), CryptoStreamMode.Write);
            CStream.Write(Bytes);
            CStream.Dispose();

            return MStream.ToArray();
        }
        public static byte[] DecryptSymmetric<T>(this string Value, byte[] Key, byte[] IV) where T : SymmetricAlgorithm
        {
            byte[] Bytes;

            if (IsHex(Value))
                Bytes = HexToBytes(Value);
            else if (IsBase64(Value))
                Bytes = Convert.FromBase64String(Value);
            else
                throw new FormatException("String isn't Base64 nor Hex");

            using var Crypto = CreateSymmetricCrypto<T>(Key, IV);

            using var MStream = new MemoryStream();
            using var CStream = new CryptoStream(MStream, Crypto.CreateDecryptor(), CryptoStreamMode.Write);
            CStream.Write(Bytes);
            CStream.Dispose();

            return MStream.ToArray();
        }

        private static bool IsBase64(string Value)
        {
            try
            {
                Convert.FromBase64String(Value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool IsHex(string Value)
        {
            bool IsHex;

            foreach (var C in Value)
            {
                IsHex = (C >= '0' && C <= '9') || (C >= 'a' && C <= 'f') || (C >= 'A' && C <= 'F');

                if (!IsHex)
                    return false;
            }

            return Value.Length % 2 == 0;
        }
        private static byte[] HexToBytes(string Value)
        {
            var TotalChars = Value.Length;
            var Bytes = new byte[TotalChars / 2];

            for (int i = 0; i < TotalChars; i += 2)
                Bytes[i / 2] = Convert.ToByte(Value.Substring(i, 2), 16);

            return Bytes;
        }
        private static SymmetricAlgorithm CreateSymmetricCrypto<T>(byte[] Key, byte[] IV) where T : SymmetricAlgorithm
        {
            var Crypto = SymmetricAlgorithm.Create(typeof(T).Name) ?? throw new NotImplementedException();

            int IVLenght = Crypto.IV.Length;
            int KeyLenght = Crypto.Key.Length;

            if (Key?.Length < KeyLenght)
                throw new ArgumentException($"Key Lenght (Current: {Key?.Length ?? 0}, Required: {KeyLenght})");

            if (IV?.Length < Crypto.IV.Length)
                throw new ArgumentException($"IV Lenght (Current: {IV?.Length ?? 0}, Required: {IVLenght}");

            Crypto.IV = IV.Take(IVLenght).ToArray();
            Crypto.Key = Key.Take(KeyLenght).ToArray();

            return Crypto;
        }
    }
}
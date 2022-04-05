using System;
using System.Security.Cryptography;
using System.Text;

namespace Sonoda.Cryptography
{
    public static class StringHashExtensions
    {
        public static byte[] Hash<T>(this string Value) where T : HashAlgorithm
        {
            return Value.Hash<T>(Encoding.UTF8);
        }
        public static byte[] Hash<T>(this string Value, Encoding Encoding) where T : HashAlgorithm
        {
            using var Algorithm = HashAlgorithm.Create(typeof(T).Name) ?? throw new NotImplementedException();
            var Bytes = Encoding.GetBytes(Value);

            return Algorithm.ComputeHash(Bytes);
        }
    }
}
using System;
using System.Text;

namespace Sonoda.Cryptography
{
    public static class ByteExtensions
    {
        public static string ToBase64(this byte[] Value) => Convert.ToBase64String(Value);
        public static string ToHex(this byte[] Value) => BitConverter.ToString(Value).Replace("-", "");
        public static string ToString(this byte[] Value, Encoding Encoding) => Encoding.GetString(Value);
    }
}
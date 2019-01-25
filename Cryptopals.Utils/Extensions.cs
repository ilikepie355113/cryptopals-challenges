using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptopals.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a string in hexadecimal format into a byte array
        /// </summary>
        /// <returns>A byte array containing the integer values represented by the hex string</returns>
        /// <exception cref="System.FormatException">Thrown when string is not in hexadecimal format, or when
        /// string is not even in length</exception>
        public static byte[] HexToBytes(this string hex)
        {
            if (Regex.IsMatch(hex, "[^a-f0-9]")) throw new FormatException("Not a valid hexidecimal string!");
            if (hex.Length % 2 != 0) throw new FormatException("Hex string must be of even length!");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }

        /// <summary>
        /// Converts a string to a byte array using ASCII values
        /// </summary>
        public static byte[] ToByteArray(this string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }

        /// <summary>
        /// Converts a byte array into its hexadecimal string representation 
        /// </summary>
        /// <returns>String in hexadecimal format</returns>
        public static string ToHexString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts a byte array to an ASCII string
        /// </summary>>
        public static string ToASCIIString(this byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Performs logical XOR on byte array with another byte array.
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2">Byte array to XOR with</param>
        /// <returns>Byte array containing the result of the XOR operation</returns>
        /// <exception cref="System.ArgumentException">Thrown when arrays are not equal in size</exception>
        public static byte[] XorWith(this byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length) throw new ArgumentException("Arrays must be of equal length!");

            byte[] xored = new byte[b1.Length];

            for (int i = 0; i < xored.Length; i++)
            {
                xored[i] = (byte)(b1[i] ^ b2[i]);
            }

            return xored;
        }
    }
}

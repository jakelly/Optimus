using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Optimus
{
    /// <summary>
    /// Helpful Extensions
    /// </summary>
    static class Extensions
    {
        /// <summary>
        /// Safe name for a file.
        /// </summary>
        /// <remarks>Borrowed from Stack Overflow: http://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c </remarks>
        /// <param name="phrase">The phrase to sluggify.</param>
        /// <returns>A "slug" keyword safe to save for a file.</returns>
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        /// <summary>
        /// Removes accents from characters in a string.
        /// </summary>
        /// <remarks>Came along with the GenerateSlug method</remarks>
        /// <param name="txt">Text to be evaluated for accented characters</param>
        /// <returns>A string without accented characters.</returns>
        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }


        /// <summary>
        /// Generates a 64 bit unsigned numbers between min and max.
        /// </summary>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        /// <param name="rand">random object</param>
        /// <returns></returns>
        public static ulong Next(this Random rand, ulong min, ulong max)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            ulong longRand = BitConverter.ToUInt64(buf, 0);
            return (longRand % (max - min) + min);
        }
    }
}

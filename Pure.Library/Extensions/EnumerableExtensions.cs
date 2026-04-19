using System.Text;

namespace Pure.Library.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Attempts to convert the value to a string
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <returns>The value as a string</returns>
        public static string ConvertToString(this byte[] value) => Encoding.UTF8.GetString(value);
    }
}

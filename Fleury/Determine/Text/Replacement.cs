using System.IO;

namespace Fleury.Determine.Text
{
    public static partial class StringExtensions
    {
        #region Replacement

        /// <summary>
        /// Normalize specific path string to suit for current operating system
        /// <example>eg. a/b/d/d -&gt; to windows a\b\c\d</example>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="basicSeparator">Original path separator</param>
        /// <returns></returns>
        public static string NormalizePath(this string source, char basicSeparator = '/')
        {
            var separator = Path.DirectorySeparatorChar;

            return source.Replace(basicSeparator, separator);
        }

        /// <summary>
        /// Clean specific string in source string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Empty(this string source, string target)
        {
            return source.Replace(target, string.Empty);
        }

        #endregion
    }
}
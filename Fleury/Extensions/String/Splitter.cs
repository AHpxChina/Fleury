using System;
using Fleury.Data.Exceptions.String;

namespace Fleury.Extensions.String
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Sub string after specific string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="after">After what</param>
        /// <param name="include">Include incoming <paramref name="after"/> value or not</param>
        /// <returns></returns>
        public static string SubStringAfter(this string source, string after, bool include = true)
        {
            if (!source.Contains(after))
                throw new NoSuchStringException($"Target: {after}");
            
            var re = source[source.IndexOf(after, StringComparison.Ordinal)..];
            return include
                ? re
                : re.Empty(after);
        }

        /// <summary>
        /// Sub string after specific string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="after">After what</param>
        /// <param name="count">Length shout be taken</param>
        /// <param name="include">Include incoming <paramref name="after"/> value or not</param>
        /// <returns></returns>
        public static string SubStringAfter(this string source, string after, int count, bool include = true)
        {
            if (!source.Contains(after))
                throw new NoSuchStringException($"Target: {after}");

            var index = source.IndexOf(after, StringComparison.Ordinal);

            if (count > source.Length || index + count >= source.Length)
                throw new ArgumentOutOfRangeException($"Specific count: {count} is too big for source");
            
            return include
                ? source.Substring(index, count)
                : source.Substring(index + 1, count);
        }
        
        /// <summary>
        /// Sub string after last specific string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="after">After what</param>
        /// <param name="include">Include incoming <paramref name="after"/> value or not</param>
        /// <returns></returns>
        public static string SubStringAfterLast(this string source, string after, bool include = true)
        {
            if (!source.Contains(after))
                throw new NoSuchStringException($"Target: {after}");

            var index = source.LastIndexOf(after, StringComparison.Ordinal);

            var re = source[index..];
            return include
                ? re
                : re.Empty(after);
        }

        /// <summary>
        /// Sub string after last specific string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="after">After what</param>
        /// <param name="count">Length shout be taken</param>
        /// <param name="include">Include incoming <paramref name="after"/> value or not</param>
        /// <returns></returns>
        public static string SubStringAfterLast(this string source, string after, int count, bool include = true)
        {
            if (!source.Contains(after))
                throw new NoSuchStringException($"Target: {after}");

            var index = source.LastIndexOf(after, StringComparison.Ordinal);

            if (count > source.Length || index + count >= source.Length)
                throw new ArgumentOutOfRangeException($"Specific count: {count} is too big for source");
            
            return include
                ? source.Substring(index, count)
                : source.Substring(index + 1, count);
        }

        public static string SubStringBefore(this string source, string before, bool include = true)
        {
            if (!source.Contains(before))
                throw new NoSuchStringException($"Target: {before}");

            var re = source[..source.IndexOf(before, StringComparison.Ordinal)];
            return include
                ? re
                : re.Empty(before);
        }
    }
}
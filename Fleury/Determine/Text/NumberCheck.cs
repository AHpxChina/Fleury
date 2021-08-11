using System;
using System.Linq;

namespace Fleury.Determine.Text
{
    public static partial class StringExtensions
    {
        #region Number check

        /// <summary>
        /// Determine if a string is int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInt(this string source)
        {
            return int.TryParse(source, out _);
        }

        /// <summary>
        /// Determine if a string is int
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output">Out parameter, if specific string is not an int, default value will be outputted</param>
        /// <returns></returns>
        public static bool IsInt(this string source, out int output)
        {
            return int.TryParse(source, out output);
        }

        /// <summary>
        /// Determine if a string is int or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int IsIntOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid int: {source}");

            if (!source.IsInt(out var re))
                throw exception;

            return re;
        }

        /// <summary>
        /// Determine if a string is long
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsLong(this string source)
        {
            return long.TryParse(source, out _);
        }

        /// <summary>
        /// Determine if a string is long
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output">Out parameter, if specific string is not a long, default value will be outputted</param>
        /// <returns></returns>
        public static bool IsLong(this string source, out long output)
        {
            return long.TryParse(source, out output);
        }

        /// <summary>
        /// Determine if a string is long or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static long IsLongOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid long: {source}");

            if (!source.IsLong(out var re))
                throw exception;

            return re;
        }

        /// <summary>
        /// Determine if a string is integer char-by-char, no size limited
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInteger(this string source)
        {
            if (source.StartsWith('-'))
                source = source.TrimStart('-');

            return source.ToCharArray().All(char.IsNumber);
        }

        /// <summary>
        /// Determine if a string is integer or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsIntegerOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid integer: {source}");

            if (!source.IsInteger())
                throw exception;

            return source;
        }

        #endregion
    }
}
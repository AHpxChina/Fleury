using System;

namespace Fleury.Extensions.String
{
    public static partial class StringExtensions
    {
        #region Empty check

        /// <summary>
        /// Determine if a string is empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whiteSpace">Consider whitespace as empty or not</param>
        /// <returns></returns>
        public static bool IsEmpty(this string source, bool whiteSpace = true)
        {
            return whiteSpace
                ? string.IsNullOrWhiteSpace(source)
                : string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// Determine if a string is not empty
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whiteSpace">Consider whitespace as empty or not</param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string source, bool whiteSpace = true)
        {
            return !source.IsEmpty(whiteSpace);
        }

        /// <summary>
        /// Determine if a string is empty or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whiteSpace">Consider whitespace as empty or not</param>
        /// <param name="exception">Exception instance for throwing, optional</param>
        /// <returns>If incoming string is not empty, source value will be returned</returns>
        /// <exception cref="Exception"></exception>
        public static string IsEmptyOrThrow(this string source, bool whiteSpace = true, Exception exception = null)
        {
            exception ??= new Exception($"Empty value: \"{source}\" of parameter: {nameof(source)}");

            if (source.IsEmpty(whiteSpace))
                throw exception;

            return source;
        }

        /// <summary>
        /// Determine if a string is not empty or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="whiteSpace">Consider whitespace as empty or not</param>
        /// <param name="exception">Exception instance for throwing, optional</param>
        /// <returns>If incoming string is empty, source value will be returned</returns>
        /// <exception cref="Exception"></exception>
        public static string IsNotEmptyOrThrow(this string source, bool whiteSpace = true, Exception exception = null)
        {
            exception ??= new Exception($"Empty value: \"{source}\" of parameter: {nameof(source)}");

            if (source.IsNotEmpty(whiteSpace))
                throw exception;

            return source;
        }

        #endregion
    }
}
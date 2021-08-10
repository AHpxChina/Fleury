using System;
using System.Linq;

namespace Fleury.Determine.Text
{
    public static class StringExtensions
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

        #endregion
    }
}
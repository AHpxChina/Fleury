using System;
using System.IO;
using System.Linq;
using System.Net;

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

        #region IP check

        /// <summary>
        /// Determine if a string is valid ipv4 or ipv6 address
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string source)
        {
            return IPAddress.TryParse(source, out _);
        }

        /// <summary>
        /// Determine if a string is valid ipv4 or ipv6 address
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ipAddress">Out parameter</param>
        /// <returns></returns>
        public static bool IsIpAddress(this string source, out IPAddress ipAddress)
        {
            return IPAddress.TryParse(source, out ipAddress);
        }
        
        /// <summary>
        /// Determine if a string is ip address or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IPAddress IsIpAddressOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid ip address: {source}");

            if (!source.IsIpAddress(out var re))
                throw exception;

            return re;
        }

        /// <summary>
        /// Determine a string is valid host
        /// <example>localhost:8080 will be true</example>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsHost(this string source)
        {
            var split = source.Split(":");

            if (split.Length != 2)
                return false;

            if (split[0].Contains('.'))
                return split[0].IsIpAddress() && split[1].IsInt();

            return split[1].IsInt();
        }
        
        /// <summary>
        /// Determine if a string is host or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsHostOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid host: {source}");

            if (!source.IsHost())
                throw exception;

            return source;
        }
        
        #endregion
    }
}
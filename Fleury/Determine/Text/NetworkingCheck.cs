using System;
using System.Net;

namespace Fleury.Determine.Text
{
    public static partial class StringExtensions
    {
        #region Networking check

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

        /// <summary>
        /// Determine if a string is valid absolute url format
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsUrl(this string source)
        {
            return Uri.IsWellFormedUriString(source, UriKind.Absolute);
        }

        /// <summary>
        /// Determine if a string is valid absolute url format or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsUrlOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid url: {source}");

            if (!source.IsUrl())
                throw exception;

            return source;
        }

        #endregion
    }
}
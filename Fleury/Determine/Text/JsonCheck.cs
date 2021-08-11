using System;
using Newtonsoft.Json.Linq;

namespace Fleury.Determine.Text
{
    public static partial class StringExtensions
    {
        #region Json checker
        
        /// <summary>
        /// Determine if a string is valid json(JToken)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsJson(this string source)
        {
            try
            {
                _ = JToken.Parse(source);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determine if a string is valid json(JToken) or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string IsJsonOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a valid json: {source}");

            if (!source.IsJson())
                throw exception;

            return source;
        }

        /// <summary>
        /// Determine if a string is valid JObject
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsJObject(this string source)
        {
            try
            {
                _ = JObject.Parse(source);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determine if a string is valid JObject
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool IsJObject(this string source, out JObject output)
        {
            try
            {
                output = JObject.Parse(source);

                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }

        /// <summary>
        /// Determine if a string is valid JObject or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JObject IsJObjectOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a JObject: {source}");

            if (!source.IsJObject(out var re))
                throw exception;

            return re;
        }
        
        /// <summary>
        /// Determine if a string is valid JObject
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsJArray(this string source)
        {
            try
            {
                _ = JArray.Parse(source);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determine if a string is valid JObject
        /// </summary>
        /// <param name="source"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool IsJArray(this string source, out JArray output)
        {
            try
            {
                output = JArray.Parse(source);

                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }

        /// <summary>
        /// Determine if a string is valid JArray or throw exception
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception">Exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JArray IsJArrayOrThrow(this string source, Exception exception = null)
        {
            exception ??= new Exception($"Not a JArray: {source}");

            if (!source.IsJArray(out var re))
                throw exception;

            return re;
        }
        
        #endregion
    }
}
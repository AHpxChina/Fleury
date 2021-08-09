using System;
using Fleury.Data.Determine;

namespace Fleury.Determine.Text
{
    /// <summary>
    /// Encapsulation of extension methods for string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check if a string is empty
        /// </summary>
        /// <param name="origin">originate</param>
        /// <param name="whiteSpace">whether to consider white space as empty</param>
        /// <returns></returns>
        public static Condition<bool, string> Empty(this Condition<string, string> origin, bool whiteSpace = true)
        {
            return whiteSpace
                ? new Condition<bool, string>(string.IsNullOrWhiteSpace(origin.Value), origin.Value)
                : new Condition<bool, string>(string.IsNullOrEmpty(origin.Value), origin.Value);
        }
        
        /// <summary>
        /// Check if a string is empty
        /// </summary>
        /// <param name="origin">originate</param>
        /// <param name="whiteSpace">whether to consider white space as empty</param>
        /// <returns></returns>
        public static Condition<bool, string> Empty(this Condition<bool, string> origin, bool whiteSpace = true)
        {
            return whiteSpace
                ? new Condition<bool, string>(string.IsNullOrWhiteSpace(origin.Last), origin.Last)
                : new Condition<bool, string>(string.IsNullOrEmpty(origin.Last), origin.Last);
        }
        
        /// <summary>
        /// Check if a string is empty
        /// </summary>
        /// <param name="origin">originate</param>
        /// <param name="whiteSpace">whether to consider white space as empty</param>
        /// <returns></returns>
        public static bool IsEmpty(this string origin, bool whiteSpace = true)
        {
            return origin.Is().Empty(whiteSpace).Value;
        }
        
        /// <summary>
        /// Check if a string is not empty
        /// </summary>
        /// <param name="origin">originate</param>
        /// <param name="whiteSpace">whether to consider white space as empty</param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string origin, bool whiteSpace = true)
        {
            return !origin.Is().Empty(whiteSpace).Value;
        }
        
        /// <summary>
        /// If the value of incoming originate is true, exception will be thrown
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="exception">exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Throw(this Condition<bool, string> origin, Exception exception)
        {
            if (origin.Value)
                throw exception;

            return origin.Last;
        }

        /// <summary>
        /// If the result of specific predicate is true, exception will be thrown
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="predicate">pass in originate</param>
        /// <param name="exception">exception for throwing</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string ThrowIf(this string origin,
            Predicate<string> predicate, Exception exception)
        {
            if (predicate.Invoke(origin))
                throw exception;

            return origin;
        }
    }
}
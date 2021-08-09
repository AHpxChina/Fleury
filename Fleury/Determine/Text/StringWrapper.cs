using Fleury.Data.Determine;

namespace Fleury.Determine.Text
{
    /// <summary>
    /// Encapsulation of extension methods for string
    /// </summary>
    public static class StringWrapper
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
    }
}
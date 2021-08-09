namespace Fleury.Determine.Text
{
    public static class StringExtensions
    {
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
    }
}
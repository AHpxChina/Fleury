# Fleury

The design document of Fleury

## Data

+ Exceptions
    + String
        + NoSuchStringException

## Extensions

+ String

    + StringExtensions

        + EmptyCheck

            + ```c#
        bool IsEmpty(this string source, bool whiteSpace = true)
        ```

            + ```c#
        bool IsNotEmpty(this string source, bool whiteSpace = true)
        ```

            + ```c#
        string IsEmptyOrThrow(this string source, bool whiteSpace = true, Exception exception = null)
        ```

            + ```c#
        string IsNotEmptyOrThrow(this string source, bool whiteSpace = true, Exception exception = null)
        ```

        + JsonCheck

            + ```c#
        bool IsJson(this string source)
        ```

            + ```c#
        string IsJsonOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsJObject(this string source)
        ```

            + ```c#
        bool IsJObject(this string source, out JObject output)
        ```

            + ```c#
        JObject IsJObjectOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsJArray(this string source)
        ```

            + ```c#
        bool IsJArray(this string source, out JArray output)
        ```

            + ```c#
        JArray IsJArrayOrThrow(this string source, Exception exception = null)
        ```

        + NetworkingCheck

            + ```c#
        bool IsIpAddress(this string source)
        ```

            + ```c#
        bool IsIpAddress(this string source, out IPAddress ipAddress)
        ```

            + ```c#
        IPAddress IsIpAddressOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsHost(this string source)
        ```

            + ```c#
        string IsHostOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsUrl(this string source)
        ```

            + ```c#
        string IsUrlOrThrow(this string source, Exception exception = null)
        ```

        + NumberCheck

            + ```c#
        bool IsInt(this string source)
        ```

            + ```c#
        bool IsInt(this string source, out int output)
        ```

            + ```c#
        int IsIntOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsLong(this string source)
        ```

            + ```c#
        bool IsLong(this string source, out long output)
        ```

            + ```c#
        long IsLongOrThrow(this string source, Exception exception = null)
        ```

            + ```c#
        bool IsInteger(this string source)
        ```

            + ```c#
        string IsIntegerOrThrow(this string source, Exception exception = null)
        ```

        + Replacement

            + ```c#
        string NormalizePath(this string source, char basicSeparator = '/')
        ```

            + ```c#
        string Empty(this string source, string target)
        ```

        + Splitter

            + ```c#
        string SubStringAfter(this string source, string after, bool include = true)
        ```

            + ```c#
        string SubStringAfter(this string source, string after, int count, bool include = true)
        ```

            + ```c#
        string SubStringAfterLast(this string source, string after, bool include = true)
        ```

            + ```c#
        string SubStringAfterLast(this string source, string after, int count, bool include = true)
        ```

            + 


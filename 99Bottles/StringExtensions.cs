using System.Collections.Generic;

namespace _99Bottles;

public static class StringExtensions
{
    public static string Join(
        this IEnumerable<string> source,
        string separator)
    {
        return string.Join(separator: separator, values: source);
    }
}

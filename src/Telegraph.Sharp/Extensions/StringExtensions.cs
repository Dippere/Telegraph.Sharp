using System;

namespace Telegraph.Sharp.Extensions;

internal static class StringExtensions
{
    public static string CapitalizeFirstLetter(this string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("There is no first letter");
#if NET6_0_OR_GREATER
        return string.Create(s.Length, s, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars[0] = char.ToUpper(chars[0]);
        });
#else
        return char.ToUpper(s[0]) + s.Substring(1);
#endif
    }

    public static string MinimizeFirstLetter(this string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("There is no first letter");
#if NET6_0_OR_GREATER
        return string.Create(s.Length, s, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars[0] = char.ToLower(chars[0]);
        });
#else
        return char.ToLower(s[0]) + s.Substring(1);
#endif
    }
}

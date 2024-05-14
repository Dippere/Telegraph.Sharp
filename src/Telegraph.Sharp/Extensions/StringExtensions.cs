using System;

namespace Telegraph.Sharp.Extensions;

internal static class StringExtensions
{
    public static string CapitalizeFirstLetter(this string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("There is no first letter");
        return string.Create(s.Length, s, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars[0] = char.ToUpper(chars[0]);
        });
    }

    public static string MinimizeFirstLetter(this string s)
    {
        if (string.IsNullOrEmpty(s))
            throw new ArgumentException("There is no first letter");
        return string.Create(s.Length, s, (chars, state) =>
        {
            state.AsSpan().CopyTo(chars);
            chars[0] = char.ToLower(chars[0]);
        });
    }
}

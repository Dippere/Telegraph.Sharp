using System.Text.RegularExpressions;

namespace Telegraph.Sharp.Extensions;

internal static partial class RegexExtensions
{
    [GeneratedRegex("(http(s)?://)?(?<resource>(youtube\\.com)|(youtu\\.be)|(twitter\\.com)|(vimeo\\.com))(/.*)?")]
    public static partial Regex LinkRegex();
}

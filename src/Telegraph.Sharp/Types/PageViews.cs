using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents the number of page views for a Telegraph article.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PageViews
{
    /// <summary>
    ///     Number of page views for the target page.
    /// </summary>
    [JsonProperty]
    public int Views { get; set; }
}
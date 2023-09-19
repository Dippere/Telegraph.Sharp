using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     Attributes of the DOM element. Key of object represents name of attribute, value represents value of attribute.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class TagAttributes
{
    private string? _src;

    
    /// <summary>
    /// Link value.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Href { get; set; }

    /// <summary>
    /// Source value.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Src
    {
        get => _src;
        set => _src = value is null ? null :
            value.StartsWith(Constants.Telegpaph) ? value.Substring(Constants.Telegpaph.Length) : value;
    }
}
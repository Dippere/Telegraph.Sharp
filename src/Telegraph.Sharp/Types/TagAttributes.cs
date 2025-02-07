using System.Text.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     Attributes of the DOM element. Key of object represents name of attribute, value represents value of attribute.
/// </summary>
public class TagAttributes
{
    private readonly string? _src;

    /// <summary>
    ///     Link value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Href { get; init; }

    /// <summary>
    ///     Source value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Src
    {
        get => _src;
        init => _src = value is null ? null :
            value.StartsWith(Constants.TelegpaphUrl) ? value.Substring(Constants.TelegpaphUrl.Length) : value;
    }
}

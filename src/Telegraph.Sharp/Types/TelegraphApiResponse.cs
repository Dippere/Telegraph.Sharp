using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
/// Represents a API response result.
/// </summary>
/// <typeparam name="T">Expected type of operation result.</typeparam>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class TelegraphApiResponse<T>
{
    /// <summary>
    /// Gets a value indicating whether the request was successful.
    /// </summary>
    [JsonProperty] 
    public bool Ok { get; set; }

    /// <summary>
    /// Gets the result object.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public T? Result { get; set; }

    /// <summary>
    /// Contains information about why a request was unsuccessful.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? Error { get; set; }
}
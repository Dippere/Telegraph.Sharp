using System.Text.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     Represents a API response result.
/// </summary>
/// <typeparam name="T">Expected type of operation result.</typeparam>
public class TelegraphApiResponse<T>
{
    /// <summary>
    ///     Gets a value indicating whether the request was successful.
    /// </summary>
    public bool Ok { get; set; }

    /// <summary>
    ///     Gets the result object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Result { get; set; }

    /// <summary>
    ///     Contains information about why a request was unsuccessful.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Error { get; set; }
}

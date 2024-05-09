using System.Text.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
/// This object represents the file uploaded to Telegraph.
/// </summary>
public class TelegraphFile
{
    /// <summary>
    /// Creates an instance of <see cref="TelegraphFile"/> from provided source.
    /// </summary>
    /// <param name="src">Source value.</param>
    public TelegraphFile(string src)
    {
        Src = src;
        Url = Constants.Telegpaph + Src;
    }

    /// <summary>
    /// Soucre value.
    /// </summary>
    public string Src { get; }


    /// <summary>
    /// Link value.
    /// </summary>
    [JsonIgnore]
    public string Url { get; }
}
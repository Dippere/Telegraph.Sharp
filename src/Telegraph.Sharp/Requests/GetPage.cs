using System.Text.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to get a Telegraph page.
///     Returns a <see cref="Page" /> object on success.
/// </summary>
public class GetPage : ApiRequestBase<Page>
{
    /// <summary>
    ///     Initializes a new request with path.
    /// </summary>
    /// <param name="path">
    ///     Path to the Telegraph page (in the format Title-12-31, i.e. everything that comes after
    ///     http://telegra.ph/).
    /// </param>
    public GetPage(string path) : base("getPage") => Path = path;

    /// <summary>
    ///     Required. Path to the Telegraph page (in the format Title-12-31, i.e. everything that comes after
    ///     http://telegra.ph/).
    /// </summary>
    public string Path { get; init; }

    /// <summary>
    ///     If <see langword="true" />, content field will be returned in Page object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReturnContent { get; set; }
}

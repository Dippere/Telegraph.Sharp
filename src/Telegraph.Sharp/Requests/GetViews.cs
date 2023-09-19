using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to get the number of views for a Telegraph article.
///     Returns a <see cref="PageViews" /> object on success.
///     By default, the total number of page views will be returned.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class GetViews : ApiRequestBase<PageViews>
{
    /// <summary>
    ///     Initializes a new request with path.
    /// </summary>
    /// <param name="path">
    ///     Path to the Telegraph page (in the format Title-12-31, where 12 is the month and 31 the day the article was first
    ///     published).
    /// </param>
    public GetViews(string path) : base("getViews") => Path = path;

    /// <summary>
    ///     Required. Path to the Telegraph page (in the format Title-12-31, where 12 is the month and 31 the day the article
    ///     was first published).
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Path { get; set; }

    /// <summary>
    ///     Required if month is passed. If passed, the number of page views for the requested year will be returned.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Year { get; set; }

    /// <summary>
    ///     Required if day is passed. If passed, the number of page views for the requested month will be returned.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Month { get; set; }

    /// <summary>
    ///     Required if hour is passed. If passed, the number of page views for the requested day will be returned.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Day { get; set; }

    /// <summary>
    ///     If passed, the number of page views for the requested hour will be returned.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int? Hour { get; set; }
}
using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to get a list of pages belonging to a Telegraph account.
///     Returns a <see cref="PageList" /> object, sorted by most recently created pages first.
/// </summary>
public class GetPageList : ApiRequestBase<PageList>, IAccessTokenTarget
{
    /// <summary>
    ///     Initializes a new request with accessToken.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    public GetPageList(string accessToken) : base("getPageList") => AccessToken = accessToken;

    /// <summary>
    ///     Sequential number of the first page to be returned.
    /// </summary>
    [JsonInclude]
    public int Offset { get; set; }

    /// <summary>
    ///     Limits the number of pages to be retrieved.
    /// </summary>
    [JsonInclude]
    public int Limit { get; set; }

    /// <summary>
    ///     Required. Access token of the Telegraph account.
    /// </summary>
    public string AccessToken { get; init; }
}
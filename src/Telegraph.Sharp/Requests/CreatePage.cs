using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to create a new Telegraph page.
///     On success, returns a <see cref="Page" /> object.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreatePage : ApiRequestBase<Page>, IAccessTokenTarget
{
    /// <summary>
    ///     Initializes a new request with accessToken, title and content.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    /// <param name="title">Page title.</param>
    /// <param name="content">Content of the page.</param>
    public CreatePage(string accessToken, string title, List<Node> content) : this("createPage", accessToken, title,
        content)
    {
    }

    /// <summary>
    ///     Initializes a new request with methodName, accessToken, title and content.
    /// </summary>
    /// <param name="methodName">Method name.</param>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    /// <param name="title">Page title.</param>
    /// <param name="content">Content of the page.</param>
    protected CreatePage(string methodName, string accessToken, string title, List<Node> content) : base(methodName) =>
        (AccessToken, Title, Content) = (accessToken, title, content);

    /// <summary>
    ///     Required. Page title.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Title { get; }

    /// <summary>
    ///     Author name, displayed below the article's title.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorName { get; set; }

    /// <summary>
    ///     Profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorUrl { get; set; }

    /// <summary>
    ///     Required. Content of the page.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public List<Node> Content { get; }

    /// <summary>
    ///     If <see langword= "true"/>, a content field will be returned in the Page object.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool ReturnContent { get; set; }

    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public string AccessToken { get; }
}
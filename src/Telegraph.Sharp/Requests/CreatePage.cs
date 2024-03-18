using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to create a new Telegraph page.
///     On success, returns a <see cref="Page" /> object.
/// </summary>
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
    public string Title { get; init; }

    /// <summary>
    ///     Author name, displayed below the article's title.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? AuthorName { get; set; }

    /// <summary>
    ///     Profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? AuthorUrl { get; set; }

    /// <summary>
    ///     Required. Content of the page.
    /// </summary>
    public List<Node> Content { get; init; }

    /// <summary>
    ///     If <see langword= "true"/>, a content field will be returned in the Page object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReturnContent { get; set; }

    /// <inheritdoc />
    public string AccessToken { get; init; }
}
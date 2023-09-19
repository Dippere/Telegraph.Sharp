using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to edit an existing Telegraph page.
///     On success, returns a <see cref="Page" /> object.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class EditPage : CreatePage
{
    /// <summary>
    ///     Initializes a new request with accessToken, path, title and content.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    /// <param name="path">Path to the page.</param>
    /// <param name="title">Page title.</param>
    /// <param name="content">Content of the page.</param>
    public EditPage(string accessToken, string path, string title, List<Node> content) : base("editPage", accessToken,
        title, content) =>
        Path = path;

    /// <summary>
    ///     Required. Path to the page.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Path { get; }
}
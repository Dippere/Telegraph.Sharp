using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a page on Telegraph.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Page
{
    /// <summary>
    ///     Path to the page.
    /// </summary>
    [JsonProperty]
    public string Path { get; set; } = null!;

    /// <summary>
    ///     URL of the page.
    /// </summary>
    [JsonProperty]
    public string Url { get; set; } = null!;

    /// <summary>
    ///     Title of the page.
    /// </summary>
    [JsonProperty]
    public string Title { get; set; } = null!;

    /// <summary>
    ///     Description of the page.
    /// </summary>
    [JsonProperty]
    public string Description { get; set; } = null!;

    /// <summary>
    ///     Name of the author, displayed below the title.
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
    ///     Image URL of the page.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? ImageUrl { get; set; }

    /// <summary>
    ///     Content of the page.
    /// </summary>
    [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<Node>? Content { get; set; }

    /// <summary>
    ///     Number of page views for the page.
    /// </summary>
    [JsonProperty]
    public int Views { get; set; }

    /// <summary>
    ///     Only returned if access token passed. True, if the target Telegraph account can edit the page.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? CanEdit { get; set; }
}
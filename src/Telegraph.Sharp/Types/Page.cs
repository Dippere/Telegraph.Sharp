using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a page on Telegraph.
/// </summary>
public class Page
{
    /// <summary>
    ///     Path to the page.
    /// </summary>
    public string Path { get; set; } = null!;

    /// <summary>
    ///     URL of the page.
    /// </summary>
    public string Url { get; set; } = null!;

    /// <summary>
    ///     Title of the page.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    ///     Description of the page.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    ///     Name of the author, displayed below the title.
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
    ///     Image URL of the page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ImageUrl { get; set; }

    /// <summary>
    ///     Content of the page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Node>? Content { get; set; }

    /// <summary>
    ///     Number of page views for the page.
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    ///     Only returned if access token passed. True, if the target Telegraph account can edit the page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool? CanEdit { get; set; }
}
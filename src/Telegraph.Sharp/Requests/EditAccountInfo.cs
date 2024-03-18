using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to update information about a Telegraph account.
///     Pass only the parameters that you want to edit.
///     On success, returns an <see cref="Account" /> object with the default fields.
/// </summary>
public class EditAccountInfo : ApiRequestBase<Account>, IAccessTokenTarget
{
    /// <summary>
    ///     Initializes a new request with accessToken.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    public EditAccountInfo(string accessToken) : base("editAccountInfo") => AccessToken = accessToken;

    /// <summary>
    ///     Account name, helps users with several accounts remember which they are currently using.
    ///     Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ShortName { get; set; }

    /// <summary>
    ///     Default author name used when creating new articles.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? AuthorName { get; set; }

    /// <summary>
    ///     Profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? AuthorUrl { get; set; }

    /// <inheritdoc />
    public string AccessToken { get; init; }
}
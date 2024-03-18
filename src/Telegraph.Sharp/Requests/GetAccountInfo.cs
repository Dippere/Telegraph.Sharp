using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to get information about a Telegraph account.
///     Returns an <see cref="Account" /> object on success.
/// </summary>
public class GetAccountInfo : ApiRequestBase<Account>, IAccessTokenTarget
{
    /// <summary>
    ///     Initializes a new request with accessToken.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    public GetAccountInfo(string accessToken) : base("getAccountInfo") => AccessToken = accessToken;

    /// <summary>
    ///     List of account fields to return.
    ///     Available fields: "short_name", "author_name", "author_url", "auth_url","page_count".
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string> Fields { get; set; } = null!;

    /// <summary>
    ///     Required. Access token of the Telegraph account.
    /// </summary>
    public string AccessToken { get; init; }


    /// <summary>
    ///     Set fields to return.
    /// </summary>
    /// <param name="shortName">
    ///     Account name, helps users with several accounts remember which they are currently using.
    ///     Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
    /// </param>
    /// <param name="authorName">Default author name used when creating new articles.</param>
    /// <param name="authorUrl">
    ///     Profile link, opened when users click on the author's name below the title. Can be any link,
    ///     not necessarily to a Telegram profile or channel.
    /// </param>
    /// <param name="authUrl">
    ///     URL to authorize a browser on telegra.ph and connect it to a Telegraph account.
    ///     This URL is valid for only one use and for 5 minutes only.
    /// </param>
    /// <param name="pageCount">Number of pages belonging to the Telegraph account.</param>
    public void SetFields(
        bool shortName,
        bool authorName,
        bool authorUrl,
        bool authUrl,
        bool pageCount)
    {
        var list = new List<string>();
        if (!shortName && !authorName && !authorUrl && !authUrl && !pageCount)
        {
            list.AddRange(["short_name", "author_name", "author_url" ]);
        }
        else
        {
            if (shortName) list.Add("short_name");
            if (authorName) list.Add("author_name");
            if (authorUrl) list.Add("author_url");
            if (authUrl) list.Add("auth_url");
            if (pageCount) list.Add("page_count");
        }

        Fields = list;
    }
}
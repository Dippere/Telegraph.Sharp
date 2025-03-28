﻿namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a Telegraph account.
/// </summary>
public class Account
{
    /// <summary>
    ///     Account name, helps users with several accounts remember which they are currently using.
    ///     Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
    /// </summary>
    public string? ShortName { get; set; }

    /// <summary>
    ///     Default author name used when creating new articles.
    /// </summary>
    public string? AuthorName { get; set; }

    /// <summary>
    ///     Profile link, opened when users click on the author's name below the title. Can be any link, not necessarily to a
    ///     Telegram profile or channel.
    /// </summary>
    public string? AuthorUrl { get; set; }

    /// <summary>
    ///     Access token of the Telegraph account.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    ///     URL to authorize a browser on telegra.ph and connect it to a Telegraph account. This URL is valid for
    ///     only one use and for 5 minutes only.
    /// </summary>
    public string? AuthUrl { get; set; }

    /// <summary>
    ///     Number of pages belonging to the Telegraph account.
    /// </summary>
    public int? PageCount { get; set; }
}

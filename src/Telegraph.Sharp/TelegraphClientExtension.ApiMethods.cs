using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegraph.Sharp.Requests;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp;

/// <summary>
///     Extension methods that map to requests from API documentation.
/// </summary>
public static partial class TelegraphClientExtension
{
    /// <summary>
    /// Use this method to create a new account.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="shortName">
    /// Required. Account name, helps users with several accounts remember which they are currently using.
    /// <para>Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.</para>
    /// </param>
    /// <param name="authorName">Default author name used when creating new articles.</param>
    /// <param name="authorUrl">
    ///     Default profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Account" /> object.</returns>
    public static async Task<Account> CreateAccountAsync(
        this ITelegraphClient telegraphClient,
        string shortName,
        string? authorName = default,
        string? authorUrl = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new CreateAccount(shortName)
            {
                AuthorName = authorName,
                AuthorUrl = authorUrl
            }, cancellationToken
        ).ConfigureAwait(false);

    /// <summary>
    ///  Use this method to create a new page.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="title">Required. Page title.</param>
    /// <param name="content">Required. Content of the page.</param>
    /// <param name="authorName">Author name, displayed below the article's title.</param>
    /// <param name="authorUrl">
    ///     Profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </param>
    /// <param name="returnContent">
    ///     If <see langword= "true"/>, a content will be returned as list of <see cref="Node"/> objects.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Page" /> object.</returns>
    public static async Task<Page> CreatePageAsync(
        this ITelegraphClient telegraphClient,
        string title,
        List<Node> content,
        string? authorName = default,
        string? authorUrl = default,
        bool returnContent = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new CreatePage(telegraphClient.AccessToken!, title, content)
            {
                AuthorName = authorName,
                AuthorUrl = authorUrl,
                ReturnContent = returnContent
            }, cancellationToken
        ).ConfigureAwait(false);

    /// <summary>
    ///  Use this method to edit <see cref="Page"/>.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="path">Required. Path to the page.</param>
    /// <param name="title">Required. Page title.</param>
    /// <param name="content">Required. Content of the page.</param>
    /// <param name="authorName">Author name, displayed below the article's title.</param>
    /// <param name="authorUrl">
    /// Profile link, opened when users click on the author's name below the title.
    /// Can be any link, not necessarily to a Telegram profile or channel.
    /// </param>
    /// <param name="returnContent"> If <see langword= "true"/>, a content will be returned as list of <see cref="Node"/> objects.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an edited <see cref="Page" /> object.</returns>
    public static async Task<Page> EditPageAsync(
        this ITelegraphClient telegraphClient,
        string path,
        string title,
        List<Node> content,
        string? authorName = default,
        string? authorUrl = default,
        bool returnContent = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new EditPage(telegraphClient.AccessToken!, path, title, content)
            {
                AuthorName = authorName,
                AuthorUrl = authorUrl,
                ReturnContent = returnContent
            }, cancellationToken
        ).ConfigureAwait(false);


    /// <summary>
    /// Use this method to get a page.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="path">Required. Path to the Telegraph page (in the format Title-12-31, i.e. everything that comes after http://telegra.ph/).</param>
    /// <param name="returnContent">If <see langword= "true"/>, a content will be returned as list of <see cref="Node"/> objects.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Page" /> object.</returns>
    public static async Task<Page> GetPageAsync(
        this ITelegraphClient telegraphClient,
        string path,
        bool returnContent = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new GetPage(path)
            {
                ReturnContent = returnContent,
            }, cancellationToken
        ).ConfigureAwait(false);

    /// <summary>
    /// Use this method to get a list of pages belonging to account.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="offset">Sequential number of the first page to be returned.</param>
    /// <param name="limit">Limits the number of pages to be retrieved.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns a <see cref="PageList"/> object, sorted by most recently created pages first.</returns>
    public static async Task<PageList> GetPageListAsync(
        this ITelegraphClient telegraphClient,
        int offset = default,
        int limit = 50,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new GetPageList(telegraphClient.AccessToken!)
            {
                Limit = limit,
                Offset = offset
            }, cancellationToken
        ).ConfigureAwait(false);

    /// <summary>
    /// Use this method to get the number of views for article. 
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="path">
    /// Required. Path to the Telegraph page (in the format Title-12-31, where 12 is the month and 31 the day the article was first published).
    /// </param>
    /// <param name="year">
    /// Required if month is passed. If passed, the number of page views for the requested year will be returned.
    /// </param>
    /// <param name="month">
    /// Required if day is passed. If passed, the number of page views for the requested month will be returned.
    /// </param>
    /// <param name="day">
    /// Required if hour is passed. If passed, the number of page views for the requested day will be returned.
    /// </param>
    /// <param name="hour">
    /// If passed, the number of page views for the requested hour will be returned.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns a <see cref="PageViews"/> object on success.</returns>
    public static async Task<PageViews> GetViewsAsync(
        this ITelegraphClient telegraphClient,
        string path,
        int? year = default,
        int? month = default,
        int? day = default,
        int? hour = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new GetViews(path)
            {
                Year = year,
                Month = month,
                Day = day,
                Hour = hour
            }, cancellationToken).ConfigureAwait(false);


    /// <summary>
    /// Use this method to update information about account. Pass only the parameters that you want to edit.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="shortName">New account name.</param>
    /// <param name="authorName">New default author name used when creating new articles.</param>
    /// <param name="authorUrl">New default profile link, opened when users click on the author's name below the title. Can be any link, not necessarily to a Telegram profile or channel.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Account"/> object with the default fields.</returns>
    public static async Task<Account> EditAccountInfoAsync(
        this ITelegraphClient telegraphClient,
        string? shortName = default,
        string? authorName = default,
        string? authorUrl = default,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new EditAccountInfo(telegraphClient.AccessToken!)
            {
                ShortName = shortName,
                AuthorName = authorName,
                AuthorUrl = authorUrl
            }, cancellationToken
        ).ConfigureAwait(false);


    /// <summary>
    /// Use this method to get information about account.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="shortName">If <see langword= "true"/>, <see cref="Account.ShortName"/> will be returned.</param>
    /// <param name="authorName">If <see langword= "true"/>, <see cref="Account.AuthorName"/> will be returned.</param>
    /// <param name="authorUrl">If <see langword= "true"/>, <see cref="Account.AuthorUrl"/> will be returned.</param>
    /// <param name="authUrl">If <see langword= "true"/>, <see cref="Account.AuthUrl"/> will be returned.</param>
    /// <param name="pageCount">If <see langword= "true"/>, <see cref="Account.PageCount"/> will be returned.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Account"/> object.</returns>
    public static async Task<Account> GetAccountInfoAsync(
        this ITelegraphClient telegraphClient,
        bool shortName = default,
        bool authorName = default,
        bool authorUrl = default,
        bool authUrl = default,
        bool pageCount = default,
        CancellationToken cancellationToken = default
    )
    {
        var request = new GetAccountInfo(telegraphClient.AccessToken!);
        request.SetFields(shortName, authorName, authorUrl, authUrl, pageCount);
        return await telegraphClient.MakeApiRequestAsync(request, cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary>
    /// Use this method to revoke account <see cref="Account.AccessToken"/> and generate a new one.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="Account"/> object with new <see cref="Account.AccessToken"/> and <see cref="Account.AuthUrl"/> fields.</returns>
    public static async Task<Account> RevokeAccessTokenAsync(
        this ITelegraphClient telegraphClient,
        CancellationToken cancellationToken = default
    ) =>
        await telegraphClient.MakeApiRequestAsync(
            new RevokeAccessToken(telegraphClient.AccessToken!), cancellationToken
        ).ConfigureAwait(false);
}
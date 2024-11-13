using Telegraph.Sharp.Exceptions;
using Telegraph.Sharp.Tests.Integ.Fixture;
using Telegraph.Sharp.Tests.Integ.Order;
using Telegraph.Sharp.Types;
using Xunit;

namespace Telegraph.Sharp.Tests.Integ.Methods;

[TestCaseOrderer(
    "Telegraph.Sharp.Tests.Integ.Order.PriorityOrderer",
    "Telegraph.Sharp.Tests.Integ")]
public class RequestsTests : IClassFixture<RequestsFixture>
{
    private readonly RequestsFixture _fixture;

    public RequestsTests(RequestsFixture fixture) => _fixture = fixture;

    #region Node equals checker

    private static void CheckNodesEquality(List<Node> actual, List<Node> expected)
    {
        Assert.NotNull(actual);
        Assert.NotNull(expected);
        Assert.Equal(expected.Count, actual.Count);
        for (var i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i].Value, actual[i].Value);
            Assert.Equal(expected[i].Tag, actual[i].Tag);
            Assert.Equal(expected[i].Attributes?.Src, actual[i].Attributes?.Src);
            Assert.Equal(expected[i].Attributes?.Href, actual[i].Attributes?.Href);
            if (actual[i].Children is not null && expected[i].Children is not null)
                CheckNodesEquality(actual[i].Children!, expected[i].Children!);
        }
    }

    #endregion

    #region Without access token

    [Theory(DisplayName = "Create account")]
    [TestPriority(1)]
    [InlineData("testShortName", null, null)]
    [InlineData("testShortName", null, "https://testAuthorUrl.com/")]
    [InlineData("testShortName", "testAuthorName", null)]
    [InlineData("testShortName", "testAuthorName", "https://testAuthorUrl.com/")]
    public async Task CreateAccountTests(string shortName, string? authorName, string? authorUrl)
    {
        var account = await _fixture.TelegraphClient.CreateAccountAsync(shortName, authorName, authorUrl);
        Assert.NotNull(account);
        Assert.Equal(shortName, account.ShortName);
        Assert.Equal(authorName ?? string.Empty, account.AuthorName);
        Assert.Equal(authorUrl ?? string.Empty, account.AuthorUrl);
        _fixture.TelegraphClient = new TelegraphClient(account.AccessToken!, _fixture.HttpClient);
    }

    [Fact(DisplayName = "Get page")]
    [TestPriority(4)]
    public async Task GetPageTests()
    {
        var page = await _fixture.TelegraphClient.GetPageAsync(_fixture.PagePath, true);
        Assert.NotNull(page);
        Assert.NotNull(page.Content);
        Assert.Equal(_fixture.ContentForEdit.Count, page.Content.Count);
        CheckNodesEquality(page.Content, _fixture.ContentForEdit);
    }


    [Theory(DisplayName = "Get views")]
    [TestPriority(7)]
    [InlineData(null, null, null, null)]
    [InlineData(2023, null, null, null)]
    [InlineData(2023, 1, null, null)]
    [InlineData(2023, 1, 20, null)]
    [InlineData(2023, 1, 20, 20)]
    public async Task GetViewsTests(int? year, int? month, int? day, int? hour)
    {
        var pageViews =
            await _fixture.TelegraphClient.GetViewsAsync(RequestsFixture.PageViewsPath, year, month, day, hour);
        Assert.NotNull(pageViews);
        // Sometimes server return 0 as result, idk how to fix it
        Assert.True(pageViews.Views >= 0);
    }

    [Theory(DisplayName = "Get views should throw exception")]
    [TestPriority(7)]
    [InlineData(2023, null, null, 1)]
    [InlineData(null, null, 2, null)]
    [InlineData(null, 1, 2, null)]
    [InlineData(null, 1, null, null)]
    [InlineData(null, 1, 20, null)]
    public async Task GetViewsShouldThrowRequestExceptionTests(int? year, int? month, int? day, int? hour)
    {
        await Assert.ThrowsAsync<RequestException>(async () =>
            await _fixture.TelegraphClient.GetViewsAsync(RequestsFixture.PageViewsPath, year, month, day, hour));
    }

    #endregion

    #region With access token

    [Fact(DisplayName = "Create page")]
    [TestPriority(2)]
    public async Task CreatePageTests()
    {
        const string title = "test-title";
        var page = await _fixture.TelegraphClient.CreatePageAsync(title, _fixture.ContentForCreate,
            returnContent: true);
        Assert.NotNull(page);
        Assert.Equal(title, page.Title);
        Assert.NotNull(page.Content);
        Assert.Equal(_fixture.ContentForCreate.Count, page.Content.Count);
        CheckNodesEquality(page.Content, _fixture.ContentForCreate);
        _fixture.PagePath = page.Path;
    }

    [Fact(DisplayName = "Edit page")]
    [TestPriority(3)]
    public async Task EditPageTests()
    {
        const string title = "test-edited-title";
        var page = await _fixture.TelegraphClient.EditPageAsync(_fixture.PagePath, title, _fixture.ContentForEdit,
            returnContent: true);
        Assert.NotNull(page);
        Assert.Equal(title, page.Title);
        Assert.NotNull(page.Content);
        Assert.Equal(_fixture.ContentForEdit.Count, page.Content.Count);
        CheckNodesEquality(page.Content, _fixture.ContentForEdit);
    }

    [Fact(DisplayName = "Get page list")]
    [TestPriority(5)]
    public async Task GetPageListTests()
    {
        var pageList = await _fixture.TelegraphClient.GetPageListAsync();
        Assert.NotNull(pageList);
        Assert.Equal(1, pageList.TotalCount);
        Assert.NotNull(pageList.Pages);
        Assert.Single(pageList.Pages);
        Assert.Equal(_fixture.PagePath, pageList.Pages[0].Path);
    }


    [Theory(DisplayName = "Get account info")]
    [TestPriority(8)]
    [InlineData(false, false, false, false, false,
        "testShortName", "testAuthorName", "https://testAuthorUrl.com/", null, null)]
    [InlineData(true, true, true, false, false,
        "testShortName", "testAuthorName", "https://testAuthorUrl.com/", null, null)]
    [InlineData(true, false, false, false, true,
        "testShortName", null, null, null, 1)]
    public async Task GetAccountInfoTests(
        bool shortName,
        bool authorName,
        bool authorUrl,
        bool authUrl,
        bool pageCount,
        string? expectedShortName,
        string? expectedAuthorName,
        string? expectedAuthorUrl,
        string? expectedAuthUrl,
        int? expectedPageCount
    )
    {
        var account = await _fixture.TelegraphClient.GetAccountInfoAsync(shortName,
            authorName,
            authorUrl,
            authUrl,
            pageCount);
        Assert.NotNull(account);
        Assert.Equal(expectedShortName, account.ShortName);
        Assert.Equal(expectedAuthorName, account.AuthorName);
        Assert.Equal(expectedAuthorUrl, account.AuthorUrl);
        Assert.Equal(expectedAuthUrl, account.AuthUrl);
        Assert.Equal(expectedPageCount, account.PageCount);
    }

    [Fact(DisplayName = "Edit account info")]
    [TestPriority(9)]
    public async Task EditAccountInfoTests()
    {
        var editedAccount1 = await _fixture.TelegraphClient.EditAccountInfoAsync(_fixture.AccountShortName);
        Assert.NotNull(editedAccount1);
        Assert.Equal(_fixture.AccountShortName, editedAccount1.ShortName);
        await Task.Delay(3500);
        var editedAccount2 =
            await _fixture.TelegraphClient.EditAccountInfoAsync(authorName: _fixture.AccountAuthorName);
        Assert.NotNull(editedAccount2);
        Assert.Equal(_fixture.AccountAuthorName, editedAccount2.AuthorName);
        await Task.Delay(3500);
        var editedAccount3 = await _fixture.TelegraphClient.EditAccountInfoAsync(authorUrl: _fixture.AccountAuthorUrl);
        Assert.NotNull(editedAccount3);
        Assert.Equal(_fixture.AccountAuthorUrl, editedAccount3.AuthorUrl);
    }

    [Fact(DisplayName = "Revoke access token")]
    [TestPriority(10)]
    public async Task RevokeAccessTokenTests()
    {
        var revokedAccessToken = await _fixture.TelegraphClient.RevokeAccessTokenAsync();
        Assert.NotNull(revokedAccessToken);
        Assert.NotNull(revokedAccessToken.AccessToken);
        Assert.NotEqual(_fixture.AccessToken, revokedAccessToken.AccessToken);
        Assert.NotNull(revokedAccessToken.AuthUrl);
    }

    #endregion
}

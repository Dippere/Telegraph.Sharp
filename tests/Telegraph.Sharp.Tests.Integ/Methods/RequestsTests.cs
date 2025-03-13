using Telegraph.Sharp.Exceptions;
using Telegraph.Sharp.Tests.Integ.Fixture;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Integ.Methods;

public class RequestsTests
{
    private static readonly RequestsFixture s_fixture = new();

    [After(Class)]
    public static void CleanUp() => s_fixture.Dispose();

    #region Node equals checker

    private static async Task CheckNodesEquality(List<Node> actual, List<Node> expected)
    {
        await Assert.That(actual).IsNotNull();
        await Assert.That(expected).IsNotNull();
        await Assert.That(actual.Count).IsEqualTo(expected.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            await Assert.That(actual[i].Value).IsEqualTo(expected[i].Value);
            await Assert.That(actual[i].Tag).IsEqualTo(expected[i].Tag);
            await Assert.That(actual[i].Attributes?.Src).IsEqualTo(expected[i].Attributes?.Src);
            await Assert.That(actual[i].Attributes?.Href).IsEqualTo(expected[i].Attributes?.Href);
            if (actual[i].Children is not null && expected[i].Children is not null)
            {
                await CheckNodesEquality(actual[i].Children!, expected[i].Children!);
            }
        }
    }

    #endregion

    #region Without access token

    [Test]
    [DisplayName("Create account")]
    [Arguments("testShortName", null, null)]
    [Arguments("testShortName", null, "https://testAuthorUrl.com/")]
    [Arguments("testShortName", "testAuthorName", null)]
    [Arguments("testShortName", "testAuthorName", "https://testAuthorUrl.com/")]
    public async Task CreateAccountTests(string shortName, string? authorName, string? authorUrl)
    {
        Account account = await s_fixture.TelegraphClient.CreateAccountAsync(shortName, authorName, authorUrl);
        await Assert.That(account).IsNotNull();
        await Assert.That(account.ShortName).IsEqualTo(shortName);
        await Assert.That(account.AuthorName).IsEqualTo(authorName ?? string.Empty);
        await Assert.That(account.AuthorUrl).IsEqualTo(authorUrl ?? string.Empty);
        s_fixture.AccessToken = account.AccessToken;
    }

    [Test]
    [DisplayName("Get page")]
    [DependsOn(nameof(EditPageTests))]
    public async Task GetPageTests()
    {
        Page page = await s_fixture.TelegraphClient.GetPageAsync(s_fixture.PagePath, true);
        await Assert.That(page).IsNotNull();
        await Assert.That(page.Content).IsNotNull();
        await Assert.That(page.Content!.Count).IsEqualTo(s_fixture.ContentForEdit.Count);
        await CheckNodesEquality(page.Content, s_fixture.ContentForEdit);
    }

    [Test]
    [DisplayName("Get views")]
    [DependsOn(nameof(GetPageListTests))]
    [Arguments(null, null, null, null)]
    [Arguments(2023, null, null, null)]
    [Arguments(2023, 1, null, null)]
    [Arguments(2023, 1, 20, null)]
    [Arguments(2023, 1, 20, 20)]
    public async Task GetViewsTests(int? year, int? month, int? day, int? hour)
    {
        PageViews pageViews = await s_fixture.TelegraphClient.GetViewsAsync(RequestsFixture.PageViewsPath, year, month, day, hour);
        await Assert.That(pageViews).IsNotNull();
        // Sometimes server return 0 as a result, idk how to fix it
        await Assert.That(pageViews.Views >= 0).IsTrue();
    }

    [Test]
    [DisplayName("Get views should throw exception")]
    [Arguments(2023, null, null, 1)]
    [Arguments(null, null, 2, null)]
    [Arguments(null, 1, 2, null)]
    [Arguments(null, 1, null, null)]
    [Arguments(null, 1, 20, null)]
    public async Task GetViewsShouldThrowRequestExceptionTests(int? year, int? month, int? day, int? hour) =>
        await Assert.ThrowsAsync<RequestException>(async () =>
            await s_fixture.TelegraphClient.GetViewsAsync(RequestsFixture.PageViewsPath, year, month, day, hour));

    #endregion

    #region With access token

    [Test]
    [DisplayName("Create page")]
    [DependsOn(nameof(CreateAccountTests))]
    public async Task CreatePageTests()
    {
        const string title = "test-title1";
        Page page = await s_fixture.TelegraphClient.CreatePageAsync(title, s_fixture.ContentForCreate,
            returnContent: true);
        await Assert.That(page).IsNotNull();
        await Assert.That(page.Title).IsEqualTo(title);
        await Assert.That(page.Content).IsNotNull();
        await Assert.That(page.Content!.Count).IsEqualTo(s_fixture.ContentForCreate.Count);
        await CheckNodesEquality(page.Content, s_fixture.ContentForCreate);
        s_fixture.PagePath = page.Path;
    }

    [Test]
    [DisplayName("Edit page")]
    [DependsOn(nameof(CreatePageTests))]
    public async Task EditPageTests()
    {
        const string title = "test-edited-title";
        Page page = await s_fixture.TelegraphClient.EditPageAsync(s_fixture.PagePath, title, s_fixture.ContentForEdit,
            returnContent: true);
        await Assert.That(page).IsNotNull();
        await Assert.That(page.Title).IsEqualTo(title);
        await Assert.That(page.Content).IsNotNull();
        await Assert.That(page.Content!.Count).IsEqualTo(s_fixture.ContentForEdit.Count);
        await CheckNodesEquality(page.Content, s_fixture.ContentForEdit);
    }

    [Test]
    [DisplayName("Get page list")]
    [DependsOn(nameof(GetPageTests))]
    public async Task GetPageListTests()
    {
        PageList pageList = await s_fixture.TelegraphClient.GetPageListAsync();
        await Assert.That(pageList).IsNotNull();
        await Assert.That(pageList.TotalCount).IsEqualTo(1);
        await Assert.That(pageList.Pages).IsNotNull().And.HasSingleItem();
        await Assert.That(pageList.Pages[0].Path).IsEqualTo(s_fixture.PagePath);
    }


    [Test]
    [DisplayName("Get account info")]
    [DependsOn(nameof(GetViewsTests))]
    [Arguments(false, false, false, false, false,
        "testShortName", "testAuthorName", "https://testAuthorUrl.com/", null, null)]
    [Arguments(true, true, true, false, false,
        "testShortName", "testAuthorName", "https://testAuthorUrl.com/", null, null)]
    [Arguments(true, false, false, false, true,
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
        Account account = await s_fixture.TelegraphClient.GetAccountInfoAsync(shortName,
            authorName,
            authorUrl,
            authUrl,
            pageCount);
        await Assert.That(account).IsNotNull();
        await Assert.That(account.ShortName).IsEqualTo(expectedShortName);
        await Assert.That(account.AuthorName).IsEqualTo(expectedAuthorName);
        await Assert.That(account.AuthorUrl).IsEqualTo(expectedAuthorUrl);
        await Assert.That(account.AuthUrl).IsEqualTo(expectedAuthUrl);
        await Assert.That(account.PageCount).IsEqualTo(expectedPageCount);
    }

    [Test]
    [DisplayName("Edit account info")]
    [DependsOn(nameof(GetAccountInfoTests))]
    public async Task EditAccountInfoTests()
    {
        Account editedAccount1 = await s_fixture.TelegraphClient.EditAccountInfoAsync(RequestsFixture.AccountShortName);
        await Assert.That(editedAccount1).IsNotNull();
        await Assert.That(editedAccount1.ShortName).IsEqualTo(RequestsFixture.AccountShortName);
        await Task.Delay(3500);
        Account editedAccount2 =
            await s_fixture.TelegraphClient.EditAccountInfoAsync(authorName: RequestsFixture.AccountAuthorName);
        await Assert.That(editedAccount2).IsNotNull();
        await Assert.That(editedAccount2.AuthorName).IsEqualTo(RequestsFixture.AccountAuthorName);
        await Task.Delay(3500);
        Account editedAccount3 =
            await s_fixture.TelegraphClient.EditAccountInfoAsync(authorUrl: RequestsFixture.AccountAuthorUrl);
        await Assert.That(editedAccount3).IsNotNull();
        await Assert.That(editedAccount3.AuthorUrl).IsEqualTo(RequestsFixture.AccountAuthorUrl);
    }

    [Test]
    [DisplayName("Revoke access token")]
    [DependsOn(nameof(EditAccountInfoTests))]
    public async Task RevokeAccessTokenTests()
    {
        Account revokedAccessToken = await s_fixture.TelegraphClient.RevokeAccessTokenAsync();
        await Assert.That(revokedAccessToken).IsNotNull();
        await Assert.That(revokedAccessToken.AccessToken).IsNotNull().And.IsNotEqualTo(s_fixture.AccessToken);
        await Assert.That(revokedAccessToken.AuthUrl).IsNotNull();
    }

    #endregion
}

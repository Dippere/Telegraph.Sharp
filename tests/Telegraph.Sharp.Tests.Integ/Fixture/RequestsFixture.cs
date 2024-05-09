using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Integ.Fixture;

public sealed class RequestsFixture : IDisposable
{
    public const string PageViewsPath = "Telegraph-manual-08-14";

    public readonly string AccountAuthorName = "testAuthorName2";
    public readonly string AccountAuthorUrl = "https://testAuthorUrl2.com/";

    public readonly string AccountShortName = "testShortName2";

    public readonly List<Node> ContentForCreate = new()
    {
        Node.H3("Test header"),
        Node.P("Hello, World!"),
        Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
    };

    public readonly List<Node> ContentForEdit = new()
    {
        Node.H3("Test header2"),
        Node.P("Hello, World!"),
        Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
    };

    private readonly HttpClient _httpClient = new();

    public RequestsFixture() => TelegraphClient = new TelegraphClient(_httpClient);

    public TelegraphClient TelegraphClient { get; }

    public string? AccessToken
    {
        get => TelegraphClient.AccessToken;
        set => TelegraphClient.AccessToken = value;
    }

    public string PagePath { get; set; } = null!;

    public void Dispose()
    {
        _httpClient.CancelPendingRequests();
        _httpClient.Dispose();
    }
}
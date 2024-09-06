using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Integ.Fixture;

public sealed class RequestsFixture : IDisposable
{
    public const string PageViewsPath = "Telegraph-manual-08-14";

    public readonly string AccountAuthorName = "testAuthorName2";
    public readonly string AccountAuthorUrl = "https://testAuthorUrl2.com/";

    public readonly string AccountShortName = "testShortName2";

    public readonly List<Node> ContentForCreate =
    [
        Node.H3("Test header"),
        Node.P("Hello, World!"),
        Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
    ];

    public readonly List<Node> ContentForEdit =
    [
        Node.H3("Test header2"),
        Node.P("Hello, World!"),
        Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
    ];

    public readonly HttpClient HttpClient = new();

    public RequestsFixture() => TelegraphClient = new TelegraphClient(HttpClient);

    public TelegraphClient TelegraphClient { get; set; }

    public string? AccessToken => TelegraphClient.AccessToken;

    public string PagePath { get; set; } = null!;

    public void Dispose()
    {
        HttpClient.CancelPendingRequests();
        HttpClient.Dispose();
    }
}
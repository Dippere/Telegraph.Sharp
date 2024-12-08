using System.Text.Json;
using Telegraph.Sharp.Requests;
using Telegraph.Sharp.Serialization;

namespace Telegraph.Sharp.Tests.Unit.Serialization;

public class RequestsTests
{
    [Test, DisplayName("Create account")]
    public async Task CreateAccountSerialization()
    {
        var request = new CreateAccount("test")
        {
            AuthorName = "test1",
            AuthorUrl = "test2"
        };
        string json = JsonSerializer.Serialize(request, TelegraphSerializerContext.Default.CreateAccount);
        await Assert.That(json).Contains("\"author_url\": \"test2\"");
    }

    [Test, DisplayName("Create page")]
    public async Task CreatePageSerialization()
    {
        var request = new CreatePage("test", "Title", [])
        {
            AuthorName = "test1",
            AuthorUrl = "test2"
        };
        string json = JsonSerializer.Serialize(request, TelegraphSerializerContext.Default.CreatePage);
        await Assert.That(json).Contains("\"author_url\": \"test2\"");
    }
}

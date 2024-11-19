using System.Text.Json;
using Telegraph.Sharp.Requests;
using Telegraph.Sharp.Tests.Unit.Data;
using Telegraph.Sharp.Types;
using Xunit;

namespace Telegraph.Sharp.Tests.Unit.Serialization;

public class RequestsTests
{
    [Fact(DisplayName = "Create Account")]
    public void CreateAccountSerialization()
    {
        var request = new CreateAccount("test")
        {
            AuthorName = "test1",
            AuthorUrl = "test2"
        };
        var json = JsonSerializer.Serialize(request, SerialOpt.SerializerOptions);
        Assert.Contains("\"author_url\":\"test2\"", json);
    }

    [Fact(DisplayName = "Create Page")]
    public void CreatePageSerialization()
    {
        var request = new CreatePage("test", "Title", new List<Node>())
        {
            AuthorName = "test1",
            AuthorUrl = "test2"
        };
        var json = JsonSerializer.Serialize(request, SerialOpt.SerializerOptions);
        Assert.Contains("\"author_url\":\"test2\"", json);
    }
}

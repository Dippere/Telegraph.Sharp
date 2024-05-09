using System.Collections.Generic;
using System.Text.Json;
using Telegraph.Sharp.Tests.Unit.Data;
using Telegraph.Sharp.Types;
using Xunit;

namespace Telegraph.Sharp.Tests.Unit.Serialization;

public class NodeTests
{
    [Fact]
    public void SerializeNode_ReturnsCorrectJson()
    {
        var nodes = new List<Node>
        {
            Node.H3("Test header"),
            Node.P("Hello, World!"),
            Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
        };

        var json = JsonSerializer.Serialize(nodes, SerialOpt.SerializerOptions);
        Assert.Contains("\"tag\":\"figcaption\"", json);
    }

    [Fact]
    public void DeserializeNode_ReturnsCorrectNode()
    {
        const string value = """
                             [
                                 {
                                     "tag": "h3",
                                     "attrs": {
                                         "id": "Test-header"
                                     },
                                     "children": [
                                         "Test header"
                                     ]
                                 },
                                 {
                                     "tag": "p",
                                     "children": [
                                         "Hello, World!"
                                     ]
                                 },
                                 {
                                     "tag": "figure",
                                     "children": [
                                         {
                                             "tag": "img",
                                             "attrs": {
                                                 "src": "/images/logo.png"
                                             }
                                         },
                                         {
                                             "tag": "figcaption",
                                             "children": [
                                                 "Logo"
                                             ]
                                         }
                                     ]
                                 }
                             ]
                             """;
        var nodes = JsonSerializer.Deserialize<List<Node>>(value, SerialOpt.SerializerOptions);
        Assert.NotNull(nodes);
        Assert.Equal(3, nodes.Count);
        Assert.Equal("Test header", nodes[0].Children![0].Value);
        Assert.Equal("Hello, World!", nodes[1].Children![0].Value);
        Assert.Equal("Logo", nodes[2].Children![1].Children![0].Value);
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
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

        var json = JsonConvert.SerializeObject(nodes);
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
        var nodes = JsonConvert.DeserializeObject<List<Node>>(value);
        Assert.NotNull(nodes);
        Assert.Equal(3, nodes.Count);
        Assert.Equal("Test header", nodes[0].Children![0].Value);
        Assert.Equal("Hello, World!", nodes[1].Children![0].Value);
        Assert.Equal("Logo", nodes[2].Children![1].Children![0].Value);
    }
}
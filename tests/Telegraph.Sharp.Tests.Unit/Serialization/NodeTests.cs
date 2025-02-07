using System.Text.Json;
using Telegraph.Sharp.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Unit.Serialization;

public class NodeTests
{
    [Test]
    public async Task SerializeNode_ReturnsCorrectJson()
    {
        List<Node> nodes = new()
        {
            Node.H3("Test header"), Node.P("Hello, World!"), Node.ImageFigure("https://telegra.ph/images/logo.png", "Logo")
        };
        string json = JsonSerializer.Serialize(nodes, TelegraphSerializerContext.Default.ListNode);
        await Assert.That(json).Contains("\"tag\": \"figcaption\"");
    }

    [Test]
    public async Task DeserializeNode_ReturnsCorrectNode()
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
        List<Node>? nodes = JsonSerializer.Deserialize(value, TelegraphSerializerContext.Default.ListNode);
        await Assert.That(nodes).IsNotNull();
        await Assert.That(nodes!.Count).IsEqualTo(3);
        await Assert.That(nodes[0].Children![0].Value).IsEqualTo("Test header");
        await Assert.That(nodes[1].Children![0].Value).IsEqualTo("Hello, World!");
        await Assert.That(nodes[2].Children![1].Children![0].Value).IsEqualTo("Logo");
    }
}

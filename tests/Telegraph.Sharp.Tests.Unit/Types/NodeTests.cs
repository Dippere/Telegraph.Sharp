using Telegraph.Sharp.Exceptions;
using Telegraph.Sharp.Tests.Unit.Attributes;
using Telegraph.Sharp.Tests.Unit.Data;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Tests.Unit.Types;

public class NodeTests
{
    private static readonly IEqualityComparer<Node> s_nodeComparer = EqualityComparer<Node>.Create(
        (a, b) => a == b && a == null ||
                  a!.Value == b!.Value &&
                  (a.Children == null && b.Children == null || a.Children!.SequenceEqual(b.Children!)) &&
                  a.Attributes == b.Attributes &&
                  a.Tag == b.Tag);

    [Test]
    [DisplayName("Empty")]
    public async Task Empty_Tests()
    {
        Node node = new();
        await Assert.That(node.Children).IsNull();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.P);
        node.Tag = TagEnum.H3;
        await Assert.That(node.Tag).IsEqualTo(TagEnum.H3);
    }

    [Test]
    [DisplayName("A")]
    public async Task A_Tests()
    {
        Node node = Node.A();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.A);
        await Assert.That(node.Attributes).IsNotNull();

        const string url = "https://example.com/";
        Node node1 = Node.A(url);
        await Assert.That(node1.Tag).IsEqualTo(TagEnum.A);
        await Assert.That(node1.Children).IsNull();
        await Assert.That(node1.Attributes).IsNotNull();
        await Assert.That(node1.Attributes!.Href).IsEqualTo(url);

        const string child = "child";
        Node node2 = Node.A(url, child);
        await Assert.That(node2.Tag).IsEqualTo(TagEnum.A);
        await Assert.That(node2.Children).IsNotNull();
        await Assert.That(node2.Children!.Count).IsEqualTo(1);
        await Assert.That(node2.Children[0]).IsEqualTo<Node>(child, s_nodeComparer);
        await Assert.That(node2.Attributes).IsNotNull();
        await Assert.That(node2.Attributes!.Href).IsEqualTo(url);

        const string child1 = "Text 1";
        const string child2 = "Text 2";
        Node node3 = Node.A(url, child1, child2);
        await Assert.That(node3.Tag).IsEqualTo(TagEnum.A);
        await Assert.That(node3.Children).IsNotNull();
        await Assert.That(node3.Children!.Count).IsEqualTo(2);
        await Assert.That(node3.Children[0]).IsEqualTo<Node>(child1, s_nodeComparer);
        await Assert.That(node3.Children[1]).IsEqualTo<Node>(child2, s_nodeComparer);
        await Assert.That(node3.Attributes).IsNotNull();
        await Assert.That(node3.Attributes!.Href).IsEqualTo(url);

        Node node4 = Node.A(url, []);
        await Assert.That(node4.Children).IsNotNull();
        await Assert.That(node4.Children).IsEmpty();
        await Assert.That(node4.Attributes).IsNotNull();
        await Assert.That(node4.Attributes!.Href).IsEqualTo(url);
    }

    [Test]
    [DisplayName("Br")]
    public async Task Br_Tests() => await CheckNodeNullChildren(Node.Br(), TagEnum.Br);

    [Test]
    [DisplayName("Hr")]
    public async Task Hr_Tests() => await CheckNodeNullChildren(Node.Hr(), TagEnum.Hr);

    [Test]
    [DisplayName("Ol child nodes")]
    public async Task Ol_Tests()
    {
        List<List<Node>> nodes =
        [
            new()
            {
                Node.P("1"), Node.P("2"), Node.P("3")
            },
            new()
            {
                Node.P("4"), Node.P("5"), Node.P("6")
            }
        ];
        Node node5 = Node.Ol(nodes);
        await Assert.That(node5.Tag).IsEqualTo(TagEnum.Ol);
        await Assert.That(node5.Children).IsNotNull();
        await Assert.That(node5.Children!.Count).IsEqualTo(2);
        await Assert.That(node5.Children[0].Children!.Count).IsEqualTo(3);
        await Assert.That(node5.Children[1].Children!.Count).IsEqualTo(3);
        await Assert.That(node5.Children[0].Tag).IsEqualTo(TagEnum.Li);
        await Assert.That(node5.Children[1].Tag).IsEqualTo(TagEnum.Li);
    }

    [Test]
    [DisplayName("Ul child nodes")]
    public async Task Ul_Tests()
    {
        List<List<Node>> nodes =
        [
            new()
            {
                Node.P("1"), Node.P("2"), Node.P("3")
            },
            new()
            {
                Node.P("4"), Node.P("5"), Node.P("6")
            }
        ];
        Node node5 = Node.Ul(nodes);
        await Assert.That(node5.Tag).IsEqualTo(TagEnum.Ul);
        await Assert.That(node5.Children).IsNotNull();
        await Assert.That(node5.Children!.Count).IsEqualTo(2);
        await Assert.That(node5.Children[0].Children!.Count).IsEqualTo(3);
        await Assert.That(node5.Children[1].Children!.Count).IsEqualTo(3);
        await Assert.That(node5.Children[0].Tag).IsEqualTo(TagEnum.Li);
        await Assert.That(node5.Children[1].Tag).IsEqualTo(TagEnum.Li);
    }

    [Test]
    [DisplayName("Img")]
    public async Task Img_Tests()
    {
        Node node = Node.Img();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Img);
        await Assert.That(node.Attributes).IsNotNull();
        await Assert.That(node.Attributes!.Href).IsNull();
        await Assert.That(node.Attributes!.Src).IsNull();

        const string src = "file.jpg";
        Node node1 = Node.Img(src);
        await Assert.That(node1.Tag).IsEqualTo(TagEnum.Img);
        await Assert.That(node1.Attributes).IsNotNull();
        await Assert.That(node1.Attributes!.Href).IsNull();
        await Assert.That(node1.Attributes.Src).IsNotNull();
        await Assert.That(node1.Attributes.Src).IsEqualTo(src);
    }

    [Test]
    [DisplayName("Video")]
    public async Task Video_Tests()
    {
        Node node = Node.Video();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Video);
        await Assert.That(node.Attributes).IsNotNull();
        await Assert.That(node.Attributes!.Href).IsNull();
        await Assert.That(node.Attributes!.Src).IsNull();

        const string src = "file.mp4";
        Node node1 = Node.Video(src);
        await Assert.That(node1.Tag).IsEqualTo(TagEnum.Video);
        await Assert.That(node1.Attributes).IsNotNull();
        await Assert.That(node1.Attributes!.Href).IsNull();
        await Assert.That(node1.Attributes.Src).IsNotNull();
        await Assert.That(node1.Attributes.Src).IsEqualTo(src);
    }

    [Test]
    [DisplayName("Iframe")]
    public async Task Iframe_Tests()
    {
        Node node = Node.Iframe();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Iframe);
        await Assert.That(node.Attributes).IsNotNull();
        await Assert.That(node.Attributes!.Href).IsNull();
        await Assert.That(node.Attributes!.Src).IsNull();

        const string url1 = "https://www.youtube.com/watch?v=123456";
        Node node1 = Node.Iframe(url1);
        await Assert.That(node1.Attributes!.Src).IsEqualTo("/embed/youtube?url=" + url1);

        const string url2 = "https://vimeo.com/1234567";
        Node node2 = Node.Iframe(url2);
        await Assert.That(node2.Attributes!.Src).IsEqualTo("/embed/vimeo?url=" + url2);

        const string url3 = "https://example.link/";
        TelegraphException exception = Assert.Throws<TelegraphException>(() => Node.Iframe(url3));
        await Assert.That(exception.Message).StartsWith("Invalid link.");

        const string url4 = "https://www.youtu.be/watch?v=123456";
        Node node4 = Node.Iframe(url4);
        await Assert.That(node4.Attributes!.Src).IsEqualTo("/embed/youtube?url=" + url4);
    }

    [Test]
    [DisplayName("Figure")]
    public async Task Figure_Tests()
    {
        Node node = Node.Figure();
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Figure);

        const string text = "Heading";
        const string caption = "Caption";
        Node node1 = Node.Figure(text, caption);
        await Assert.That(node1.Tag).IsEqualTo(TagEnum.Figure);
        await Assert.That(node1.Children).IsNotNull();
        await Assert.That(node1.Children!.Count).IsEqualTo(2);
        await Assert.That(node1.Children[0]).IsEqualTo<Node>(text, s_nodeComparer);
        await Assert.That(node1.Children[1]).IsEqualTo<Node>(caption, s_nodeComparer);
    }

    [Test]
    [DisplayName("ImageFigure")]
    public async Task ImageFigure_Tests()
    {
        const string imgSrc = "image.jpg";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        Node node = Node.ImageFigure(imgSrc, caption1, caption2);
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Figure);
        await Assert.That(node.Children).IsNotNull();
        await Assert.That(node.Children![0].Tag).IsEqualTo(TagEnum.Img);
        await Assert.That(node.Children[1].Tag).IsEqualTo(TagEnum.Figcaption);
        await Assert.That(node.Children[0].Attributes!.Src).IsEqualTo(imgSrc);
        await Assert.That(node.Children[1].Children![0]).IsEqualTo<Node>(caption1, s_nodeComparer);
        await Assert.That(node.Children[1].Children![1]).IsEqualTo<Node>(caption2, s_nodeComparer);
    }

    [Test]
    [DisplayName("VideoFigure")]
    public async Task VideoFigure_Tests()
    {
        const string videoSrc = "video.mp4";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        Node node = Node.VideoFigure(videoSrc, caption1, caption2);
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Figure);
        await Assert.That(node.Children).IsNotNull();
        await Assert.That(node.Children![0].Tag).IsEqualTo(TagEnum.Video);
        await Assert.That(node.Children[1].Tag).IsEqualTo(TagEnum.Figcaption);
        await Assert.That(node.Children[0].Attributes!.Src).IsEqualTo(videoSrc);
        await Assert.That(node.Children[1].Children![0]).IsEqualTo<Node>(caption1, s_nodeComparer);
        await Assert.That(node.Children[1].Children![1]).IsEqualTo<Node>(caption2, s_nodeComparer);
    }

    [Test]
    [DisplayName("IframeFigure")]
    public async Task IframeFigure_Tests()
    {
        const string imgSrc = "https://www.youtube.com/watch?v=123456";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        Node node = Node.IframeFigure(imgSrc, caption1, caption2);
        await Assert.That(node.Tag).IsEqualTo(TagEnum.Figure);
        await Assert.That(node.Children).IsNotNull();
        await Assert.That(node.Children![0].Tag).IsEqualTo(TagEnum.Iframe);
        await Assert.That(node.Children[1].Tag).IsEqualTo(TagEnum.Figcaption);
        await Assert.That(node.Children[0].Attributes!.Src).IsEqualTo("/embed/youtube?url=" + imgSrc);
        await Assert.That(node.Children[1].Children![0]).IsEqualTo<Node>(caption1, s_nodeComparer);
        await Assert.That(node.Children[1].Children![1]).IsEqualTo<Node>(caption2, s_nodeComparer);
    }

    #region Structured Nodes

    [Test]
    [ArgumentDisplayFormatter<DisplayNodesTestCaseFormatter>]
    [MethodDataSource(typeof(NodesTestCaseDataSource), nameof(NodesTestCaseDataSource.TestCases))]
    public async Task Structured_Nodes_Tests(NodesTestCase testCase)
    {
        await CheckNodeNullChildren(testCase.NodeEmpty, testCase.TagEnum);
        await CheckSingleTextContentNode(testCase.NodeSingle, testCase.TagEnum, testCase.Single);
        await CheckMultipleTextContentNode(testCase.NodeSeveral, testCase.TagEnum, testCase.Text1, testCase.Text2);
        await CheckNodeEmptyChildren(testCase.NodeEmptyList, testCase.TagEnum);
    }

    #endregion

    #region Private methods

    private static async Task CheckSingleTextContentNode(Node node, TagEnum expectedTag, string expectedText)
    {
        await Assert.That(node.Tag).IsEqualTo(expectedTag);
        await Assert.That(node.Children).IsNotNull();
        await Assert.That(node.Children!.Count).IsEqualTo(1);
        await Assert.That(node.Children[0]).IsEqualTo<Node>(expectedText, s_nodeComparer);
    }

    private static async Task CheckMultipleTextContentNode(Node node, TagEnum expectedTag,
        params string[] expectedTexts)
    {
        await Assert.That(node.Tag).IsEqualTo(expectedTag);
        await Assert.That(node.Children).IsNotNull();
        await Assert.That(node.Children!.Count).IsEqualTo(expectedTexts.Length);
        for (int i = 0; i < expectedTexts.Length; ++i)
        {
            await Assert.That(node.Children[i].Value).IsEqualTo(expectedTexts[i]);
        }
    }

    private static async Task CheckNodeNullChildren(Node node, TagEnum expectedTag)
    {
        await Assert.That(node.Tag).IsEqualTo(expectedTag);
        await Assert.That(node.Children).IsNull();
    }

    private static async Task CheckNodeEmptyChildren(Node node, TagEnum expectedTag)
    {
        await Assert.That(node.Tag).IsEqualTo(expectedTag);
        await Assert.That(node.Children).IsNotNull().And.IsEmpty();
    }

    #endregion
}

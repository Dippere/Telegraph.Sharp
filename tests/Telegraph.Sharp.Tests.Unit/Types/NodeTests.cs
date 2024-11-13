using Telegraph.Sharp.Exceptions;
using Telegraph.Sharp.Tests.Unit.Data;
using Telegraph.Sharp.Types;
using Xunit;

namespace Telegraph.Sharp.Tests.Unit.Types;

public class NodeTests
{
    [Fact(DisplayName = "Empty")]
    public void Empty_Tests()
    {
        var node = new Node();
        Assert.Null(node.Children);
        Assert.Equal(TagEnum.P, node.Tag);
        node.Tag = TagEnum.H3;
        Assert.Equal(TagEnum.H3, node.Tag);
    }

    [Fact(DisplayName = "A")]
    public void A_Tests()
    {
        var node = Node.A();
        Assert.Equal(TagEnum.A, node.Tag);
        Assert.NotNull(node.Attributes);

        const string url = "https://example.com/";
        var node1 = Node.A(url);
        Assert.Equal(TagEnum.A, node1.Tag);
        Assert.Null(node1.Children);
        Assert.NotNull(node1.Attributes);
        Assert.Equal(url, node1.Attributes!.Href);


        const string child = "child";
        var node2 = Node.A(url, child);
        Assert.Equal(TagEnum.A, node2.Tag);
        Assert.NotNull(node2.Children);
        Assert.Single(node2.Children);
        Assert.Equal(child, node2.Children[0]);
        Assert.NotNull(node2.Attributes);
        Assert.Equal(url, node2.Attributes!.Href);

        const string child1 = "Text 1";
        const string child2 = "Text 2";
        var node3 = Node.A(url, child1, child2);

        Assert.Equal(TagEnum.A, node3.Tag);
        Assert.NotNull(node3.Children);
        Assert.Equal(2, node3.Children.Count);
        Assert.Equal(child1, node3.Children[0]);
        Assert.Equal(child2, node3.Children[1]);
        Assert.NotNull(node3.Attributes);
        Assert.Equal(url, node3.Attributes!.Href);


        var node4 = Node.A(url, Array.Empty<Node>());
        Assert.NotNull(node4.Children);
        Assert.Empty(node4.Children);
        Assert.NotNull(node4.Attributes);
        Assert.Equal(url, node4.Attributes!.Href);
    }

    [Fact(DisplayName = "Br")]
    public void Br_Tests()
    {
        CheckNodeNullChildren(Node.Br(), TagEnum.Br);
    }

    [Fact(DisplayName = "Hr")]
    public void Hr_Tests()
    {
        CheckNodeNullChildren(Node.Hr(), TagEnum.Hr);
    }

    [Fact(DisplayName = "Ol child test")]
    public void Ol_Tests()
    {
        var nodes = new List<List<Node>>
        {
            new()
            {
                Node.P("1"),
                Node.P("2"),
                Node.P("3")
            },
            new()
            {
                Node.P("4"),
                Node.P("5"),
                Node.P("6")
            }
        };
        var node5 = Node.Ol(nodes);
        Assert.Equal(TagEnum.Ol, node5.Tag);
        Assert.NotNull(node5.Children);
        Assert.Equal(2, node5.Children.Count);
        Assert.Equal(3, node5.Children[0].Children!.Count);
        Assert.Equal(3, node5.Children[1].Children!.Count);
        Assert.Equal(TagEnum.Li, node5.Children[0].Tag);
        Assert.Equal(TagEnum.Li, node5.Children[1].Tag);
    }

    [Fact(DisplayName = "Ul child test")]
    public void Ul_Tests()
    {
        var nodes = new List<List<Node>>
        {
            new()
            {
                Node.P("1"),
                Node.P("2"),
                Node.P("3")
            },
            new()
            {
                Node.P("4"),
                Node.P("5"),
                Node.P("6")
            }
        };
        var node5 = Node.Ul(nodes);
        Assert.Equal(TagEnum.Ul, node5.Tag);
        Assert.NotNull(node5.Children);
        Assert.Equal(2, node5.Children.Count);
        Assert.Equal(3, node5.Children[0].Children!.Count);
        Assert.Equal(3, node5.Children[1].Children!.Count);
        Assert.Equal(TagEnum.Li, node5.Children[0].Tag);
        Assert.Equal(TagEnum.Li, node5.Children[1].Tag);
    }

    [Fact(DisplayName = "Img")]
    public void Img_Tests()
    {
        var node = Node.Img();
        Assert.Equal(TagEnum.Img, node.Tag);
        Assert.NotNull(node.Attributes);
        Assert.Null(node.Attributes!.Href);
        Assert.Null(node.Attributes.Src);

        var src = "file.jpg";
        var node1 = Node.Img(src);
        Assert.Equal(TagEnum.Img, node1.Tag);
        Assert.NotNull(node1.Attributes);
        Assert.Null(node1.Attributes!.Href);
        Assert.NotNull(node1.Attributes.Src);
        Assert.Equal(src, node1.Attributes.Src);
    }

    [Fact(DisplayName = "Video")]
    public void Video_Tests()
    {
        var node = Node.Video();
        Assert.Equal(TagEnum.Video, node.Tag);
        Assert.NotNull(node.Attributes);
        Assert.Null(node.Attributes!.Href);
        Assert.Null(node.Attributes.Src);

        var src = "file.mp4";
        var node1 = Node.Video(src);
        Assert.Equal(TagEnum.Video, node1.Tag);
        Assert.NotNull(node1.Attributes);
        Assert.Null(node1.Attributes!.Href);
        Assert.NotNull(node1.Attributes.Src);
        Assert.Equal(src, node1.Attributes.Src);
    }

    [Fact(DisplayName = "Iframe")]
    public void Iframe_Tests()
    {
        var node = Node.Iframe();
        Assert.Equal(TagEnum.Iframe, node.Tag);
        Assert.NotNull(node.Attributes);
        Assert.Null(node.Attributes!.Href);
        Assert.Null(node.Attributes.Src);

        var url1 = "https://www.youtube.com/watch?v=123456";
        var node1 = Node.Iframe(url1);
        Assert.Equal("/embed/youtube?url=" + url1, node1.Attributes!.Src);

        var url2 = "https://vimeo.com/1234567";
        var node2 = Node.Iframe(url2);
        Assert.Equal("/embed/vimeo?url=" + url2, node2.Attributes!.Src);

        var url3 = "https://example.link/";
        var exception = Assert.Throws<TelegraphException>(() => Node.Iframe(url3));
        Assert.StartsWith("Invalid link.", exception.Message);

        var url4 = "https://www.youtu.be/watch?v=123456";
        var node4 = Node.Iframe(url4);
        Assert.Equal("/embed/youtube?url=" + url4, node4.Attributes!.Src);
    }

    [Fact(DisplayName = "Figure")]
    public void Figure_Tests()
    {
        var node = Node.Figure();
        Assert.Equal(TagEnum.Figure, node.Tag);

        const string text = "Heading";
        const string caption = "Caption";
        var node1 = Node.Figure(text, caption);
        Assert.Equal(TagEnum.Figure, node1.Tag);
        Assert.NotNull(node1.Children);
        Assert.Equal(2, node1.Children.Count);
        Assert.Equal(text, node1.Children[0]);
        Assert.Equal(caption, node1.Children[1]);
    }

    [Fact(DisplayName = "ImageFigure")]
    public void ImageFigure_Tests()
    {
        const string imgSrc = "image.jpg";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        var node = Node.ImageFigure(imgSrc, caption1, caption2);
        Assert.Equal(TagEnum.Figure, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Equal(TagEnum.Img, node.Children[0].Tag);
        Assert.Equal(TagEnum.Figcaption, node.Children[1].Tag);
        Assert.Equal(imgSrc, node.Children[0].Attributes!.Src);
        Assert.Equal(caption1, node.Children[1].Children![0]);
        Assert.Equal(caption2, node.Children[1].Children![1]);
    }

    [Fact(DisplayName = "VideFigure")]
    public void VideoFigure_Tests()
    {
        const string imgSrc = "video.mp4";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        var node = Node.VideoFigure(imgSrc, caption1, caption2);
        Assert.Equal(TagEnum.Figure, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Equal(TagEnum.Video, node.Children[0].Tag);
        Assert.Equal(TagEnum.Figcaption, node.Children[1].Tag);
        Assert.Equal(imgSrc, node.Children[0].Attributes!.Src);
        Assert.Equal(caption1, node.Children[1].Children![0]);
        Assert.Equal(caption2, node.Children[1].Children![1]);
    }

    [Fact(DisplayName = "IframeFigure")]
    public void IframeFigure_Tests()
    {
        const string imgSrc = "https://www.youtube.com/watch?v=123456";
        const string caption1 = "caption1";
        const string caption2 = "caption2";
        var node = Node.IframeFigure(imgSrc, caption1, caption2);
        Assert.Equal(TagEnum.Figure, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Equal(TagEnum.Iframe, node.Children[0].Tag);
        Assert.Equal(TagEnum.Figcaption, node.Children[1].Tag);
        Assert.Equal("/embed/youtube?url=" + imgSrc, node.Children[0].Attributes!.Src);
        Assert.Equal(caption1, node.Children[1].Children![0]);
        Assert.Equal(caption2, node.Children[1].Children![1]);
    }

    #region Structured Nodes

    [Theory(DisplayName = "Structured nodes")]
    [MemberData(nameof(NodesTestCase.TestCasesData), MemberType = typeof(NodesTestCase))]
    public void Structured_Nodes_Tests(NodesTestCase testCase)
    {
        CheckNodeNullChildren(testCase.NodeEmpty, testCase.TagEnum);
        CheckSingleTextContentNode(testCase.NodeSingle, testCase.TagEnum, testCase.Single);
        CheckMultipleTextContentNode(testCase.NodeSeveral, testCase.TagEnum, testCase.Text1, testCase.Text2);
        CheckNodeEmptyChildren(testCase.NodeEmptyList, testCase.TagEnum);
    }

    #endregion

    #region Private methods

    private static void CheckSingleTextContentNode(Node node, TagEnum expectedTag, string expectedText)
    {
        Assert.Equal(expectedTag, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Single(node.Children);
        Assert.Equal(expectedText, node.Children[0]);
    }

    private static void CheckMultipleTextContentNode(Node node, TagEnum expectedTag, params string[] expectedTexts)
    {
        Assert.Equal(expectedTag, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Equal(expectedTexts.Length, node.Children.Count);
        for (var i = 0; i < expectedTexts.Length; ++i) Assert.Same(expectedTexts[i], node.Children[i].Value);
    }

    private static void CheckNodeNullChildren(Node node, TagEnum expectedTag)
    {
        Assert.Equal(expectedTag, node.Tag);
        Assert.Null(node.Children);
    }

    private static void CheckNodeEmptyChildren(Node node, TagEnum expectedTag)
    {
        Assert.Equal(expectedTag, node.Tag);
        Assert.NotNull(node.Children);
        Assert.Empty(node.Children);
    }

    #endregion
}
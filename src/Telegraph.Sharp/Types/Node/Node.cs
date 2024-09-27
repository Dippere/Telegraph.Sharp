using System.Collections.Generic;
using System.Linq;
using Telegraph.Sharp.Exceptions;

namespace Telegraph.Sharp.Types;

public partial class Node
{
    private static Node CreateNode(TagEnum tag, IEnumerable<Node>? children = null, TagAttributes? attributes = null)
    {
        var node = new Node { Tag = tag };
        if (children is not null) node.Children = children.ToList();
        if (attributes is not null) node.Attributes = attributes;
        return node;
    }

    #region Static Methods

    #region P

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.P"/>.
    /// </summary>
    public static Node P() => CreateNode(TagEnum.P);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.P"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node P(string text) => CreateNode(TagEnum.P, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.P"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node P(IEnumerable<Node> nodes) => CreateNode(TagEnum.P, nodes);

    /// <inheritdoc cref="P(IEnumerable{Node})"/>
    public static Node P(params Node[] nodes) => CreateNode(TagEnum.P, nodes);

    #endregion

    #region H3

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H3"/>.
    /// </summary>
    public static Node H3() => CreateNode(TagEnum.H3);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H3"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node H3(string text) => CreateNode(TagEnum.H3, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H3"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node H3(IEnumerable<Node> nodes) => CreateNode(TagEnum.H3, nodes);

    /// <inheritdoc cref="H3(IEnumerable{Node})"/>
    public static Node H3(params Node[] nodes) => CreateNode(TagEnum.H3, nodes);

    #endregion

    #region H4

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H4"/>.
    /// </summary>
    public static Node H4() => CreateNode(TagEnum.H4);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H4"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node H4(string text) => CreateNode(TagEnum.H4, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.H4"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node H4(IEnumerable<Node> nodes) => CreateNode(TagEnum.H4, nodes);

    /// <inheritdoc cref="H4(IEnumerable{Node})"/>
    public static Node H4(params Node[] nodes) => CreateNode(TagEnum.H4, nodes);

    #endregion

    #region A

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.A"/>.
    /// </summary>
    public static Node A() => CreateNode(TagEnum.A, attributes: new TagAttributes());

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.A"/> and href attribute.
    /// </summary>
    /// <param name="href">Href value.</param>
    public static Node A(string href) => CreateNode(TagEnum.A, attributes: new TagAttributes { Href = href });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.A"/>, href attribute and a child node with given text.
    /// </summary>
    /// <param name="href">Href value.</param>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node A(string href, string text) =>
        CreateNode(TagEnum.A, new List<Node> { text }, new TagAttributes { Href = href });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.A"/>, href attribute and a child node with given text.
    /// </summary>
    /// <param name="href">Href value.</param>
    /// <param name="nodes">Child nodes.</param>
    public static Node A(string href, IEnumerable<Node> nodes) =>
        CreateNode(TagEnum.A, nodes, new TagAttributes { Href = href });


    /// <inheritdoc cref="A(string,IEnumerable{Node})"/>
    public static Node A(string href, params Node[] nodes) =>
        CreateNode(TagEnum.A, nodes, new TagAttributes { Href = href });

    #endregion

    #region B

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.B"/>.
    /// </summary>
    public static Node B() => CreateNode(TagEnum.B);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.B"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node B(string text) => CreateNode(TagEnum.B, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.B"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node B(IEnumerable<Node> nodes) => CreateNode(TagEnum.B, nodes);

    /// <inheritdoc cref="B(IEnumerable{Node})"/>
    public static Node B(params Node[] nodes) => CreateNode(TagEnum.B, nodes);

    #endregion

    #region I

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.I"/>.
    /// </summary>
    public static Node I() => CreateNode(TagEnum.I);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.I"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node I(string text) => CreateNode(TagEnum.I, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.I"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node I(IEnumerable<Node> nodes) => CreateNode(TagEnum.I, nodes);

    /// <inheritdoc cref="I(IEnumerable{Node})"/>
    public static Node I(params Node[] nodes) => CreateNode(TagEnum.I, nodes);

    #endregion

    #region Em

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Em"/>.
    /// </summary>
    public static Node Em() => CreateNode(TagEnum.Em);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Em"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Em(string text) => CreateNode(TagEnum.Em, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Em"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Em(IEnumerable<Node> nodes) => CreateNode(TagEnum.Em, nodes);

    /// <inheritdoc cref="Em(IEnumerable{Node})"/>
    public static Node Em(params Node[] nodes) => CreateNode(TagEnum.Em, nodes);

    #endregion

    #region U

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.U"/>.
    /// </summary>
    public static Node U() => CreateNode(TagEnum.U);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.U"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node U(string text) => CreateNode(TagEnum.U, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.U"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node U(IEnumerable<Node> nodes) => CreateNode(TagEnum.U, nodes);

    /// <inheritdoc cref="U(IEnumerable{Node})"/>
    public static Node U(params Node[] nodes) => CreateNode(TagEnum.U, nodes);

    #endregion

    #region S

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.S"/>.
    /// </summary>
    public static Node S() => CreateNode(TagEnum.S);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.S"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node S(string text) => CreateNode(TagEnum.S, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.S"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node S(IEnumerable<Node> nodes) => CreateNode(TagEnum.S, nodes);

    /// <inheritdoc cref="S(IEnumerable{Node})"/>
    public static Node S(params Node[] nodes) => CreateNode(TagEnum.S, nodes);

    #endregion

    #region Br

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Br"/>.
    /// </summary>
    public static Node Br() => CreateNode(TagEnum.Br);

    #endregion

    #region Code

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Code"/>.
    /// </summary>
    public static Node Code() => CreateNode(TagEnum.Code);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Code"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Code(string text) => CreateNode(TagEnum.Code, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Code"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Code(IEnumerable<Node> nodes) => CreateNode(TagEnum.Code, nodes);

    /// <inheritdoc cref="Code(IEnumerable{Node})"/>
    public static Node Code(params Node[] nodes) => CreateNode(TagEnum.Code, nodes);

    #endregion

    #region Pre

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Pre"/>.
    /// </summary>
    public static Node Pre() => CreateNode(TagEnum.Pre);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Pre"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Pre(string text) => CreateNode(TagEnum.Pre, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Pre"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Pre(IEnumerable<Node> nodes) => CreateNode(TagEnum.Pre, nodes);

    /// <inheritdoc cref="Pre(IEnumerable{Node})"/>
    public static Node Pre(params Node[] nodes) => CreateNode(TagEnum.Pre, nodes);

    #endregion

    #region Strong

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Strong"/>.
    /// </summary>
    public static Node Strong() => CreateNode(TagEnum.Strong);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Strong"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Strong(string text) => CreateNode(TagEnum.Strong, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Strong"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Strong(IEnumerable<Node> nodes) => CreateNode(TagEnum.Strong, nodes);

    /// <inheritdoc cref="Strong(IEnumerable{Node})"/>
    public static Node Strong(params Node[] nodes) => CreateNode(TagEnum.Strong, nodes);

    #endregion

    #region Aside

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Aside"/>.
    /// </summary>
    public static Node Aside() => CreateNode(TagEnum.Aside);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Aside"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Aside(string text) => CreateNode(TagEnum.Aside, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Aside"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Aside(IEnumerable<Node> nodes) => CreateNode(TagEnum.Aside, nodes);

    /// <inheritdoc cref="Aside(IEnumerable{Node})"/>
    public static Node Aside(params Node[] nodes) => CreateNode(TagEnum.Aside, nodes);

    #endregion

    #region Blockquote

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Blockquote"/>.
    /// </summary>
    public static Node Blockquote() => CreateNode(TagEnum.Blockquote);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Blockquote"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Blockquote(string text) => CreateNode(TagEnum.Blockquote, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Blockquote"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Blockquote(IEnumerable<Node> nodes) => CreateNode(TagEnum.Blockquote, nodes);

    /// <inheritdoc cref="Blockquote(IEnumerable{Node})"/>
    public static Node Blockquote(params Node[] nodes) => CreateNode(TagEnum.Blockquote, nodes);

    #endregion

    #region Hr

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Hr"/>.
    /// </summary>
    public static Node Hr() => CreateNode(TagEnum.Hr);

    #endregion

    #region Li

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Li"/>.
    /// </summary>
    public static Node Li() => CreateNode(TagEnum.Li);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Li"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Li(string text) => CreateNode(TagEnum.Li, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Li"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Li(IEnumerable<Node> nodes) => CreateNode(TagEnum.Li, nodes);

    /// <inheritdoc cref="Li(IEnumerable{Node})"/>
    public static Node Li(params Node[] nodes) => CreateNode(TagEnum.Li, nodes);

    #endregion

    #region Ol

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ol"/>.
    /// </summary>
    public static Node Ol() => CreateNode(TagEnum.Ol);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ol"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Ol(IEnumerable<Node> nodes) => CreateNode(TagEnum.Ol, nodes);

    /// <inheritdoc cref="Ol(IEnumerable{Node})"/>
    public static Node Ol(params Node[] nodes) => CreateNode(TagEnum.Ol, nodes);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ol"/> and given child nodes as <see cref="TagEnum.Li"/> nodes.
    /// </summary>
    /// <param name="lists">Child nodes.</param>
    public static Node Ol(IEnumerable<IEnumerable<Node>> lists) =>
        CreateNode(TagEnum.Ol, lists.Select(Li));

    #endregion

    #region Ul

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ul"/>.
    /// </summary>
    public static Node Ul() => CreateNode(TagEnum.Ul);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ul"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Ul(IEnumerable<Node> nodes) => CreateNode(TagEnum.Ul, nodes);

    /// <inheritdoc cref="Ul(IEnumerable{Node})"/>
    public static Node Ul(params Node[] nodes) => CreateNode(TagEnum.Ul, nodes);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Ul"/> and given child nodes as <see cref="TagEnum.Li"/> nodes.
    /// </summary>
    /// <param name="lists">Child nodes.</param>
    public static Node Ul(IEnumerable<IEnumerable<Node>> lists) =>
        CreateNode(TagEnum.Ul, lists.Select(Li));

    #endregion

    #region Img

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Img"/>.
    /// </summary>
    public static Node Img() => CreateNode(TagEnum.Img, attributes: new TagAttributes());

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Img"/> from provided link.
    /// </summary>
    /// <param name="src">Link to the image.</param>
    public static Node Img(string src) => CreateNode(TagEnum.Img, attributes: new TagAttributes { Src = src });

    #endregion

    #region Video

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Video"/>.
    /// </summary>
    public static Node Video() => CreateNode(TagEnum.Video, attributes: new TagAttributes());

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Video"/> from provided link.
    /// </summary>
    /// <param name="src">Link to the video.</param>
    public static Node Video(string src) => CreateNode(TagEnum.Video, attributes: new TagAttributes { Src = src });

    #endregion

    #region Iframe

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Iframe"/>.
    /// </summary>
    public static Node Iframe() => CreateNode(TagEnum.Iframe, attributes: new TagAttributes());

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Iframe"/> from provided link.
    /// </summary>
    /// <param name="src">Youtube, Vimeo or Twitter link.</param>
    public static Node Iframe(string src)
    {
        var resources = new Dictionary<string, string>
        {
            { "youtube.com", "youtube" },
            { "youtu.be", "youtube" },
            { "twitter.com", "twitter" },
            { "vimeo.com", "vimeo" }
        };

        if (!System.Uri.TryCreate(src, System.UriKind.Absolute, out var uri))
        {
            throw new TelegraphException("Invalid URL format.");
        }

        var host = uri.Host;
        foreach (var resource in resources)
        {
            if (host.EndsWith(resource.Key, System.StringComparison.OrdinalIgnoreCase))
            {
                return CreateNode(TagEnum.Iframe, attributes: new TagAttributes
                {
                    Src = $"/embed/{resource.Value}?url={src}"
                });
            }
        }

        throw new TelegraphException("Invalid link.");
    }

    #endregion

    #region Figcaption

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figcaption"/>.
    /// </summary>
    public static Node Figcaption() => CreateNode(TagEnum.Figcaption);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figcaption"/> and a child node with given text.
    /// </summary>
    /// <param name="text">Text to be added as a child node.</param>
    public static Node Figcaption(string text) => CreateNode(TagEnum.Figcaption, new List<Node> { text });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figcaption"/> and given child nodes.
    /// </summary>
    /// <param name="nodes">Child nodes.</param>
    public static Node Figcaption(IEnumerable<Node> nodes) => CreateNode(TagEnum.Figcaption, nodes);

    /// <inheritdoc cref="Figcaption(IEnumerable{Node})"/>
    public static Node Figcaption(params Node[] nodes) => CreateNode(TagEnum.Figcaption, nodes);

    #endregion

    #region Figure

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figure"/>.
    /// </summary>
    public static Node Figure() => CreateNode(TagEnum.Figure);

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figure"/> and provided caption.
    /// </summary>
    /// <param name="node"><see cref="TagEnum.Img"/>, <see cref="TagEnum.Video"/> or <see cref="TagEnum.Iframe"/> node.</param>
    /// <param name="caption">Caption to be added as a child node.</param>
    public static Node Figure(Node node, Node caption) => CreateNode(TagEnum.Figure, new List<Node> { node, caption });

    /// <summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figure"/> with <see cref="TagEnum.Img"/> and given child nodes.
    /// </summary>
    /// <param name="imgSrc">Link to the image.</param>
    /// <param name="captionNodes">Child nodes to be added as caption.</param>
    public static Node ImageFigure(string imgSrc, IEnumerable<Node> captionNodes) =>
        Figure(Img(imgSrc), Figcaption(captionNodes));

    /// <inheritdoc cref="ImageFigure(string, IEnumerable{Node})"/>
    public static Node ImageFigure(string imgSrc, params Node[] captionNodes) => ImageFigure(imgSrc, captionNodes.ToList());

    ///<summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figure"/> with <see cref="TagEnum.Video"/> and given child nodes.
    /// </summary>
    /// <param name="videoSrc">Link to the video.</param>
    /// <param name="captionNodes">Child nodes to be added as caption.</param>
    public static Node VideoFigure(string videoSrc, IEnumerable<Node> captionNodes) =>
        Figure(Video(videoSrc), Figcaption(captionNodes));

    /// <inheritdoc cref="VideoFigure(string, IEnumerable{Node})"/>
    public static Node VideoFigure(string videoSrc, params Node[] captionNodes) => VideoFigure(videoSrc, captionNodes.ToList());

    ///<summary>
    /// Creates a <see cref="Node"/> with tag <see cref="TagEnum.Figure"/> with <see cref="TagEnum.Iframe"/> and given child nodes.
    /// </summary>
    /// <param name="iframeSrc">Youtube, Vimeo or Twitter link.</param>
    /// <param name="captionNodes">Child nodes to be added as caption.</param>
    public static Node IframeFigure(string iframeSrc, IEnumerable<Node> captionNodes) =>
        Figure(Iframe(iframeSrc), Figcaption(captionNodes));

    /// <inheritdoc cref="IframeFigure(string, IEnumerable{Node})"/>
    public static Node IframeFigure(string iframeSrc, params Node[] captionNodes) =>
        IframeFigure(iframeSrc, captionNodes.ToList());

    #endregion

    #endregion
}
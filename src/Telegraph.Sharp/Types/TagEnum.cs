using System.Text.Json.Serialization;
using Telegraph.Sharp.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     Name of the DOM element.
/// </summary>
[JsonConverter(typeof(TagEnumConverter))]
public enum TagEnum
{
    /// <summary>
    ///     Paragraph.
    /// </summary>
    P,

    /// <summary>
    ///     Hyperlink.
    /// </summary>
    A,

    /// <summary>
    ///     Aside content.
    /// </summary>
    Aside,

    /// <summary>
    ///     <b>Bold</b> text.
    /// </summary>
    B,

    /// <summary>
    ///     Quoted block.
    /// </summary>
    Blockquote,

    /// <summary>
    ///     Single line break.
    /// </summary>
    Br,

    /// <summary>
    ///     <c>Code</c> block.
    /// </summary>
    Code,

    /// <summary>
    ///     <i>Italic</i> text.
    /// </summary>
    Em,

    /// <summary>
    ///     Caption for a <see cref="Figure" /> element.
    /// </summary>
    Figcaption,

    /// <summary>
    ///     Self-contained content like image, illustration, diagram, code snippet, etc.
    /// </summary>
    Figure,

    /// <summary>
    ///     Heading 3.
    /// </summary>
    H3,

    /// <summary>
    ///     Heading 4.
    /// </summary>
    H4,

    /// <summary>
    ///     Horizontal line.
    /// </summary>
    Hr,

    /// <summary>
    ///     Italic text.
    /// </summary>
    I,

    /// <summary>
    ///     Embedded iframe.
    /// </summary>
    Iframe,

    /// <summary>
    ///     Image.
    /// </summary>
    Img,

    /// <summary>
    ///     List item.
    /// </summary>
    Li,

    /// <summary>
    ///     Ordered list.
    /// </summary>
    Ol,

    /// <summary>
    ///     Preformatted text.
    /// </summary>
    Pre,

    /// <summary>
    ///     Strikethrough text.
    /// </summary>
    S,

    /// <summary>
    ///     Strongly emphasized text.
    /// </summary>
    Strong,

    /// <summary>
    ///     Underlined text.
    /// </summary>
    U,

    /// <summary>
    ///     Unordered list.
    /// </summary>
    Ul,

    /// <summary>
    ///     Embedded video.
    /// </summary>
    Video
}

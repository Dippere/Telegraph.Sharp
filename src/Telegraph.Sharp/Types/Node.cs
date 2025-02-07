using System.Collections.Generic;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a DOM element node.
/// </summary>
[JsonConverter(typeof(NodeConverter))]
public partial class Node
{
    /// <summary>
    ///     The value of the node.
    /// </summary>
    [JsonIgnore]
    public string Value { get; set; } = null!;

    /// <summary>
    ///     Name of the DOM element. Available tags: a, aside, b, blockquote, br, code, em, figcaption, figure, h3, h4, hr, i,
    ///     iframe, img, li, ol, p, pre, s, strong, u, ul, video.
    /// </summary>
    [JsonPropertyName("tag")]
    public TagEnum Tag { get; set; }

    /// <summary>
    ///     Optional. Attributes of the DOM element. Key of object represents name of attribute, value represents value of
    ///     attribute. Available attributes: href, src.
    /// </summary>
    [JsonPropertyName("attrs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public TagAttributes? Attributes { get; set; }

    /// <summary>
    ///     Optional. List of child nodes for the DOM element.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Node>? Children { get; set; }

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="Node" />.
    /// </summary>
    public Node()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Node" /> with value.
    /// </summary>
    public Node(string value) => Value = value;

    #endregion

    #region Conversion Operators

    /// <summary>
    ///     Defines an implicit conversion of a <see cref="Node" /> object to a string data type.
    /// </summary>
    /// <param name="node">A Node object.</param>
    /// <returns>A string that represents the value of the node.</returns>
    public static implicit operator string(Node node) => node.Value;

    /// <summary>
    ///     Defines an implicit conversion of a string data type to a <see cref="Node" /> object.
    /// </summary>
    /// <param name="value">A string value.</param>
    /// <returns>A new instance of a Node object with the value set to the provided string.</returns>
    public static implicit operator Node(string value) => new(value);

    #endregion
}

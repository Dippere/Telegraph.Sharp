using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Converters;

internal class NodeConverter : JsonConverter<Node>
{
    public override bool CanConvert(Type objectType) => objectType == typeof(Node);

    public override Node Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var rootElement = document.RootElement;
        if (rootElement.ValueKind == JsonValueKind.String)
        {
            return new Node { Value = rootElement.GetString()! };
        }
        var node = new Node();

        if (rootElement.TryGetProperty("tag", out var tagElement))
        {
            node.TagValue = tagElement.GetString()!;
        }

        if (rootElement.TryGetProperty("attrs", out var attrsElement))
        {
            node.Attributes = attrsElement.Deserialize<TagAttributes>(options);
        }

        if (rootElement.TryGetProperty("children", out var childrenElement))
        {
            node.Children = childrenElement.Deserialize<List<Node>>(options);
        }

        return node;
    }


    public override void Write(Utf8JsonWriter writer, Node value, JsonSerializerOptions options)
    {
        if (!string.IsNullOrEmpty(value.Value))
        {
            writer.WriteStringValue(value.Value);
            return;
        }
        writer.WriteStartObject();
        writer.WriteString("tag", value.TagValue);
        if (value.Attributes != null)
        {
            writer.WritePropertyName("attrs");
            JsonSerializer.Serialize(writer, value.Attributes, options);
        }
        if (value.Children is { Count: > 0 })
        {
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.Children, options);
        }

        writer.WriteEndObject();
    }

}
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Serialization;

internal class NodeConverter : JsonConverter<Node>
{

    public override Node Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        JsonElement rootElement = document.RootElement;
        return rootElement.ValueKind switch
        {
            JsonValueKind.String => new Node { Value = rootElement.GetString()! },
            JsonValueKind.Object => new Node
            {
                Tag = rootElement.TryGetProperty("tag", out JsonElement tagElement) ? JsonSerializer.Deserialize(tagElement, SourceGenerationContext.Default.TagEnum): default,
                Attributes = rootElement.TryGetProperty("attrs", out JsonElement attrsElement) ? JsonSerializer.Deserialize(attrsElement, SourceGenerationContext.Default.TagAttributes) : default,
                Children = rootElement.TryGetProperty("children", out JsonElement childrenElement) ? JsonSerializer.Deserialize(childrenElement,SourceGenerationContext.Default.ListNode) : default
            },
            _ => throw new JsonException("Invalid node")
        };
    }

    public override void Write(Utf8JsonWriter writer, Node value, JsonSerializerOptions options)
    {
        if (!string.IsNullOrEmpty(value.Value))
        {
            writer.WriteStringValue(value.Value);
            return;
        }
        writer.WriteStartObject();
        writer.WritePropertyName("tag");
        JsonSerializer.Serialize(writer, value.Tag, SourceGenerationContext.Default.TagEnum);
        if (value.Attributes is not null)
        {
            writer.WritePropertyName("attrs");
            JsonSerializer.Serialize(writer, value.Attributes, SourceGenerationContext.Default.TagAttributes);
        }
        if (value.Children is { Count: > 0 })
        {
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.Children, SourceGenerationContext.Default.ListNode);
        }

        writer.WriteEndObject();
    }
}

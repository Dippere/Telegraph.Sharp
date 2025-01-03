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
                Tag = rootElement.TryGetProperty("tag", out JsonElement tagElement) ? tagElement.Deserialize(TelegraphSerializerContext.Default.TagEnum): default,
                Attributes = rootElement.TryGetProperty("attrs", out JsonElement attrsElement) ? attrsElement.Deserialize(TelegraphSerializerContext.Default.TagAttributes) : null,
                Children = rootElement.TryGetProperty("children", out JsonElement childrenElement) ? childrenElement.Deserialize(TelegraphSerializerContext.Default.ListNode) : null
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
        JsonSerializer.Serialize(writer, value.Tag, TelegraphSerializerContext.Default.TagEnum);
        if (value.Attributes is not null)
        {
            writer.WritePropertyName("attrs");
            JsonSerializer.Serialize(writer, value.Attributes, TelegraphSerializerContext.Default.TagAttributes);
        }
        if (value.Children is { Count: > 0 })
        {
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.Children, TelegraphSerializerContext.Default.ListNode);
        }

        writer.WriteEndObject();
    }
}

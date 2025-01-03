﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Serialization;

internal class NodeConverter : JsonConverter<Node>
{
    public override bool CanConvert(Type objectType) => objectType == typeof(Node);

    public override Node Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var rootElement = document.RootElement;
        return rootElement.ValueKind switch
        {
            JsonValueKind.String => new Node { Value = rootElement.GetString()! },
            JsonValueKind.Object => new Node
            {
                Tag = rootElement.TryGetProperty("tag", out var tagElement) ? tagElement.Deserialize<TagEnum>(options) : default,
                Attributes = rootElement.TryGetProperty("attrs", out var attrsElement) ? attrsElement.Deserialize<TagAttributes>(options) : default,
                Children = rootElement.TryGetProperty("children", out var childrenElement) ? childrenElement.Deserialize<List<Node>>(options) : default
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
        JsonSerializer.Serialize(writer, value.Tag, options);
        if (value.Attributes is not null)
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

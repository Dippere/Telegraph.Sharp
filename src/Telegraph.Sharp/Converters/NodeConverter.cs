using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Converters;

internal class NodeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(Node);

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var node = new Node();
        var token = JToken.Load(reader);

        if (token.Type != JTokenType.Object)
        {
            node.Value = token.ToString();
            return node;
        }

        var type = typeof(Node);
        foreach (var property in type.GetProperties())
        {
            var name = property.Name;
            var attributes = property.GetCustomAttributes(false);

            if (attributes.Any(att => att is JsonIgnoreAttribute)) continue;

            var jsonPropertyAttribute = attributes.FirstOrDefault(att => att is JsonPropertyAttribute);
            if (jsonPropertyAttribute is JsonPropertyAttribute attr) name = attr.PropertyName;

            property.SetValue(node, token[name!]?.ToObject(property.PropertyType));
        }

        if (node.Attributes is { Href: null, Src: null }) node.Attributes = null;
        return node;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var node = value as Node;

        if (node?.Value != null)
        {
            writer.WriteValue(node.Value);
        }
        else
        {
            writer.WriteStartObject();

            var type = value!.GetType();

            foreach (var item in type.GetProperties().Where(v => v.Name != nameof(Node.Children)))
            {
                var name = item.Name;
                var attrs = item.GetCustomAttributes(false);


                if (attrs.Any(v => v is JsonIgnoreAttribute)) continue;
                foreach (JsonPropertyAttribute attr in attrs.Where(v => v is JsonPropertyAttribute))
                    name = attr.PropertyName;
                writer.WritePropertyName(name!);
                serializer.Serialize(writer, item.GetValue(value));
            }

            var childrenProp = type.GetProperties().FirstOrDefault(v => v.Name == nameof(Node.Children));
            var clildrenName = childrenProp!.Name;

            var childrenPropAtrs = childrenProp.GetCustomAttributes(false);
            foreach (JsonPropertyAttribute attr in childrenPropAtrs.Where(v => v is JsonPropertyAttribute))
                clildrenName = attr.PropertyName;

            writer.WritePropertyName(clildrenName!);
            serializer.Serialize(writer, childrenProp.GetValue(value));

            writer.WriteEndObject();
        }
    }
}
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Extensions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Serialization;

internal sealed class TagEnumConverter : JsonConverter<TagEnum>
{
    public override TagEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException("Invalid tag");
        string s = reader.GetString()!.CapitalizeFirstLetter();
#if NET6_0_OR_GREATER
        return Enum.Parse<TagEnum>(s);
#else
        return (TagEnum)Enum.Parse(typeof(TagEnum), s);
#endif
    }

    public override void Write(Utf8JsonWriter writer, TagEnum value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().MinimizeFirstLetter());
    }
}

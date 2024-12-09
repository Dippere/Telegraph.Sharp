using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Serialization;

internal sealed class TagEnumConverter() : JsonStringEnumConverter<TagEnum>(JsonNamingPolicy.SnakeCaseLower);

using System.Text.Json;

namespace Telegraph.Sharp.Tests.Unit.Data;

public static class SerialOpt
{
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };
}
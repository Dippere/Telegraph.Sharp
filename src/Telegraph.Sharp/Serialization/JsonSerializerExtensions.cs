using System.Text.Json;

namespace Telegraph.Sharp.Serialization;

internal static class JsonSerializerDefaultOptions
{
   public static readonly JsonSerializerOptions JsonSerializerOpt = new()
   {
      PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
   };
}
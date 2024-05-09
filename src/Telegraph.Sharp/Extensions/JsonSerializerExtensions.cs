using System.Text.Json;

namespace Telegraph.Sharp.Extensions;

internal static class JsonSerializerExtensions
{
   public static readonly JsonSerializerOptions JsonSerializerOpt = new()
   {
      PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
   };
}
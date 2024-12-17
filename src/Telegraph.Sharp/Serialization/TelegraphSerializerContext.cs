using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Serialization;


/// <summary>
/// <see cref="JsonSerializerContext"/> for Telegraph API.
/// </summary>
[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
// Serialization
[JsonSerializable(typeof(CreateAccount), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(CreatePage), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(EditAccountInfo), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(EditPage), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(GetAccountInfo), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(GetPage), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(GetPageList), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(GetViews), GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(RevokeAccessToken), GenerationMode = JsonSourceGenerationMode.Serialization)]
// Deserialization
[JsonSerializable(typeof(TagAttributes))]
[JsonSerializable(typeof(TagEnum))]
[JsonSerializable(typeof(TelegraphApiResponse<Account>))]
[JsonSerializable(typeof(TelegraphApiResponse<PageList>))]
[JsonSerializable(typeof(TelegraphApiResponse<Page>))]
[JsonSerializable(typeof(TelegraphApiResponse<PageViews>))]
public partial class TelegraphSerializerContext : JsonSerializerContext;

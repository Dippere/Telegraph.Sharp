using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to create a new Telegraph account.
///     On success, returns an <see cref="Account" /> object.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CreateAccount : ApiRequestBase<Account>
{
    /// <summary>
    ///     Initializes a new request with shortName.
    /// </summary>
    /// <param name="shortName">
    ///     Account name, helps users with several accounts remember which they are currently using.
    ///     Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
    /// </param>
    public CreateAccount(string shortName) : base("createAccount") => ShortName = shortName;

    /// <summary>
    ///     Required. Account name, helps users with several accounts remember which they are currently using.
    ///     Displayed to the user above the "Edit/Publish" button on Telegra.ph, other users don't see this name.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string ShortName { get; }

    /// <summary>
    ///     Default author name used when creating new articles.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorName { get; set; }

    /// <summary>
    ///     Default profile link, opened when users click on the author's name below the title.
    ///     Can be any link, not necessarily to a Telegram profile or channel.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string? AuthorUrl { get; set; }
}
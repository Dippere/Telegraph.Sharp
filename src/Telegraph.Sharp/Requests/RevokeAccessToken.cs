using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to revoke <see cref="AccessToken" /> of account and generate a new one.
///     On success, returns an <see cref="Account" /> object with new <see cref="Account.AccessToken" /> and
///     <see cref="Account.AuthUrl" /> fields.
/// </summary>
public class RevokeAccessToken : ApiRequestBase<Account>, IAccessTokenTarget
{
    /// <summary>
    ///     Initializes a new request with accessToken.
    /// </summary>
    /// <param name="accessToken">Access token of the Telegraph account.</param>
    public RevokeAccessToken(string accessToken) : base("revokeAccessToken") => AccessToken = accessToken;

    /// <inheritdoc />
    public string AccessToken { get; init; }
}

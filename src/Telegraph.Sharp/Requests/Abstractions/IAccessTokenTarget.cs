namespace Telegraph.Sharp.Requests.Abstractions;

/// <summary>
///     Represents a request having <see cref="AccessToken" /> parameter.
/// </summary>
public interface IAccessTokenTarget
{
    /// <summary>
    ///     Access token of the Telegraph account.
    /// </summary>
    string AccessToken { get; }
}

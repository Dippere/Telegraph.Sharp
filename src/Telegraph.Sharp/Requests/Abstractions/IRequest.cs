using System.Net.Http;

namespace Telegraph.Sharp.Requests.Abstractions;

/// <summary>
///     Represents a request.
/// </summary>
public interface IRequest
{
    /// <summary>
    ///     Method name.
    /// </summary>
    string MethodName { get; }

    /// <summary>
    ///     Generate content of HTTP message.
    /// </summary>
    /// <returns>Content of HTTP request.</returns>
    HttpContent? ToHttpContent();
}
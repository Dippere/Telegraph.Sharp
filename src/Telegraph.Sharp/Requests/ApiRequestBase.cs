using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Serialization;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Represents an API request.
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result.</typeparam>
public abstract class ApiRequestBase<TResponse> : IRequest<TResponse>
{
    /// <summary>
    ///     Initializes an instance of request.
    /// </summary>
    /// <param name="methodName">API method.</param>
    protected ApiRequestBase(string methodName) => MethodName = methodName;

    /// <inheritdoc />
    [JsonIgnore]
    public string MethodName { get; }

    /// <inheritdoc />
    public virtual HttpContent ToHttpContent()
    {
        var content = new StringContent(
            JsonSerializer.Serialize(this, GetType(), JsonSerializerDefaultOptions.JsonSerializerOpt),
            Encoding.UTF8,
            "application/json"
        );
        content.Headers.ContentType!.CharSet = null;
        return content;
    }
}

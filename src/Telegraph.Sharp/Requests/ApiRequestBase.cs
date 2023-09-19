using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegraph.Sharp.Requests.Abstractions;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Represents an API request.
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result.</typeparam>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
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
            JsonConvert.SerializeObject(this),
            Encoding.UTF8,
            "application/json"
        );
        content.Headers.ContentType!.CharSet = null;
        return content;
    }
}
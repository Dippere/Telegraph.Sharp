using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegraph.Sharp.Exceptions;
using Telegraph.Sharp.Extensions;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp;


/// <summary>
///     A client to use the Telegraph API.
/// </summary>
public sealed class TelegraphClient : ITelegraphClient
{
    private readonly HttpClient _httpClient;

    /// <summary>
    ///     Create a new <see cref="TelegraphClient" /> instance.
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="httpClient">A custom <see cref="HttpClient"/>.</param>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="accessToken" /> format is invalid.
    /// </exception>
    public TelegraphClient(string accessToken, HttpClient? httpClient = null) : this(httpClient) =>
        AccessToken = !string.IsNullOrEmpty(accessToken)
            ? accessToken
            : throw new ArgumentNullException(nameof(accessToken));


    /// <summary>
    ///     Create a new <see cref="TelegraphClient" /> instance.
    /// </summary>
    /// <param name="httpClient">A custom <see cref="HttpClient" />.</param>
    public TelegraphClient(HttpClient? httpClient = null) => _httpClient = httpClient ?? new HttpClient();

    /// <inheritdoc/>
    public string? AccessToken { get; set; }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is null or request is <see cref="IAccessTokenTarget"/> and <see cref="AccessToken"/> is null.
    /// </exception>
    /// <exception cref="RequestException">
    ///     Request failed.
    /// </exception>
    public async Task<TResponse> MakeApiRequestAsync<TResponse>(
     IRequest<TResponse> request,
     CancellationToken cancellationToken = default)
    {
        if (request is IAccessTokenTarget && AccessToken is null)
            throw new ArgumentNullException(nameof(AccessToken));

        return await MakeRequestAsync(
            request,
            $"{Constants.TelegpaphApi}/{request.MethodName}",
            async (httpResponse) =>
            {
                var apiResponse = await httpResponse.DeserializeContentAsync<TelegraphApiResponse<TResponse>>().ConfigureAwait(false);
                if (apiResponse.Ok is false)
                    throw new RequestException(apiResponse.Error!);

                return apiResponse.Result!;
            },
            cancellationToken
        ).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is null.
    /// </exception>
    /// <exception cref="RequestException">
    ///     Request failed.
    /// </exception>
    public async Task<TResponse> MakeNonApiRequestAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default) where TResponse : class =>
        await MakeRequestAsync(
            request,
            $"{Constants.Telegpaph}/{request.MethodName}",
            async httpResponse => await httpResponse.DeserializeContentAsync<TResponse>().ConfigureAwait(false),
            cancellationToken
        ).ConfigureAwait(false);


    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is null.
    /// </exception>
    /// <exception cref="RequestException">
    ///     Request failed.
    /// </exception>
    public async Task<TResponse> MakeRequestAsync<TResponse>(
        IRequest<TResponse> request,
        string url,
        Func<HttpResponseMessage, Task<TResponse>> deserializeFunc,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
        httpRequest.Content = request.ToHttpContent();

        using var httpResponse = await SendRequestAsync(_httpClient, httpRequest, cancellationToken).ConfigureAwait(false);
        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new RequestException($"Response with code: {httpResponse.StatusCode}");

        return await deserializeFunc(httpResponse).ConfigureAwait(false);
    }
    
    private static async Task<HttpResponseMessage> SendRequestAsync(
        HttpClient httpClient,
        HttpRequestMessage httpRequest,
        CancellationToken cancellationToken)
    {
        HttpResponseMessage? httpResponse;
        try
        {
            httpResponse = await httpClient
                .SendAsync(httpRequest, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (TaskCanceledException exception)
        {
            if (cancellationToken.IsCancellationRequested) throw;

            throw new RequestException("Request timed out", exception);
        }
        catch (Exception exception)
        {
            throw new RequestException(
                "Exception during making request",
                exception
            );
        }

        return httpResponse;
    }
}
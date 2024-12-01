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
    /// <inheritdoc/>
    public string? AccessToken { get; init; }
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
    /// <exception cref="ArgumentNullException">
    /// <paramref name="request"/> is null.
    /// </exception>
    /// <exception cref="RequestException">
    ///     Request failed.
    /// </exception>
    public async Task<TResponse> MakeRequestAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        switch (request)
        {
            case null:
                throw new ArgumentNullException(nameof(request));
            case IAccessTokenTarget when AccessToken == null:
                throw new ArgumentNullException(nameof(AccessToken));
        }

        using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{Constants.TelegpaphApiUrl}/{request.MethodName}");
        httpRequest.Content = request.ToHttpContent();

        using HttpResponseMessage httpResponse = await SendRequestAsync(_httpClient, httpRequest, cancellationToken).ConfigureAwait(false);
        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new RequestException($"Response with code: {httpResponse.StatusCode}");

        TelegraphApiResponse<TResponse> apiResponse = await httpResponse.DeserializeContentAsync<TelegraphApiResponse<TResponse>>().ConfigureAwait(false);
        if (apiResponse.Ok is false)
            throw new RequestException(apiResponse.Error!);

        return apiResponse.Result!;
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
            if (cancellationToken.IsCancellationRequested)
                throw;

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

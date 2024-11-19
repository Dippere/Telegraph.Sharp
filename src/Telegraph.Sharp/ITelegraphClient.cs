using System.Threading;
using System.Threading.Tasks;
using Telegraph.Sharp.Requests.Abstractions;

namespace Telegraph.Sharp;

/// <summary>
/// A client interface to use the Telegraph API.
/// </summary>
public interface ITelegraphClient
{
    /// <summary>
    /// Access token of the Telegraph account.
    /// </summary>
    string? AccessToken { get; init; }

    /// <summary>
    /// Send a request.
    /// </summary>
    /// <typeparam name="TResponse">Type of expected result in the response object.</typeparam>
    /// <param name="request">Request object.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Result of the request.</returns>
    Task<TResponse> MakeRequestAsync<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken = default);
}

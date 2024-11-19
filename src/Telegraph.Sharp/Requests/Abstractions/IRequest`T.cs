namespace Telegraph.Sharp.Requests.Abstractions;

/// <summary>
///     Represents a request.
/// </summary>
/// <typeparam name="TResponse">Type of result expected in result.</typeparam>
public interface IRequest<TResponse> : IRequest;

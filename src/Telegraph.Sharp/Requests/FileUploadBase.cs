using System.Collections.Generic;
using System.Net.Http;
using Telegraph.Sharp.Requests.Abstractions;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///   Represents an upload request.
/// </summary>
public abstract class FileUploadBase : IRequest<List<TelegraphFile>>
{
    /// <inheritdoc/>
    public string MethodName => "upload";
    
    /// <inheritdoc/>
    public abstract HttpContent? ToHttpContent();
}
using System.Collections.Generic;
using System.Net.Http;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to upload files to Telegraph.
///     Returns a list of <see cref="TelegraphFile"/> objects.
/// </summary>
public sealed class UploadFiles : FileUploadBase
{
    /// <summary>
    /// Initializes a new request with filesToUpload.
    /// </summary>
    /// <param name="filesToUpload">
    /// The files that will be uploaded to Telegraph.
    /// </param>
    public UploadFiles(List<FileToUpload> filesToUpload) => FilesToUpload = filesToUpload;
    
    /// <summary>
    /// Required. The files that will be uploaded to Telegraph.
    /// </summary>
    public List<FileToUpload> FilesToUpload { get; }
    
    
    /// <inheritdoc />
    public override HttpContent ToHttpContent()
    {
        var requestContent = new MultipartFormDataContent();
        requestContent.Headers.ContentType!.MediaType = "multipart/form-data";
        for (var i = 0; i < FilesToUpload.Count; i++)
        {
            var fileContent = FilesToUpload[i].ToStreamContent();
            requestContent.Add(fileContent, $"{i}", $"{i}.{FilesToUpload[i].FileType.ToString().ToLower()}");
        }

        return requestContent;

    }
}
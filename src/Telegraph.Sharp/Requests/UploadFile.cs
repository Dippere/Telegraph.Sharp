using System.Net.Http;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp.Requests;

/// <summary>
///     Use this method to upload single file to Telegraph.
///     Returns a list of <see cref="TelegraphFile"/> with one object inside it.
/// </summary>
public sealed class UploadFile : FileUploadBase 
{
    /// <summary>
    /// Required. The file that will be uploaded to Telegraph.
    /// </summary>
    public FileToUpload FileToUpload { get; }

    /// <summary>
    ///   Initializes a new request with fileToUpload.
    /// </summary>
    /// <param name="fileToUpload">
    ///     The file that will be uploaded to Telegraph.
    /// </param>
    public UploadFile(FileToUpload fileToUpload) => FileToUpload = fileToUpload;
  
    
    /// <inheritdoc />
    public override HttpContent ToHttpContent()
    {
        var requestContent = new MultipartFormDataContent();
        requestContent.Headers.ContentType!.MediaType = "multipart/form-data";
        requestContent.Add(FileToUpload.ToStreamContent(), "file", $"file.{FileToUpload.FileType.ToString().ToLower()}");
        return requestContent;
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegraph.Sharp.Requests;
using Telegraph.Sharp.Types;

namespace Telegraph.Sharp;

/// <summary>
///     Extension methods that map to requests.
/// </summary>
public static partial class TelegraphClientExtension
{

    /// <summary>
    /// Use this method to upload file to Telegraph.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="fileToUpload">File that will be uploaded to the Telegraph.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an <see cref="TelegraphFile"/> object.</returns>
    public static async Task<TelegraphFile> UploadFileAsync(
        this ITelegraphClient telegraphClient,
        FileToUpload fileToUpload, 
        CancellationToken cancellationToken = default) =>
        (await telegraphClient.MakeNonApiRequestAsync(new UploadFile(fileToUpload), cancellationToken)
            .ConfigureAwait(false)).First();


    /// <summary>
    /// Use this method to upload files to Telegraph.
    /// </summary>
    /// <param name="telegraphClient">An instance of <see cref="ITelegraphClient"/>.</param>
    /// <param name="filesToUpload">A list of <see cref="FileToUpload"/> that will be uploaded to the Telegraph.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>Returns an list of <see cref="TelegraphFile"/> object.</returns>
    public static async Task<List<TelegraphFile>> UploadFilesAsync(
        this ITelegraphClient telegraphClient,
        List<FileToUpload> filesToUpload, 
        CancellationToken cancellationToken = default)
    {
        var result = new List<TelegraphFile>(filesToUpload.Count);
        var parts = GetBySize(filesToUpload);
        for (var i = 0; i < parts.Count; i++)
        {
            var uploaded = await telegraphClient.UploadSeveralFiles(parts[i], cancellationToken).ConfigureAwait(false);
            result.AddRange(uploaded);
        }
        return result;
    }
    
    
    
    private static List<List<FileToUpload>> GetBySize(IReadOnlyList<FileToUpload> fileToUploads)
    {
        const long maxSize = 20 * 1024 * 1024; //maxsize for one post upload request
        var result = new List<List<FileToUpload>>();
        var currentGroup = new List<FileToUpload>();
        long currentSize = 0;

        for (var i = 0; i < fileToUploads.Count; i++)
        {
            var fileSize = fileToUploads[i].Content.Length;
            
            if (currentSize + fileSize > maxSize)
            {
                result.Add(currentGroup);
                currentGroup = new List<FileToUpload>();
                currentSize = 0;
            }

            currentGroup.Add(fileToUploads[i]);
            currentSize += fileSize;
        }
        if (currentGroup.Count > 0)
        {
            result.Add(currentGroup);
        }

        return result;
    }
    
    private static async Task<List<TelegraphFile>> UploadSeveralFiles(
        this ITelegraphClient telegraphClient,
        List<FileToUpload> files,
        CancellationToken token = default) =>
        await telegraphClient.MakeNonApiRequestAsync(
            new UploadFiles(files),token
        ).ConfigureAwait(false);
}
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Telegraph.Sharp.Exceptions;

namespace Telegraph.Sharp.Types;

/// <summary>
/// This object represents a file that will be uploaded to the Telegraph.
/// </summary>
public class FileToUpload
{
    private FileToUpload(Stream content, FileTypeEnum type)
    {
        Content = content;
        FileType = type;
        Type = FileType switch 
        {
            FileTypeEnum.MP4 => "video/mp4",
            FileTypeEnum.PNG => "image/png",
            FileTypeEnum.JPEG => "image/jpeg",
            FileTypeEnum.GIF => "image/gif",
            FileTypeEnum.JPG => "image/jpg",
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }

    /// <summary>
    /// File content represented as <see cref="Stream"/> object.
    /// </summary>
    public Stream Content { get;  }
    
    /// <summary>
    /// <see cref="FileTypeEnum"/> value.
    /// </summary>
    public FileTypeEnum FileType { get;  }

    /// <summary>
    /// Mediatype value.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Creates a <see cref="FileTypeEnum.JPEG"/>-format <see cref="FileToUpload"/>.
    /// </summary>
    /// <param name="content">File content represented as <see cref="Stream"/> object.</param>
    public static FileToUpload Jpeg(Stream content) => new FileToUpload(content, FileTypeEnum.JPEG);

    /// <summary>
    /// Creates a <see cref="FileTypeEnum.PNG"/>-format <see cref="FileToUpload"/>.
    /// </summary>
    /// <param name="content">File content represented as <see cref="Stream"/> object.</param>
    public static FileToUpload Png(Stream content) => new FileToUpload(content, FileTypeEnum.PNG);
    
    /// <summary>
    /// Creates a <see cref="FileTypeEnum.MP4"/>-format <see cref="FileToUpload"/>.
    /// </summary>
    /// <param name="content">File content represented as <see cref="Stream"/> object.</param>
    public static FileToUpload Mp4(Stream content) => new FileToUpload(content, FileTypeEnum.MP4);
    
    /// <summary>
    /// Creates a <see cref="FileTypeEnum.GIF"/>-format <see cref="FileToUpload"/>.
    /// </summary>
    /// <param name="content">File content represented as <see cref="Stream"/> object.</param>
    public static FileToUpload Gif(Stream content) => new FileToUpload(content, FileTypeEnum.GIF);
    
    /// <summary>
    /// Creates a <see cref="FileTypeEnum.JPG"/>-format <see cref="FileToUpload"/>.
    /// </summary>
    /// <param name="content">File content represented as <see cref="Stream"/> object.</param>
    public static FileToUpload Jpg(Stream content) => new FileToUpload(content, FileTypeEnum.JPG);
    
    /// <summary>
    /// Creates a new instance of <see cref="StreamContent"/> from this <see cref="FileToUpload"/>.
    /// </summary>
    /// <exception cref="TelegraphException">File size is greater than 5 MB.</exception>
    public StreamContent ToStreamContent()
    {
        const long maxFileSize = 5 * 1024 * 1024;
        if (Content.Length > maxFileSize)
        {
            throw new TelegraphException("File size is greater than 5 MB.");
        }
        return new StreamContent(Content)
        {
            Headers = { ContentType = MediaTypeHeaderValue.Parse(Type) }
        };
    }
}
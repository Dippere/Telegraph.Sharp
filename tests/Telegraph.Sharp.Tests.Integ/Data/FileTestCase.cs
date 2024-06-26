﻿using Telegraph.Sharp.Types;
using Xunit;

namespace Telegraph.Sharp.Tests.Integ.Data;

public record FileTestCase
{
    public FileTestCase(string path, FileTypeEnum fileType)
    {
        const string filesPath = "Files/";
        var stream = File.OpenRead(filesPath + path);
        FileToUpload = fileType switch
        {
            FileTypeEnum.MP4 => FileToUpload.Mp4(stream),
            FileTypeEnum.JPEG => FileToUpload.Jpeg(stream),
            FileTypeEnum.PNG => FileToUpload.Png(stream),
            FileTypeEnum.JPG => FileToUpload.Jpg(stream),
            FileTypeEnum.GIF => FileToUpload.Gif(stream),
            _ => throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null)
        };
    }

    public FileToUpload FileToUpload { get; }

    public static IEnumerable<FileTestCase> TestCases =>
    [
        new FileTestCase("test.jpg",FileTypeEnum.JPG),
        new FileTestCase("test.png",FileTypeEnum.PNG),
        new FileTestCase("test.mp4",FileTypeEnum.MP4),
        new FileTestCase("test.gif",FileTypeEnum.GIF),
        new FileTestCase("test.jpeg",FileTypeEnum.JPEG)
    ];

    public static FileTestCase Mp4MaxSize => new("test10MB.mp4", FileTypeEnum.MP4);

    public static readonly TheoryData<FileTestCase> TestCasesData = new(TestCases);

    public override string ToString() => FileToUpload.FileType.ToString();
}
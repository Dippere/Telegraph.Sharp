﻿using System.IO;
using System.Text.Json;
using Telegraph.Sharp.Serialization;

namespace Telegraph.Sharp.Extensions;

internal static class StreamExtensions
{
    /// <summary>
    ///     Deserialized JSON in Stream into <typeparamref name="T" />.
    /// </summary>
    /// <param name="stream"><see cref="Stream" /> with content.</param>
    /// <typeparam name="T">Type of the resulting object.</typeparam>
    /// <returns>Deserialized instance of <typeparamref name="T" /> or <c>null</c>.</returns>
    public static T? DeserializeJsonFromStream<T>(this Stream? stream)
        where T : class
    {
        if (stream is null || !stream.CanRead)
        {
            return null;
        }
        T? searchResult = JsonSerializer.Deserialize(stream, typeof(T), TelegraphSerializerContext.Default) as T;
        return searchResult;
    }
}

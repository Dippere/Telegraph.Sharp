﻿using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Telegraph.Sharp.Exceptions;

namespace Telegraph.Sharp.Extensions;

internal static class HttpResponseMessageExtensions
{
    /// <summary>
    ///     Deserialize body from HttpContent into <typeparamref name="T" />.
    /// </summary>
    /// <param name="httpResponse"><see cref="HttpResponseMessage" /> instance.</param>
    /// <typeparam name="T">Type of the resulting object.</typeparam>
    /// <returns></returns>
    /// <exception cref="RequestException">
    ///     Thrown when body in the response can not be deserialized into <typeparamref name="T" />.
    /// </exception>
    internal static async Task<T> DeserializeContentAsync<T>(
        this HttpResponseMessage httpResponse)
        where T : class
    {
        Stream? contentStream = null;

        if (httpResponse.Content is null)
        {
            throw new RequestException(
                "Response doesn't contain any content",
                httpResponse.StatusCode
            );
        }

        try
        {
            T? deserializedObject;

            try
            {
                contentStream = await httpResponse.Content
                    .ReadAsStreamAsync()
                    .ConfigureAwait(false);

                deserializedObject = contentStream
                    .DeserializeJsonFromStream<T>();
            }
            catch (Exception exception)
            {
                throw CreateRequestException(
                    httpResponse,
                    "Required properties not found in response",
                    exception
                );
            }

            if (deserializedObject is null)
            {
                throw CreateRequestException(
                    httpResponse,
                    "Required properties not found in response"
                );
            }
            return deserializedObject;
        }
        finally
        {
            if (contentStream is not null)
            {
#if NET6_0_OR_GREATER
                await contentStream.DisposeAsync().ConfigureAwait(false);
#else
                contentStream.Dispose();
#endif
            }
        }
    }

    private static RequestException CreateRequestException(
        HttpResponseMessage httpResponse,
        string message,
        Exception? exception = null
    ) =>
        exception is null
            ? new RequestException(
                message,
                httpResponse.StatusCode
            )
            : new RequestException(
                message,
                httpResponse.StatusCode,
                exception
            );
}

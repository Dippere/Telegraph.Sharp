using System;
using System.Runtime.Serialization;

namespace Telegraph.Sharp.Exceptions;


/// <summary>
/// Represents a inner library exception.
/// </summary>
public class TelegraphException : Exception
{

    /// <summary>
    /// Initializes a new instance of the <see cref="TelegraphException" /> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public TelegraphException(string message) : base(message)
    {
    }
}
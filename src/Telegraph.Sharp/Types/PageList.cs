using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a list of Telegraph articles belonging to an account. Most recently created articles first.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class PageList : IEnumerable<Page>
{
    /// <summary>
    ///     Total number of pages belonging to the target Telegraph account.
    /// </summary>
    [JsonProperty]
    public int TotalCount { get; set; }

    /// <summary>
    ///     Requested pages of the target Telegraph account.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<Page> Pages { get; set; } = null!;

    #region IEnumarable implementation

    /// <inheritdoc />
    public IEnumerator<Page> GetEnumerator() => Pages.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
}
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Telegraph.Sharp.Types;

/// <summary>
///     This object represents a list of Telegraph articles belonging to an account. Most recently created articles first.
/// </summary>
public class PageList
{
    /// <summary>
    ///     Total number of pages belonging to the target Telegraph account.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    ///     Requested pages of the target Telegraph account.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<Page> Pages { get; set; } = null!;

}
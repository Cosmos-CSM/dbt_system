using CSM_Database_Core.Entities.Abstractions.Bases;

using System.Text.Json.Serialization;

namespace DBT_System.Abstractions.Bases;

/// <summary>
///     Represents a [CSM Database System] entity base with naming identification.
/// </summary>
/// <remarks>
///     Usage must be exclusively for [CSM Database System] entities.
/// </remarks>
public abstract class SystemNamedEntityBase
    : NamedEntityBase
{

    /// <inheritdoc/>
    [JsonIgnore]
    public override Type Database { get; init; } = typeof(SystemDatabase);

}

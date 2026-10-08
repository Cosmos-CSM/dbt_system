using CSM_Database_Core.Entities.Abstractions.Bases;

using DBT_System.Abstractions.Interfaces;

namespace DBT_System.Abstractions.Bases;

/// <summary>
/// Represents a state entity base class that extends NamedEntityBase and adds a State property.
/// </summary>
public abstract class StateNamedEntityBase
 : NamedEntityBase, IStateReference
{
    /// <inheritdoc/>
    public long State { get; set; }
}

using CSM_Database_Core.Depots.Abstractions.Interfaces;

using CSM_System_Database_Core.Entities;

namespace CSM_System_Database_Core.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents an entities depot provider for <see cref="Configuration"/>.
/// </summary>
public interface IConfigurationsDepot
    : IDepot<Configuration> {
}

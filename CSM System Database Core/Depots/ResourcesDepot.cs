using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using CSM_System_Database_Core.Depots.Abstractions.Interfaces;
using CSM_System_Database_Core.Entities;

namespace CSM_System_Database_Core.Depots;

/// <inheritdoc cref="IResourcesDepot"/>
public class ResourcesDepot
    : DepotBase<SystemDatabase, Resource>, IResourcesDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="Database">
    ///     System database context dependency.
    /// </param>
    /// <param name="Disposer">
    ///     Data disposition context manager.
    /// </param>
    public ResourcesDepot(SystemDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}

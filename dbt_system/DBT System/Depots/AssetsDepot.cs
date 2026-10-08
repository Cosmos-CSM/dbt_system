using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using DBT_System.Depots.Abstractions.Interfaces;
using DBT_System.Entities;

namespace DBT_System.Depots;

/// <inheritdoc cref="IAssetsDepot"/>
public class AssetsDepot
    : DepotBase<SystemDatabase, Asset>, IAssetsDepot {

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="Database">
    ///     System database context dependency.
    /// </param>
    /// <param name="Disposer">
    ///     Data disposition context manager.
    /// </param>
    public AssetsDepot(SystemDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}

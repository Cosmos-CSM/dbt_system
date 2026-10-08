using CSM_Database_Core.Depots.Abstractions.Interfaces;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Database_Testing.Abstractions.Bases;
using CSM_Database_Testing.Disposing.Abstractions.Bases;

using DBT_System;

using DBT_System_Testing.Managers;

namespace DBT_System_Testing.Abstractions.Bases;

/// <summary>
///     Represents an <see cref="SystemDatabase"/> integration tests base for a Depot.
/// </summary>
/// <typeparam name="TEntity">
///     Type of the <see cref="IEntity"/> being handled.
/// </typeparam>
/// <typeparam name="TDepot">
///     Type of the <see cref="IDepot{TEntity}"/> being tested.
/// </typeparam>
public abstract class SystemDepotIntegrationTestsBase<TEntity, TDepot>
    : DepotIntegrationTestsBase<TEntity, TDepot, SystemDatabase>
    where TEntity : class, IEntity, new()
    where TDepot : class, IDepot<TEntity> {

    /// <summary>
    ///     System testing data store manager.
    /// </summary>
    new protected readonly StoreManager _storeManager;

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="databaseFactory">
    ///     Main database factory 
    /// </param>
    /// <param name="databaseFactories">
    ///     Collateral used databases factories to be used, this are usually needed when the <typeparamref name="TEntity"/> used has dependencies on a different <see cref="CSM_Database_Core.Abstractions.Interfaces.IDatabase"/> source than it's own context.
    /// </param>
    protected SystemDepotIntegrationTestsBase(DatabaseFactory? databaseFactory = null, params DatabaseFactory[] databaseFactories)
        : base(databaseFactory, databaseFactories) {

        _storeManager = new StoreManager(
                base._storeManager
            );
    }
}
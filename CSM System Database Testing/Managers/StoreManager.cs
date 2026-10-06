using CSM_Database_Testing.Managers;
using CSM_System_Database_Core.Entities;
using CSM_System_Database_Testing.Utils;

namespace CSM_System_Database_Testing.Managers;

/// <summary>
///     Represents a test data storing handler for <see cref="CSM_System_Database_Core.SystemDatabase"/> entities.
/// </summary>
public class StoreManager {

    readonly TestingStoreManager _storeManager;

    /// <summary>
    ///     Creates a new instance
    /// </summary>
    /// <param name="storeManager">
    ///     Testing data store manager.
    /// </param>
    public StoreManager(TestingStoreManager storeManager) {
        _storeManager = storeManager;
    }

    /// <summary>
    /// Create and store a new <see cref="EntityState"/> entity in the database.
    /// </summary>
    /// <param name="ref"></param>
    /// <returns></returns>
    public async Task<EntityState> StoreEntityState(EntityState? @ref = null) {
        EntityState entityState = DraftUtils.EntityState(@ref);
        return await _storeManager.Store(entityState);
    }

    /// <summary>
    /// Create and store a new <see cref="Asset"/> entity in the database.
    /// </summary>
    /// <param name="ref"></param>
    /// <returns></returns>
    public async Task<Asset> StoreAsset(Asset? @ref = null) {
        Asset asset = DraftUtils.Asset(@ref);
        return await _storeManager.Store(asset);
    }

    /// <summary>
    /// Create and store a new <see cref="Resource"/> entity in the database.
    /// </summary>
    /// <param name="ref"></param>
    /// <returns></returns>
    public async Task<Resource> StoreResource(Resource? @ref = null) {
        Resource resource = DraftUtils.Resource(@ref);

        if (resource.Type == null || resource.Type?.Id <= 0) {
            resource.Type = await StoreAsset(resource.Type);
        }

        return await _storeManager.Store(resource);
    }
    /// <summary>
    /// Create and store a new <see cref="Configuration"/> entity in the database.
    /// </summary>
    /// <param name="ref"></param>
    /// <returns></returns>
    public async Task<Configuration> StoreConfiguration(Configuration? @ref = null) {
        Configuration resource = DraftUtils.Configuration(@ref);
        return await _storeManager.Store(resource);
    }

}

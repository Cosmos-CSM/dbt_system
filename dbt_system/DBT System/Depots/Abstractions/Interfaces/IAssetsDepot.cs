using CSM_Database_Core.Depots.Abstractions.Interfaces;

using DBT_System.Entities;

namespace DBT_System.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents an entities depot provider for <see cref="Asset"/>.
/// </summary>
public interface IAssetsDepot
    : IDepot<Asset> {
}

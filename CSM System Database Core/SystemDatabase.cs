using System.Resources;

using CSM_Database_Core;
using CSM_Database_Core.Core.Models;

using CSM_System_Database_Core.Entities;

using Microsoft.EntityFrameworkCore;


namespace CSM_System_Database_Core;

/// <summary>
///     Represents a [CSM System] database context.
/// </summary>
public class SystemDatabase
    : DatabaseBase<SystemDatabase> {

    /// <summary>
    ///     Database signature
    /// </summary>
    public override string Sign { get; protected set; } = "CSMSys";

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public SystemDatabase()
        : base() {
    }

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    /// <param name="databaseOptions">
    ///     Database context options.
    /// </param>
    public SystemDatabase(DatabaseOptions<SystemDatabase> databaseOptions)
        : base(databaseOptions) {
    }


    /// <summary>
    ///     EntityStates DB Set.
    /// </summary>
    public DbSet<Entities.EntityState> EntityStates { get; set; } = default!;

    /// <summary>
    ///     Assets DB Set.
    /// </summary>
    public DbSet<Asset> Assets { get; set; } = default!;

    /// <summary>
    ///     Configurations DB Set.
    /// </summary>
    public DbSet<Configuration> Configurations { get; set; } = default!;

    /// <summary>
    ///     Resources DB Set.
    /// </summary>
    public DbSet<Resource> Resources { get; set; } = default!;

}
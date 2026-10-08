using CSM_Database_Core.Core.Attributes;

using DBT_System.Abstractions.Bases;
namespace DBT_System.Entities;

/// <summary>
///     Represents a specific resource asset within the system database.
/// </summary>
public class Asset :
    SystemNamedEntityBase {


    /// <summary>
    ///     Resources data.
    /// </summary>
    [EntityRelation]
    public ICollection<Resource> Resources { get; set; } = [];
}

using CSM_Database_Core.Core.Attributes;

using CSM_System_Database_Core.Abstractions.Bases;
namespace CSM_System_Database_Core.Entities;

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

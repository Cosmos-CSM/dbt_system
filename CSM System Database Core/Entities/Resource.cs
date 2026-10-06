using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;
using CSM_Database_Core.Validation;

using CSM_System_Database_Core.Abstractions.Bases;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSM_System_Database_Core.Entities;
/// <summary>
///     Represesnts a local or external resource within the system database.
/// </summary>
public class Resource :
    SystemNamedEntityBase {

    /// <summary>
    ///     Whether the resource has a local or network access resource.
    /// </summary>
    [ExclusiveValidator("type")]
    public string? Local { get; set; }

    /// <summary>
    ///     Whether the resource has a remote access resource.
    /// </summary>
    [ExclusiveValidator("type")]
    public string? External { get; set; }

    /// <summary>
    ///     Resource type, such as a file or hyper link.
    /// </summary>
    [EntityRelation]
    public Asset Type { get; set; } = default!;

    /// <summary>
    /// Custom design entity
    /// </summary>
    /// <param name="etBuilder"></param>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        base.DesignEntity(etBuilder);

        etBuilder.Link<Resource, Asset>(
              nameof(Type),
              isRequired: true,
              isAutoLoaded: true
          );
    }

}

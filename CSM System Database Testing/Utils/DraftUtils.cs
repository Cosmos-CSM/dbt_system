using CSharp_Extension.Common.Enums;
using CSharp_Extension.Common.Utils;

using CSM_Database_Testing;
using CSM_System_Database_Core.Entities;

namespace CSM_System_Database_Testing.Utils;


/// <summary>
///     Handles [CSM System Database] objects drafting for testing purposes.
/// </summary>
static public class DraftUtils
{

    /// <summary>
    ///     Gets a new random 16 length string.
    /// </summary>
    static string Epy => RandomUtils.String(16);

    /// <summary>
    ///     Drafts a <see cref="EntityState"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="EntityState"/>.
    /// </returns>
    static public EntityState EntityState(EntityState? @ref = null)
    {
        @ref = BaseDraftUtils.NamedEntity(@ref);
        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="Resource"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="Resource"/>.
    /// </returns>
    static public Resource Resource(Resource? @ref = null) {
        @ref = BaseDraftUtils.NamedEntity(@ref);
        @ref.Local = @ref.Local ?? "local@" + Epy;
        @ref.Type = @ref.Type;
        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="Asset"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="Asset"/>.
    /// </returns>
    static public Asset Asset(Asset? @ref = null) {
        @ref = BaseDraftUtils.NamedEntity(@ref);
        return @ref;
    }

    /// <summary>
    ///     Drafts a <see cref="Configuration"/> data.
    /// </summary>
    /// <param name="ref">
    ///     Default entity data.
    /// </param>
    /// <returns>
    ///     A drafted <see cref="Configuration"/>.
    /// </returns>
    static public Configuration Configuration(Configuration? @ref = null) {
        @ref = BaseDraftUtils.NamedEntity(@ref);
        @ref.Path = @ref.Path ?? "def_path@" + Epy;
        @ref.Value = @ref.Value;
        @ref.IsArray = @ref.IsArray;
        @ref.ValueReferenceType = @ref.ValueReferenceType;
        @ref.ScalarValueType = @ref.ScalarValueType ?? ScalarValues.STRING;
        @ref.ReferenceValueType = @ref.ReferenceValueType;
        return @ref;
    }
}

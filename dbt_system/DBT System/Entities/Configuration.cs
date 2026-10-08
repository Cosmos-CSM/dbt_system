using CSharp_Extension.Common.Enums;

using CSM_Database_Core.Validation;

using DBT_System.Abstractions.Bases;

namespace DBT_System.Entities;

/// <summary>
///     Specifies how the value of a <see cref="Configuration"/> should be interpreted.
/// </summary>
public enum ValueReference {

    /// <summary>
    ///     The value is a literal, scalar value.
    /// </summary>
    SCALAR,

    /// <summary>
    ///     The value is a reference to another entity or resource.
    /// </summary>
    REFERENCE,
}

/// <summary>
///     Represents a specific topics configuration within the system database.
/// </summary>
public class Configuration :
    SystemNamedEntityBase {

    /// <summary>
    ///     The path of the configuration, which can be used for group configurations.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    ///     The value of the configuration, which can be a literal value or a reference to another entity/resource.
    /// </summary>
    public byte[] Value { get; set; } = [];

    /// <summary>
    ///     Indicates whether the configuration value is an array of values.
    /// </summary>
    public bool IsArray { get; set; }

    /// <summary>
    ///     Specifies how the value of the configuration should be interpreted (as a scalar value or a reference).
    /// </summary>
    public ValueReference ValueReferenceType { get; set; }

    /// <summary>
    ///     The type of the value when <see cref="ValueReferenceType"/> is <see cref="ValueReference.SCALAR"/>.
    /// </summary>
    [ExclusiveValidator("value")]
    public ScalarValues? ScalarValueType { get; set; }

    /// <summary>
    ///     The type name of the value when <see cref="ValueReferenceType"/> is <see cref="ValueReference.REFERENCE"/>.
    /// </summary>
    [ExclusiveValidator("value")]
    public string? ReferenceValueType { get; set; }

}

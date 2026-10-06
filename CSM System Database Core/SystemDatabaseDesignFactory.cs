
using CSharp_Extension.Common.Utils;

using Microsoft.EntityFrameworkCore.Design;

namespace CSM_System_Database_Core;

/// <summary>
///     EF Design time factory for <see cref="SystemDatabase"/>
/// </summary>
internal class SystemDatabaseDesignFactory
    : IDesignTimeDbContextFactory<SystemDatabase> {


    public SystemDatabase CreateDbContext(string[] args) {
        ConsoleUtils.Warning(
            "Designing database using a design factory",
            new Dictionary<string, object?> {
                { "DesignFactory", GetType().FullName },
                { "Database", typeof(SystemDatabase).FullName  },
            }
        );

        return new SystemDatabase();
    }

}

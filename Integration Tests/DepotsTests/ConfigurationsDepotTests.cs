using CSM_Database_Core.Depots.Models;

using CSM_System_Database_Core.Depots;
using CSM_System_Database_Core.Entities;

using CSM_System_Database_Testing.Abstractions.Bases;
using CSM_System_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="AssetsDepot"/>
/// </summary>
public class ConfigurationsDepotTests
    : SystemDepotIntegrationTestsBase<Configuration, ConfigurationDepot> {

    protected override Configuration EntityFactory(string entropy) {
        return DraftUtils.Configuration();
    }

    public override async Task Update_Single_Success() {
        // Expectation
        Configuration expConfiguration = await _storeManager.StoreConfiguration();

        string? oldDescription = expConfiguration.Description;
        ValueReference? oldReferenceValueType = expConfiguration.ValueReferenceType;

        expConfiguration.Description = "New description";
        expConfiguration.ValueReferenceType = ValueReference.REFERENCE;
        //Acting
        UpdateOutput<Configuration> actOutput = await _depot.Update(
                new QueryInput<Configuration, UpdateInput<Configuration>> {
                    Parameters = new UpdateInput<Configuration> {
                        Entity = expConfiguration,
                    }
                }
            );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.Equal(oldReferenceValueType, actOutput.Original.ValueReferenceType);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
        Assert.NotEqual(actOutput.Original.ValueReferenceType, actOutput.Updated.ValueReferenceType);

    }
}

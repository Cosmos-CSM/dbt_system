using CSM_Database_Core.Depots.Models;

using CSM_System_Database_Core.Depots;
using CSM_System_Database_Core.Entities;

using CSM_System_Database_Testing.Abstractions.Bases;
using CSM_System_Database_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="AssetsDepot"/>
/// </summary>
public class AssetsDepotTests
    : SystemDepotIntegrationTestsBase<Asset, AssetsDepot> {

    protected override Asset EntityFactory(string entropy) {
        return DraftUtils.Asset();
    }

    public override async Task Update_Single_Success() {
        // Expectation
        Asset expAsset = await _storeManager.StoreAsset();

        string? oldDescription = expAsset.Description;
        expAsset.Description = "New description";

        //Acting
        UpdateOutput<Asset> actOutput = await _depot.Update(
                new QueryInput<Asset, UpdateInput<Asset>> {
                    Parameters = new UpdateInput<Asset> {
                        Entity = expAsset,
                    }
                }
            );

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
    }
}

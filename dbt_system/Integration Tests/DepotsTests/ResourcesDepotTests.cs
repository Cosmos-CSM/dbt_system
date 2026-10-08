using CSM_Database_Core.Depots.Models;

using DBT_System.Depots;
using DBT_System.Entities;

using DBT_System_Testing.Abstractions.Bases;
using DBT_System_Testing.Utils;

namespace Integration_Tests.DepotsTests;

/// <summary>
///     Integration tests class for <see cref="ResourcesDepot"/>
/// </summary>
public class ResourcesDepotTests
    : SystemDepotIntegrationTestsBase<Resource, ResourcesDepot> {

    protected override Resource EntityFactory(string entropy) {
        return DraftUtils.Resource(
            new Resource {
                Name = $"Resource_{entropy}",
                Description = $"Description_{entropy}",
                Local = $"Local_{entropy}",
                Type = _storeManager.StoreAsset().GetAwaiter().GetResult(),
            }
        );
    }

    public override async Task Update_Single_Success() {
        // Expectation
        Resource expResource = await _storeManager.StoreResource();

        Asset expAsset = await _storeManager.StoreAsset();
        expResource.Type = expAsset;

        string? oldDescription = expResource.Description;
        expResource.Description = "New description";
        expResource.Local = "New Local";

        //Acting
        UpdateOutput<Resource> actOutput = await _depot.Update(
                new QueryInput<Resource, UpdateInput<Resource>> {
                    Parameters = new UpdateInput<Resource> {
                        Entity = expResource,
                    }
                }
            );

        Resource? ogResource = actOutput.Original;
        Resource newResource = actOutput.Updated;

        // Asserting
        Assert.NotNull(actOutput.Original);
        Assert.Equal(ogResource?.Id, newResource.Id);
        Assert.Equal(oldDescription, actOutput.Original.Description);
        Assert.NotEqual(actOutput.Original.Description, actOutput.Updated.Description);
        Assert.NotEqual(actOutput.Original.Local, actOutput.Updated.Local);
        Assert.NotEqual(ogResource?.Type.Id, newResource.Type.Id);


    }
}

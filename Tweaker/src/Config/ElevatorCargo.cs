using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class ElevatorCargo : DataTransfer.ConfigBaseMultiple<DataTransfer.ElevatorCargo>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(ElevatorCargoCage_SpawnObjectiveItemsInLandingArea));
                break;
            }
        }
    }
}

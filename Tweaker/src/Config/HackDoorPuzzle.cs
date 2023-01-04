using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class HackDoorPuzzle : DataTransfer.ConfigBaseMultiple<DataTransfer.HackDoorPuzzle>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(LG_SecurityDoor_Locks_SetupForChainedPuzzle));
                break;
            }
        }
    }
}

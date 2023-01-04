using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class ResourcePack : DataTransfer.ConfigBaseMultiple<DataTransfer.ResourcePack>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(PlayerBackpackManager_PickupHealthRel));
                Plugin.Harmony.PatchAll(typeof(PlayerBackpackManager_ReceiveAmmoGive));
                break;
            }
        }
    }
}

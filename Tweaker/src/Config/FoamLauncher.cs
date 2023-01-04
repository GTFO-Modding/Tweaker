using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class FoamLauncher : DataTransfer.ConfigBaseMultiple<DataTransfer.FoamLauncher>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(GlueGun_Setup));
                break;
            }
        }
    }
}

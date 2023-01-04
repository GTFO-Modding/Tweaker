using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class BioTracker : DataTransfer.ConfigBaseMultiple<DataTransfer.BioTracker>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(EnemyScanner_Setup));
                break;
            }
        }
    }
}

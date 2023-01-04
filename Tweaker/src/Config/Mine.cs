using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class Mine : DataTransfer.ConfigBaseMultiple<DataTransfer.Mine>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(MineDeployerFirstPerson_Setup));
                Plugin.Harmony.PatchAll(typeof(MineDeployerInstance_Detonate_Explosive_Setup));
                break;
            }
        }
    }
}

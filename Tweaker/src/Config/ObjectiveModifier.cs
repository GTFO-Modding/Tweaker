using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class ObjectiveModifier : DataTransfer.ConfigBaseMultiple<DataTransfer.ObjectiveModifier>
{
    public override void OnConfigLoaded()
    {
        foreach(var config in Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(CM_PageLoadout_UpdatePageData));
                break;
            }
        }
    }
}

using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class RundownLayout : DataTransfer.ConfigBaseSingle<DataTransfer.RundownLayout>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(CM_PageRundown_New_UpdateExpeditionIconProgression));
            Plugin.Harmony.PatchAll(typeof(CM_PageRundown_New_Update));
        }
    }
}

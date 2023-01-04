using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class PageExpeditionResult : DataTransfer.ConfigBaseSingle<DataTransfer.PageExpeditionResult>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(CM_PageExpeditionFail_Setup));
            Plugin.Harmony.PatchAll(typeof(CM_PageExpeditionSuccess_Setup));
        }
    }
}

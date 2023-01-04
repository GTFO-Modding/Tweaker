using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class PlayerAIBot : DataTransfer.ConfigBaseSingle<DataTransfer.PlayerAIBot>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(WardenObjectiveManager_OnLocalPlayerStartExpedition_2));
        }
    }
}

using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class InfectionSpitter : DataTransfer.ConfigBaseSingle<DataTransfer.InfectionSpitter>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(WardenObjectiveManager_OnLocalPlayerStartExpedition_3));
            Plugin.Harmony.PatchAll(typeof(InfectionSpitter_TryPlaySound));
        }
    }
}

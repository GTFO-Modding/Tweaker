using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class WeakDoorDamage : DataTransfer.ConfigBaseSingle<DataTransfer.WeakDoorDamage>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(LG_WeakDoorBladeDamage_MeleeDamage));
            Plugin.Harmony.PatchAll(typeof(LG_WeakDoor_AttemptDamage));
        }
    }
}

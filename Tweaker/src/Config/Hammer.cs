using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;
class Hammer : DataTransfer.ConfigBaseMultiple<DataTransfer.Hammer>
{
    public override void OnConfigLoaded()
    {
        foreach (var config in this.Config)
        {
            if (config.internalEnabled)
            {
                Plugin.Harmony.PatchAll(typeof(MeleeWeaponFirstPerson_Setup));
                Plugin.Harmony.PatchAll(typeof(MeleeWeaponFirstPerson_OnWield));
                Plugin.Harmony.PatchAll(typeof(Dam_EnemyDamageLimb_MeleeDamage));
                break;
            }
        }

    }
}

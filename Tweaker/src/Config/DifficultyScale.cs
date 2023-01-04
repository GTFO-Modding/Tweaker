using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class DifficultyScale : DataTransfer.ConfigBaseSingle<DataTransfer.DifficultyScale>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            Plugin.Harmony.PatchAll(typeof(BulletWeapon_BulletHit));
            Plugin.Harmony.PatchAll(typeof(CP_Bioscan_Core_Master_OnPlayerScanChangedCheckProgress));
            Plugin.Harmony.PatchAll(typeof(Dam_PlayerDamageBase_OnIncomingDamage));
            Plugin.Harmony.PatchAll(typeof(EnemyCostManager_AddCost));
            Plugin.Harmony.PatchAll(typeof(MeleeWeaponFirstPerson_DoAttackDamage));
        }
    }
}

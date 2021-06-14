using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class DifficultyScale : DataTransfer.ConfigBaseSingle<DataTransfer.DifficultyScale>
    {
        public override void OnConfigLoaded()
        {
            if (this.Config.internalEnabled)
            {
                BasePlugin.Instance.PatchAll(typeof(BulletWeapon_BulletHit));
                BasePlugin.Instance.PatchAll(typeof(CP_Bioscan_Core_Master_OnPlayerScanChangedCheckProgress));
                BasePlugin.Instance.PatchAll(typeof(Dam_PlayerDamageBase_OnIncomingDamage));
                BasePlugin.Instance.PatchAll(typeof(EnemyCostManager_AddCost));
                BasePlugin.Instance.PatchAll(typeof(MeleeWeaponFirstPerson_DoAttackDamage));
            }
        }
    }
}

using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class Hammer : DataTransfer.ConfigBaseMultiple<DataTransfer.Hammer>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(MeleeWeaponFirstPerson_Setup));
                    BasePlugin.Instance.PatchAll(typeof(MeleeWeaponFirstPerson_OnWield));
                    BasePlugin.Instance.PatchAll(typeof(MWS_Chargeup_Enter));
                    BasePlugin.Instance.PatchAll(typeof(MWS_ChargeUp_Update));
                    BasePlugin.Instance.PatchAll(typeof(Dam_EnemyDamageLimb_MeleeDamage));
                    break;
                }
            }

        }
    }
}

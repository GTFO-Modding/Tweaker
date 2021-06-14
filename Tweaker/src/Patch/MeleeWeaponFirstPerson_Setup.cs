using Dex.Tweaker.Core;
using HarmonyLib;
using Gear;
using GameData;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "Setup")]
    class MeleeWeaponFirstPerson_Setup
    {
        public static void Prefix(ref ItemDataBlock data, MeleeWeaponFirstPerson __instance)
        {
            Hammer.Equiped = new DataTransfer.Hammer();
            foreach(var hammer in ConfigManager.Hammer.Config)
            {
                if (!hammer.internalEnabled
                    || hammer.ItemID != data.persistentID) continue;
                Hammer.Equiped = hammer;
                __instance.m_damageLight = hammer.Damage.Min;
                __instance.m_damageHeavy = hammer.Damage.Max;
                __instance.m_cameraDamageRayLength = hammer.CameraDamageRayLength;
                __instance.m_inputBufferTime = hammer.InputBufferTime;
                __instance.m_maxPushFrequency = hammer.MaxPushFrequency;
                __instance.m_attackDamageSphereDotScale = hammer.AttackDamageSphereDotScale;
                __instance.m_pushDamageSphereRadius = hammer.PushDamageSphereRadius;
                __instance.m_syncTimeout = hammer.SyncTimeout;
                __instance.m_bufferedAttackTime = hammer.BufferedAttackTime;
                __instance.m_bufferedPushTime = hammer.BufferedPushTime;
                __instance.m_staminaSpeedMinMax = new Vector2(hammer.StaminaSpeed.Min, hammer.StaminaSpeed.Max);
                Hammer.ReplaceData(__instance.m_attackMissRight, hammer.AttackMissRight);
                Hammer.ReplaceData(__instance.m_attackMissLeft, hammer.AttackMissLeft);
                Hammer.ReplaceData(__instance.m_attackHitRight, hammer.AttackHitRight);
                Hammer.ReplaceData(__instance.m_attackHitLeft, hammer.AttackHitLeft);
                Hammer.ReplaceData(__instance.m_attackPush, hammer.AttackPush);
                Hammer.ReplaceData(__instance.m_attackChargeUpRight, hammer.AttackChargeUpRight);
                Hammer.ReplaceData(__instance.m_attackChargeUpLeft, hammer.AttackChargeUpLeft);
                Hammer.ReplaceData(__instance.m_attackChargeUpReleaseLeft, hammer.AttackChargeUpReleaseLeft);
                Hammer.ReplaceData(__instance.m_attackChargeUpReleaseRight, hammer.AttackChargeUpReleaseRight);
                break;
            }
        }
    }
}

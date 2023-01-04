using Dex.Tweaker.Core;
using HarmonyLib;
using Gear;
using GameData;
using UnityEngine;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(MeleeWeaponFirstPerson), nameof(MeleeWeaponFirstPerson.Setup))]
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
            __instance.m_attackDamageSphereDotScale = hammer.AttackDamageSphereDotScale;
            __instance.m_syncTimeout = hammer.SyncTimeout;
            __instance.m_bufferedAttackTime = hammer.BufferedAttackTime;
            __instance.m_bufferedPushTime = hammer.BufferedPushTime;
            break;
        }
    }
}

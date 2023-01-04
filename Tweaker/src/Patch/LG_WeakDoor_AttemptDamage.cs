using Dex.Tweaker.Util;
using HarmonyLib;
using LevelGeneration;
using UnityEngine;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(LG_WeakDoor), nameof(LG_WeakDoor.AttemptDamage))]
class LG_WeakDoor_AttemptDamage
{
    public static bool Prefix(LG_WeakDoor __instance, Vector3 sourcePos)
    {
        if(LG_WeakDoorBladeDamage_MeleeDamage.damageMem == 0) return true;

        __instance.m_sync.AttemptDoorInteraction(eDoorInteractionType.DoDamage, LG_WeakDoorBladeDamage_MeleeDamage.damageMem, 0f, sourcePos, null);
        Log.Debug($"Attempting custom damagevalue on weakdoor of {LG_WeakDoorBladeDamage_MeleeDamage.damageMem}");

        return false;
    }
}
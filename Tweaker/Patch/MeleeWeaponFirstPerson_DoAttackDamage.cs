using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "DoAttackDamage")]
    class MeleeWeaponFirstPerson_DoAttackDamage
    {
        public static void Prefix(MeleeWeaponFirstPerson __instance)
        {
            CoreManager.Current.DifficultyScale.ScaleHammerDamage(__instance.m_damageToDeal);
        }
    }
}
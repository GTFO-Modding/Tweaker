using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb), "MeleeDamage")]
    class Dam_EnemyDamageLimb_MeleeDamage
    {
        public static void Prefix(ref float dam, Dam_EnemyDamageLimb __instance)
        {
            CoreManager.Current.Hammer.ModifyDamage(ref dam, __instance);
        }
    }
}
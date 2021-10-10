using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_PlayerDamageBase), "OnIncomingDamage")]
    class Dam_PlayerDamageBase_OnIncomingDamage
    {
        public static void Prefix(ref float damage)
        {
            CoreManager.Current.DifficultyScale.ScaleDamagePlayer(ref damage);
        }
    }
}

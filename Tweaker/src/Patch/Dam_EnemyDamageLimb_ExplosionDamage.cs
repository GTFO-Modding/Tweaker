using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb), "ExplosionDamage")]
    class Dam_EnemyDamageLimb_ExplosionDamage
    {
        public static void Prefix(ref float dam, Dam_EnemyDamageLimb __instance)
            => Log.Debug($"Explosion\n\tdamage: {dam}\n\ttarget: {__instance.m_base.name}");
    }
}

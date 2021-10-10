using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_EnemyDamageLimb), "ExplosionDamage")]
    class Dam_EnemyDamageLimb_ExplosionDamage
    {
        public static void Prefix(float dam, Dam_EnemyDamageLimb __instance)
            => Log.Debug($"Explosion damage: {dam} target: {__instance.m_base.name}");
    }
}

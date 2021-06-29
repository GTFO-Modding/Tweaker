using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_SyncedDamageBase), "RegisterDamage")]
    class Dam_SyncedDamageBase_RegisterDamage
    {
        public static void Postfix(ref float dam, Dam_SyncedDamageBase __instance)
            => Log.Debug($"Registered Damage: {dam} Health: {__instance.Health} / {__instance.HealthMax} Target: {__instance.name}");
    }
}
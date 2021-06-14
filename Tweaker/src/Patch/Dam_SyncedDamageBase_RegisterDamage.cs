using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(Dam_SyncedDamageBase), "RegisterDamage")]
    class Dam_SyncedDamageBase_RegisterDamage
    {
        public static void Prefix(ref float dam, Dam_SyncedDamageBase __instance)
        {
            HealthPre = __instance.Health;
            HealthPost = HealthPre - dam;
            Log.Debug($"Register Damage\n\tbase target: {__instance.name}\n\tbase health: {HealthPre}/{__instance.HealthMax}\n\tamount: {dam}\n\thealth remainder: {HealthPost}");
        }
        static float HealthPre { get; set; }
        static float HealthPost { get; set; }
    }
}
using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "OnDespawn")]
    class GlowstickInstance_OnDespawn
    {
        public static void Prefix(GlowstickInstance __instance)
        {
            CoreManager.Current.GamerGlowstick.Despawn(__instance.GetInstanceID(), __instance.transform.position);
        }
    }
}
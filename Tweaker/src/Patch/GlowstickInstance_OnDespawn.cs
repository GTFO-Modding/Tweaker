using System;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "OnDespawn")]
    class GlowstickInstance_OnDespawn
    {
        public static void Prefix(GlowstickInstance __instance)
        {
            if (ConfigManager.GamerGlowstick.Config.internalEnabled)
                GamerGlowstick.Despawn(__instance.GetInstanceID(), __instance.transform.position);
        }
    }
}
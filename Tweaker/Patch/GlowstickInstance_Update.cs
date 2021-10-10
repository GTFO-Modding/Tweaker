using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "Update")]
    class GlowstickInstance_Update
    {
        public static void Postfix(GlowstickInstance __instance)
        {
            CoreManager.Current.GamerGlowstick.Update(__instance);
        }
    }
}
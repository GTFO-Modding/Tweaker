using System;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "Update")]
    class GlowstickInstance_Update
    {
        public static void Postfix(GlowstickInstance __instance)
        {
            if (!ConfigManager.GamerGlowstick.Config.internalEnabled) return;
            if (__instance == null) return;
            if (!__instance.m_hasLight) return;
            if (GamerGlowstick.Exist(__instance.GetInstanceID(), __instance.GetItem()))
            {
                __instance.m_light.SetColor(GamerGlowstick.lookup[GamerGlowstick.currentID].color);
                __instance.m_light.UpdateData();
            }
        }
    }
}
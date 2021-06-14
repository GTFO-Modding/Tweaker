using System;
using Dex.Tweaker.Core;
using Dex.Tweaker.PluginDependency;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PUI_Watermark), "UpdateWatermark")]
    class PUI_Watermark_UpdateWatermark
    {
        public static void Postfix(PUI_Watermark __instance)
            => __instance.m_watermarkText.SetText($"<color=red>MODDED</color>\n<color=orange>{MTFO.Version}</color>");
    }
}
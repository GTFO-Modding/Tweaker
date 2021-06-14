using System;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(AnalyticsManager), "OnGameEvent")]
    class AnalyticsManager_OnGameEvent
    {
        public static bool Prefix()
            => false;
    }
}
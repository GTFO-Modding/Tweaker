using System;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(DropServerGameSession), "ReportLayerProgression")]
    class DropServerGameSession_ReportLayerProgression
    {
        public static bool Prefix()
            => false;
    }
}

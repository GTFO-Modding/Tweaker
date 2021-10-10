using System;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(DropServerGameSession), "ReportSessionResult")]
    class DropServerGameSession_ReportSessionResult
    {
        public static bool Prefix()
            => false;
    }
}
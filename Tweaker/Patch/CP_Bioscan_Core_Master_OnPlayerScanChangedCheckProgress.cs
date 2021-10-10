using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using ChainedPuzzles;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CP_Bioscan_Core), "Master_OnPlayerScanChangedCheckProgress")]
    class CP_Bioscan_Core_Master_OnPlayerScanChangedCheckProgress
    {
        public static void Prefix(ref float scanProgress)
        {
            CoreManager.Current.DifficultyScale.ScaleScanProgress(ref scanProgress);
        }
    }
}
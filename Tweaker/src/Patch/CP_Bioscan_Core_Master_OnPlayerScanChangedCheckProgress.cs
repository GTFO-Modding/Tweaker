using System;
using Dex.Tweaker.Util;
using Dex.Tweaker.Core;
using HarmonyLib;
using ChainedPuzzles;
using SNetwork;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CP_Bioscan_Core), "Master_OnPlayerScanChangedCheckProgress")]
    class CP_Bioscan_Core_Master_OnPlayerScanChangedCheckProgress
    {
        public static void Prefix(ref float scanProgress)
        {
            if (!ConfigManager.DifficultyScale.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (ConfigManager.DifficultyScale.Config.Solo.enabled && ConfigManager.DifficultyScale.Config.Solo.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * ConfigManager.DifficultyScale.Config.Solo.ProgressBioscan;
                    break;
                case 2:
                    if (ConfigManager.DifficultyScale.Config.Duo.enabled && ConfigManager.DifficultyScale.Config.Duo.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * ConfigManager.DifficultyScale.Config.Duo.ProgressBioscan;
                    break;
                case 3:
                    if (ConfigManager.DifficultyScale.Config.Trio.enabled && ConfigManager.DifficultyScale.Config.Trio.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * ConfigManager.DifficultyScale.Config.Trio.ProgressBioscan;
                    break;
                case 4:
                    if (ConfigManager.DifficultyScale.Config.Full.enabled && ConfigManager.DifficultyScale.Config.Full.ProgressBioscan != 1.0f)
                        scanProgress = scanProgress * ConfigManager.DifficultyScale.Config.Full.ProgressBioscan;
                    break;
                default:
                    Log.Warning("Abnormal number of players detected in session");
                    break;
            }
        }
    }
}
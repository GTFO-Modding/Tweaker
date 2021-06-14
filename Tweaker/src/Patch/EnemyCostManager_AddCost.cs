using System;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using SNetwork;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyCostManager), "AddCost", new Type[] { typeof(float) })]
    class EnemyCostManager_AddCost
    {
        public static void Prefix(ref float points)
        {
            if (!ConfigManager.DifficultyScale.Config.internalEnabled) return;
            switch (SNet.SessionHub.PlayersInSession.Count)
            {
                case 1:
                    if (ConfigManager.DifficultyScale.Config.Solo.enabled && ConfigManager.DifficultyScale.Config.Solo.EnemyWaveCost != 1.0f)
                        points = points * ConfigManager.DifficultyScale.Config.Solo.EnemyWaveCost;
                    break;
                case 2:
                    if (ConfigManager.DifficultyScale.Config.Duo.enabled && ConfigManager.DifficultyScale.Config.Duo.EnemyWaveCost != 1.0f)
                        points = points * ConfigManager.DifficultyScale.Config.Duo.EnemyWaveCost;
                    break;
                case 3:
                    if (ConfigManager.DifficultyScale.Config.Trio.enabled && ConfigManager.DifficultyScale.Config.Trio.EnemyWaveCost != 1.0f)
                        points = points * ConfigManager.DifficultyScale.Config.Trio.EnemyWaveCost;
                    break;
                case 4:
                    if (ConfigManager.DifficultyScale.Config.Full.enabled && ConfigManager.DifficultyScale.Config.Full.EnemyWaveCost != 1.0f)
                        points = points * ConfigManager.DifficultyScale.Config.Full.EnemyWaveCost;
                    break;
                default:
                    Log.Warning("Abnormal number of players detected in session");
                    break;
            }
            Log.Debug($"Adding enemy wave cost of {points} to {EnemyCostManager.Current.m_currentCost} out of {EnemyCostManager.Current.m_allowedTotalCost}");
        }
    }
}
using System;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using GameData;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MineDeployerFirstPerson), "Setup")]
    class MineDeployerFirstPerson_Setup
    {
        public static void Prefix(ref ItemDataBlock data, MineDeployerFirstPerson __instance)
        {
            Log.Debug(
                "Mine Deployer Setup" +
                $"\n\tdeployPickupInteractionDuration:{__instance.m_deployPickupInteractionDuration}" +
                $"\n\ttimeBetweenPlacements:{__instance.m_timeBetweenPlacements}"
            );
            foreach (var config in ConfigManager.Mine.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                __instance.m_deployPickupInteractionDuration = config.DeployPickupInteractionDuration;
                __instance.m_timeBetweenPlacements = config.TimeBetweenPlacements;
                break;
            }
        }
    }
}

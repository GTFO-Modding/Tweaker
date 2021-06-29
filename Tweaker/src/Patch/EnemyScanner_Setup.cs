using System;
using System.Text;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;
using GameData;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyScanner), "Setup")]
    class EnemyScanner_Setup
    {
        public static void Prefix(ref ItemDataBlock data, EnemyScanner __instance)
        {
            object[] information =
            {
                __instance.m_scanConeDotMin,
                __instance.m_maxScanWorldRadius,
                __instance.m_localObjRadius,
                __instance.m_enemyObjMinScale,
                __instance.m_maxObjs,
                __instance.m_maxCourseNodeDistance,
                __instance.m_scanDelay,
                __instance.m_pulseDuration,
                __instance.m_posDelay,
                __instance.m_tagDuration,
                __instance.m_rechargeDuration
            };

            var logOutput = new StringBuilder();
            var format = " {0,21}: {1}";

            logOutput.AppendLine("Enemyscanner Setup");
            foreach(var info in information) logOutput.AppendLine(string.Format(format, nameof(info), info));
            foreach (var config in ConfigManager.BioTracker.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                information[ 0] = config.scanConeDotMin;
                information[ 1] = config.maxScanWorldRadius;
                information[ 2] = config.localObjRadius;
                information[ 3] = config.enemyObjMinScale;
                information[ 4] = config.maxObjs;
                information[ 5] = config.maxCourseNodeDistance;
                information[ 6] = config.scanDelay;
                information[ 7] = config.pulseDuration;
                information[ 8] = config.posDelay;
                information[ 9] = config.tagDuration;
                information[10] = config.rechargeDuration;
                logOutput.AppendLine($"Loaded {config.name}[{config.ItemID}]");
                break;
            }
            //m_showingNoTargetsTimer is set in UpdateTagProgress
            Log.Debug(logOutput.ToString());
        }
    }
}
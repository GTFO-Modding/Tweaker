using System;
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
            Log.Debug(
                "EnemyScanner Setup" +
                $"\n\tscanConeDotMin:{__instance.m_scanConeDotMin}" +
                $"\n\tmaxScanWorldRadius:{__instance.m_maxScanWorldRadius}" +
                $"\n\tlocalObjRadius:{__instance.m_localObjRadius}" +
                $"\n\tenemyObjMinScale:{__instance.m_enemyObjMinScale}" +
                $"\n\tmaxObjs:{ __instance.m_maxObjs}" +
                $"\n\tmaxCourseNodeDistance:{__instance.m_maxCourseNodeDistance}" +
                $"\n\tscanDelay:{__instance.m_scanDelay}" +
                $"\n\tpulseDuration:{__instance.m_pulseDuration}" +
                $"\n\tposDelay:{__instance.m_posDelay}" +
                $"\n\ttagDuration:{__instance.m_tagDuration}" +
                $"\n\trechargeDuration:{__instance.m_rechargeDuration}"
            );

            foreach (var config in ConfigManager.BioTracker.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                __instance.m_scanConeDotMin = config.scanConeDotMin;
                __instance.m_maxScanWorldRadius = config.maxScanWorldRadius;
                __instance.m_localObjRadius = config.localObjRadius;
                __instance.m_enemyObjMinScale = config.enemyObjMinScale;
                __instance.m_maxObjs = config.maxObjs;
                __instance.m_maxCourseNodeDistance = config.maxCourseNodeDistance;
                __instance.m_scanDelay = config.scanDelay;
                __instance.m_pulseDuration = config.pulseDuration;
                __instance.m_posDelay = config.posDelay;
                __instance.m_tagDuration = config.tagDuration;
                __instance.m_rechargeDuration = config.rechargeDuration;
                break;
            }
            //m_showingNoTargetsTimer is set in UpdateTagProgress
        }
    }
}
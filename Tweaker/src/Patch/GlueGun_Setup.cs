using System;
using HarmonyLib;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using GameData;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlueGun), "Setup")]
    class GlueGun_Setup
    {
        public static void Prefix(ref ItemDataBlock data, GlueGun __instance)
        {
            Log.Debug(
                "GlueGun Setup" +
                $"\n\ttimeToMaxPressure:{__instance.m_timeToMaxpressure}" +
                $"\n\ttimeToDepleatePressure:{__instance.m_timeToDepleatePressure}" +
                $"\n\tpressureProgressToFire:{__instance.m_pressureProgressToFire}" +
                $"\n\tmeterAngMinPressure:{__instance.m_meterAngMinpressure}" +
                $"\n\tmeterAngMaxpressure:{ __instance.m_meterAngMaxpressure}" +
                $"\n\tfireDelayMin:{__instance.m_fireDelayMin}" +
                $"\n\tfireDelayMax:{__instance.m_fireDelayMax}" +
                $"\n\tforceSizeMin:{__instance.m_forceSizeMin}" +
                $"\n\tforceSizeMax:{__instance.m_forceSizeMax}" +
                $"\n\tspreadMin:{__instance.m_spreadMin}" +
                $"\n\tspreadMax:{__instance.m_spreadMax}" +
                $"\n\tburstShotsMin:{__instance.m_burstShotsMin}" +
                $"\n\tburstShotsMax:{__instance.m_burstShotsMax}" +
                $"\n\tburstShotDelay:{__instance.m_burstShotDelay}" +
                $"\n\tnoiseScaleTarget:{__instance.m_noiseScaleTarget}" +
                $"\n\tnoiseIntensity:{__instance.m_noiseIntensity}" +
                $"\n\tmeterShakeAng:{__instance.m_meterShakeAng}" +
                $"\n\tsyncTimeout:{__instance.m_syncTimeout}"
            );

            foreach (var config in ConfigManager.FoamLauncher.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                __instance.m_timeToMaxpressure = config.TimeToMaxPressure;
                __instance.m_timeToDepleatePressure = config.TimeToDepleatePressure;
                __instance.m_pressureProgressToFire = config.PressureProgressToFire;
                __instance.m_meterAngMinpressure = config.MeterAngPressure.Min;
                __instance.m_meterAngMaxpressure = config.MeterAngPressure.Max;
                __instance.m_fireDelayMin = config.FireDelay.Min;
                __instance.m_fireDelayMax = config.FireDelay.Max;
                __instance.m_forceSizeMin = config.ForceSize.Min;
                __instance.m_forceSizeMax = config.ForceSize.Max;
                __instance.m_spreadMin = config.Spread.Min;
                __instance.m_spreadMax = config.Spread.Max;
                __instance.m_burstShotsMin = config.BurstShots.Min;
                __instance.m_burstShotsMax = config.BurstShots.Max;
                __instance.m_burstShotDelay = config.BurstShotDelay;
                __instance.m_noiseScaleTarget = config.NoiseScaleTarget;
                __instance.m_noiseIntensity = config.NoiseIntensity;
                __instance.m_meterShakeAng = config.MeterShakeAng;
                __instance.m_syncTimeout = config.SyncTimeout;
                break;
            }
        }
    }
}

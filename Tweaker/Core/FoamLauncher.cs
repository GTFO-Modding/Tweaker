using System;
using Dex.Tweaker.Patch;
using Dex.Tweaker.Util;
using GameData;

namespace Dex.Tweaker.Core
{
    class FoamLauncher : ConfigBaseMultiple<FoamLauncher.Data>
    {
        public class Data : DataBase
        {
            public float TimeToMaxPressure { get; set; } = 2.5f;
            public float TimeToDepleatePressure { get; set; } = 0.8f;
            public float PressureProgressToFire { get; set; } = 0.075f;
            public MinMaxf MeterAngPressure { get; set; } = new(112f, -108f);
            public MinMaxf FireDelay { get; set; } = new(0.2f, 2f);
            public MinMaxf ForceSize { get; set; } = new(14f, 16f);
            public MinMaxf Spread { get; set; } = new(1f, 7f);
            public MinMaxInt BurstShots { get; set; } = new(1, 12);
            public float BurstShotDelay { get; set; } = 0.08f;
            public float NoiseScaleTarget { get; set; } = 0.005f;
            public float NoiseIntensity { get; set; } = 15f;
            public float MeterShakeAng { get; set; } = 8f;
            public float SyncTimeout { get; set; } = 2f;
            public uint ItemID { get; set; } = 73U;
            public string name { get; set; } = "Default";
        }

        public override Type[] PatchClasses => new[]
        {
            typeof(GlueGun_Setup)
        };

        public void OnSetup(ref ItemDataBlock data, GlueGun instance)
        {
            Log.Debug(
                "GlueGun Setup" +
                $"\n\ttimeToMaxPressure:{instance.m_timeToMaxpressure}" +
                $"\n\ttimeToDepleatePressure:{instance.m_timeToDepleatePressure}" +
                $"\n\tpressureProgressToFire:{instance.m_pressureProgressToFire}" +
                $"\n\tmeterAngMinPressure:{instance.m_meterAngMinpressure}" +
                $"\n\tmeterAngMaxpressure:{instance.m_meterAngMaxpressure}" +
                $"\n\tfireDelayMin:{instance.m_fireDelayMin}" +
                $"\n\tfireDelayMax:{instance.m_fireDelayMax}" +
                $"\n\tforceSizeMin:{instance.m_forceSizeMin}" +
                $"\n\tforceSizeMax:{instance.m_forceSizeMax}" +
                $"\n\tspreadMin:{instance.m_spreadMin}" +
                $"\n\tspreadMax:{instance.m_spreadMax}" +
                $"\n\tburstShotsMin:{instance.m_burstShotsMin}" +
                $"\n\tburstShotsMax:{instance.m_burstShotsMax}" +
                $"\n\tburstShotDelay:{instance.m_burstShotDelay}" +
                $"\n\tnoiseScaleTarget:{instance.m_noiseScaleTarget}" +
                $"\n\tnoiseIntensity:{instance.m_noiseIntensity}" +
                $"\n\tmeterShakeAng:{instance.m_meterShakeAng}" +
                $"\n\tsyncTimeout:{instance.m_syncTimeout}"
            );

            foreach (var config in this.Config)
            {
                if (!config.internalEnabled
                    || config.ItemID != data.persistentID)
                    continue;
                instance.m_timeToMaxpressure = config.TimeToMaxPressure;
                instance.m_timeToDepleatePressure = config.TimeToDepleatePressure;
                instance.m_pressureProgressToFire = config.PressureProgressToFire;
                instance.m_meterAngMinpressure = config.MeterAngPressure.Min;
                instance.m_meterAngMaxpressure = config.MeterAngPressure.Max;
                instance.m_fireDelayMin = config.FireDelay.Min;
                instance.m_fireDelayMax = config.FireDelay.Max;
                instance.m_forceSizeMin = config.ForceSize.Min;
                instance.m_forceSizeMax = config.ForceSize.Max;
                instance.m_spreadMin = config.Spread.Min;
                instance.m_spreadMax = config.Spread.Max;
                instance.m_burstShotsMin = config.BurstShots.Min;
                instance.m_burstShotsMax = config.BurstShots.Max;
                instance.m_burstShotDelay = config.BurstShotDelay;
                instance.m_noiseScaleTarget = config.NoiseScaleTarget;
                instance.m_noiseIntensity = config.NoiseIntensity;
                instance.m_meterShakeAng = config.MeterShakeAng;
                instance.m_syncTimeout = config.SyncTimeout;
                break;
            }
        }
    }
}

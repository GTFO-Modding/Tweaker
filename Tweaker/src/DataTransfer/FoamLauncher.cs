using System;

namespace Dex.Tweaker.DataTransfer
{
    class FoamLauncher
    {
        public float TimeToMaxPressure { get; set; } = 2.5f;
        public float TimeToDepleatePressure { get; set; } = 0.8f;
        public float PressureProgressToFire { get; set; } = 0.075f;
        public MinMax MeterAngPressure { get; set; } = new MinMax(112f, -108f);
        public MinMax FireDelay { get; set; } = new MinMax(0.2f, 2f);
        public MinMax ForceSize { get; set; } = new MinMax(14f, 16f);
        public MinMax Spread { get; set; } = new MinMax(1f, 7f);
        public MinMaxInt BurstShots { get; set; } = new MinMaxInt(1, 12);
        public float BurstShotDelay { get; set; } = 0.08f;
        public float NoiseScaleTarget { get; set; } = 0.005f;
        public float NoiseIntensity { get; set; } = 15f;
        public float MeterShakeAng { get; set; } = 8f;
        public float SyncTimeout { get; set; } = 2f;
        public uint ItemID { get; set; } = 73U;
        public string name { get; set; } = "Default";
        public bool internalEnabled { get; set; } = false;
    }
}

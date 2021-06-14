using System;

namespace Dex.Tweaker.DataTransfer
{
    class Hammer
    {
        public MinMax Damage { get; set; } = new MinMax(4f, 20f);
        public float PrecisionDamageMulti { get; set; } = 1f;
        public float CameraDamageRayLength { get; set; } = 1.8f;
        public float InputBufferTime { get; set; } = 0.5f;
        public float MaxPushFrequency { get; set; } = 1.2f;
        public float AttackDamageSphereDotScale { get; set; } = 0.9f;
        public float PushDamageSphereRadius { get; set; } = 0.6f;
        public float SyncTimeout { get; set; } = 2f;
        public float BufferedAttackTime { get; set; } = -1f;
        public float BufferedPushTime { get; set; } = -1f;
        public MinMax StaminaSpeed { get; set; } = new MinMax(0.8f, 1f);
        public float ChargeUpTime { get; set; } = 2f;
        public float AutoAttackTime { get; set; } = 4f;
        public HammerData AttackMissRight { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.2f,
            AttackLength = 1f,
            AttackHitTime = 0.3333333f,
            AttackCamFwdHitTime = 0.5f,
            DamageStartTime = 0.3333333f,
            DamageEndTime = 0.7666667f,
            ComboEarlyTime = 0.6666667f
        };
        public HammerData AttackMissLeft { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.2f,
            AttackLength = 1f,
            AttackHitTime = 0.3333333f,
            AttackCamFwdHitTime = 0.5f,
            DamageStartTime = 0.3333333f,
            DamageEndTime = 0.7666667f,
            ComboEarlyTime = 0.6666667f
        };
        public HammerData AttackHitRight { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.0f,
            AttackLength = 0.5f,
            AttackHitTime = 0.5f,
            ComboEarlyTime = 0.4f
        };
        public HammerData AttackHitLeft { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.0f,
            AttackLength = 0.5f,
            AttackHitTime = 0.5f,
            ComboEarlyTime = 0.4f
        };
        public HammerData AttackPush { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.2f,
            AttackLength = 0.6666667f,
            DamageStartTime = 0.1333333f,
            DamageEndTime = 0.2666667f,
            AttackCamFwdHitTime = 0.3333333f,
            ComboEarlyTime = 0.8333333f
        };
        public HammerData AttackChargeUpRight { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.23f
        };
        public HammerData AttackChargeUpLeft { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.3f
        };
        public HammerData AttackChargeUpReleaseRight { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.0f,
            AttackLength = 0.3666667f,
            AttackHitTime = 0.1333333f,
            DamageStartTime = 0.0f,
            DamageEndTime = 0.3666667f,
            AttackCamFwdHitTime = 0.1333333f,
            ComboEarlyTime = 0.3f
        };
        public HammerData AttackChargeUpReleaseLeft { get; set; } = new HammerData()
        {
            AnimBlendIn = 0.0f,
            AttackLength = 0.3666667f,
            AttackHitTime = 0.1333333f,
            DamageStartTime = 0.0f,
            DamageEndTime = 0.3666667f,
            AttackCamFwdHitTime = 0.1333333f,
            ComboEarlyTime = 0.3f
        };
        public HammerPart Head { get; set; } = new HammerPart();
        public HammerPart Neck { get; set; } = new HammerPart();
        public HammerPart Handle { get; set; } = new HammerPart();
        public HammerPart Pommel { get; set; } = new HammerPart();
        public uint ItemID { get; set; } = 100U;
        public string name { get; set; } = "Default";
        public bool internalEnabled { get; set; } = false;
    }
}

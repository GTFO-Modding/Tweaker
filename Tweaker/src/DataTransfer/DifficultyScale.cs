using System;

namespace Dex.Tweaker.DataTransfer
{
    class DifficultyScale
    {
        public Scale Solo { get; set; } = new Scale();
        public Scale Duo { get; set; } = new Scale();
        public Scale Trio { get; set; } = new Scale();
        public Scale Full { get; set; } = new Scale();
        public bool internalEnabled { get; set; } = false;
    }

    class Scale
    {
        public float BulletDamage { get; set; } = 1.0f;
        public float DamagePlayer { get; set; } = 1.0f;
        public float HammerDamage { get; set; } = 1.0f;
        public float EnemyWaveCost { get; set; } = 1.0f;
        public float ProgressBioscan { get; set; } = 1.0f;
        public bool enabled { get; set; } = false;
    }
}

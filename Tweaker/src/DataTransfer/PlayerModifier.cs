using System;

namespace Dex.Tweaker.DataTransfer
{
    class PlayerModifier
    {
        public float SlideForceScale { get; set; } = 1f;
        public float EvadeSpeed { get; set; } = 3f;
        public float ModelScale { get; set; } = 1f;
        public bool CanStealthBhop { get; set; } = true;
        public bool internalEnabled { get; set; } = false;
    }
}

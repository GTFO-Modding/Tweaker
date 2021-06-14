using System;

namespace Dex.Tweaker.DataTransfer
{
    class HammerPart
    {
        public HammerPart() { }
        public Vector3 Scale { get; set; } = new Vector3(1f, 1f, 1f);
        public Vector3 Position { get; set; } = new Vector3(0f, 0f, 0f);
        public Vector3 Rotation { get; set; } = new Vector3(0f, 0f, 0f);
    }
}

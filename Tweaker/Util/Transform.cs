using System;
using System.Collections.Generic;
using System.Text;

namespace Dex.Tweaker.Util
{
    class Transform
    {
        public Vector3 Scale { get; set; } = new(1f, 1f, 1f);
        public Vector3 Position { get; set; } = new(0f, 0f, 0f);
        public Vector3 Rotation { get; set; } = new(0f, 0f, 0f);
    }
}

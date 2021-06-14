using System;

namespace Dex.Tweaker.DataTransfer
{
    class Infection
    {
        public float Amount { get; set; } = 0.01f;
        public MinMax Rate { get; set; } = new MinMax(1.0f, 1.5f);
        public bool Enabled { get; set; } = false;
    }
}

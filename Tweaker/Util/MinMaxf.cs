using System;

namespace Dex.Tweaker.Util
{
    class MinMaxf
    {
        public MinMaxf(float min, float max)
        {
            Min = min;
            Max = max;
        }
        public float Min { get; set; }
        public float Max { get; set; }
    }
}

using System;

namespace Dex.Tweaker.Util
{
    class RGB
    {
        public RGB(float red, float green, float blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
    }
}

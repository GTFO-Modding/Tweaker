﻿using System;

namespace Dex.Tweaker.DataTransfer
{
    class MinMaxInt
    {
        public MinMaxInt(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}

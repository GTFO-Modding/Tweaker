using System;
using System.Collections.Generic;
using System.Text;

namespace Dex.Tweaker.DataTransfer
{
    class NavMeshAgent
    {
        public float Climb { get; set; } = 0.5f;
        public float Height { get; set; } = 2f;
        public float Radius { get; set; } = 0.25f;
        public float Slope { get; set; } = 55f;
    }
}

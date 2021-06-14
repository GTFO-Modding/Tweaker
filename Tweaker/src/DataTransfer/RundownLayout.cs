using System;

namespace Dex.Tweaker.DataTransfer
{
    class RundownLayout
    {
        public ExpeditionButton[] Tier1 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("A1", -375f, 0f, 0f, 2f),
            new ExpeditionButton("A2",  375f, 0f, 0f, 2f)
        };
        public ExpeditionButton[] Tier2 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("B1", -525f,    0f, 0f, 1.428571f),
            new ExpeditionButton("B2",    0f, -315f, 0f, 1.428571f),
            new ExpeditionButton("B3",  525f,    0f, 0f, 1.428571f)
        };
        public ExpeditionButton[] Tier3 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("C1", -412.5f, 0f, 0f, 1.818182f),
            new ExpeditionButton("C2",  412.5f, 0f, 0f, 1.818182f)
        };
        public ExpeditionButton[] Tier4 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("D1", -75f, 0f, 0f, 10f)
        };
        public ExpeditionButton[] Tier5 { get; set; }
        public bool HideProgression { get; set; } = true;
        public bool HideTiers { get; set; } = true;
        public bool internalEnabled { get; set; } = false;
    }
}

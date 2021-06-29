using System;

namespace Dex.Tweaker.DataTransfer
{
    class RundownLayout
    {
        public ExpeditionButton[] Tier1 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("A1", 1.666667f, -450f,    0, 0),
            new ExpeditionButton("A2", 1.666667f,     0, -270, 0),
            new ExpeditionButton("A3", 1.666667f,  450f,    0, 0)
        };
        public ExpeditionButton[] Tier2 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("B1", 1.428571f, -525,    0, 0),
            new ExpeditionButton("B2", 1.428571f, -175, -210, 0),
            new ExpeditionButton("B3", 1.428571f,  175, -210, 0),
            new ExpeditionButton("B4", 1.428571f,  525,    0, 0)
        };
        public ExpeditionButton[] Tier3 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("C1", 1.818182f, -412.5f,       0, 0),
            new ExpeditionButton("C2", 1.818182f,       0, -247.5f, 0),
            new ExpeditionButton("C3", 1.818182f,  412.5f,       0, 0)
        };
        public ExpeditionButton[] Tier4 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("D1", 2.5f, -300, 0, 0),
            new ExpeditionButton("D2", 2.5f,  300, 0, 0)
        };
        public ExpeditionButton[] Tier5 { get; set; } = new ExpeditionButton[]
        {
            new ExpeditionButton("E1", 10f, -75, 0, 0)
        };
        public bool HideProgression { get; set; } = true;
        public bool HideTiers { get; set; } = true;
        public bool internalEnabled { get; set; } = false;
    }
}

namespace Dex.Tweaker.DataTransfer;

class RundownLayout : JsonConfig
{
    public ExpeditionButton[] Tier1 { get; set; } = new ExpeditionButton[]
    {
        new ("A1", 1.666667f, -450f,    0, 0),
        new ("A2", 1.666667f,     0, -270, 0),
        new ("A3", 1.666667f,  450f,    0, 0)
    };
    public ExpeditionButton[] Tier2 { get; set; } = new ExpeditionButton[]
    {
        new ("B1", 1.428571f, -525,    0, 0),
        new ("B2", 1.428571f, -175, -210, 0),
        new ("B3", 1.428571f,  175, -210, 0),
        new ("B4", 1.428571f,  525,    0, 0)
    };
    public ExpeditionButton[] Tier3 { get; set; } = new ExpeditionButton[]
    {
        new ("C1", 1.818182f, -412.5f,       0, 0),
        new ("C2", 1.818182f,       0, -247.5f, 0),
        new ("C3", 1.818182f,  412.5f,       0, 0)
    };
    public ExpeditionButton[] Tier4 { get; set; } = new ExpeditionButton[]
    {
        new ("D1", 2.5f, -300, 0, 0),
        new ("D2", 2.5f,  300, 0, 0)
    };
    public ExpeditionButton[] Tier5 { get; set; } = new ExpeditionButton[]
    {
        new ("E1", 10f, -75, 0, 0)
    };
    public bool HideProgression { get; set; } = true;
    public bool HideTiers { get; set; } = true;
}

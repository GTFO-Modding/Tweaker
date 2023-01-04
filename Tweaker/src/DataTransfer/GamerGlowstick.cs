namespace Dex.Tweaker.DataTransfer;

class GamerGlowstick : JsonConfig
{
    public uint ItemID { get; set; } = 130U;
    public float PulseRate { get; set; } = 1f;
    public RGB Max { get; set; } = new RGB(0.8f, 0.8f, 0.8f);
    public RGB Min { get; set; } = new RGB(0.4f, 0.4f, 0.4f);
    public bool ToggleLevelLight { get; set; } = true;
}

namespace Dex.Tweaker.DataTransfer;

class PlayerModifier : JsonConfig
{
    public float SlideForceScale { get; set; } = 1f;
    public float EvadeSpeed { get; set; } = 3f;
    public float ModelScale { get; set; } = 1f;
    public bool CanStealthBhop { get; set; } = true;
}

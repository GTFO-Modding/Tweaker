namespace Dex.Tweaker.DataTransfer;

class Mine : JsonConfig
{
    public float Delay { get; set; } = 0.25f;
    public float Radius { get; set; } = 2.5f;
    public MinMax Distance { get; set; } = new MinMax(3f, 15f);
    public MinMax Damage { get; set; } = new MinMax(15f, 35f);
    public float Force { get; set; } = 1000f;
    public float ExplosionDelay { get; set; } = 0.25f;
    public float DeployPickupInteractionDuration { get; set; } = 0.5f;
    public float TimeBetweenPlacements { get; set; } = 2f;
    public uint ItemID { get; set; } = 37U;
    public string name { get; set; } = "Default";
}

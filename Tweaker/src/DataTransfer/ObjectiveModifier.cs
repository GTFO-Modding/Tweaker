namespace Dex.Tweaker.DataTransfer;

class ObjectiveModifier : JsonConfig
{
    public uint DataBlockId { get; set; } = 34U;
    public float TimeLimit { get; set; } = 10f;
    public Infection Infection { get; set; } = new Infection();
    public bool ExplodePlayer { get; set; } = true;
    public string name { get; set; } = "Default";
}

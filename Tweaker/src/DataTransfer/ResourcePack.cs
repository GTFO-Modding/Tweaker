namespace Dex.Tweaker.DataTransfer;

class ResourcePack : JsonConfig
{
    public uint DataBlockId { get; set; } = 34U;
    public float ammoStandardRel { get; set; } = 0.2f;
    public float ammoSpecialRel { get; set; } = 0.2f;
    public float ammoClassRel { get; set; } = 0.2f;
    public float healthAmountRel { get; set; } = 0.2f;
    public string name { get; set; } = "Default";
}

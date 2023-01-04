namespace Dex.Tweaker.DataTransfer;

class ElevatorCargo : JsonConfig
{
    public uint DataBlockId { get; set; } = 34U;
    public CargoItem[] CargoItems { get; set; } = new CargoItem[] { new CargoItem() };
    public bool ForceDisable { get; set; } = false;
    public string name { get; set; } = "Fog Turbine";
}

class CargoItem
{
    public uint ItemId { get; set; } = 133U;
    public int ObjectiveChainIndex { get; set; } = 0;
}

using System;

namespace Dex.Tweaker.DataTransfer
{
    class ElevatorCargo
    {
        public uint DataBlockId { get; set; } = 34U;
        public uint[] ItemID { get; set; } = new uint[] { 133U };
        public bool ForceDisable { get; set; } = false;
        public string name { get; set; } = "Fog Turbine";
        public bool internalEnabled { get; set; } = false;
    }
}

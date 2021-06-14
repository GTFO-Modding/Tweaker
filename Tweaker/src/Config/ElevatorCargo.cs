using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class ElevatorCargo : DataTransfer.ConfigBaseMultiple<DataTransfer.ElevatorCargo>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(ElevatorCargoCage_SpawnObjectiveItemsInLandingArea));
                    break;
                }
            }
        }
    }
}

using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class HackDoorPuzzle : DataTransfer.ConfigBaseMultiple<DataTransfer.HackDoorPuzzle>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(LG_SecurityDoor_Locks_SetupForChainedPuzzle));
                    break;
                }
            }
        }
    }
}

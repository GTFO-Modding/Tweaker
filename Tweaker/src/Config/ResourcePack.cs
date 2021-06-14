using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class ResourcePack : DataTransfer.ConfigBaseMultiple<DataTransfer.ResourcePack>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(PlayerBackpackManager_PickupHealthRel));
                    BasePlugin.Instance.PatchAll(typeof(PlayerBackpackManager_ReceiveAmmoGive));
                }
            }
        }
    }
}

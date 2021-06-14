using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class FoamLauncher : DataTransfer.ConfigBaseMultiple<DataTransfer.FoamLauncher>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(GlueGun_Setup));
                    break;
                }
            }
        }
    }
}

using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class Mine : DataTransfer.ConfigBaseMultiple<DataTransfer.Mine>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(MineDeployerFirstPerson_Setup));
                    BasePlugin.Instance.PatchAll(typeof(MineDeployerInstance_Detonate_Explosive_Setup));
                    break;
                }
            }
        }
    }
}

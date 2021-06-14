using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class BioTracker : DataTransfer.ConfigBaseMultiple<DataTransfer.BioTracker>
    {
        public override void OnConfigLoaded()
        {
            foreach (var config in this.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(EnemyScanner_Setup));
                    break;
                }
            }
        }
    }
}

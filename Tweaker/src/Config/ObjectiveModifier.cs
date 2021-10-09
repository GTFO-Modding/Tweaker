using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class ObjectiveModifier : DataTransfer.ConfigBaseMultiple<DataTransfer.ObjectiveModifier>
    {
        public override void OnConfigLoaded()
        {
            foreach(var config in base.Config)
            {
                if (config.internalEnabled)
                {
                    BasePlugin.Instance.PatchAll(typeof(CM_PageLoadout_UpdatePageData));
                }
            }
        }
    }
}

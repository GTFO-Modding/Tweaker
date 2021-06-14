using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class RundownLayout : DataTransfer.ConfigBaseSingle<DataTransfer.RundownLayout>
    {
        public override void OnConfigLoaded()
        {
            if (this.Config.internalEnabled)
            {
                BasePlugin.Instance.PatchAll(typeof(CM_PageRundown_New_UpdateExpeditionIconProgression));
            }
        }
    }
}

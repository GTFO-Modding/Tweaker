using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class PageExpeditionResult : DataTransfer.ConfigBaseSingle<DataTransfer.PageExpeditionResult>
    {
        public override void OnConfigLoaded()
        {
            if (this.Config.internalEnabled)
            {
                BasePlugin.Instance.PatchAll(typeof(CM_PageExpeditionFail_Setup));
                BasePlugin.Instance.PatchAll(typeof(CM_PageExpeditionSuccess_Setup));
            }
        }
    }
}

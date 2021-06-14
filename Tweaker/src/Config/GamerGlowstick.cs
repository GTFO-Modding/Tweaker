using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class GamerGlowstick : DataTransfer.ConfigBaseSingle<DataTransfer.GamerGlowstick>
    {
        public override void OnConfigLoaded()
        {
            if(this.Config.internalEnabled)
            {
                BasePlugin.Instance.PatchAll(typeof(GlowstickInstance_OnCollisionEnter));
                BasePlugin.Instance.PatchAll(typeof(GlowstickInstance_OnDespawn));
                BasePlugin.Instance.PatchAll(typeof(GlowstickInstance_Update));
            }
        }
    }
}

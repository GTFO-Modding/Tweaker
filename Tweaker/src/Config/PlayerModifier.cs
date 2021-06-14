using System;
using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config
{
    class PlayerModifier : DataTransfer.ConfigBaseSingle<DataTransfer.PlayerModifier>
    {
        public override void OnConfigLoaded()
        {
            if (this.Config.internalEnabled)
            {
                if (!this.Config.CanStealthBhop)
                    BasePlugin.Instance.PatchAll(typeof(EnemyDetection_DetectOnNoiseDistance_Conditional_AnimatedWindow));
                if (this.Config.ModelScale != 1f)
                    BasePlugin.Instance.PatchAll(typeof(PlayerAgent_Setup));
                if (this.Config.SlideForceScale != 1f)
                    BasePlugin.Instance.PatchAll(typeof(PlayerLocomotion_AddExternalPushForce));
                if (this.Config.EvadeSpeed != 3f)
                    BasePlugin.Instance.PatchAll(typeof(PLOC_Stand_Update));
            }
        }
    }
}

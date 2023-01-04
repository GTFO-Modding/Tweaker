using Dex.Tweaker.Patch;

namespace Dex.Tweaker.Config;

class PlayerModifier : DataTransfer.ConfigBaseSingle<DataTransfer.PlayerModifier>
{
    public override void OnConfigLoaded()
    {
        if (Config.internalEnabled)
        {
            if (!Config.CanStealthBhop)
                Plugin.Harmony.PatchAll(typeof(EnemyDetection_DetectOnNoiseDistance_Conditional_AnimatedWindow));
            if (Config.ModelScale != 1f)
                Plugin.Harmony.PatchAll(typeof(PlayerAgent_Setup));
            if (Config.SlideForceScale != 1f)
                Plugin.Harmony.PatchAll(typeof(PlayerLocomotion_AddExternalPushForce));
            if (Config.EvadeSpeed != 3f)
                Plugin.Harmony.PatchAll(typeof(PLOC_Stand_Update));
        }
    }
}

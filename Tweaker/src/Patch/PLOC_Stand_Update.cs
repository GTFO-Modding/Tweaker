using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(PLOC_Stand), nameof(PLOC_Stand.Update))]
class PLOC_Stand_Update
{
    public static void Postfix(PLOC_Stand __instance)
    {
        if(ConfigManager.PlayerModifier.Config.internalEnabled && ConfigManager.PlayerModifier.Config.EvadeSpeed != 3f)
        if (__instance.m_moveSpeedMulti == 3f)
            __instance.m_moveSpeedMulti = ConfigManager.PlayerModifier.Config.EvadeSpeed; // this is for dodging
    }
}

using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PLOC_Stand), "Update")]
    class PLOC_Stand_Update
    {
        public static void Postfix(PLOC_Stand __instance)
        {
            CoreManager.Current.PlayerModifier.Evade(__instance);
        }
    }
}

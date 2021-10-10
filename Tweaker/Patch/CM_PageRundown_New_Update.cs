using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageRundown_New), "Update")]
    class CM_PageRundown_New_Update
    {
        public static void Postfix(CM_PageRundown_New __instance)
        {
            CoreManager.Current.RundownLayout.ModifyUpdate(__instance);
        }
    }
}

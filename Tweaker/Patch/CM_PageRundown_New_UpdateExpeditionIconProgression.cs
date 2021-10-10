using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageRundown_New), "UpdateExpeditionIconProgression")]
    class CM_PageRundown_New_UpdateExpeditionIconProgression
    {
        public static void Postfix(CM_PageRundown_New __instance)
        {
            CoreManager.Current.RundownLayout.ModifyIcons(__instance);
        }
    }
}
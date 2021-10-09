using System;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;
using Globals;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageRundown_New), "Update")]
    class CM_PageRundown_New_Update
    {
        public static void Postfix(CM_PageRundown_New __instance)
        {
            if (!ConfigManager.RundownLayout.Config.internalEnabled) return;

            //Hide rundown progression
            if (ConfigManager.RundownLayout.Config.HideProgression)
                __instance.m_tierMarkerSectorSummary.SetVisible(false);

            if (!ConfigManager.RundownLayout.Config.HideTiers) return;
            __instance.m_tierMarker1.SetVisible(false);
            __instance.m_tierMarker2.SetVisible(false);
            __instance.m_tierMarker3.SetVisible(false);
            __instance.m_tierMarker4.SetVisible(false);
            __instance.m_tierMarker5.SetVisible(false);
        }
    }
}

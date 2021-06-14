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
            if (Global.RundownIdToLoad > 1)
            {
                GuiManager.MainMenuLayer.ChangePage(eCM_MenuPage.CMP_NONE);
                Log.Error("THE RUNDOWN INFO SCREEN WAS SKIPPED, UNABLE TO CONTINUE WITH THE GAME. IF USING QUALITY OF LIFE SET SkipRundownInfo TO FALSE");
            }

            //Disable matchmake buttons
            __instance.m_matchmakeAllButton.SetVisible(false);
            __instance.m_matchmakeAllButton.SetText("MATCHMAKE DISABLED");
            __instance.m_matchmakeAllButton.OnBtnPressCallback = null;

            __instance.m_expeditionWindow.m_matchButton.SetVisible(false);

            //Replace discord button
            __instance.m_discordButton.SetText(Discord.name);
            __instance.m_discordButton.OnBtnPressCallback = Discord.callback;

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

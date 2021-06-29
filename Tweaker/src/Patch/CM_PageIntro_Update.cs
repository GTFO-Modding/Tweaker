using System;
using Dex.Tweaker.Core;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;
using Globals;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageIntro), "Update")]
    class CM_PageIntro_Update
    {
        public static void Postfix(CM_PageIntro __instance)
        {
            __instance.m_startupScreen.m_btnBug.SetText(Wiki.name);
            __instance.m_startupScreen.m_btnBug.OnBtnPressCallback = Wiki.callback;
            __instance.m_startupScreen.m_btnDiscord.SetText(Discord.name);
            __instance.m_startupScreen.m_btnDiscord.OnBtnPressCallback = Discord.callback;
        }
    }
}

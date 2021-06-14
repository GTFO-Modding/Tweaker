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
            if (Global.RundownIdToLoad == 1) return;
            __instance.m_startupScreen.m_text.m_text = Halt;
            __instance.m_startupScreen.m_btnStart.SetVisible(false);
            if (Notified) return;
            Log.Error("Incorrect rundown id loaded. Use id 1 to continue");
            Notified = true;
        }
        public static bool Notified { get; set; }
        static string Halt { get; } = "The game was halted due to an attempt to play the official rundown with mods\n\nSet RundownIdToLoad to 1 in Game Setup data block and relaunch the game to proceed\nIf necessary also change the desired rundown persistentID to 1 in the rundown data block";
    }
}

using System;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_StartupScreen), "SetText")]
    class CM_StartupScreen_SetText
    {
        public static void Prefix(ref string txt)
            => txt = $"{txt}\n\nTweaker <color=#808080>by Dex</color>";
    }
}

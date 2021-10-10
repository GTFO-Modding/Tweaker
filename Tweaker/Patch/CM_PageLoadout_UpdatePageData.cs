using System.Text;
using Dex.Tweaker.Util;
using HarmonyLib;
using CellMenu;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(CM_PageLoadout), "UpdatePageData")]
    class CM_PageLoadout_UpdatePageData
    {
        public static void Prefix(CM_PageLoadout __instance)
        {
            CoreManager.Current.ObjectiveModifier.Modifier = null;
        }
    }
}
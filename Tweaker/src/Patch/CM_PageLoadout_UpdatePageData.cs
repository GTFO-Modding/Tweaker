using CellMenu;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch;

[HarmonyPatch(typeof(CM_PageLoadout), nameof(CM_PageLoadout.UpdatePageData))]
class CM_PageLoadout_UpdatePageData
{
    public static void Prefix(CM_PageLoadout __instance)
    {
        ObjectiveModifier.Modifier = null;
    }
}
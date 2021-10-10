using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(WardenObjectiveManager), "OnLocalPlayerStartExpedition")]
    class WardenObjective_OnLocalPlayerStartExpedition
    {
        public static void Postfix()
        {
            CoreManager.Current.ObjectiveModifier.OnExpeditionStart();
            CoreManager.Current.ResourcePack.OnExpeditionStart();
            CoreManager.Current.NavMesh.OnExpeditionStart();
        }
    }
}

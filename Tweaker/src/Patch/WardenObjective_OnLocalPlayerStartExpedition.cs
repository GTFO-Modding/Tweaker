using System;
using Dex.Tweaker.Core;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(WardenObjectiveManager), "OnLocalPlayerStartExpedition")]
    class WardenObjective_OnLocalPlayerStartExpedition
    {
        public static void Postfix()
            => ObjectiveModifier.Load();
    }
}

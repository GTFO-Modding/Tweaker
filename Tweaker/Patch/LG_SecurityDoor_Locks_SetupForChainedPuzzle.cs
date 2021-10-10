using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using LevelGeneration;
using ChainedPuzzles;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(LG_SecurityDoor_Locks), "SetupForChainedPuzzle")]
    class LG_SecurityDoor_Locks_SetupForChainedPuzzle
    {
        public static void Postfix(ref ChainedPuzzleInstance puzzleToOpen, LG_SecurityDoor_Locks __instance)
        {
            CoreManager.Current.HackDoorPuzzle.OnSetup(ref puzzleToOpen, __instance);
        }
    }
}

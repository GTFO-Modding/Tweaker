using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using LevelGeneration;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(LG_ComputerTerminal), "Setup")]
    class LG_ComputerTerminal_Setup
    {
        public static void Prefix()
        {
            CurrentIndex = CurrentIndex + 1U;
        }
        public static void Postfix(LG_ComputerTerminal __instance)
        {
            object[] information =
            {
                CurrentIndex,
                __instance.ItemKey,
                __instance.transform.position.x,
                __instance.transform.position.y,
                __instance.transform.position.z,
                __instance.transform.rotation.x,
                __instance.transform.rotation.y,
                __instance.transform.rotation.z,
                __instance.transform.rotation.w
            };
            var logOutput = string.Format("[{0,2}] {1,-13} position {2,13}, {3,13}, {4,13} | rotation {5,13}, {6,13}, {7,13}, {8,13}", information);
            Log.Message(logOutput);
        }
        public static uint CurrentIndex { get; set; }
    }
}

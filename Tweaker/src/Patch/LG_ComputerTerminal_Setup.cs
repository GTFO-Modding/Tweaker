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
            Log.Message(
                $"Terminal Setup [{CurrentIndex}]" +
                $"\n\tkey: {__instance.ItemKey}" +
                $"\n\tposition: { __instance.transform.position.x}, { __instance.transform.position.y}, { __instance.transform.position.z}" +
                $"\n\trotation: {__instance.transform.rotation.x}, {__instance.transform.rotation.y}, {__instance.transform.rotation.z}, {__instance.transform.rotation.w}"
            );
        }
        public static uint CurrentIndex { get; set; }
    }
}

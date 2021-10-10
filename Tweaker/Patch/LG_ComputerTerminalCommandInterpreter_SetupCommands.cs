using System;
using HarmonyLib;
using LevelGeneration;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(LG_ComputerTerminalCommandInterpreter), "SetupCommands")]
    class LG_ComputerTerminalCommandInterpreter_SetupCommands
    {
        public static void Postfix(LG_ComputerTerminalCommandInterpreter __instance)
        {
            //TODO add config to disable this patch?
            __instance.AddOutput("LOCATION: <color=orange>" +
                __instance.m_terminal.SpawnNode.m_zone.NavInfo
                    .GetFormattedText(LG_NavInfoFormat.Full_And_Number_With_Underscore) +
                    "</color>");
        }
    }
}

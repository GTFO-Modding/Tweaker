using System;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(DropServerManager), "GetBoosterImplantPlayerDataAsync")]
    class DropServerManager_GetBoosterImplantPlayerDataAsync
    {
        public static bool Prefix()
            => false;
    }
}
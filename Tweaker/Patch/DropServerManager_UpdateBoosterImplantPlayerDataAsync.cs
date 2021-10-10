using System;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(DropServerManager), "UpdateBoosterImplantPlayerDataAsync")]
    class DropServerManager_UpdateBoosterImplantPlayerDataAsync
    {
        public static bool Prefix()
            => false;
    }
}
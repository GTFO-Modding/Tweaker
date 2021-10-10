using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerAgent), "Setup")]
    class PlayerAgent_Setup
    {
        public static void Postfix(PlayerAgent __instance)
        {
            CoreManager.Current.PlayerModifier.Scale(__instance);
        }
    }
}

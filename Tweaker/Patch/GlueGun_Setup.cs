using System;
using HarmonyLib;
using Dex.Tweaker.Util;
using GameData;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlueGun), "Setup")]
    class GlueGun_Setup
    {
        public static void Prefix(ref ItemDataBlock data, GlueGun __instance)
        {
            CoreManager.Current.FoamLauncher.OnSetup(ref data, __instance);
        }
    }
}

using System;
using Dex.Tweaker.Util;
using GameData;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MineDeployerFirstPerson), "Setup")]
    class MineDeployerFirstPerson_Setup
    {
        public static void Prefix(ref ItemDataBlock data, MineDeployerFirstPerson __instance)
        {
            CoreManager.Current.Mine.OnSetup(ref data, __instance);
        }
    }
}

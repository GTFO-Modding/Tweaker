using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MineDeployerInstance_Detonate_Explosive), "Setup")]
    class MineDeployerInstance_Detonate_Explosive_Setup
    {
        public static void Prefix(ref iMineDeployerInstanceCore core, MineDeployerInstance_Detonate_Explosive __instance)
        {
            CoreManager.Current.Mine.OnSetup(ref core, __instance);
        }
    }
}
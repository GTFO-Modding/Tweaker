using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Enemies;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyAI), "Setup")]
    class EnemyAI_Setup
    {
        public static void Postfix(EnemyAI __instance)
        {
            CoreManager.Current.NavMesh.Setup(__instance);
        }
    }
}

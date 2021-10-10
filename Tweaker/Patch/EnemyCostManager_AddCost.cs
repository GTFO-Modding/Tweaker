using System;
using Dex.Tweaker.Util;
using HarmonyLib;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(EnemyCostManager), "AddCost", new Type[] { typeof(float) })]
    class EnemyCostManager_AddCost
    {
        public static void Prefix(ref float points)
        {
            CoreManager.Current.DifficultyScale.EnemyWaveCost(ref points);
        }
    }
}
//using System;
//using Dex.Tweaker.Util;
//using HarmonyLib;
//using Enemies;

//namespace Dex.Tweaker.Patch
//{
//    [HarmonyPatch(typeof(EnemyAgent), "AllocateCost")]
//    class EnemyAgent_AllocateCost
//    {
//        public static void Postfix(EnemyAgent __instance)
//        {
//            Log.Debug($"Enemy cost of {__instance.m_enemyCost} being allocated");
//        }
//    }
//}

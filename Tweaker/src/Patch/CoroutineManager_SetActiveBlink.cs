//using System;
//using HarmonyLib;

//namespace Dex.Tweaker.Patch
//{
//    [HarmonyPatch(typeof(CoroutineManager), "SetActiveBlink")]
//    class CoroutineManager_SetActiveBlink
//    {
//        public static void Prefix(ref float delay) => delay = 0f;
//    }
//}
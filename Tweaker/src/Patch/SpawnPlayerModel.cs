//using System;
//using Dex.Tweaker.Core;
//using HarmonyLib;
//using CellMenu;

//namespace Dex.Tweaker.Patch
//{
//    class SpawnPlayerModel
//    {
//        [HarmonyPatch(typeof(CM_PlayerLobbyBar), "SpawnPlayerModel")]
//        public static void Prefix(ref int index) => Replace(ref index);
//
//        [HarmonyPatch(typeof(CM_PlayerLobbyBar), "SpawnPlayerModel")]
//        public static void PostFix(ref int index) => Restore(ref index);
//        static void Replace(ref int index)
//        {
//            if(index != preferredIndex)
//            {
//                originalIndex = index;
//                index = preferredIndex;
//            }
//        }
//        static void Restore(ref int index)
//        {
//            if (index != originalIndex)
//                index = originalIndex;
//        }
//        static int preferredIndex { get => 1; }
//        static int originalIndex { get; set; }
//    }
//}
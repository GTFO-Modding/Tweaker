//using System;
//using AK;
//using Dex.Tweaker.Util;
//using HarmonyLib;
//using LevelGeneration;
//using Player;
//using UnityEngine;

//namespace Dex.Tweaker.Patch
//{
//    [HarmonyPatch(typeof(ElevatorRide), "OnGSWantToStartExpedition")]
//    class ElevatorRide_OnGSWantToStartExpedition
//    {
//        public static bool Prefix()
//        {
//            ElevatorRide.Current.ChangeState(ElevatorRideState.ReturnUp);
//            return false;
//        }
//    }

//    [HarmonyPatch(typeof(ElevatorRide), "ChangeState")]
//    class ElevatorRide_ChangeState
//    {
//        public static void Prefix(ref ElevatorRideState state, ElevatorRide __instance)
//        {
//            switch(state)
//            {
//                case ElevatorRideState.Idle:
//                    Log.Debug("Elevator is Idle"); //Never gets called
//                    break;
//                case ElevatorRideState.ReturnUp:
//                    Log.Debug("Elevator is returning");
//                    break;
//            }
//        }
//    }

//    [HarmonyPatch(typeof(ElevatorRide), "UpdateCommon")]
//    class ElevatorRide_UpdateCommon
//    {
//        public static void Prefix(ElevatorRide __instance)
//        {
//            if (__instance.m_currentState != ElevatorRideState.ReturnUp) return;
//            if (__instance.m_elevatorCage.transform.position.y < 199f) return;
//            //Log.Message($"Elevator position {__instance.m_elevatorCage.transform.position.x}, {__instance.m_elevatorCage.transform.position.y}, {__instance.m_elevatorCage.transform.position.z}");
//            Log.Debug(":^)");
//            var player = PlayerManager.GetLocalPlayerAgent();
//            player.Damage.ExplosionDamage(player.PlayerData.health, player.Position, Vector3.one * 100f);
//            ulong _ = CellSound.Post(EVENTS.STICKYMINEEXPLODE, player.Position);
//        }
//    }
//}

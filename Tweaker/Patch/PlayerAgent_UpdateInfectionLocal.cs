using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerAgent), "UpdateInfectionLocal")]
    class PlayerAgent_UpdateInfectionLocal
    {
        public static void Prefix(PlayerAgent __instance)
        {
            CoreManager.Current.ObjectiveModifier.OnUpdate(ref __instance);

            //probably move this into the player input handler?
            CoreManager.Current.NavMesh.OnUpdate();
        }
    }
}
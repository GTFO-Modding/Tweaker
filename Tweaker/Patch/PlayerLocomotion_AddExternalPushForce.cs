using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerLocomotion), "AddExternalPushForce")]
    class PlayerLocomotion_AddExternalPushForce
    {
        public static void Prefix(ref UnityEngine.Vector3 force)
        {
            CoreManager.Current.PlayerModifier.Slide(ref force);
        }
    }
}

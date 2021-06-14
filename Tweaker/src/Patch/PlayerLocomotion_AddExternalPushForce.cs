using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Player;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerLocomotion), "AddExternalPushForce")]
    class PlayerLocomotion_AddExternalPushForce
    {
        public static void Prefix(ref Vector3 force)
        {
            if (ConfigManager.PlayerModifier.Config.internalEnabled && ConfigManager.PlayerModifier.Config.SlideForceScale != 1f)
                force = force * ConfigManager.PlayerModifier.Config.SlideForceScale;
        }
    }
}

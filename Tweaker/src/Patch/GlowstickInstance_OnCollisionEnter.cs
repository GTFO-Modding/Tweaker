using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "OnCollisionEnter")]
    class GlowstickInstance_OnCollisionEnter
    {
        public static void Postfix(Collision col)
        {
            if (ConfigManager.GamerGlowstick.Config.internalEnabled)
                GamerGlowstick.TurnOffLights(ref col);
        }
    }
}
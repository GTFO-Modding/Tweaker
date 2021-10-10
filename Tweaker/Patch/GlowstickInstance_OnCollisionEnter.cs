using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(GlowstickInstance), "OnCollisionEnter")]
    class GlowstickInstance_OnCollisionEnter
    {
        public static void Postfix(Collision col)
        {
            CoreManager.Current.GamerGlowstick.TurnOffLights(ref col);
        }
    }
}
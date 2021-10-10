using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MWS_ChargeUp), "Enter")]
    class MWS_Chargeup_Enter
    {
        public static void Prefix(MWS_ChargeUp __instance)
        {
            CoreManager.Current.Hammer.ModifyChargeTime(__instance);
        }
    }
}

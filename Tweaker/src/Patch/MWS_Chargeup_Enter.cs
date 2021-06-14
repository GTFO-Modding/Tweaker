using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MWS_ChargeUp), "Enter")]
    class MWS_Chargeup_Enter
    {
        public static void Prefix(MWS_ChargeUp __instance)
        {
            if (Hammer.Equiped == null) return;
            if (Hammer.Equiped.internalEnabled)
                __instance.m_maxDamageTimeDef = Hammer.Equiped.ChargeUpTime;
        }
    }
}

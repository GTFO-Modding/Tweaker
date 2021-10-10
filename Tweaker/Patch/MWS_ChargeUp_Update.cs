using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MWS_ChargeUp), "Update")]
    class MWS_ChargeUp_Update
    {
        public static void Prefix(MWS_ChargeUp __instance)
        {
            CoreManager.Current.Hammer.ModifyAutoAttack(__instance);
        }
    }
}

using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "OnWield")]
    class MeleeWeaponFirstPerson_OnWield
    {
        public static void Prefix(MeleeWeaponFirstPerson __instance)
        {
            CoreManager.Current.Hammer.OnWield(__instance);
        }
    }
}

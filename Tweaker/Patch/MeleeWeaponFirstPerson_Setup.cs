using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Gear;
using GameData;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "Setup")]
    class MeleeWeaponFirstPerson_Setup
    {
        public static void Prefix(ItemDataBlock data, MeleeWeaponFirstPerson __instance)
        {
            CoreManager.Current.Hammer.Setup(data, __instance);
        }
    }
}

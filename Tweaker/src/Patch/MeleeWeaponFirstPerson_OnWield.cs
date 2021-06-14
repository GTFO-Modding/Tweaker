using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Gear;
using UnityEngine;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(MeleeWeaponFirstPerson), "OnWield")]
    class MeleeWeaponFirstPerson_OnWield
    {
        public static void Prefix(MeleeWeaponFirstPerson __instance)
        {
            if (Hammer.Equiped == null) return;
            var gearPart = __instance.FPItemHolder.m_inventoryLocal.m_wieldedItem.GearPartHolder;
            Hammer.SetTransform(gearPart.MeleeHeadPart.transform, Hammer.Equiped.Head);
            Hammer.SetTransform(gearPart.MeleeNeckPart.transform, Hammer.Equiped.Neck);
            Hammer.SetTransform(gearPart.MeleeHandlePart.transform, Hammer.Equiped.Handle);
            Hammer.SetTransform(gearPart.MeleePommelPart.transform, Hammer.Equiped.Pommel);
        }
    }
}

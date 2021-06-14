using System;
using Dex.Tweaker.Core;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerBackpackManager), "ReceiveAmmoGive")]
    class PlayerBackpackManager_ReceiveAmmoGive
    {
        public static void Prefix(ref pAmmoGive data)
        {
            if (ResourcePack.Instance == null) return;
            if (data.ammoStandardRel > 0) data.ammoStandardRel = ResourcePack.Instance.ammoStandardRel;
            if (data.ammoSpecialRel > 0) data.ammoSpecialRel = ResourcePack.Instance.ammoSpecialRel;
            if (data.ammoClassRel > 0) data.ammoClassRel = ResourcePack.Instance.ammoClassRel;
        }
    }
}

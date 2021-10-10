using System;
using Dex.Tweaker.Util;
using HarmonyLib;
using Player;

namespace Dex.Tweaker.Patch
{
    [HarmonyPatch(typeof(PlayerBackpackManager), "PickupHealthRel")]
    class PlayerBackpackManager_PickupHealthRel
    {
        public static void Prefix(ref float amountRel)
        {
            CoreManager.Current.ResourcePack.Receive(ref amountRel);
        }
    }
}